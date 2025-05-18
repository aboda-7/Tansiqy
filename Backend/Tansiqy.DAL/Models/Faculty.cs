using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tansiqy.DAL.Models;

public class Faculty
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Department> Departments { get; set; }
    public ICollection<FacultyUniversity> FacultyUniversities { get; set; }
    public ICollection<FacultyDegree> FacultyDegrees { get; set; }
}