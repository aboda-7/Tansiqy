using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tansiqy.DAL.Models
{
    //[Table("Faculty")]
    public class Faculty
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Department> Departments { get; set; }
        public ICollection<FacultyUniversity> FacultyUniversities { get; set; }
        public ICollection<FacultyDegree> FacultyDegrees { get; set; }
        public ICollection<FacultyFavourite> FacultyFavourites { get; set; }
    }
}
