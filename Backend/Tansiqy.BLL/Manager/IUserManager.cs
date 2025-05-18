using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.UserDtos;
using Tansiqy.DAL.Models;

namespace Tansiqy.BLL.Manager
{
    public interface IUserManager
    {
        IEnumerable<UserReadDtos> GetAll();
        UserReadDtos GetById(int id);
        void Add(UserAddDtos user);
        void Update(int id, UserUpdateDtos user);
        void Delete(int id);
    }
}
