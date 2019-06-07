using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWPF.Model
{
    public class OfficeAssignment
    {
        public int InstructorID { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual Person Person { get; set; }

    }
}
