using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _141_IEnumeratorExample
{
    class SomeIntValue : IEnumerable<int>
    {
        //int _maxCount;

        IntEnumerator intEnumerator;

        public SomeIntValue(int numValues)
        {
            intEnumerator = new IntEnumerator(numValues);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return intEnumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return intEnumerator;
        }
    }
}
