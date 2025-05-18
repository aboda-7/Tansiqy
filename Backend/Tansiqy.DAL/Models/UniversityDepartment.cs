using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tansiqy.DAL.Models
{
    public class UniversityDepartment
    {
        public int UniID { get; set; }
        public University University { get; set; }

        public int DepID { get; set; }
        public Department Department { get; set; }
    }
}
