using System.Reflection;

namespace Students.Models
{
    public class Grade
    {
        public List<int>? Math { get; set; }
        public List<int>? Biology { get; set; }
        public List<int>? Test { get; set; }

        public List<int> GetTopicGrades(string topic)
        {
            Type gradeType = this.GetType();
            object? grades = gradeType.GetProperty(topic)?.GetValue(this, null);

            if (grades is not null)
            {
                return (List<int>)grades;
            }

            return new List<int>();
        }

        public double GetTopicAverageGrades(string topic)
        {
            Type gradeType = this.GetType();
            object? grades = gradeType.GetProperty(topic)?.GetValue(this, null);

            if (grades is not null)
            {
                List<int> newGrades = (List<int>)grades;

                return newGrades.Average();
            }

            return 0;
        }
    }
}
