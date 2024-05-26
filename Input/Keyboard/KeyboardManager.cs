using Microsoft.Xna.Framework.Input;
using Saga.Input.Mouse;
using Saga.Util;
using Saga.Util.Event;
using System;

namespace Saga.Input.Keyboard
{
    /// <summary>
    /// The KeyboardManager handles logic for keyboard events
    /// </summary>
    internal class KeyboardManager : BaseManager
    {
        internal EventManager<KeyboardEvent, Keys> _eventManager;
        private KeyboardState _prevKeyboardState;
        private KeyboardState _thisKeyboardState;

        public KeyboardManager()
        {
            _prevKeyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            _thisKeyboardState = _prevKeyboardState;
        }

        public void AddEventListener(KeyboardEvent eventType, Action<Keys> method)
        {
            _eventManager.AddEventListener(eventType, method);
        }

        public void RemoveEventListener(KeyboardEvent eventType, Action<Keys> method)
        {
            _eventManager.RemoveEventListener(eventType, method);
        }

        public override void Update()
        {
            // Update our current keyboard state and fetch pressed keys
            _thisKeyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            Keys[] thisPressedKeys = _thisKeyboardState.GetPressedKeys();
            Keys[] lastPressedKeys = _prevKeyboardState.GetPressedKeys();

            // Ascertain if there are any new keys pressed
            foreach (Keys key in thisPressedKeys)
            {
                if (_prevKeyboardState.IsKeyUp(key))
                {
                    _eventManager.Emit(KeyboardEvent.KEY_PRESSED, key);
                }
            }

            // Ascertain if there are any new keys released
            foreach (Keys key in lastPressedKeys)
            {
                if (_thisKeyboardState.IsKeyUp(key))
                {
                    _eventManager.Emit(KeyboardEvent.KEY_RELEASED, key);
                }
            }

            // Store our current state for next update
            _prevKeyboardState = _thisKeyboardState;
        }
    }
}
