using System;

namespace CsharpVjestina.Dz1.Zadatak1
{
    class IntegerList : IIntegerList
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
        private int[] _internalStorage;

        public IntegerList()
        {
            _capacity = 4;
            _internalStorage = new int[4];
        }

        public IntegerList(int initialSize)
        {
            if (initialSize > 0)
            {
                _capacity = initialSize;
                _internalStorage = new int[initialSize];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Add(int item)
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
            int[] newStorage = new int[_capacity];
            for (int i = 0; i < _capacity / 2; i++)
            {
                newStorage[i] = _internalStorage[i];
            }
            _internalStorage = newStorage;
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < _size; i++)
            {
                _internalStorage[i] = 0;
            }
            _size = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetElement(int index)
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

        public int IndexOf(int item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (item == _internalStorage[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(int item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (item == _internalStorage[i])
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
            _internalStorage[_size - 1] = 0;
            _size--;
            return true;
        }

        public void ListExample(IIntegerList listOfIntegers)
        {
            listOfIntegers.Add(1);
            listOfIntegers.Add(2);
            listOfIntegers.Add(3);
            listOfIntegers.Add(4);
            listOfIntegers.Add(5);
            // lista je [1,2,3,4,5]

            listOfIntegers.RemoveAt(0);
            // Lista je [2,3,4,5]

            listOfIntegers.Remove(5);
            // Lista je [2,3,4]

            Console.WriteLine(listOfIntegers.Count);
            // 3

            Console.WriteLine(listOfIntegers.Remove(100));
            // false, nemamo element u vrijednosti 100
            Console.WriteLine(listOfIntegers.RemoveAt(5));
            // false, nemamo ništa na poziciji 5

            Console.WriteLine(listOfIntegers.Contains(3) + ", " + listOfIntegers.IndexOf(3));
            // true, imamo ga na poziciji 1      
            Console.WriteLine(listOfIntegers.GetElement(1));

            listOfIntegers.Clear();
            Console.WriteLine(listOfIntegers.Count);
            // 0
        }
    }
}
