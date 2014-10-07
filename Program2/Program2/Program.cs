//Name: Program 2
//Author: Tyler Jackson
//Date: 9/4/2014
//Description: This program prompts the user for a type of shape, and then based on the 
//            chosen shape a certain type of shape is instantiated.  Then using the derived 
//            class's functions, the correct formula for area and perimeter/circumference is used.
//            The results are then displayed to the screen

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
            //create loop to prevent the user from having to restart the program
            bool terminate = false;
            while (!terminate)
            {
                //prompt the user for a type of shape
                Console.WriteLine("Please choose a shape (1 for Circle, 2 for Rectangle, or 0 to Exit.");
                bool invalidShapeNumber = true;
                int shapeNumber = -1;
                
                //loop to make sure a valid shape or exit code was input
                while (invalidShapeNumber)
                {
                    shapeNumber = Convert.ToInt16(Console.ReadLine());
                    if (shapeNumber != 1 && shapeNumber != 2 && shapeNumber != 0)
                    {
                        Console.WriteLine("That was an invalid shape option.  Please input either 1 for Circle or 2 for Rectangle or 0 to Exit.");
                    }
                    else
                    {
                        invalidShapeNumber = false;
                    }
                }
                //check that the exit code wasn't input
                if (shapeNumber != 0)
                {
                    //declare our shape and based on the input instantiate it using the correct derviced class
                    Shape ourShape;
                    if (shapeNumber == 1)
                    {
                        ourShape = new Circle();
                    }
                    else
                    {
                        ourShape = new Rectangle();
                    }
                    ourShape.AskForDimensions();
                    ourShape.DisplayResults();
                    Console.WriteLine("\n\n");
                }
                else
                {
                    terminate = true;
                }
            }
        }
    }
}