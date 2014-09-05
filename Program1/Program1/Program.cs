//Name: Program 1
//Author: Tyler Jackson
//Date: 9/4/2014
//Description: This is just a basic program to work on reading and writing from/to the console

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start by printing the quote and prompting the user for a movie guess
            Console.WriteLine("Welcome Human! Please provide the source of the below quote:");
            Console.WriteLine("His name is Robert Paulson...His name is Robert Paulson...");

            //create a loop for the input so that they will be prompted over and over till they guess correct
            bool wrongGuess = true;
            while (wrongGuess)
            {
                //store the movie guess and convert it to lower case to remove case sensitiivity
                String movieGuess = Console.ReadLine();
                if(movieGuess.ToLower() != "fight club")
                {
                    Console.WriteLine("Wrong answer, Try again.");
                }else
                {

                    wrongGuess = false;
                }
                
            }
            Console.WriteLine("You are right. Congratulations");
            Console.ReadLine();
        }
    }
}
