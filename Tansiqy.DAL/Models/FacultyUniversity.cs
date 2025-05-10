using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tansiqy.DAL.Models
{
    public class FacultyUniversity
    {
        public int FID { get; set; }
        public Faculty Faculty { get; set; }

        public int UniID { get; set; }
        public University University { get; set; }
    }
}
