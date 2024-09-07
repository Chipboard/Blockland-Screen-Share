using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLSS
{
    internal class Debug
    {
        public static void Log(string message)
        {
            Program.captureForm.DebugOutput.Text = Program.captureForm.DebugOutput.Text + "\r\n" + message;
        }
    }
}
