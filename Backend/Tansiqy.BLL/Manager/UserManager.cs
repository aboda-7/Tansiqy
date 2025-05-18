using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.DegreeDtos;
using Tansiqy.BLL.Dtos.UserDtos;
using Tansiqy.DAL.Models;
using Tansiqy.DAL.Repository;

namespace Tansiqy.BLL.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Add(UserAddDtos user)
        {
            var existingUser = _userRepository.GetAll()
                          .FirstOrDefault(u => u.Email == user.Email);

            if (existingUser != null)
            {
                throw new InvalidOperationException("User with id or email already exists");
            }

            var userModel = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                DegID = user.DegreeId,
            };
            _userRepository.Add(userModel);
        }

        public void Delete(int id)
        {
            var userModel = _userRepository.GetById(id);
            _userRepository.Delete(userModel);
        }

        public IEnumerable<UserReadDtos> GetAll()
        {
            var userModel = _userRepository.GetAll();
            var userDtos = userModel.Select(u => new UserReadDtos
            {
                ID = u.ID,
                Name = u.Name,
                Email = u.Email,
                Password = u.Password,
                Role = u.Role,
                DegreeId = u.DegID
            }).ToList();

            return userDtos;
        }

        public UserReadDtos GetById(int id)
        {
            var userModel = _userRepository.GetById(id);

            if (userModel == null)
            {
                throw new InvalidOperationException("User Not Found");
            }

            var userDtos = new UserReadDtos
            {
                ID = userModel.ID,
                Name = userModel.Name,
                Email = userModel.Email,
                Password = userModel.Password,
                Role = userModel.Role,
                DegreeId = userModel.DegID
            };

            return userDtos;
        }

        public void Update(int id, UserUpdateDtos user)
        {
            var userModel = _userRepository.GetById(id);

            userModel.Name = user.Name;
            userModel.Email = user.Email;
            userModel.Password = user.Password;
            userModel.Role = user.Role;
            userModel.DegID = user.DegreeId;

            _userRepository.Update(userModel);
        }
    }
}
