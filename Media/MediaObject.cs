using BLSS.Core;
using BLSS.Mathematics;

namespace BLSS.Media
{
    internal class MediaObject : IDisposable
    {
        public Vector2Int resolution;

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
                    Bitmap? mediaBitmap = Bitmap.FromFile(filePath) as Bitmap;
                    resolution = new Vector2Int(mediaBitmap.Width, mediaBitmap.Height);
                    mediaData = mediaBitmap;
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
            if (x > resolution.x)
                x = MathUtil.Wrap(x, 0, resolution.x);

            if (y > resolution.y)
                y = MathUtil.Wrap(y, 0, resolution.y);

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
