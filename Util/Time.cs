namespace Saga.Util
{
    public static class Time
    {
        /// <summary>
        /// Time elapsed since the application started.
        /// </summary>
        public static float RunTime;

        /// <summary>
        /// Time elapsed since previous frame, scaled by timescale.
        /// </summary>
        public static float DeltaTime;

        /// <summary>
        /// Time elapsed since previous frame, unscaled by timescale.
        /// </summary>
        public static float UnscaledDeltaTime;

        /// <summary>
        /// The maximum value that delta time can be.
        /// </summary>
        public static float MaxDeltaTime = float.MaxValue;

        /// <summary>
        /// Time elapsed since the scene was loaded (unscaled by default).
        /// </summary>
        public static float SceneRunTime;

        /// <summary>
        /// The time scale of delta time.
        /// </summary>
        public static float TimeScale = 1f;

        /// <summary>
        /// The number of frames elapsed.
        /// </summary>
        public static float FrameCount;

        internal static void Update(float deltaTime)
        {
            if (deltaTime > MaxDeltaTime)
                deltaTime = MaxDeltaTime;

            RunTime += deltaTime;
            DeltaTime = deltaTime * TimeScale;
            UnscaledDeltaTime = deltaTime;
            SceneRunTime += deltaTime;
            FrameCount += 1;
        }

        internal static void ResetSceneRunTime()
        {
            SceneRunTime = 0f;
        }
    }
}
