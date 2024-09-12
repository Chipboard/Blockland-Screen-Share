using BLSS.Media;
using BLSS.Core;
using System.Collections.Concurrent;

namespace BLSS.BrickScreen
{
    internal static class BrickMediaUpdater
    {
        static ConcurrentDictionary<string, BrickMediaObject> brickMediaObjects = [];

        // TODO: Limit this to 25 FPS or so
        public static void Update()
        {
            foreach (KeyValuePair<string, MediaCapture> mediaCapture in MediaManager.captures)
            {
                // Check and get if it exists, otherwise create
                if(brickMediaObjects.TryGetValue(mediaCapture.Key, out BrickMediaObject? brickMediaObject))
                {
                    brickMediaObject = new();
                    brickMediaObjects.TryAdd(mediaCapture.Key, brickMediaObject);
                }

                // Update the media object
            }
        }
    }
}
