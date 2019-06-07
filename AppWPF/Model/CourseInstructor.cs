using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWPF.Model
{
    public class CourseInstructor
    {
        public int CourseID { get; set; }
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
        public virtual Course Course { get; set; }

    }
}
