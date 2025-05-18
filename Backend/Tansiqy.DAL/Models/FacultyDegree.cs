using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tansiqy.DAL.Models
{
    public class FacultyDegree
    {
        public int FID { get; set; }
        public Faculty Faculty { get; set; }

        public int DegID { get; set; }
        public Degree Degree { get; set; }
    }
}
