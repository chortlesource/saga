namespace Saga.Util
{
    public class BaseManager
    {
        private bool _enabled;

        /// <summary>
        /// Method is called when BaseManager is Enabled.
        /// </summary>
        public virtual void onEnabled() { }

        /// <summary>
        /// Method is called when BaseManager is Disabled.
        /// </summary>
        public virtual void onDisabled() { }

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
                        onEnabled();
                    else
                        onDisabled();
                }
            }
        }

    }
}
