using System.Windows.Forms;

namespace BLSS.Core
{
    internal static class Debug
    {
        public static void Log(string message)
        {
            Program.captureForm.DebugOutput.Invoke(
                delegate
                {
                    Program.captureForm.DebugOutput.Text = Program.captureForm.DebugOutput.Text + "\r\n" + message;
                });
        }

        public static void Clear()
        {
            Program.captureForm.DebugOutput.Invoke(
            delegate
            {
                Program.captureForm.DebugOutput.Text = "";
            });
        }
    }
}