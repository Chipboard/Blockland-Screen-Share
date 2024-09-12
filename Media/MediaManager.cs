using System.Collections.Concurrent;
using BLSS.Core;

namespace BLSS.Media
{
    internal static class MediaManager
    {
        public static readonly ConcurrentDictionary<string, MediaCapture> captures = [];

        /// <summary>
        /// Create a new media capture object.
        /// </summary>
        /// <param name="captureName">The name that will be used as the key to access this object.</param>
        /// <param name="filePath">Path to the media file.</param>
        /// <returns>Whether the MediaCapture was successfully created.</returns>
        public static bool CreateCapture(string captureName, string filePath, out string captureFinalName)
        {
            int i = 0;
            string originalCaptureName = captureName;
            while (captures.ContainsKey(captureName))
            {
                i++;
                captureName = $"{originalCaptureName}({i})";
            }

            captureFinalName = captureName;

            Debug.Log($"Attempting to create a media capture from: {Path.GetFileName(filePath)}");

            if (MediaCapture.Create(filePath, out MediaCapture newCapture))
            {
                if (!captures.TryAdd(captureName, newCapture))
                {
                    Debug.Log($"Failed to add capture to ConcurrentDictionary for {captureFinalName}");
                    return false;
                }

                Debug.Log($"Successfully created MediaCapture for: {captureFinalName}");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Remove a media capture from the manager.
        /// </summary>
        /// <param name="captureName">The name of the capture to remove.</param>
        public static void RemoveCapture(string captureName)
        {
            if (captures.ContainsKey(captureName))
            {
                if (captures.TryRemove(captureName, out MediaCapture? capture))
                {
                    capture.Dispose();
                }
            }
            else
            {
                Debug.Log($"Tried to remove a capture that wasn't in the dictionary: {captureName}");
            }
        }
    }
}
