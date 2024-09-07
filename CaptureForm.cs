using BLSS.Media;

namespace BLSS
{
    public partial class CaptureForm : Form
    {
        public CaptureForm()
        {
            InitializeComponent();
        }

        private void CaptureList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DebugOutput_TextChanged(object sender, EventArgs e)
        {
            // todo scroll to bottom if ur already there i guess
        }

        private void AddCaptureButton_Click(object sender, EventArgs e)
        {
            string capturePath = IO.OpenDialog(IO.imageMediaFilter);
            string captureName = Path.GetFileName(capturePath);

            if (capturePath == null)
                return;

            if (MediaManager.CreateCapture(captureName, capturePath, out captureName))
            {
                CaptureList.Items.Add(captureName);
                CaptureList.SelectedIndex = CaptureList.Items.Count - 1;
            }
        }

        private void RemoveCaptureButton_Click(object sender, EventArgs e)
        {
            if (CaptureList.Items.Count > 0)
            {
                MediaManager.RemoveCapture(CaptureList.Items[CaptureList.SelectedIndex].ToString());
                CaptureList.Items.RemoveAt(CaptureList.SelectedIndex);
                CaptureList.SelectedIndex = CaptureList.Items.Count-1;
            }
        }
    }
}
