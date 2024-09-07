using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLSS.Media
{
    internal class MediaCapture : IDisposable
    {
        public CaptureType CaptureType { get; private set; }
        public MediaObject MediaObject { get; private set; }

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
            CaptureType = DetectCaptureType(filePath);

            if (CaptureType == CaptureType.Unknown)
            {
                Debug.Log($"Unknown CaptureType for: {Path.GetFileName(filePath)}");
                return false;
            }

            MediaObject = new(CaptureType, filePath);

            return true;
        }

        /// <summary>
        /// Dispose the MediaCapture to clean up unused resources.
        /// </summary>
        public void Dispose()
        {
            MediaObject?.Dispose();
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
            string[] imageExtensions = [".png", ".jpg", ".jpeg", ".bmp", ".gif"];

            // List of common video file extensions
            string[] videoExtensions = [".mp4", ".avi", ".mov", ".wmv", ".mkv", ".flv"];

            if (Array.Exists(imageExtensions, ext => ext == extension))
                return CaptureType.Image;
            else if (Array.Exists(videoExtensions, ext => ext == extension))
                return CaptureType.Video;
            else
                return CaptureType.Unknown;
        }

        /// <summary>
        /// Get a pixel at specified coordinate.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Color of desired pixel.</returns>
        public Color GetPixel(int x, int y) => MediaObject.GetPixel(x, y);
    }

    public enum CaptureType
    {
        Unknown,
        Screen,
        Image,
        Video
    }
}
