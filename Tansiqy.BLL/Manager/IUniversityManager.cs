using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.UniversityDtos;
using Tansiqy.DAL.Models;

namespace Tansiqy.BLL.Manager
{
    public interface IUniversityManager
    {
        IEnumerable<UniversityReadDtos> GetAll();
        UniversityReadDtos GetById(int id);
        void Add(UniversityAddDtos university);
        void Update(UniversityUpdateDtos university);
        void Delete(int id);
    }
}