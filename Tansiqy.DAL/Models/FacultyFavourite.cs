using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tansiqy.DAL.Models
{
    public class FacultyFavourite
    {
        public int FID { get; set; }
        public Faculty Faculty { get; set; }

        public int FavID { get; set; }
        public Favourite Favourite { get; set; }
    }
}
