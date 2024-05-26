using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Saga.Util;
using Saga.Util.Core;
using Saga.Util.Event;
using System;

namespace Saga.Input.Mouse
{

    /// <summary>
    /// The MouseManager handles the logic for MouseEvent's
    /// </summary>
    internal class MouseManager : BaseManager
    {
        internal EventManager<MouseEvent, MouseData> _eventManager;
        internal MouseState _initialState;
        internal MouseState _lastState;
        internal MouseState _currentState;
        internal MouseData  _mouseData;
        internal bool _isDragging;

        public MouseManager() {
            _initialState  = Microsoft.Xna.Framework.Input.Mouse.GetState(); ;
            _lastState    = _initialState;
            _currentState = _initialState;

            _mouseData = new MouseData();
            _eventManager = new EventManager<MouseEvent, MouseData>();
        }

        public void AddEventListener(MouseEvent eventType, Action<MouseData> method)
        {
            _eventManager.AddEventListener(eventType, method);
        }

        public void RemoveEventListener(MouseEvent eventType, Action<MouseData> method)
        {
            _eventManager.RemoveEventListener(eventType, method);
        }

        public override void Update()
        {
            if (!Enabled) return;

            // Get the current mouse state and store the current position in data
            _currentState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            _mouseData.Position = new Vector2(_currentState.Position.X, _currentState.Position.Y);

            if (_currentState.LeftButton == ButtonState.Pressed)
            {
                if (_lastState.LeftButton != ButtonState.Pressed)
                {
                    _mouseData.DragStart = _mouseData.Position;
                    _eventManager.Emit(MouseEvent.LEFT_MOUSE_DOWN, _mouseData);
                    _initialState = _currentState;
                }
                else
                {
                    if (Math.Abs(_mouseData.Position.X - _mouseData.DragStart.X) > 8 || Math.Abs(_mouseData.Position.Y - _mouseData.DragStart.Y) > 8)
                    {
                        if (!_isDragging)
                        {
                            _isDragging = true;
                            _eventManager.Emit(MouseEvent.MOUSE_DRAG_START, _mouseData);
                        }
                    }
                }
            }
            else if (_currentState.LeftButton == ButtonState.Released)
            {
                if (_lastState.LeftButton != ButtonState.Released)
                {
             
                    _eventManager.Emit(MouseEvent.LEFT_MOUSE_UP, _mouseData);

                    if (_mouseData.DragStart != _mouseData.Position)
                    {
                        _mouseData.DragEnd = new Vector2(_currentState.Position.X, _currentState.Position.Y);
                        _isDragging = false;
                        _eventManager.Emit(MouseEvent.MOUSE_DRAG_END, _mouseData);
                    }
                }
            }

            if (_currentState.RightButton == ButtonState.Pressed)
            {
                if (_lastState.RightButton != ButtonState.Pressed)
                {
                    _eventManager.Emit(MouseEvent.RIGHT_MOUSE_DOWN, _mouseData);
                }
            }
            else if (_currentState.RightButton == ButtonState.Released)
            {
                if (_lastState.RightButton != ButtonState.Released)
                {
                    _eventManager.Emit(MouseEvent.RIGHT_MOUSE_UP, _mouseData);
                }
            }

            if (_currentState.ScrollWheelValue != _lastState.ScrollWheelValue)
            {
                _mouseData.ScrollWheelValue = _currentState.ScrollWheelValue;
                _mouseData.ScrollWheelDelta = _currentState.ScrollWheelValue - _lastState.ScrollWheelValue;

                if(_mouseData.ScrollWheelDelta > 0)
                    _eventManager.Emit(MouseEvent.MOUSE_WHEEL_UP, _mouseData);
                else
                    _eventManager.Emit(MouseEvent.MOUSE_WHEEL_DOWN, _mouseData);
            }

            // Keep a current copy of the mouse state for comparison next time
            _lastState = _currentState;
        }

    }
}
