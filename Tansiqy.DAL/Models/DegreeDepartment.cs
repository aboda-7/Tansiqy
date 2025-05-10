using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tansiqy.DAL.Models
{
    public class DegreeDepartment
    {
        public int DegID { get; set; }
        public Degree Degree { get; set; }

        public int DepID { get; set; }
        public Department Department { get; set; }
    }
}
