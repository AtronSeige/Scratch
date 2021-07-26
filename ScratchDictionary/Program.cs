using System;
using System.Collections.Generic;
using System.Linq;

namespace ScratchDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Numbers, string> dOrdered = new Dictionary<Numbers, string>();
            dOrdered.Add(Numbers.One, "1");
            dOrdered.Add(Numbers.Two, "2");
            dOrdered.Add(Numbers.Three, "3");
            dOrdered.Add(Numbers.Four, "4");
            dOrdered.Add(Numbers.Five, "5");

            Dictionary<Numbers, string> dUnOrdered = new Dictionary<Numbers, string>();
            dUnOrdered.Add(Numbers.Five, "5");
            dUnOrdered.Add(Numbers.Four, "4");
            dUnOrdered.Add(Numbers.One, "1");
            dUnOrdered.Add(Numbers.Three, "3");
            dUnOrdered.Add(Numbers.Two, "2");



            Reorder(dOrdered, dUnOrdered);

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void Reorder(Dictionary<Numbers, string> dOrdered, Dictionary<Numbers, string> dUnOrdered)
        {

            // Use OrderBy method. This will sort the items in the order they are created as enums
            foreach (var item in dUnOrdered.OrderBy(i => i.Key))
            {
                Console.WriteLine(item);
            }
        }
    }

    enum Numbers
    {
        One,
        Two,
        Three,
        Four,
        Five,

    }
}
