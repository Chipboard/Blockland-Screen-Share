using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLSS.Media
{
    internal class MediaCapture : IDisposable
    {
        public CaptureType captureType { get; private set; }
        public MediaObject mediaObject { get; private set; }

        /// <summary>
        /// Create a new MediaCapture.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="mediaCapture"></param>
        /// <returns>True if the media successfully initializes, false otherwise.</returns>
        public static bool Create(string filePath, out MediaCapture mediaCapture)
        {
            mediaCapture = new();

            if (mediaCapture.Initialize(filePath))
                return true;

            return false;
        }

        /// <summary>
        /// Initialize the MediaCapture.
        /// </summary>
        /// <param name="filePath">The file to load.</param>
        /// <returns>Returns true if successful, false otherwise.</returns>
        public bool Initialize(string filePath)
        {
            Debug.Log("Initializing MediaCapture.");
            captureType = DetectCaptureType(filePath);

            if (captureType == CaptureType.Unknown)
            {
                Debug.Log($"Unknown CaptureType for: {Path.GetFileName(filePath)}");
                return false;
            }

            mediaObject = new(captureType, filePath);

            return true;
        }

        /// <summary>
        /// Dispose the MediaCapture to clean up unused resources.
        /// </summary>
        public void Dispose()
        {
            mediaObject?.Dispose();
        }

        /// <summary>
        /// Detect the CaptureType for the given file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>The compatible CaptureType</returns>
        static CaptureType DetectCaptureType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            // List of common image file extensions
            string[] imageExtensions = { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };

            // List of common video file extensions
            string[] videoExtensions = { ".mp4", ".avi", ".mov", ".wmv", ".mkv", ".flv" };

            if (Array.Exists(imageExtensions, ext => ext == extension))
                return CaptureType.Image;
            else if (Array.Exists(videoExtensions, ext => ext == extension))
                return CaptureType.Video;
            else
                return CaptureType.Unknown;
        }

        public void GetPixel(int x, int y) => mediaObject.GetPixel(x, y);
    }

    public enum CaptureType
    {
        Unknown,
        Screen,
        Image,
        Video
    }
}
