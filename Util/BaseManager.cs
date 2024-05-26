namespace Saga.Util
{
    public class BaseManager
    {
        private bool _enabled;

        /// <summary>
        /// Method is called when BaseManager is Enabled.
        /// </summary>
        public virtual void OnEnabled() { }

        /// <summary>
        /// Method is called when BaseManager is Disabled.
        /// </summary>
        public virtual void OnDisabled() { }

        /// <summary>
        /// Called every frame to update the BaseManager.
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Returns true if the BaseManager is enabled. Calling onEnabled / onDisabled when changed.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise returns <c>false</c></value>
        public bool Enabled
        {
            get { return _enabled; }
            set { 
                if(_enabled != value)
                {
                    _enabled = value;

                    if (_enabled)
                        OnEnabled();
                    else
                        OnDisabled();
                }
            }
        }

    }
}
