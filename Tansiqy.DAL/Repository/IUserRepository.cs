using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.DAL.Models;

namespace Tansiqy.DAL.Repository
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
