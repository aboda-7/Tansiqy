using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.DAL.Models;

namespace Tansiqy.DAL.Repository
{
    public interface IFacultyRepository
    {
        IQueryable<Faculty> GetAll();
        Faculty GetById(int id);
        void Add(Faculty faculty);
        void Update(Faculty faculty);
        void Delete(Faculty faculty);

    }
}
