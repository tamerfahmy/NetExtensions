using System;
using System.Linq;

namespace System.Collections.Generic
{
    public class RingBuffer<T> : IRingBuffer<T>
    {
        private readonly Queue<T> _buffer;
        private readonly int _size;

        public RingBuffer(int size)
        {
            if (size < 1)
                throw new ArgumentException($"{nameof(size)} cannot be negative or zero");

            _size = size;
            _buffer = new Queue<T>();
        }

        public void Put(T obj)
        {
            if (_buffer.Count == _size)
            {
                T value = _buffer.Dequeue();
            }

            _buffer.Enqueue(obj);
        }

        public IList<T> Get()
        {
            return _buffer.ToList();
        }

        public T GetLast()
        {
            return _buffer.ToList().LastOrDefault();
        }

        public T GetFirst()
        {
            return _buffer.ToList().FirstOrDefault();
        }
    }
}
