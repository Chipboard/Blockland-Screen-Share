using BLSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLSS
{
    internal static class MediaManager
    {
        static Dictionary<string, MediaCapture> captures = new();

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
                captures.Add(captureName, newCapture);
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
            if(captures.TryGetValue(captureName, out MediaCapture capture))
            {
                captures.Remove(captureName);
                capture.Dispose();
            } else
            {
                Debug.Log($"Tried to remove a capture that wasn't in the dictionary: {captureName}");
            }
        }
    }
}
