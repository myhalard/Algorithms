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
using Algorithms.Sort;

namespace Algorithms
{
    public static class QuickSelect
    {
        public static T Select<T>(ArraySegment<T> items, int rank, IComparer<T> comparer)
        {
            var random = new System.Random();
            return SelectHelper(items, rank, random, comparer);
        }

        private static T SelectHelper<T>(ArraySegment<T> items, int rank, System.Random random, IComparer<T> comparer)
        {
            var pivot = ChoosePivot(items.Length, random);
            pivot = Partition.TwoWayPartition(items, pivot, comparer);

            if (pivot > rank)
            {
                items = new ArraySegment<T>(items, 0, pivot);
                return SelectHelper(items, rank, random, comparer);
            }
            if (pivot < rank)
            {
                items = new ArraySegment<T>(items, pivot + 1, items.Length - pivot - 1);
                return SelectHelper(items, rank - pivot - 1, random, comparer);
            }
            return items[pivot];
        }

        private static int ChoosePivot(int length, System.Random random)
        {
            return random.Next(length);
        }

    }
}