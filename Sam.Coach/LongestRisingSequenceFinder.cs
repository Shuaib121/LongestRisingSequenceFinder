using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sam.Coach
{
    internal class LongestRisingSequenceFinder : ILongestRisingSequenceFinder
    {
        public Task<IEnumerable<int>> Find(IEnumerable<int> numbers) => Task.Run(() =>
        {
            IEnumerable<int> result = null;

            // TODO: return the longest raising sequence in the collection provided, i.e.
            // when numbers = [4, 6, -3, 3, 7, 9] then expected result is [-3, 3, 7, 9]
            // when numbers = [9, 6, 4, 5, 2, 0] then expected result is [4, 5]

            int[] lis = numbers.ToArray();

            // create two lists, list will be used in the loops while longestList will be used to store the longest rising sequence
            List<int> list = new List<int>();
            List<int> longestList = new List<int>();
            int currentMax;
            int highestCount = 0;

            
            for (int i = 0; i < lis.Length; i++)
            {
                currentMax = int.MinValue;
                for (int j = i; j < lis.Length; j++)
                {
                    if (lis[j] > currentMax)
                    {
                        list.Add(lis[j]);
                        currentMax = lis[j];
                    }
                }

                // Compare previous highest subsequence  
                if (list.Count > highestCount)
                {
                    highestCount = list.Count;
                    longestList = new List<int>(list);

                }

                // Chooses the sequence which is better ordered from lowest to highest
                if (list.Count == highestCount)
                {
                    bool lower = false;
                    for (int q = 0; q < highestCount; q++)
                    {
                        if (list.ElementAt(q) < longestList.ElementAt(q))
                        {
                            lower = true;
                        }
                    }

                    if (lower == true)
                    {
                        highestCount = list.Count;
                        longestList = new List<int>(list);
                    }
                }

                list.Clear();
            }

            result = longestList;
            return result;
        });
    }
}
