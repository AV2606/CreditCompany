using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Tools
{
    public static class System
    {
        /// <summary>
        /// Allocs a console window UI and shows it.
        /// </summary>
        public static void AllocateConsole()
        {
            AllocConsole();
            Console.SetBufferSize(150, 150);
            Console.SetWindowSize(150, 150);
            Console.SetWindowPosition(0, 0);
            Console.ReadLine();
        }
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
    }
}
