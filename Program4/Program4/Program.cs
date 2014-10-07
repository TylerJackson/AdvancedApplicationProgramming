/* Name:        Program 4 part1
 * Author:      Tyler Jackson
 * Date:        9/24/14
 * Description: This part of the hw assignment will read in a string from the user with any combination of upper case and
 *              lower case letters and convert the first character of each word to upper case if it is not already.
 *              This will be done using an extension of the string class
 * 
 * Notes:       It didn't specify to convert upper case characters that aren't the first letter in a word to lower case so I 
 *              did not do that.  Also, this program assumes that the user inputs a grammatically correct sentence.
 *                  i.e. It starts with a letter, and only has one space between each word, and ends with something like a
 *                      period or a question mark.
 *              
 *              The extension method for the string class is in a namespace I put at the bottom of this file.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;


namespace Program4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please provide a string with any combination of upper case or lower case letters: ");
            string ourString = Console.ReadLine();
            ourString = ourString.ConvertFirstLettersToUpperCase();

            Console.WriteLine("Our converted string: {0}", ourString);
            Console.ReadLine();
        }

    }

}

namespace Extensions
{
    public static class Extensions
    {
        public static string ConvertFirstLettersToUpperCase(this string str)
        {
            var charArray = str.ToCharArray();

            charArray[0] = charArray[0].ToString().ToUpper()[0];
            for (int i = 1; i < charArray.Length -1; i++)
            {
                if (charArray[i - 1] == ' ')
                {

                    charArray[i] = charArray[i].ToString().ToUpper()[0];
                }

            }
            return new string(charArray);
        }
    }
}