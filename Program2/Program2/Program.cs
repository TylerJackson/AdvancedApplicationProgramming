//Name: Program 2
//Author: Tyler Jackson
//Date: 9/4/2014
//Description: This program prompts the user for a shape and then dimensions and calculates the area based on the user input.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose a shape (1 for Circle, 2 for Rectangle).");
            bool invalidShapeNumber = true;
            int shapeNumber = 0;
            while (invalidShapeNumber)
            {
                shapeNumber = Convert.ToInt16(Console.ReadLine());
                if(shapeNumber != 1 && shapeNumber != 2)
                {
                    Console.WriteLine("That was an invalid shape option.  Please input either 1 for Circle or 2 for Rectangle.")
                }else
                {
                    invalidShapeNumber = false;
                }
            }

            if(shapeNumber == 1)
            {
                Console.WriteLine("You chose Circle!  Please enter the radius of the circle:");
                int radius = Convert.ToInt32(Console.ReadLine());

            }
            


        }
    }
}
