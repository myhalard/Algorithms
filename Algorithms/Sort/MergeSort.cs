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
using Algorithms.Collections;

namespace Algorithms.Sort
{
    public static class MergeSort
    {
        private const int Cutoff = 7;

        public static void Sort<T>(ArraySegment<T> items)
        {
            Sort(items, Comparer<T>.Default);
        }

        public static void Sort<T>(ArraySegment<T> items, IComparer<T> comparer)
        {
            var auxiliary = new T[items.Length];
            SortHelper(items, auxiliary, comparer);
        }

        private static void SortHelper<T>(ArraySegment<T> items, T[] auxiliary, IComparer<T> comparer)
        {
            if (items.Length <= Cutoff)
            {
                InsertionSort.Sort(items, comparer);
                return;
            }

            var middle = items.Length / 2;
            var lower = new ArraySegment<T>(items, 0, middle);
            var upper = new ArraySegment<T>(items, middle, items.Length - middle);

            SortHelper(lower, auxiliary, comparer);
            SortHelper(upper, auxiliary, comparer);
            Merge(lower, upper, auxiliary, comparer);
        }

        private static void Merge<T>(ArraySegment<T> lower, ArraySegment<T> upper, T[] auxiliary, IComparer<T> comparer)
        {
            var result = new ArraySegment<T>(lower.Array, lower.Offset, lower.Length + upper.Length);
            var temp = new ArraySegment<T>(auxiliary, lower.Offset, lower.Length);
            ArraySegment<T>.Copy(lower, 0, temp, 0, lower.Length);
            lower = temp;

            if (lower[lower.Length - 1].IsLessThanOrEqual(upper[0], comparer))
            {
                return;
            }

            var lowerIndex = 0;
            var upperIndex = 0;
            for (var index = 0; index < result.Length; ++index)
            {
                if (comparer.Compare(lower[lowerIndex], upper[upperIndex]) <= 0)
                {
                    result[index] = lower[lowerIndex++];
                    if (lowerIndex == lower.Length)
                    {
                        break;
                    }
                }
                else
                {
                    result[index] = upper[upperIndex++];
                    if (upperIndex == upper.Length)
                    {
                        ArraySegment<T>.Copy(lower, lowerIndex, result, index + 1, lower.Length - lowerIndex);
                        break;
                    }
                }
            }
        }
    }
}