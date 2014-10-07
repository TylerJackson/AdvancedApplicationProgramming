/* Name: Program3 part 1
 * Author: Tyler Jackson
 * Description: This is the first part of homework 3.  I instantiated a list of GradeBook objects with varying grade values.
 *              I then created a separate GradeBook object whos grade I will use to compare against the list.  I then implemented
 *              a GreaterThanCount method that accepts an Ienumerable of type T as the first parameter and an object of type
 *              T as the second parameter.  In this function I count the number of elements in the IEnumerable that are greater
 *              than the second input parameter and then return that value.  I then call this function passing my list, and the
 *              separate gradebook object as the 2 arguments.  This is possible because I made my GradeBook class implement
 *              IComparable
 * 
 * 
 * Date: 9/18/2014
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            //collection initialization syntax to create my List of GradeBooks
            var gradeBookList = new List<GradeBook>()
            {
                new GradeBook("Joe",75),
                new GradeBook("Frank",80),
                new GradeBook("Jill",90),
                new GradeBook("Jane",100),
                new GradeBook("John",35)

            };
            //my separate gradebook object to compare against the list
            var gradeBook = new GradeBook("Tyson", 70);

            //call the GreaterThanCount method and return the result to the console.
            Console.WriteLine("The number greater than {0} in the collection is: {1}", gradeBook.Grade, GreaterThanCount(gradeBookList, gradeBook));
            Console.ReadLine();       
        }

        //this method returns how many objects in the collection are greater than x
        //I require that T implements IComparable and that way when I call compareTo in the implementation there won't be any
        //chance of errors
        static int GreaterThanCount<T>(IEnumerable<T> collection, T x) where T:IComparable
        {
            int numGreater = 0;
            foreach(T gradeBook in collection)
            {

                //gradebook is greater than x
                if(gradeBook.CompareTo(x) > 0)
                {
                    numGreater++;
                }
            }
            return numGreater;
        }
    }
}
