using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tansiqy.DAL.Models
{
    //[Table("User")]
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public int? Degree_Id { get; set; }

        [ForeignKey("Degree_Id")]
        public Degree Degree { get; set; }
    }
}
