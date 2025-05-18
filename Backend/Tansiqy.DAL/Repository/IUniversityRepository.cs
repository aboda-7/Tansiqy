using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.DAL.Models;

namespace Tansiqy.DAL.Repository
{
    public interface IUniversityRepository
    {
        IQueryable<University> GetAll();
        University GetById(int id);
        void Add(University university);
        void Update(University university);
        void Delete(University university);
    }
}
