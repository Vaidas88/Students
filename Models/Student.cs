using System.Reflection;

namespace Students.Models
{
    public class Student
    {
        private static int IdCounter = 0;
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public int ClassNumber { get; set; } = 1;
        public Grade Grades { get; set; } = new Grade();

        public Student()
        {
            IdCounter++;
            Id = IdCounter;
            Grades.Math = GenerateGrades();
            Grades.Biology = GenerateGrades();
            ClassNumber = GenerateClassNumber();
        }

        public string GetStudentInfo()
        {
            return $"{Id}. {Name} {Surname} from class {ClassNumber}";
        }

        private int GenerateClassNumber()
        {
            Random random = new Random();
            return random.Next(1, 5);
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

            if (gradesProps.Length > 0)
            {
                List<string> topics = GetTopics(gradesProps);
                topics.ForEach(topic =>
                {
                    List<int> grades = Grades.GetClassGrades(topic);
                    if (grades.Count > 0)
                    {
                        gradesListString.Add($"Grades for {topic}: {string.Join(", ", Grades.GetTopicGrades(topic))}");
                        gradesListString.Add($"Average grades for {topic}: {Grades.GetTopicAverageGrades(topic)}");
                    }

                });
            }

            return gradesListString;
        }

        public double GetTotalAverage()
        {
            PropertyInfo[] gradesProps = Grades.GetType().GetProperties();
            double totalAverage = 0;
            double divider = 1;

            if (gradesProps.Length > 0)
            {
                List<string> topics = GetTopics(gradesProps);
                topics.ForEach(topic =>
                {
                    List<int> grades = Grades.GetClassGrades(topic);
                    if (grades.Count > 0)
                    {
                        totalAverage += Grades.GetClassAverageGrades(topic);
                        totalAverage = totalAverage / divider;
                        divider++;
                    }

                });
            }

            return totalAverage;
        }

        private List<string> GetTopics(PropertyInfo[] gradesProps)
        {
            List<string> topics = new List<string>();

            foreach (var gradesClassProp in gradesProps)
            {
                topics.Add(gradesClassProp.Name);
            }

            return topics;
        }
    }
}
