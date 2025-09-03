using System.Collections;

namespace DataStructure
{
    public class HashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private const float LoadFactorThreshold = 0.75f;

        private System.Collections.Generic.LinkedList<HashItem<TKey, TValue>>[] _buckets;
        private int _count;
        private int _capacity;

        public HashTable(int initialCapacity = 10)
        {
            _capacity = initialCapacity;
            _buckets = new System.Collections.Generic.LinkedList<HashItem<TKey, TValue>>[_capacity];
            _count = 0;
        }

        public int Count => _count;

        public void Add(TKey key, TValue value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            ResizeIfNeeded();

            int index = GetIndex(key);
            _buckets[index] ??= new System.Collections.Generic.LinkedList<HashItem<TKey, TValue>>();

            foreach (var item in _buckets[index])
            {
                if (EqualityComparer<TKey>.Default.Equals(item.Key, key))
                {
                    throw new InvalidOperationException("Key already exists.");
                }
            }

            _buckets[index].AddLast(new HashItem<TKey, TValue>(key, value));
            _count++;
        }

        public TValue Get(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            int index = GetIndex(key);

            var bucket = _buckets[index];
            if (bucket != null)
            {
                foreach (var item in bucket)
                {
                    if (EqualityComparer<TKey>.Default.Equals(item.Key, key))
                    {
                        return item.Value;
                    }
                }
            }

            throw new KeyNotFoundException($"Key '{key}' not found.");
        }

        public bool Contains(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            int index = GetIndex(key);

            var bucket = _buckets[index];
            if (bucket != null)
            {
                foreach (var item in bucket)
                {
                    if (EqualityComparer<TKey>.Default.Equals(item.Key, key))
                        return true;
                }
            }

            return false;
        }

        public bool Remove(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            int index = GetIndex(key);

            var bucket = _buckets[index];
            if (bucket != null)
            {
                var node = bucket.First;
                while (node != null)
                {
                    if (EqualityComparer<TKey>.Default.Equals(node.Value.Key, key))
                    {
                        bucket.Remove(node);
                        _count--;
                        return true;
                    }
                    node = node.Next;
                }
            }

            return false;
        }

        private void ResizeIfNeeded()
        {
            if ((float)_count / _capacity > LoadFactorThreshold)
            {
                Resize();
            }
        }

        private void Resize()
        {
            int newCapacity = _capacity * 2;
            var newBuckets = new System.Collections.Generic.LinkedList<HashItem<TKey, TValue>>[newCapacity];

            foreach (var bucket in _buckets)
            {
                if (bucket == null) continue;

                foreach (var item in bucket)
                {
                    int newIndex = (item.Key!.GetHashCode() & 0x7FFFFFFF) % newCapacity;
                    newBuckets[newIndex] ??= new System.Collections.Generic.LinkedList<HashItem<TKey, TValue>>();
                    newBuckets[newIndex].AddLast(item);
                }
            }

            _capacity = newCapacity;
            _buckets = newBuckets;
        }

        private int GetIndex(TKey key)
        {
            int hash = key.GetHashCode();
            return (hash & 0x7FFFFFFF) % _capacity;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var bucket in _buckets)
            {
                if (bucket != null)
                {
                    foreach (var item in bucket)
                    {
                        yield return new KeyValuePair<TKey, TValue>(item.Key, item.Value);
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class HashItem<K, V>
        {
            public K Key { get; }
            public V Value { get; }

            public HashItem(K key, V value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
