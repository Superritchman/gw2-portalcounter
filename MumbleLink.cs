using System;
using System.Runtime.InteropServices;
using System.IO.MemoryMappedFiles;

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

        private readonly int MEM_SIZE;

        private byte[] buffer;
        private GCHandle bufferHandle;

        private MemoryMappedFile mmf;
        private MemoryMappedViewStream stream;

        public MumbleLink()
        {
            MEM_SIZE = Marshal.SizeOf(typeof(LinkedMem));

            mmf = MemoryMappedFile.CreateOrOpen(NAME, MEM_SIZE);
            stream = mmf.CreateViewStream(0, MEM_SIZE);

            buffer = new byte[MEM_SIZE];
            bufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        }

        public LinkedMem Read()
        {
            stream.Position = 0;
            stream.Read(buffer, 0, MEM_SIZE);
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
            if (stream != null)
                stream.Dispose();
            if (bufferHandle != null)
                bufferHandle.Free();
            if (mmf != null)
            {
                mmf.Dispose();
            }
        }
    }
}
