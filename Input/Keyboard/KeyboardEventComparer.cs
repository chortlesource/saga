using Saga.Input.Mouse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saga.Input.Keyboard
{
    /// <summary>
    /// A simple Comparer that prevents boxing / unboxing when using enumeration as key
    /// </summary>
    internal class KeyboardEventComparer
    {
        public bool Equals(KeyboardEvent x, KeyboardEvent y)
        {
            return x == y;
        }

        public int GetHashCode(KeyboardEvent obj)
        {
            return (int)obj;
        }
    }
}
