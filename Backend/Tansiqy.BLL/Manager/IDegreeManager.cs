using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.DegreeDtos;
using Tansiqy.DAL.Models;

namespace Tansiqy.BLL.Manager
{
    public interface IDegreeManager
    {
        IEnumerable<DegreeReadDtos> GetAll();
        DegreeReadDtos GetById(int id);
        void Add(DegreeAddDtos degree);
        void Update(int id, DegreeUpdateDtos degree);
        void Delete(int id);
    }
}