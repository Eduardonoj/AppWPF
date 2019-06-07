using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWPF.Model
{
    public class OnlineCourse
    {
        public int CourseID { get; set; }
        public string URL { get; set; }
        public virtual Course Course { get; set; }
    }
}
