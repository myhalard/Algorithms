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

namespace Algorithms.Tests.Sort
{
    public static class SortIntsTestHelper
    {
        public static readonly int[] SortedInts = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static readonly int[] ReverseInts = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        public static readonly int[] ScrambledInts1 = { 0, 1, 4, 7, 2, 5, 8, 3, 6, 9 };
        public static readonly int[] ScrambledInts2 = { 7, 4, 1, 0, 8, 5, 2, 9, 6, 3 };
        public static readonly int[] ScrambledInts3 = { 9, 6, 3, 8, 5, 2, 7, 4, 1, 0 };
        public static readonly int[] ScrambledInts4 = { 7, 5, 3, 9, 1, 4, 0, 6, 2, 8 };

        public static int[] SortedOneThousandArray = new int[1000];
        public static int[] SortedOneMillionArray = new int[1000*1000];

        private static void FillSortedArray(int[] array)
        {
            for (var index = 0; index < array.Length; ++index)
            {
                array[index] = index;
            }
        }

        static SortIntsTestHelper()
        {
            FillSortedArray(SortedOneThousandArray);
            FillSortedArray(SortedOneMillionArray);
        }

        public static IEnumerable<int[]> CommonIntArrays()
        {
            yield return SortedInts;
            yield return ReverseInts;
            yield return ScrambledInts1;
            yield return ScrambledInts2;
            yield return ScrambledInts3;
            yield return ScrambledInts4;
        }


        private static int[] ScrambledArray(int size)
        {
            var result = new int[size];
            for (var index = 0; index < result.Length; ++index)
            {
                result[index] = index;
            }
            Shuffle.RandomShuffle(new ArraySegment<int>(result));
            return result;            
        }
        public static int[] ScrambledOneThousandArray()
        {
            return ScrambledArray(1000);
        }
        public static int[] ScrambledOneMillionArray()
        {
            return ScrambledArray(1000*1000);
        }

    }
}