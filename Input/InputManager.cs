using Microsoft.Xna.Framework.Input;
using Saga.Input.Keyboard;
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
        internal KeyboardManager _keyboardManager = new KeyboardManager();

        public void AddEventListener(MouseEvent eventType, Action<MouseData> method) => _mouseManager.AddEventListener(eventType, method);
        public void RemoveEventListener(MouseEvent eventType, Action<MouseData> method) => _mouseManager.RemoveEventListener(eventType, method);
        public void AddEventListener(KeyboardEvent eventType, Action<Keys> method) => _keyboardManager.AddEventListener(eventType, method);
        public void RemoveEventListener(KeyboardEvent eventType, Action<Keys> method) => _keyboardManager.RemoveEventListener(eventType, method);


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
