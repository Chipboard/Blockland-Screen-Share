using BLSS.Core;
using BLSS.Mathematics;
using System.Drawing.Imaging;

namespace BLSS.Media
{
    internal class MediaObject : IDisposable
    {
        public Vector2Int Resolution { get; private set; }
        public int FrameCount { get; private set; }
        public float FrameTimeMS {  get; private set; }

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

                    if (mediaBitmap == null)
                        return;

                    Resolution = new Vector2Int(mediaBitmap.Width, mediaBitmap.Height);
                    mediaData = mediaBitmap;

                    try
                    {
                        FrameCount = mediaBitmap.GetFrameCount(FrameDimension.Time);

                        const int PropertyTagFrameDelay = 0x5100; // FrameDelay property tag
                        PropertyItem propItem = mediaBitmap.GetPropertyItem(PropertyTagFrameDelay);

                        int[] delays = new int[FrameCount];
                        for (int i = 0; i < FrameCount; i++)
                        {
                            delays[i] = BitConverter.ToInt32(propItem.Value, i * 4); // Delay for each frame in hundredths of a second
                        }

                        // Calculate the average delay in milliseconds
                        FrameTimeMS = CalculateAverageDelay(delays);
                        Debug.Log($"Frame MS: {FrameTimeMS}");
                        Debug.Log($"Frame Count: {FrameCount}");
                    } catch
                    {
                        Debug.Log("No animation found.");
                    }

                    break;

                default:
                    Debug.Log("Creating an unidentified MediaObject is not supported!");
                    mediaData = "Unidentified";
                    break;
            }
        }

        /// <summary>
        /// Set the current frame of the media.
        /// </summary>
        /// <param name="frame"></param>
        public void SetFrame(int frame)
        {
            switch (captureType)
            {
                case CaptureType.Image:

                    break;

                default:
                    throw new NotImplementedException($"CaptureType: {captureType} not implemented for frame setting!");
            }
        }

        /// <summary>
        /// Calculate the average delay in ms from an array of delays.
        /// </summary>
        /// <param name="delays"></param>
        /// <returns></returns>
        static float CalculateAverageDelay(int[] delays)
        {
            float totalDelay = 0;
            foreach (int delay in delays)
            {
                // Convert from hundredths of a second to milliseconds
                totalDelay += delay * 10;
            }
            return totalDelay / delays.Length;
        }

        /// <summary>
        /// Get a pixel at specified coordinate.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Color of desired pixel.</returns>
        public Color GetPixel(int x, int y)
        {
            if (x > Resolution.x)
                x = MathUtil.Wrap(x, 0, Resolution.x);

            if (y > Resolution.y)
                y = MathUtil.Wrap(y, 0, Resolution.y);

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
