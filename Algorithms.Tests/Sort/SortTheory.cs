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
using NUnit.Framework;

namespace Algorithms.Tests.Sort
{
    public static class SortTheory
    {
        public static void TestSortCommonArrays(System.Action<ArraySegment<int>, IComparer<int>> sortAlgorithm)
        {
            foreach (var ints in SortIntsTestHelper.CommonIntArrays())
            {
                sortAlgorithm(new ArraySegment<int>(ints), Comparer<int>.Default);
                CollectionAssert.AreEqual(SortIntsTestHelper.SortedInts, ints);
            }
        }

        public static void TestSortOneThousandArray(System.Action<ArraySegment<int>, IComparer<int>> sortAlgorithm)
        {
            var scrambled = SortIntsTestHelper.ScrambledOneThousandArray();
            sortAlgorithm(new ArraySegment<int>(scrambled), Comparer<int>.Default);
            CollectionAssert.AreEqual(SortIntsTestHelper.SortedOneThousandArray, scrambled);
        }

        public static void TestSortOneMillionArray(System.Action<ArraySegment<int>, IComparer<int>> sortAlgorithm)
        {
            var scrambled = SortIntsTestHelper.ScrambledOneMillionArray();
            sortAlgorithm(new ArraySegment<int>(scrambled), Comparer<int>.Default);
            CollectionAssert.AreEqual(SortIntsTestHelper.SortedOneMillionArray, scrambled);
        }
    }
}