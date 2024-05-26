using Saga.Input.Mouse;
using Saga.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saga.Input
{
    /// <summary>
    /// Handles the initialization and update of various input sources
    /// </summary>
    internal class InputManager : BaseManager
    {
        internal MouseManager _mouseManager = new MouseManager();

        public void AddEventListener(MouseEvent eventType, Action<MouseData> method) => _mouseManager.AddEventListener(eventType, method);
        public void RemoveEventListener(MouseEvent eventType, Action<MouseData> method) => _mouseManager.RemoveEventListener(eventType, method);

        public override void Update()
        {
            _mouseManager.Update();
        }

        public override void OnEnabled()
        {
            _mouseManager.Enabled = true;
        }

        public override void OnDisabled() 
        {
            _mouseManager.Enabled = false;
        }
    }
}
