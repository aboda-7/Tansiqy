using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.UniversityDtos;
using Tansiqy.DAL.Models;
using Tansiqy.DAL.Repository;

namespace Tansiqy.BLL.Manager
{
    public class UniversityManager : IUniversityManager
    {
        private readonly IUniversityRepository _universityRepository;
        public UniversityManager(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }
        public void Add(UniversityAddDtos university)
        {
            var universityModel = new University
            {
                Name = university.Name,
                Description = university.Description,
                Type = university.Type,
                City = university.City,
                Link = university.Link,
                Rank = university.Ranking,
            };
            _universityRepository.Add(universityModel);
        }

        public void Delete(int id)
        {
            var universityModel = _universityRepository.GetById(id);
            _universityRepository.Delete(universityModel);
        }

        public IEnumerable<UniversityReadDtos> GetAll()
        {
            var universityModel = _universityRepository.GetAll();
            var universityDtos = universityModel.Select(a => new UniversityReadDtos
            {
                ID = a.ID,
                Name = a.Name,
                Description = a.Description,
                Type = a.Type,
                City = a.City,
                Link = a.Link,
                Ranking = a.Rank,
            });
            return universityDtos;
        }

        public UniversityReadDtos GetById(int id)
        {
            var universityModel = _universityRepository.GetById(id);

            if (universityModel == null)
            {
                throw new InvalidOperationException("University Not Found");
            }

            var universityDtos = new UniversityReadDtos
            {
                ID = universityModel.ID,
                Name = universityModel.Name,
                Description = universityModel.Description,
                Type = universityModel.Type,
                City = universityModel.City,
                Link = universityModel.Link,
                Ranking = universityModel.Rank,
            };
            return universityDtos;
        }

        public void Update(UniversityUpdateDtos university)
        {
            var universityModel = _universityRepository.GetById(university.UniID);

            universityModel.City = university.City;
            universityModel.Name = university.Name;
            universityModel.Description = university.Description;
            universityModel.Link = university.Link;
            universityModel.Rank = university.Ranking;
            universityModel.Type = university.Type;

            _universityRepository.Update(universityModel);
        }
    }
}
