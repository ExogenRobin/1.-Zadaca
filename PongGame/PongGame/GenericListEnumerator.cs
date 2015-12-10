using System;
using System.Collections;
using System.Collections.Generic;

namespace _4.zadatak {
    internal class GenericListEnumerator<X> : IEnumerator<X> {
        private GenericList<X> genericList;
        private int _current = -1;

        public GenericListEnumerator(GenericList<X> genericList) {
            this.genericList = genericList;
        }

        public bool MoveNext() {
            if (_current >= genericList.Count) {
                return false;
            }
            _current++;
            if (_current < genericList.Count) {
                return true;
            }
            else {
                return false;
            }
        }

        public X Current {
            get {
                return genericList.GetElement(_current);
            }
        }

        object IEnumerator.Current {
            get { return Current; }
        }

        public void Dispose() {
        }


        public void Reset() {
        }
    }
}