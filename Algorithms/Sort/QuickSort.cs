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
    public class QuickSort
    {
        private const int Cutoff = 7;

        public static void Sort<T>(ArraySegment<T> items)
        {
            Sort(items, Comparer<T>.Default);
        }

        public static void Sort<T>(ArraySegment<T> items, IComparer<T> comparer)
        {
            var random = new System.Random();
            SortHelper(items, random, comparer);
        }

        private static void SortHelper<T>(ArraySegment<T> items, System.Random random, IComparer<T> comparer)
        {
            if (items.Length <= Cutoff)
            {
                InsertionSort.Sort(items, comparer);
                return;
            }

            var pivot = ChoosePivot(items.Length, random);
            pivot = Partition.TwoWayPartition(items, pivot, comparer);
            var lower = new ArraySegment<T>(items, 0, pivot);
            var upper = new ArraySegment<T>(items, pivot + 1, items.Length - pivot - 1);
            SortHelper(lower, random, comparer);
            SortHelper(upper, random, comparer);
        }

        private static int ChoosePivot(int length, System.Random random)
        {
            return random.Next(length);
        }

    }
}