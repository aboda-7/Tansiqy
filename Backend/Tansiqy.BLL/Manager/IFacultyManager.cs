using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.FacultyDtos;
using Tansiqy.DAL.Models;

namespace Tansiqy.BLL.Manager
{
    public interface IFacultyManager
    {
        IEnumerable<FacultyReadDtos> GetAll();
        FacultyReadDtos GetById(int id);
        void Add(FacultyAddDtos faculty);
        void Update(int id, FacultyUpdateDtos faculty);
        void Delete(int id);
    }
}
