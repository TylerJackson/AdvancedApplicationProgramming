using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;
        private double area;
        private double perimeter;

        public override void CalculatePerimeterCircumference()
        {
            this.perimeter = this.height * 2 + this.width * 2;
        }

        public override void CalculateArea()
        {
            this.area = this.width * this.height;
        }

        public override void AskForDimensions()
        {
            Console.WriteLine("Thank you for choosing Rectangle.  Please provide the rectangle's height:");
            String tempHeight = Console.ReadLine();
            this.height = Convert.ToDouble(tempHeight);
            Console.WriteLine("\nPlease provide the rectangle's width:");
            String tempWidth = Console.ReadLine();
            this.width = Convert.ToDouble(tempWidth);

            CalculateArea();
            CalculatePerimeterCircumference();
        }

        public override void DisplayResults()
        {
            Console.WriteLine("The area of the rectangle is: {0}.\nThe perimeter of the rectangle is: {1}.", this.area, this.perimeter);
        }
    }
}
