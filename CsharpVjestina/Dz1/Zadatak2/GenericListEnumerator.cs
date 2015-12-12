using System;
using System.Collections;
using System.Collections.Generic;

namespace CsharpVjestina.Dz1.Zadatak2
{
    internal class GenericListEnumerator<X> : IEnumerator<X>
    {
        private IGenericList<X> _collection;
        private int curIndex;
        private X curX;

        public GenericListEnumerator(IGenericList<X> collection)
        {
            this._collection = collection;
            curIndex = -1;
            curX = default(X);
        }

        public bool MoveNext()
        {
            curIndex++;
            if (curIndex < _collection.Count)
            {
                curX = _collection.GetElement(curIndex);
                return true;
            }
            return false;
        }

        public X Current
        {
            get
            {
                return curX;
            }
        }
        
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            // ignore this
        }

        public void Reset()
        {
            // ignore this
        }
    }
}