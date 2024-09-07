using System.Runtime.CompilerServices;

namespace BLSS.Media
{
    internal class MediaObject : IDisposable
    {
        object mediaData;
        CaptureType captureType;

        /// <summary>
        /// Create a new MediaObject for use in reading back media.
        /// </summary>
        /// <param name="captureType"></param>
        /// <param name="filePath"></param>
        public MediaObject(CaptureType captureType, string filePath)
        {
            Debug.Log($"Creating MediaObject of CaptureType: {captureType}");
            this.captureType = captureType;
            switch (captureType)
            {
                case CaptureType.Image:
                    mediaData = Bitmap.FromFile(filePath);
                    break;

                default:
                    Debug.Log("Creating an unidentified MediaObject is not supported!");
                    mediaData = "Unidentified";
                    break;
            }
        }

        /// <summary>
        /// Get a pixel at specified coordinate.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Color of desired pixel.</returns>
        public Color GetPixel(int x, int y)
        {
            switch (captureType)
            {
                case CaptureType.Image:
                    return (mediaData as Bitmap).GetPixel(x, y);

                default:
                    return Color.Black;
            }
        }

        public void Dispose()
        {
            Debug.Log($"Disposing MediaObject of type: {captureType}");
            switch (captureType)
            {
                case CaptureType.Image:
                    (mediaData as Image)?.Dispose();
                    break;
            }
        }
    }
}
