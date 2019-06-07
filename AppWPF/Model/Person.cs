using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWPF.Model
{
    public class Person
    {
        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime Enrollment { get; set; }

        public virtual OfficeAssignment OfficeAssignment { get; set; }
     
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }


    }
}
