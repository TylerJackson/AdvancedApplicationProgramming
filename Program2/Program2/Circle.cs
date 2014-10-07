using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    public class Circle : Shape
    {
        private double radius;
        private double area;
        private double circumference;

        public override void CalculatePerimeterCircumference()
        {
            this.circumference = System.Math.PI * radius * 2;
        }

        public override void CalculateArea()
        {
            this.area = System.Math.PI * radius * radius;
        }

        public override void AskForDimensions()
        {
            Console.WriteLine("Thank you for choosing Circle.  Please provide the circle's radius:");
            String tempRadius = Console.ReadLine();
            this.radius = Convert.ToDouble(tempRadius);
            CalculateArea();
            CalculatePerimeterCircumference();
        }

        public override void DisplayResults()
        {
            Console.WriteLine("The area of the circle is: {0}.\nThe circumference of the circle is: {1}.", this.area, this.circumference);

        }

    }
}
