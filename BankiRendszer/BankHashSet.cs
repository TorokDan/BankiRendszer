using System;
using System.Collections.Generic;

namespace BankiRendszer
{
    public class BankHashSet<K, T>
    {
        private class BankHashSetItem
        {
            public K key;
            public T content;
        }

        public delegate int HashCallback(K key, int size);

        private List<BankHashSetItem>[] _contents;
        private int _size;

        private HashCallback HashFunction;

        // CONSTRUCTOR
        public BankHashSet(int size, HashCallback hashFv = null)
        {
            _size = size;

            _contents = new List<BankHashSetItem>[_size];
            for (int i = 0; i < _contents.Length; i++)
                _contents[i] = new List<BankHashSetItem>();
            
            HashFunction = hashFv ?? DefaultHashing; // null coalescing
        }

        public BankHashSet()
            : this(100, DefaultHashing)
        {
            
        }
        
        // PUBLIC
        public void Insert(K key, T content)
        {
            _contents[HashFunction(key, _size)].Add(new BankHashSetItem() // A méret nem biztos, hogy stimmel
            {
                key = key,
                content = content
            });
        }

        public T Find(K key) => LinearSearch(key, HashFunction(key, _size));

        public T this[K key]
        {
            get => Find(key);
            set => Insert(key, value);
        }

        // PRIVATE
        private static int DefaultHashing(K key, int size)
        {
            return Math.Abs(key.GetHashCode()) % size;
        }

        private T LinearSearch(K key, int index)
        {
            int i = 0;
            while (i < _contents[index].Count &&
                   !_contents[index][i].key.Equals(key))
            {
                i++;
            }

            return i < _contents[index].Count
                ? _contents[index][i].content
                : throw new ArgumentException("Item with this key not found");
        }
    }
}