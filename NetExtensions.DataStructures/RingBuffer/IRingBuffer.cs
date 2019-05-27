using System;
using System.Collections.Generic;

namespace System.Collections.Generic
{
    public interface IRingBuffer<T>
    {
        void Put(T obj);
        IList<T> Get();
        T GetLast();
        T GetFirst();
    }
}
