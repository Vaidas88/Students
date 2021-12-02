using Students.Models;

namespace Students
{
    public class StudentConsole
    {
        public List<Student> students = new List<Student>();

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
            Student student = new Student();
            
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

        public void CommandNotFound()
        {
            Console.WriteLine("Command was not recognized. Please try again.");
        }
    }
}
