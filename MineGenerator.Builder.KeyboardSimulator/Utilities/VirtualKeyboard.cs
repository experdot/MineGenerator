using System;
using System.Collections.Generic;
using System.Text;

namespace MineGenerator.Builder
{
    public class VirtualKeyboard
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "MapVirtualKeyA")]
        private static extern int MapVirtualKey(int wCode, int wMapType);
        [System.Runtime.InteropServices.DllImport("user32 ")]
        private static extern int GetAsyncKeyState(int vKey);

        public static void SendKey(VirtualKeys key, int interval = 10)
        {
            VirtualKeyDown(key);
            System.Threading.Thread.Sleep(interval);
            VirtualKeyUp(key);
        }

        public static void SendCouple(VirtualKeys key1, VirtualKeys key2, int interval = 10)
        {
            VirtualKeyDown(key1);
            System.Threading.Thread.Sleep(interval);
            VirtualKeyDown(key2);
            System.Threading.Thread.Sleep(interval);
            VirtualKeyUp(key1);
            System.Threading.Thread.Sleep(interval);
            VirtualKeyUp(key2);
        }

        private static void VirtualKeyDown(VirtualKeys key)
        {
            keybd_event((byte)key, (byte)MapVirtualKey((int)key, 2), 0x1 | 0, 0);
        }

        private static void VirtualKeyUp(VirtualKeys key)
        {
            keybd_event((byte)key, (byte)MapVirtualKey((int)key, 2), 0x1 | 0x2, 0);
        }
    }
}
