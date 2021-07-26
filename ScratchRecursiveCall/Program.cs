using System;
using System.Collections.Generic;

namespace ScratchRecursiveCall
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> mainList = new List<List<string>>();
            mainList.Add(new List<string> { "1", "2", "3" });
            mainList.Add(new List<string> { "4", "5", "6" });
            mainList.Add(new List<string> { "7", "8", "9" });
            //mainList.Add(new List<string> { "3593", "6894" });

            //Get the full list and iterate
            var result = GeneratePermutations<string>(0, mainList);
            var count = 1;
            foreach (List<string> x in result)
            {
                Console.WriteLine($"{count}. {String.Join(',', x)}");
                count++;
            }

            //Iterate through the list as it is being generated
            count = 1;
            foreach (List<string> x in GetNextPermutation<string>(0, mainList))
            {
                Console.WriteLine($"{count}. {String.Join(',', x)}");
                count++;
            }

            Console.WriteLine("All done");
            Console.ReadKey();
        }

        static List<List<T>> GeneratePermutations<T>(int level, List<List<T>> mainList)
        {
            List<List<T>> retval = new List<List<T>>();
            if (level == mainList.Count)
            {
                retval.Add(new List<T>());
                return retval;
            }

            foreach (T item in mainList[level])
            {
                foreach (var sublist in GeneratePermutations(level + 1, mainList))
                {
                    var tmp = new List<T> { item };
                    tmp.AddRange(sublist);
                    retval.Add(tmp);
                }
            }
            return retval;
        }

        static IEnumerable<List<T>> GetNextPermutation<T>(int level, List<List<T>> mainList)
        {
            List<T> retval = new List<T>();
            if (level < mainList.Count)
            {
                foreach (T item in mainList[level])
                {
                    foreach (var sublist in GetNextPermutation<T>(level + 1, mainList))
                    {
                        var tmp = new List<T> { item };
                        tmp.AddRange(sublist);
                        yield return tmp;
                    }
                }
            }
            else
            {
                yield return retval;
            }
        }

    }
}
