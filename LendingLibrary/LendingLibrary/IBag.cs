using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary
{
    public interface IBag<T> : IEnumerable<T>
    // IEnumerable: loops over the generic or non-generic collections.
    // GetEnumerator: get current elements from the collection.
    {
        /// <summary>
        /// Add an item to the bag. <c>null</c> items are ignored.
        /// </summary>
        void Pack(T item);

        /// <summary>
        /// Remove the item from the bag at the given index.
        /// </summary>
        /// <returns>The item that was removed.</returns>
        T Unpack(int index);
    }
    class IBag2<T> : IBag<T>
    {
        private List<T> _items = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in _items)
                yield return item;
        }

        public void Pack(T item)
        {
            _items.Add(item);
        }

        public T Unpack(int index)
        {
            T item = _items[index];
            _items.RemoveAt(index);
            return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
