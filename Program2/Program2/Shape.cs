using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    //abstract class because we will never want a generic shape to be declared
    public abstract class Shape
    {
        //all of these will need to be overriden in a derived class which is what we want since 
        //each shape will have its own unique implementation
        public abstract void CalculatePerimeterCircumference();
        public abstract void CalculateArea();
        public abstract void AskForDimensions();
        public abstract void DisplayResults();
    }
}
