using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QueueKata
{
    public interface IQueue<T> : IReadOnlyCollection<T>
    {
        void Enqueue(T item);
        T Peek();
        T Dequeue();
    }

    public interface IStack<T> : IReadOnlyCollection<T>
    {
        void Push(T item);
        T Pop();
    }

    public class SimpleStack<T> : IStack<T>
    {
        private readonly List<T> _inner = new List<T>();

        public void Push(T item)
        {
            lock (_inner)
            {
                _inner.Insert(0, item);
            }
        }

        public T Pop()
        {
            lock (_inner)
            {
                if (_inner.Count == 0)
                {
                    throw new Exception("Stack is empty. Nothing to pop.");
                }

                var top = _inner[0];
                _inner.RemoveAt(0);
                return top;
            }
        }

        public int Count
        {
            get
            {
                lock (_inner)
                {
                    return _inner.Count;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            lock (_inner)
            {
                return _inner.GetEnumerator();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }        
    }

    public class TwoStackQueue<T> : IQueue<T>
    {
        private readonly object _lock = new object();
        private readonly SimpleStack<T> _in = new SimpleStack<T>();
        private readonly SimpleStack<T> _out = new SimpleStack<T>();

        public void Enqueue(T item)
        {
            lock (_lock)
            {
                _in.Push(item);
            }
        }

        public T Peek()
        {
            lock (_lock)
            {
                Deliver();

                return _out.First();
            }
        }

        public T Dequeue()
        {
            lock (_lock)
            {
                Deliver();

                return _out.Pop();
            }
        }

        private void Deliver()
        {
            if (_out.Count == 0 && _in.Count > 0)
            {
                while (_in.Count > 0)
                {
                    _out.Push(_in.Pop());
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            lock (_lock)
            {
                foreach (var item in _out)
                {
                    yield return item;
                }
                foreach (var item in _in.Reverse())
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count { get
            {
                lock (_lock)
                {
                    return _in.Count + _out.Count;
                }
            }
        }
    }
}
