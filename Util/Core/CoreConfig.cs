using System;
using System.Collections.Generic;
using System.Text;

namespace Saga.Util.Core
{
    internal class CoreConfig
    {
        /// <summary>
        /// Prevents calling of Update and Draw functions when focus has been lost.
        /// </summary>
        public bool PauseOnLostFocus = true;

        /// <summary>
        /// Enable or disable the debug features
        /// </summary>
        public bool DebugEnabled = false;
    }
}
