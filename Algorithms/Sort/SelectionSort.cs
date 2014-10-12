using System.Collections.Generic;
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
using Algorithms.Collections;

namespace Algorithms.Sort
{
    public static class SelectionSort
    {
        public static void Sort<T>(ArraySegment<T> items)
        {
            Sort(items, Comparer<T>.Default);
        }

        public static void Sort<T>(ArraySegment<T> items, IComparer<T> comparer)
        {
            for (var outer = 0; outer < items.Length; ++outer)
            {
                var minimum = outer;
                for (var inner = outer + 1; inner < items.Length; ++inner)
                {
                    if (items[inner].IsLessThan(items[minimum], comparer))
                    {
                        minimum = inner;
                    }
                }
                items.Swap(outer, minimum);
            }
        }
    }
}