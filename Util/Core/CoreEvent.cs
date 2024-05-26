using System;
using System.Collections.Generic;
using System.Text;

namespace Saga.Util.Core
{
    internal enum CoreEvent
    {
        /// <summary>
        /// Fired to indicate the contents of VRAM will be wiped and need to be regenerated.
        /// </summary>
        GraphicsDeviceReset,

        /// <summary>
        /// Fired to indicate a change in scene
        /// </summary>
        SceneChanged,

        /// <summary>
        /// Fired to indicate application is ending
        /// </summary>
        Halt
    }
}
