using Students.Models;

namespace Students
{
    public class StudentConsole
    {
        public List<Student> students = new List<Student>();

        public void GenerateFakeStudents()
        {
            students.Add(new Student() { Name = "Jonas", Surname = "Jonauskas" });
            students.Add(new Student() { Name = "Petras", Surname = "Petrauskas" });
            students.Add(new Student() { Name = "Tadas", Surname = "Tadauskas" });
            students.Add(new Student() { Name = "Romas", Surname = "Romauskas" });
            students.Add(new Student() { Name = "Adomas", Surname = "Adomauskas" });
        }

        public void ExecAdd()
        {
            Console.WriteLine("Please enter student's First Name:");
            string firstName = Console.ReadLine() ?? "";

            Console.WriteLine("Please enter student's Sure Name:");
            string sureName = Console.ReadLine() ?? "";

            Student student = new Student();
            student.Name = firstName;
            student.Surname = sureName;

            students.Add(student);
        }

        public void ExecList()
        {
            students.ForEach(student => Console.WriteLine($"{student.GetStudentInfo()}."));
        }

        public void ExecPick(string command)
        {
            int id = 0;
            Student student = null;

            try
            {
                id = Convert.ToInt32(command.Split(" ").Last());
                student = students.Single(student => student.Id == id);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Student with supplied id was not found.");
            }
            catch (Exception)
            {
                Console.WriteLine("Something wrong, try again.");
            }

            Console.WriteLine("Info about student: \n");

            Console.WriteLine(student.GetStudentInfo());

            student.GetGradesToString().ForEach(entry => Console.WriteLine(entry));
        }

        public void ExecBestInTopic(string command)
        {
            string topic = command.Substring(command.IndexOf(' ') + 1);
            Console.WriteLine(GetBestStudent(students, topic));
        }
        public void ExecBestInClass(string command)
        {
            string[] commands = command.Split(" ");
            string topic = commands[1];
            int classNumber = Convert.ToInt32(commands.Last());
            Console.WriteLine(GetBestStudent(students, topic, classNumber));
        }

        public void ExecBest()
        {
            Console.WriteLine(GetBestStudent(students));
        }

        public void CommandNotFound()
        {
            Console.WriteLine("Command was not recognized. Please try again.");
        }

        public string GetBestStudent(List<Student> studentList, string topic = "", int classNumber = 0)
        {
            if (classNumber > 0)
            {
                List<Student> filteredStudentList = studentList.FindAll(student => student.ClassNumber == classNumber);
                studentList = filteredStudentList;
            }

            Student bestStudent = null;
            Student prevStudent = null;
            double bestAverage = 0;

            studentList.ForEach(student =>
            {
                double averageGrades = 0;
                double prevAverageGrades = 0;

                if (bestStudent == null)
                {
                    bestStudent = student;
                    prevStudent = student;
                }

                if (topic == "")
                {
                    averageGrades = student.GetTotalAverage();
                    prevAverageGrades = prevStudent.GetTotalAverage();
                }
                else
                {
                    averageGrades = student.Grades.GetTopicAverageGrades(topic);
                    prevAverageGrades = prevStudent.Grades.GetTopicAverageGrades(topic);
                }

                if (averageGrades >= prevAverageGrades)
                {
                    bestStudent = student;
                    bestAverage = averageGrades;
                }
                prevStudent = student;
            });

            if (classNumber > 0)
            {
                return $"Best student in {topic} from class {classNumber}: {bestStudent.Name} {bestStudent.Surname} with an average of {bestAverage}";
            }
            if (topic == "")
            {
                return $"Best student in all classes: {bestStudent.Name} {bestStudent.Surname} with a total average of {bestAverage}";
            }
            return $"Best student in {topic}: {bestStudent.Name} {bestStudent.Surname} with an average of {bestAverage}";
        }
    }
}
