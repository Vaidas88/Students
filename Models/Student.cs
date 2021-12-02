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
                    gradesListString.Add($"Grades for {className}: {string.Join(", ", GetClassGrades(className))}");
                    gradesListString.Add($"Average grades for {className}: {GetClassAverageGrades(className)}");
                });
            }

            return gradesListString;
        }

        private List<string> GetClassNames(PropertyInfo[] gradesClassProps){
            List<string> classNames = new List<string>();

            foreach(var gradesClassProp in gradesClassProps)
            {
                classNames.Add(gradesClassProp.Name);
            }

            return classNames;
        }

        private List<int> GetClassGrades(string className)
        {
            List<int> grades = (List<int>)Grades.GetType()?.GetProperty(className)?.GetValue(Grades, null);

            return grades;
        }

        public double GetClassAverageGrades(string className)
        {
            List<int> grades = (List<int>)Grades.GetType()?.GetProperty(className)?.GetValue(Grades, null);

            return grades.Average();
        }
    }
}
