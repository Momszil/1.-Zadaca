using System;

namespace CsharpVjestina.Dz1.Zadatak2
{
    public class GenericList<X> : IGenericList<X>
    {
        /// <summary>
        /// Current size of our storage.
        /// </summary>
        private int _size;
        /// <summary>
        /// Current capacity of our storage.
        /// </summary>
        private int _capacity;
        /// <summary>
        /// Array with currently sotred data.
        /// </summary>
        private X[] _internalStorage;

        public GenericList()
        {
            _capacity = 4;
            _internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
            if (initialSize > 0)
            {
                _capacity = initialSize;
                _internalStorage = new X[initialSize];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public void Add(X item)
        {
            if (_capacity <= _size)
            {
                AllocateDouble();
            }
            _internalStorage[_size] = item;
            _size++;
        }

        private void AllocateDouble()
        {
            _capacity *= 2;
            X[] newStorage = new X[_capacity];
            for (int i = 0; i < _capacity / 2; i++)
            {
                newStorage[i] = _internalStorage[i];
            }
            _internalStorage = newStorage;
        }

        public void Clear()
        {
            _internalStorage = new X[_capacity]; 
            _size = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index > -1 && index < _size)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (item.Equals(_internalStorage[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(X item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (item.Equals(_internalStorage[i]))
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= _size || index < 0)
            {
                return false;
            }
            
            if (index < _capacity - 1)
            {
                for (int i = index; i < _size - 1; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
            }

            _size--;
            X[] newStorage = new X[_capacity];
            Array.Copy(_internalStorage, newStorage, _size);
            _internalStorage = newStorage;
            return true;
        }
    }
}
