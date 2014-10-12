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
    internal static class Partition
    {
        public static int TwoWayPartition<T>(ArraySegment<T> items, int pivot, IComparer<T> comparer)
        {
            items.Swap(0, pivot);
            var lessIndex = 1;

            for (var index = 1; index < items.Length; ++index)
            {
                if (items[index].IsLessThanOrEqual(items[0], comparer))
                {
                    items.Swap(lessIndex, index);
                    ++lessIndex;
                }
            }
            items.Swap(0, lessIndex - 1);
            return lessIndex - 1;
        }
    }
}