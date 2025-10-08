using System.Collections;

namespace DataStructure
{
    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private T[] _items;
        private int _size;
        private const int DefaultCapacity = 4;

        public PriorityQueue(int capacity = DefaultCapacity)
        {
            _items = new T[capacity];
        }

        public int Count => _size;

        public void Add(T item)
        {
            EnsureCapacity();
            _items[_size] = item;
            BubbleUp(_size);
            _size++;
        }

        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("Queue is empty");
            return _items[0];
        }

        public T Pop()
        {
            if (_size == 0)
                throw new InvalidOperationException("Queue is empty");

            T root = _items[0];
            _items[0] = _items[_size - 1];
            _items[_size - 1] = default!;
            _size--;

            BubbleDown(0);
            return root;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1) return false;

            _items[index] = _items[_size - 1];
            _items[_size - 1] = default!;
            _size--;

            if (index < _size)
            {
                int parentIndex = (index - 1) / 2;
                if (index > 0 && _items[index].CompareTo(_items[parentIndex]) < 0)
                    BubbleUp(index);
                else
                    BubbleDown(index);
            }

            return true;
        }

        private void BubbleUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (_items[parentIndex].CompareTo(_items[index]) <= 0) break;
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }

        private void BubbleDown(int index)
        {
            while (index < _size)
            {
                int left = index * 2 + 1;
                int right = index * 2 + 2;
                int smallest = index;

                if (left < _size && _items[left].CompareTo(_items[smallest]) < 0)
                    smallest = left;
                if (right < _size && _items[right].CompareTo(_items[smallest]) < 0)
                    smallest = right;

                if (smallest == index) break;

                Swap(index, smallest);
                index = smallest;
            }
        }

        private void Swap(int i, int j)
        {
            (_items[i], _items[j]) = (_items[j], _items[i]);
        }

        private void EnsureCapacity()
        {
            if (_size < _items.Length) return;
            int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
            Array.Resize(ref _items, newCapacity);
        }

        private int IndexOf(T item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_items[i]!.Equals(item)) return i;
            }
            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
                yield return _items[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
