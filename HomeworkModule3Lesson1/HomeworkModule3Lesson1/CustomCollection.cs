
namespace HomeworkModule3Lesson1
{
    internal class CustomCollection<T> : IEnumerable<T>
    {
        internal T[] _items;
        internal int _size;
        internal int _index = 0;

        private static readonly T[] s_emptyArray = new T[0];

        public CustomCollection()
        {
            _items = s_emptyArray;
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)_items).GetEnumerator();
        }

        public void Add(T item)
        {
            _size = _items.Length + 1;
            Array.Resize(ref _items, _size);
            _items[_index] = item;
            _index++;

        }

        public void Sort()
        {
            Array.Sort(_items, 0, _size);
        }

        public int Count()
        {
            return _items.Length;
        }

        public void SetDefaultAt(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            _items[index] = default;
        }
    }
}
