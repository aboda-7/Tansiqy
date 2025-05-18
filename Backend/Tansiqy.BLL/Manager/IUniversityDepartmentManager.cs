using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.UniversityDepartmentDtos;
using Tansiqy.DAL.Models;

namespace Tansiqy.BLL.Manager
{
    public interface IUniversityDepartmentManager
    {
        void Add(UniversityDepartmentAddDtos unidep);
        IEnumerable<int> GetDepartmentsByUniversityId(int universityId);
        IEnumerable<int> GetUniversitiesByDepartmentId(int departmentId);
        void Remove(int uniId, int depId);
        bool Update(int currentFID, int currentUniID, UniversityDepartmentUpdateDtos updateDto);
    }
}
