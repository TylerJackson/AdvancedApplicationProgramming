/* Name:        Program 4 part3
 * Author:      Tyler Jackson
 * Date:        9/26/14
 * Description: This part of the hw assignment will read in a sentence from the user and group each word by its first letter
 *              (this part is case insensitive).  It will then count the number of words that fall under each letter and 
 *              print the results to the console.
 *              i.e.
 *                  t: 2
 *                  b: 1
 *                  a: 3
 *                  c: 4
 *                  f: 1
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program4Part3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please provide a sentence: ");
            string sentence = Console.ReadLine();

            //parse input sentence into different words and store in a string array
            string[] words = sentence.Split(' ');

            //convert all the words to lower case to create case insensitivity
            for(int i=0;i<words.Count();i++)
            {
                words[i] = words[i].ToLower();
            }

            //use LINQ groupby to groupby the first letter of each word, and then store the results in a dictionary
            //the dictionary will have the first letter as the key, and the number of words under that category as the value
            Dictionary<char, int> groupedWords = words.GroupBy(w => w[0]).ToDictionary(g => g.Key, g => g.ToList().Count);
            
            //loop through the dictionary and print the desired statistics to the screen
            foreach (KeyValuePair<char,int>entry in groupedWords)
            {
                Console.WriteLine("{0}: {1}",entry.Key,entry.Value);
            }
            Console.ReadLine();
        }
    }
}
