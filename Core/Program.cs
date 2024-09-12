using BLSS.BrickScreen;
using BLSS.Networking;

namespace BLSS.Core
{
    internal static class Program
    {
        public static CaptureForm captureForm;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            captureForm = new();
            captureForm.FormClosed += CaptureForm_FormClosed;
            Thread loopThread = new(UpdateThread);
            loopThread.Start();
            Application.Run(captureForm);
        }

        private static void CaptureForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            captureForm = null;
        }

        private static void UpdateThread()
        {
            while (captureForm != null)
            {
                Time.Update();
                TCP.EnsureConnection();
                BrickMediaManager.Update();
            }
        }
    }
}