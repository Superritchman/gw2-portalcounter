using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PortalCounter
{
    static class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static bool chatactive = false;
        private static System.Timers.Timer aTimer = new System.Timers.Timer(1000);
        private static bool preventSpam = false;

        private static MainForm mForm = new MainForm();
        public static bool hook = true;

        [STAThread]
        static void Main()
        {
            aTimer.Elapsed += aTimer_Elapsed;
            _hookID = SetHook(_proc);
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mForm);
            UnhookWindowsHookEx(_hookID);
        }

        private static void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            preventSpam = false;
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {            
            if (hook && nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || Control.ModifierKeys != Keys.None))
            {
                Keys vkCode = (Keys)Marshal.ReadInt32(lParam);
                
                // read settings
                bool bChat = Properties.Settings.Default.ProtectChat;
                Keys kHotKey = PortalCounter.Properties.Settings.Default.HotKey;
                Keys kModifier = Properties.Settings.Default.Modifier;                

                // deactivate chat only if hotkey isnt enter
                if (bChat && vkCode == Keys.Enter && kHotKey != Keys.Enter)
                    chatactive = !chatactive;

                if (!chatactive)
                {
                    mForm.BackColor = System.Drawing.Color.Black;

                    Console.WriteLine(kHotKey + " - " + Control.ModifierKeys);

                    kHotKey = normalizeHotkey(kHotKey);

                    // (Hotkey and modifier) or (hokey is actual modifier)
                    if (!preventSpam && (vkCode.Equals(kHotKey) && Control.ModifierKeys == kModifier) || Control.ModifierKeys.Equals(kHotKey))
                    {
                        mForm.startTimer();

                        if (!kModifier.Equals(Keys.None))
                        {
                            preventSpam = true;
                            aTimer.Start();
                        }
                    }
                }
                else
                {
                    mForm.BackColor = System.Drawing.Color.OrangeRed;
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private static Keys normalizeHotkey(Keys input)
        {
            if (input.Equals(Keys.ControlKey))
                return Keys.Control;
            if (input.Equals(Keys.Menu))
                return Keys.Alt;
            if(input.Equals(Keys.ShiftKey))
                return Keys.Shift;

            return input;
        }
    }
}
