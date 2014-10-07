/* Name:        Program 4 part2
 * Author:      Tyler Jackson
 * Date:        9/24/14
 * Description: This part of the hw assignment will read in a number from the user and calculate its factorial using the 
 *              LINQ aggregate function.
 * 
 * Notes:       For factorial to work you need a positive whole number.  I used an enumerable and range to put the input
 *              number into the correct form for LINQ aggregate.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program4Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please input an integer and I will calculate it's factorial: ");
                var inputNumber = Convert.ToInt16(Console.ReadLine());
                var numbersForFactorial = Enumerable.Range(1,inputNumber);

                var numberAfterFactorial = numbersForFactorial.Aggregate((seed, num) => seed * num);
                Console.WriteLine("The number after the factorial is: {0}", numberAfterFactorial);
            }
            catch (Exception e)
            {
                Console.WriteLine("You must have not put a postive whole number..");
            }
            Console.ReadLine();

        }
    }
}
