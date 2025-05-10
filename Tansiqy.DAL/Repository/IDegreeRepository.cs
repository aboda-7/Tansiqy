using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.DAL.Models;

namespace Tansiqy.DAL.Repository
{
    public interface IDegreeRepository
    {
        IQueryable<Degree> GetAll();
        Degree GetById(int id);
        void Add(Degree degree);
        void Update(Degree degree);
        void Delete(Degree degree);
    }
}
