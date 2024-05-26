using System;
using System.Collections.Generic;
using System.Text;

namespace Saga.Util.Core
{

    /// <summary>
    /// A simple Comparer that prevents boxing / unboxing when using enumeration as key
    /// </summary>
    internal struct CoreEventComparer : IEqualityComparer<CoreEvent>
    {
        public bool Equals(CoreEvent x, CoreEvent y)
        {
            return x == y;
        }

        public int GetHashCode(CoreEvent obj)
        {
            return (int)obj;
        }
    }
}
