/* Name: Program3 part 2
 * Author: Tyler Jackson
 * Description: This is the second part of homework 3.  I was supposed to read an integer in from
 *              the user and then take the square root of it and print it back to the screen.
 *              
 *              The things I need to account for are errors in the type of input the user provides.  If the input
 *              is not an integer or is negative number I am supposed to account for all exceptions, print invalid number, and
 *              in all cases print goodbye to the screen.
 *              
 *              The easiest ways to account for all errors was to use a generic Exception in my catch statement.
 * Date: 9/18/2014
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please input a number that you want the square root of: ");
                int input = Convert.ToInt16(Console.ReadLine());
                //if the input is a negative number then throw an exception
                if(input < 0)
                {
                    throw new ArgumentException("Invalid Number");
                }
                else
                {
                    //print the square root of the number to the console.
                    Console.WriteLine("The square root of {0} is: {1}", input, Math.Sqrt(input));
                }
            }catch(Exception ex)
            {
                //if there is an exception print invalid number to the screen
                Console.WriteLine("Invalid Number");
            }
            finally
            {
                //in all cases print goodbye to the console
                Console.WriteLine("GoodBye");
                Console.ReadLine();
            }
        }
    }
}
