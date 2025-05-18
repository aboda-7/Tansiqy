using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tansiqy.BLL.Dtos.Department
{
    public class DepartmentReadDtos
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FacultyID { get; set; }
    }
}
