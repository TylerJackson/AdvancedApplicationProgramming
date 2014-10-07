//This is the file with errors.  I excluded it from the file project, because I didn't think it would 
//build correctly with 2 Main declarations.

using System;
using System.Collections.Generic;

namespace Assgn2
{
    class Program
    {
        static void Main(string[] args)
        {

            var gradeBook = new GradeBook();
            gradeBook.AddGrade(80);
            gradeBook.AddGrade(75);
            gradeBook.AddGrade(70);
            gradeBook.AddGrade(70);
            var isPassing = gradeBook.IsStudentPassing();
            //Should be passing with average 75 but seems to be wrong
            Console.WriteLine("Passing: {0}", isPassing);


            var gradeBook2 = new GradeBook();
            gradeBook2.AddGrade(80);
            isPassing = gradeBook2.IsStudentPassing();
            //Should be passing with average 80 but seems to be wrong
            Console.WriteLine("Passing: {0}", isPassing);

            Console.ReadLine();
        }
    }

    class GradeBook
    {
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public bool IsStudentPassing()
        {
            var averageGrade = CalculateAverageGrade();
            if (averageGrade > PassingGrade)
                return true;
            else
                return false;

        }

        /// <summary>
        /// This should calculate the average grade after dropping the lowest grade (Lowest grade is dropped when multiple grades are present)
        /// </summary>
        /// <returns></returns>
        private double CalculateAverageGrade()
        {
            if(grades.Count >1)
            {
                var lowestGrade = grades[0];
                foreach (var grade in grades)
                {
                    if (grade < lowestGrade)
                        lowestGrade = grade;
                }

                double totalScore = 0;

                foreach (var grade in grades)
                {
                    totalScore += grade;
                }
                totalScore -= lowestGrade;
                var averageGrade = totalScore / (grades.Count - 1);
                Console.WriteLine("Average Grade is {0}", averageGrade);
                return averageGrade;
            }
            else
            {
                Console.WriteLine("Average Grade is {0}", grades[0]);
                return grades[0];
            }
        }

        private readonly List<double> grades = new List<double>();
        const int PassingGrade = 70;
    }
}
