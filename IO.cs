using System.IO;

namespace BLSS
{
    internal static class IO
    {
        public static readonly string imageMediaFilter = "Media Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.mp4;*.avi;*.mov;*.wmv;*.mkv;";

        /// <summary>
        /// Get a save dialog and return the desired save path. Null if not found.
        /// </summary>
        /// <param name="fileFilter">Filter for specifying what file type(s) are allowed.</param>
        /// <returns>Desired file path.</returns>
        public static string SaveDialog(string fileFilter)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                InitialDirectory = Application.ExecutablePath,
                Title = "Save Layers",

                CheckFileExists = false,
                CheckPathExists = true,

                DefaultExt = fileFilter,
                Filter = $"{fileFilter} files (*.{fileFilter})|*.{fileFilter}",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            DialogResult result = saveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                return saveDialog.FileName;
            }
            else
            {
                if (result != DialogResult.Cancel)
                    MessageBox.Show($"SaveDialog failure! {result}");

                return null;
            }
        }

        /// <summary>
        /// Get an open file dialog and return the desired path. Null if not found.
        /// </summary>
        /// <param name="fileFilter">Filter for specifying what file type(s) are allowed.</param>
        /// <returns>Desired file path.</returns>
        public static string OpenDialog(string fileFilter)
        {
            OpenFileDialog openDialog = new();
            openDialog.Filter = fileFilter;
            openDialog.Multiselect = false;

            DialogResult result = openDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                Debug.Log($"Open file error: {result}");
                return null;
            }

            return openDialog.FileName;
        }
    }
}
