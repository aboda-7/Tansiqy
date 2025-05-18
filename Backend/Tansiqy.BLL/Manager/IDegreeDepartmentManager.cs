using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.DegreeDepartmentDtos;
using Tansiqy.DAL.Models;

namespace Tansiqy.BLL.Manager
{
    public interface IDegreeDepartmentManager
    {
        void Add(DegreeDepartmentAddDtos dto);
        IEnumerable<int> GetDepartmentsByDegreeId(int degreeId);
        IEnumerable<int> GetDegreesByDepartmentId(int departmentId);
        bool Update(int degreeId, int departmentId, DegreeDepartmentUpdateDtos updateDto);
        void Remove(int degreeId, int departmentId);
    }
}