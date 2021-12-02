using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Students.Models
{
    public class Student
    {
        private static int IdCounter = 0;
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public Grade Grades = new Grade();

        public Student()
        {
            IdCounter++;
            Id = IdCounter;
            Grades.Math = GenerateGrades();
            Grades.Biology = GenerateGrades();
        }

        public string GetStudentInfo()
        {
            return $"{Id}. {Name} {Surname}.";
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

        public List<string> GetGradesToString()
        {
            List<string> gradesListString = new List<string>();
            PropertyInfo[] gradesProps = Grades.GetType().GetProperties();

            if(gradesProps.Length > 0)
            {
                List<string> classNames = GetClassNames(gradesProps);
                classNames.ForEach(className => {
                    gradesListString.Add($"Grades for {className}: {string.Join(", ", Grades.GetClassGrades(className))}");
                    gradesListString.Add($"Average grades for {className}: {Grades.GetClassAverageGrades(className)}");
                });
            }

            return gradesListString;
        }

        private List<string> GetClassNames(PropertyInfo[] gradesProps){
            List<string> classNames = new List<string>();

            foreach(var gradesClassProp in gradesProps)
            {
                classNames.Add(gradesClassProp.Name);
            }

            return classNames;
        }
    }
}
