namespace DataStructure
{
    public class DynamicArray<T>
    {
        private T[] _items;
        private int _count;
        private int _capacity = 0;
        private int _defaultCapacity = 4;
        public int Count => _count;
        public int Capacity => _capacity;
        public DynamicArray(int defaultCapacity = 4)
        {
            _items = new T[defaultCapacity];
            _capacity = defaultCapacity;
        }

        public void Add(T item)
        {
            if (_count == _capacity)
            {
                Resize(_capacity * 2);
            }
            _items[_count] = item;
            _count++;

        }

        public void Resize(int newCapacity)
        {
            var newArray = new T[newCapacity];
            Array.Copy(_items, newArray, _count);
            _items = newArray;
            _capacity = newCapacity;
        }
    }
}
