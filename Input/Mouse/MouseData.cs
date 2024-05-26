using Microsoft.Xna.Framework;

namespace Saga.Input.Mouse
{
    /// <summary>
    /// A container for MouseData which is lazy initialized
    /// </summary>
    internal class MouseData
    {
        public int ScrollWheelValue;
        public int ScrollWheelDelta;
        private Vector2? _dragStart;
        private Vector2? _dragEnd;
        private Vector2? _position;

        public MouseData()
        {
            ScrollWheelValue = 0;
            ScrollWheelDelta = 0;
        }

        public Vector2 DragStart
        {
            get
            {
                if (_dragStart == null)
                    _dragStart = new Vector2();
                return _dragStart.Value;
            }
            set
            {
                _dragStart = value;
            }
        }

        public Vector2 DragEnd
        {
            get
            {
                if (_dragEnd == null)
                    _dragEnd = new Vector2();
                return _dragEnd.Value;
            }
            set
            {
                _dragEnd = value;
            }
        }

        public Vector2 Position
        {
            get
            {
                if (_position == null)
                    _position = new Vector2();
                return _position.Value;
            }
            set
            {
                _position = value;
            }
        }

    }
}
