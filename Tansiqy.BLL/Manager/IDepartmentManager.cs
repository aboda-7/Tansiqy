using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.Department;
using Tansiqy.DAL.Models;

namespace Tansiqy.BLL.Manager
{
    public interface IDepartmentManager
    {
        IEnumerable<DepartmentReadDtos> GetAll();
        DepartmentReadDtos GetById(int id);
        void Add(DepartmentAddDtos department);
        void Update(DepartmentUpdateDtos department);
        void Delete(int id);
    }
}
