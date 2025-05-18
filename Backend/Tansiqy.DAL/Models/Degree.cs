using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tansiqy.DAL.Models;

public class Degree
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    public ICollection<FacultyDegree> FacultyDegrees { get; set; }
    public ICollection<DegreeDepartment> DegreeDepartments { get; set; }
    public ICollection<User> Users { get; set; }
}