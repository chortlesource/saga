using System;
using System.Collections.Generic;

namespace Saga.Util.Timer
{
    /// <summary>
    /// A Manager for Handling Timers
    /// </summary>
    internal class TimerManager : BaseManager
    {
        private List<Timer> _timers = new List<Timer>();

        public override void Update()
        {
            for (var i = _timers.Count - 1; i >= 0; i--)
            {  
                if (_timers[i].Tick())
                {
                    _timers[i].Unload();
                    _timers.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Schedule a single use or repeating timer that will call in passed action.
        /// </summary>
        /// <param name="duration">Length of timer in seconds.</param>
        /// <param name="repeating">If <c>true</c> timer will repeat. If <c>false</c> timer is single use only.</param>
        /// <param name="context">Context.</param>
        /// <param name="onComplete">Method to be called on completion</param>
        /// <returns></returns>
        internal ITimer Schedule(float duration, bool repeating, object context, Action<ITimer> onComplete)
        {
            var timer = new Timer();
            timer.Create(duration, repeating, context, onComplete);
            _timers.Add(timer);

            return timer;
        }
    }
}
