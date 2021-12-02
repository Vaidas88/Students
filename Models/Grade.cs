using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    public class Grade
    {
        public List<int>? Math { get; set; }
        public List<int>? Biology { get; set; }

        public List<int> GetClassGrades(string className)
        {
            List<int> grades = (List<int>)this.GetType().GetProperty(className).GetValue(this, null);
            
            return grades;
        }

        public double GetClassAverageGrades(string className)
        {
            List<int> grades = (List<int>)this.GetType().GetProperty(className).GetValue(this, null);

            return grades.Average();
        }
    }
}
