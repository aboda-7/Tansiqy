using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.DAL.Models;

namespace Tansiqy.DAL.Repository
{
    public interface IDepartmentRepository
    {
        IQueryable<Department> GetAll();
        Department GetById(int id);
        void Add(Department department);
        void Update(Department department);
        void Delete(Department department);
    }
}
