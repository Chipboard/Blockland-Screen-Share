using System.Diagnostics;

namespace BLSS.Core
{
    static class Time
    {
        public static float ElapsedTime { get; private set; }
        public static float DeltaTime { get; private set; }

        readonly static Stopwatch stopwatch = Stopwatch.StartNew();

        public static void Update()
        {
            DeltaTime = stopwatch.ElapsedMilliseconds;
            ElapsedTime += stopwatch.ElapsedMilliseconds;
            stopwatch.Restart();
        }
    }
}
