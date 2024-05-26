using System;

namespace Saga.Util.Timer
{
    /// <summary>
    /// A Class implementing ITimer Interface
    /// </summary>
    internal class Timer : ITimer
    {
        public object Context { get; set; }

        private float _duration;
        private float _timeElapsed;
        private bool _compelete;
        private bool _repeating;

        private Action<ITimer> _onComplete;        

        public T GetContext<T>()
        {
            return (T)Context;
        }

        public void Reset()
        {
            _timeElapsed = 0f;
        }

        internal void Create(float duration, bool repeating, object context, Action<ITimer> onComplete)
        {
            _duration = duration;
            _repeating = repeating;
            Context = context;
            _onComplete = onComplete;
        }

        internal bool Tick()
        {
            if(!_compelete && _timeElapsed > _duration)
            {
                _timeElapsed -= _duration;
                _onComplete(this);

                if (!_compelete && !_repeating)
                    _compelete = true;
            }

            _timeElapsed += Time.DeltaTime;
            return _compelete;
        }

        public void Stop()
        {
            _compelete = true;
        }

        internal void Unload()
        {
            Context = null;
            _onComplete = null;
        }
    }
}
