using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>   // 비교가능한 값
    {
        private const int DefaultCapacity = 1000;

        private struct Entry
        {
            public TKey key;
            public TValue value;
        }
        private Entry[] table;

        public Dictionary()
        {
            table = new Entry[DefaultCapacity];
        }
        public void Add(TKey key, TValue value) 
        {
            // 1. key를 index로 해싱
            int index = key.GetHashCode() % table.Length;
        }
    }
}
