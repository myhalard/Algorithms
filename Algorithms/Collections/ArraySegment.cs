/*
 * Copyright 2014 Marc-Yervant Halard
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System.Collections.Generic;

namespace Algorithms.Collections
{
    public struct ArraySegment<T>
    {
        private readonly T[] _array;
        private readonly int _offset;
        private readonly int _length;

        public ArraySegment(T[] array)
            : this(array, 0, array.Length)
        {
        }

        public ArraySegment(T[] array, int offset, int length)
        {
            _array = array;
            _offset = offset;
            _length = length;
        }

        public ArraySegment(ArraySegment<T> segment, int offset, int length)
        {
            _array = segment._array;
            _offset = segment._offset + offset;
            _length = length;
        }

        public IEnumerable<T> AsEnumerable()
        {
            for (var index = 0; index < _length; ++index)
            {
                yield return _array[_offset + index];
            }
        }

        public T this[int index]
        {
            get { return _array[_offset + index]; }
            set { _array[_offset + index] = value; }
        }

        public int Length
        {
            get { return _length; }
        }

        public void Swap(int left, int right)
        {
            var temp = this[left];
            this[left] = this[right];
            this[right] = temp;
        }

        internal T[] Array
        {
            get { return _array; }
        }

        internal int Offset
        {
            get { return _offset; }
        }

        public static void Copy(ArraySegment<T> source, int sourceOffset, ArraySegment<T> destination, int destinationOffset, int length)
        {
            System.Array.Copy(source._array, source._offset + sourceOffset, destination._array, destination._offset + destinationOffset, length);
        }
    }
}