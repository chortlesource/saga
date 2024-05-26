using Saga.Util.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saga.Input.Mouse
{
    /// <summary>
    /// A simple Comparer that prevents boxing / unboxing when using enumeration as key
    /// </summary>
    internal class MouseEventComparer : IEqualityComparer<MouseEvent>
    {
        public bool Equals(MouseEvent x, MouseEvent y)
        {
            return x == y;
        }

        public int GetHashCode(MouseEvent obj)
        {
            return (int)obj;
        }
    }
}
