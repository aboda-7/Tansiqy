using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tansiqy.DAL.Models
{
    //[Table("University")]
    public class University
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Link { get; set; }
        public int Rank { get; set; }

        public ICollection<FacultyUniversity> FacultyUniversities { get; set; }
        public ICollection<UniversityDepartment> UniversityDepartments { get; set; }
    }
}
