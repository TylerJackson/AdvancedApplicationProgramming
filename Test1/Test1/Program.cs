using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tempSet = new Set<int>();
            tempSet.Add(5);
            tempSet.Add(8);
            tempSet.Add(7);
            foreach(int temp in tempSet)
            {
                Console.WriteLine(temp);
            }

            var tempSortedSet = new SortedSet<int>();
            tempSortedSet.Add(5);
            tempSortedSet.Add(8);
            tempSortedSet.Add(7);
            foreach (int temp in tempSortedSet)
            {
                Console.WriteLine(temp);
            }


            Console.ReadLine();


        }
    }
}
