using BLSS.Core;
using BLSS.Media;

namespace BLSS.BrickScreen
{
    internal class BrickMediaObject(MediaCapture mediaCapture)
    {
        readonly MediaCapture mediaCapture = mediaCapture;
        float lastUpdateTime;
        int frame;

        /// <summary>
        /// Update BrickMediaObject
        /// </summary>
        public void Update()
        {
            // Check if it's time to display a frame
            if (Time.ElapsedTime - lastUpdateTime < mediaCapture.MediaObject.FrameTimeMS)
                return;

            // Update time and bricks
            lastUpdateTime = Time.ElapsedTime;

            // Update frame
            frame++;

            if (frame > mediaCapture.MediaObject.FrameCount)
            {
                frame = 0;
            }

            mediaCapture.MediaObject.SetFrame(frame);
        }
    }
}