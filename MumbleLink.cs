using System;
using System.Runtime.InteropServices;
using System.IO;

namespace Gw2Mem
{
    class MumbleLink : IDisposable
    {
        private const string NAME = "MumbleLink";
        private const float METER_TO_INCH = 39.3701f;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct LinkedMem
        {
            public UInt32 uiVersion;
            public UInt32 uiTick;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] fAvatarPosition;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] fAvatarFront;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] fAvatarTop;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] fCameraPosition;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] fCameraFront;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public float[] fCameraTop;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string identity;
            public UInt32 context_len;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] context;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
            public string description;
        };

        public struct Coordinate
        {
            public float x, y, z;
            public int world_id;
            public int map_id;
        }

        #region Win32

        [DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CreateFileMapping(IntPtr hFile, IntPtr lpAttributes, FileMapProtection flProtect, Int32 dwMaxSizeHi, Int32 dwMaxSizeLow, string lpName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenFileMapping(FileMapAccess DesiredAccess, bool bInheritHandle, string lpName);

        [DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr MapViewOfFile(IntPtr hFileMapping, FileMapAccess dwDesiredAccess, Int32 dwFileOffsetHigh, Int32 dwFileOffsetLow, Int32 dwNumberOfBytesToMap);

        [Flags]
        private enum FileMapAccess : uint
        {
            FileMapCopy = 0x0001,
            FileMapWrite = 0x0002,
            FileMapRead = 0x0004,
            FileMapAllAccess = 0x001f,
            fileMapExecute = 0x0020,
        }

        [Flags]
        private enum FileMapProtection : uint
        {
            PageReadonly = 0x02,
            PageReadWrite = 0x04,
            PageWriteCopy = 0x08,
            PageExecuteRead = 0x20,
            PageExecuteReadWrite = 0x40,
            SectionCommit = 0x8000000,
            SectionImage = 0x1000000,
            SectionNoCache = 0x10000000,
            SectionReserve = 0x4000000,
        }

        [DllImport("kernel32", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hFile);

        [DllImport("kernel32")]
        private static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

        #endregion Win32

        private readonly int MEM_SIZE;

        private IntPtr mappedFile;
        private IntPtr mapView;
        private byte[] buffer;
        private GCHandle bufferHandle;
        private UnmanagedMemoryStream unmanagedStream;

        unsafe public MumbleLink()
        {
            MEM_SIZE = Marshal.SizeOf(typeof(LinkedMem));

            mappedFile = OpenFileMapping(FileMapAccess.FileMapRead, false, NAME);
            if (mappedFile == IntPtr.Zero)
            {
                mappedFile = CreateFileMapping(IntPtr.Zero, IntPtr.Zero, FileMapProtection.PageReadWrite, 0, MEM_SIZE, NAME);
                if (mappedFile == IntPtr.Zero)
                    throw new Exception("Unable to create file mapping");
            }

            mapView = MapViewOfFile(mappedFile, FileMapAccess.FileMapRead, 0, 0, MEM_SIZE);
            if (mapView == IntPtr.Zero)
                throw new Exception("Unable to map view of file");

            buffer = new byte[MEM_SIZE];
            bufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

            byte* p = (byte*)mapView.ToPointer();
            unmanagedStream = new UnmanagedMemoryStream(p, MEM_SIZE, MEM_SIZE, FileAccess.Read);
        }

        public LinkedMem Read()
        {
            unmanagedStream.Position = 0;
            unmanagedStream.Read(buffer, 0, MEM_SIZE);
            return (LinkedMem)Marshal.PtrToStructure(bufferHandle.AddrOfPinnedObject(), typeof(LinkedMem));
        }

        public Coordinate GetCoordinates()
        {
            LinkedMem l = Read();

            /* 
             * Note that the mumble coordinates differ from the actual in-game coordinates.
             * They are in the format x,z,y and z has been negated so that underwater is negative
             * rather than positive.
             * 
             * Coordinates are based on a central point (0,0), which may be the center of the zone, 
             * where traveling west is negative, east is positive, north is positive and south is negative.
             * 
             */

            Coordinate coord = new Coordinate();
            coord.x = l.fAvatarPosition[0] * METER_TO_INCH; //west to east
            coord.y = l.fAvatarPosition[2] * METER_TO_INCH; //north to south
            coord.z = -l.fAvatarPosition[1] * METER_TO_INCH; //altitude
            coord.world_id = BitConverter.ToInt32(l.context, 36);
            coord.map_id = BitConverter.ToInt32(l.context, 28);

            return coord;
        }

        public void Dispose()
        {
            if (unmanagedStream != null)
                unmanagedStream.Dispose();
            if (bufferHandle != null)
                bufferHandle.Free();
            if (mapView != IntPtr.Zero)
            {
                UnmapViewOfFile(mapView);
                mapView = IntPtr.Zero;
            }
            if (mappedFile != IntPtr.Zero)
            {
                CloseHandle(mappedFile);
                mappedFile = IntPtr.Zero;
            }
        }
    }
}
