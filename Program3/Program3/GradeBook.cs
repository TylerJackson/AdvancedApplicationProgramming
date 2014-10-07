//Tyler Jackson

//This is the GradeBook class that implements IComparable on the Grade property
//I also created a constructor that takes the student's name and his/her grade as input



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class GradeBook:IComparable
    {
        public string Name { get; set; }
        public double Grade { get; set; }

        public GradeBook(string name,double grade)
        {
            this.Name = name;
            this.Grade = grade;
        }
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            GradeBook gradeBook = obj as GradeBook;
            if(gradeBook != null)
            {
                return this.Grade.CompareTo(gradeBook.Grade);
            }
            else
            {
                throw new ArgumentException("Object is not a temperature.");
            }
        }
    }
}
