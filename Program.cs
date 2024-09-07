namespace BLSS
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
            Debug.Log("Program starting...");
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
                TCP.EnsureConnection();
                BrickMediaUpdater.Update();
            }
        }
    }
}