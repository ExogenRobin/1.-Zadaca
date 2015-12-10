using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.zadatak {
    class GenericList<X> : IGenericList<X> {
        private X[] _internalStorage;
        private X[] _temp;
        private int _sizeOfArray;
        private int _count = 0;

        public GenericList() {
            _internalStorage = new X[4];
            _sizeOfArray = 4;
        }

        public GenericList(int initialSize) {
            _internalStorage = new X[initialSize];
            _sizeOfArray = initialSize;
        }

        public int Count { get { return _count; } }

        public void Add(X item) {
            if (_count == _sizeOfArray) {
                _temp = new X[_sizeOfArray];
                _internalStorage.CopyTo(_temp, 0);

                _sizeOfArray = _internalStorage.Length * 2;
                _internalStorage = new X[_sizeOfArray];

                _temp.CopyTo(_internalStorage, 0);
            }
            try {
                _internalStorage[_count] = item;
                _count++;
            }
            catch (IndexOutOfRangeException) {

            }
        }

        public void Clear() {
            _internalStorage = new X[_sizeOfArray];
            _count = 0;
        }

        public bool Contains(X item) {
            for (int i = 0; i < _sizeOfArray - 1; i++) {
                if (_internalStorage[i].Equals(item)) {
                    return true;
                }
            }
            return false;
        }

        public X GetElement(int index) {
            if (index <= _sizeOfArray) {
                return _internalStorage[index];
            }
            else {
                throw new System.IndexOutOfRangeException();
            }
        }

        public int IndexOf(X item) {
            for (int i = 0; i < _sizeOfArray; i++) {
                if (_internalStorage[i].Equals(item)) {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(X item) {
            if (IndexOf(item) < 0) {
                return false;
            }
            return RemoveAt(IndexOf(item));
        }

        public bool RemoveAt(int index) {
            if (index >= _count) {
                return false;
            }

            for (int i = index; i < _sizeOfArray - 1; i++) {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _internalStorage[_sizeOfArray - 1] = ConvertValue<X>(0);
            _count--;
            return true;
        }

        private static T ConvertValue<T>(int value) {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public IEnumerator<X> GetEnumerator() { 
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
