using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinformGame
{
    public class RawKeyboard
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetKeyboardState(byte[] lpKeyState);
        private byte[] keyState;

        public void Update() 
        {
            keyState = new byte[256];
            GetKeyboardState(keyState);
        }

        public bool IsPressed(Keys key) 
        {
            return (keyState[(byte)(((int)key) & 0xFF)] & 0x80) != 0;
        }
    }
}
