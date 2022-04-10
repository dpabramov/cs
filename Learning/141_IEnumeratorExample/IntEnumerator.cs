using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _141_IEnumeratorExample
{
    class IntEnumerator : IEnumerator<int>
    {
        private int _count = 0;

        private int _maxCount;

        private Random random = new Random(1000);

        public int Current
        {
            get
            {
                return random.Next(1000);
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public IntEnumerator(int maxCount)
        {
            _maxCount = maxCount;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return _count++ < _maxCount;
        }

        public void Reset()
        {
        }
    }
}
