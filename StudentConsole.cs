using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            students.ForEach(student => Console.WriteLine($"{student.Id}. {student.Name} {student.Surname}."));
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

            Console.WriteLine($"Name: {student.Name} {student.Surname}.");

            student.GetGradesToString().ForEach(entry => Console.WriteLine(entry));
        }
    }
}
