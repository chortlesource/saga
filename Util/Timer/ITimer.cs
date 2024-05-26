namespace Saga.Util.Timer
{
    /// <summary>
    /// An Interface for Timers
    /// </summary>
    internal interface ITimer
    {
        object Context { get; }

        /// <summary>
        /// Called to stop repeating timers only. Has no effect on non-recurrent timers.
        /// </summary>
        void Stop();

        /// <summary>
        /// Called to set elapsed time of timer to 0.
        /// </summary>
        void Reset();

        /// <summary>
        /// Returns 'Context' cast to T for convenience
        /// </summary>
        /// <returns>Context</returns>
        /// <typeparam name="T">The 1st type parameter</typeparam>
        T GetContext<T>();

    }
}
