using BLSS.Media;
using BLSS.Core;
using System.Collections.Concurrent;

namespace BLSS.BrickScreen
{
    internal static class BrickMediaManager
    {
        static ConcurrentDictionary<string, BrickMediaObject> brickMediaObjects = [];

        public static void Update()
        {
            foreach (KeyValuePair<string, MediaCapture> CapturePair in MediaManager.captures)
            {
                // Check and get if it exists, otherwise create
                if(!brickMediaObjects.TryGetValue(CapturePair.Key, out BrickMediaObject? brickMediaObject))
                {
                    Debug.Log($"Registering {CapturePair.Key}!");
                    brickMediaObject = new(CapturePair.Value);
                    brickMediaObjects.TryAdd(CapturePair.Key, brickMediaObject);
                }

                // Continue if null
                if (brickMediaObject == null)
                    continue;

                // Update the media object
                brickMediaObject.Update();
            }
        }
    }
}
