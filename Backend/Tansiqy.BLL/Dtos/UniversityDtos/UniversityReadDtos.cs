﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tansiqy.BLL.Dtos.UniversityDtos
{
    public class UniversityReadDtos
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Link { get; set; }
        public int Ranking { get; set; }
    }
}
