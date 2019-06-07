using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWPF.Model
{
    public class OnsiteCourse
    {
        public int CourseID { get; set;}
        public string Location { get; set; }
        public string Days { get; set; }
        public DateTime Time { get; set; }
        public virtual Course Course { get; set; }
    }
}
