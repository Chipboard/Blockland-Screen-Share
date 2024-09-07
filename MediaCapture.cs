using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLSS
{
    internal class MediaCapture : IDisposable
    {
        CaptureType captureType;

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

            return true;
        }

        /// <summary>
        /// Dispose the MediaCapture to clean up unused resources.
        /// </summary>
        public void Dispose()
        {
            Debug.Log("Disposing a MediaCapture.");
        }

        enum CaptureType
        {
            Screen,
            Image,
            Video
        }
    }
}
