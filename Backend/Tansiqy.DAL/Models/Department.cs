using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tansiqy.DAL.Models
{
    //[Table("Department")]
    public class Department
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int faculty_Id { get; set; }

        [ForeignKey("faculty_Id")]
        public Faculty Faculty { get; set; }

        public ICollection<UniversityDepartment> UniversityDepartments { get; set; }
        public ICollection<DegreeDepartment> DegreeDepartments { get; set; }
    }
}
