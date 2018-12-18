using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShreeMehtaPublicity.Utility
{
    public class InlineComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> getEquals;
        private readonly Func<T, int> getHashcode;


        public InlineComparer(Func<T, T, bool> equals, Func<T, int> hashCode)
        {
            getEquals = equals;
            getHashcode = hashCode;
        }
        public bool Equals(T x, T y)
        {
            return getEquals(x, y);
        }
        public int GetHashCode(T obj)
        {
            return getHashcode(obj);
        }
    }
}
