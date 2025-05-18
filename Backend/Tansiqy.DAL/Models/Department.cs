using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tansiqy.DAL.Models;

public class Department
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int FID { get; set; }
    public Faculty Faculty { get; set; }

    public ICollection<UniversityDepartment> UniversityDepartments { get; set; }
    public ICollection<DegreeDepartment> DegreeDepartments { get; set; }
}