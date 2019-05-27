using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace System.Collections.Concurrent
{
    public class ConcurrentRingBuffer<T> : IRingBuffer<T>
    {
        private readonly ConcurrentQueue<T> _buffer;
        private readonly int _size;
        private readonly ReaderWriterLockSlim _lock;

        public ConcurrentRingBuffer(int size)
        {
            if (size < 1)
                throw new ArgumentException($"{nameof(size)} cannot be negative or zero");

            _size = size;
            _lock = new ReaderWriterLockSlim();
            _buffer = new ConcurrentQueue<T>();
        }

        public void Put(T obj)
        {
            _lock.EnterWriteLock();
            try
            {
                if (_buffer.Count == _size)
                {
                    T value;
                    _buffer.TryDequeue(out value);
                }

                _buffer.Enqueue(obj);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public IList<T> Get()
        {
            _lock.EnterWriteLock();
            try
            {
                return _buffer.ToArray();
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
        public T GetLast()
        {
            _lock.EnterWriteLock();
            try
            {
                return _buffer.ToList().LastOrDefault();
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public T GetFirst()
        {
            _lock.EnterWriteLock();
            try
            {
                return _buffer.ToList().FirstOrDefault();
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}
