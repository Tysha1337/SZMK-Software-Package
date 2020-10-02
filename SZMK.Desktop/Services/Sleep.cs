using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SZMK.Desktop.Services
{
    public class Sleep
    {
        private Timer timer;

        private int idle = 0;

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool LockWorkStation();

        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dwTime;
        }
        public static long GetTickCount()
        {
            return Environment.TickCount;
        }
        static int GetLastInputTime()
        {
            try
            {
                int idleTime = 0;
                LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
                lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
                lastInputInfo.dwTime = 0;

                int envTicks = Environment.TickCount;

                if (GetLastInputInfo(ref lastInputInfo))
                {
                    int lastInputTick = (int)lastInputInfo.dwTime;

                    idleTime = envTicks - lastInputTick;
                }

                return ((idleTime > 0) ? (idleTime / 1000) : 0);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        public bool Start()
        {
            try
            {
                Timer timer = new Timer(1000);
                timer.Elapsed += Timer_Elapsed;

                timer.Start();

                return true;
            }
            catch (Exception Ex)
            {
                SystemArgs.PrintLog(Ex.ToString());

                return false;
            }
        }

        public bool Stop()
        {
            try
            {
                if (timer != null)
                {
                    timer.Stop();
                }

                return true;
            }
            catch (Exception Ex)
            {
                SystemArgs.PrintLog(Ex.ToString());

                return false;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                idle = GetLastInputTime();

                if (idle > 10800 && DateTime.Now.Hour < 6)
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
