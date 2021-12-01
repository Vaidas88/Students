using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    public class Student
    {
        private static int IdCounter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Grade Grades = new Grade();

        public Student()
        {
            IdCounter++;
            Id = IdCounter;
            Grades.Math = GenerateGrades();
            Grades.Biology = GenerateGrades();
        }

        private List<int> GenerateGrades()
        {
            List<int> randomGrades = new List<int>();
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                randomGrades.Add(random.Next(1, 11));
            }

            return randomGrades;
        }

        public string GradesToString(string className)
        {
            if (className == "Math")
            {
                return string.Join(", ", this.Grades.Math);
            }
            if (className == "Biology")
            {
                return string.Join(", ", this.Grades.Biology);
            }

            return "";
        }

        public double AverageGrades(string className)
        {
            if (className == "Math")
            {
                return this.Grades.Math.Average();
            }
            if (className == "Biology")
            {
                return this.Grades.Biology.Average();
            }

            return 0;
        }
    }
}
