using System.Reflection;

namespace Students.Models
{
    public class Grade
    {
        public List<int>? Math { get; set; }
        public List<int>? Biology { get; set; }

        public List<int> GetClassGrades(string className)
        {
            Type gradeType = this.GetType();
            PropertyInfo? gradeProp = gradeType.GetProperty(className);
            object? grades = gradeType.GetProperty(className)?.GetValue(this, null);

            if(grades is not null)
            {
                return (List<int>)grades;
            }

            return new List<int>();
        }

        public double GetClassAverageGrades(string className)
        {
            Type gradeType = this.GetType();
            PropertyInfo? gradeProp = gradeType.GetProperty(className);
            object? grades = gradeType.GetProperty(className)?.GetValue(this, null);
            
            if(grades is not null)
            {
                List<int> newGrades = (List<int>)grades;

                return newGrades.Average();
            }

            return 0;
        }
    }
}
