using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.zadatak {
    public class IntegerList : IIntegerList {
        private int[] _internalStorage;
        private int[] _temp;
        private int _sizeOfArray;
        private int _count = 0;

        public IntegerList() {
            _internalStorage = new int[4];
            _sizeOfArray = 4;
        }

        public IntegerList(int initialSize) {
            _internalStorage = new int[initialSize];
            _sizeOfArray = initialSize;
        }

        public int Count { get { return _count; } }

        public void Add(int item) {
            if (_count == _sizeOfArray) {
                _temp = new int[_sizeOfArray];
                _internalStorage.CopyTo(_temp, 0);

                _sizeOfArray = _internalStorage.Length * 2;
                _internalStorage = new int[_sizeOfArray];

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
            _internalStorage = new int[_sizeOfArray];
            _count = 0;
        }

        public bool Contains(int item) {
            for (int i = 0; i < _sizeOfArray - 1; i++) {
                if (_internalStorage[i].Equals(item)) {
                    return true;
                }
            }
            return false;
        }

        public int GetElement(int index) {
            if (index <= _sizeOfArray) {
                return _internalStorage[index];
            }
            else {
                throw new System.IndexOutOfRangeException();
            }

        }

        public int IndexOf(int item) {
            for (int i = 0; i < _sizeOfArray; i++) {
                if (_internalStorage[i].Equals(item)) {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(int item) {
            if (IndexOf(item) < 0) {
                return false;
            }
            return RemoveAt(IndexOf(item));
        }

        public bool RemoveAt(int index) {
            if (index >= _count) {
                return false;
            }
            _internalStorage[index] = 0;

            for (int i = index; i < _sizeOfArray - 1; i++) {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _internalStorage[_sizeOfArray - 1] = 0;
            _count--;
            return true;
        }

        public void Write() {
            Console.Write("[");
            for (int i = 0; i < _sizeOfArray; i++) {
                Console.Write(_internalStorage[i] + ",");
            }
            Console.Write("]\n");
        }
    }
}
