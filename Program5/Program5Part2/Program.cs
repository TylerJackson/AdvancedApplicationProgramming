/* Name: Program 5 part 2
 * Author: Tyler Jackson
 * Date: 10/5/14
 * Description: This is problem 2 in program 5.  It contains a custom attributes class called BugFixed,
 *              and then an Example class that implements this new attribute.  Finally, in our Main function
 *              we use reflection to get some of the metadata regarding the methods and attributes we created in 
 *              our Example class.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Program5Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo[] mif = typeof(Example).GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            foreach (MethodInfo method in mif)
            {
                var attributes = method.GetCustomAttributes(typeof(BugFixed), false);
                if(attributes.Count() > 0)
                {
                    Console.WriteLine(method.Name);
                }
                foreach (var attr in attributes)
                {
                    Console.WriteLine(attr.ToString());
                }
                //Console.WriteLine(method.Name);
            }
            Console.ReadLine();
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method,AllowMultiple = true)]
    class BugFixed:Attribute
    {
        public int ReportNumber { get; set; }
        public string Description { get; set; }

        public BugFixed(int num, string desc)
        {
            this.ReportNumber = num;
            this.Description = desc;
        }
        public BugFixed(string desc)
        {
            this.ReportNumber = -1;
            this.Description = desc;
        }
        public override string ToString()
        {
            if(ReportNumber > 0)
            {
                return "   Report Number: " + this.ReportNumber + " Description: " + this.Description;
            }else
            {
                return "   Description: " + this.Description;
            }
        }

    }

    class Example
    {
        [BugFixed(4, "Performance: Uses SortedDictionary")]
        [BugFixed(3, "Throws IndexOfOutRangeException on empty array")]
        [BugFixed("Performance: Uses repeated string concatenation in for-loop")]
        [BugFixed(2, "Loops forever on one-element array")]
        [BugFixed(1, "Spelling mistakes in output")]
        public static String PrintMedian(int[] xs)
        {
            /* ... */
            return "";
        }
        
        [BugFixed(67, "Rounding error in quantum mechanical simulation")]
        public double CalculateAgeOfUniverse()
        {
            /* ... */
            return 11.2E9;
        }
    }
}
