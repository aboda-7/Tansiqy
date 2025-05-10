using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.FacultyDtos;
using Tansiqy.DAL.Models;
using Tansiqy.DAL.Repository;

namespace Tansiqy.BLL.Manager
{
    public class FacultyManager : IFacultyManager
    {
        private readonly IFacultyRepository _facultyRepository;
        public FacultyManager(IFacultyRepository facultyRepository) 
        {
            _facultyRepository = facultyRepository;
        }
        public void Add(FacultyAddDtos faculty)
        {
            var facultyModel = new Faculty
            {
                Name = faculty.Name,
                Description = faculty.Description,
            };
            _facultyRepository.Add(facultyModel);
        }

        public void Delete(int id)
        {
            var facultyModel = _facultyRepository.GetById(id);
            _facultyRepository.Delete(facultyModel);
        }

        public IEnumerable<FacultyReadDtos> GetAll()
        {
            var facultyModel = _facultyRepository.GetAll();
            var facultyDtos = facultyModel.Select(a => new FacultyReadDtos
            {
                Name = a.Name,
                Description = a.Description,
            }).ToList();

            return facultyDtos;
        }

        public FacultyReadDtos GetById(int id)
        {
            var facultyModel = _facultyRepository.GetById(id);

            if (facultyModel == null)
            {
                throw new InvalidOperationException("Faculty Not Found");
            }

            var facultyDtos = new FacultyReadDtos
            {
                Name = facultyModel.Name,
                Description = facultyModel.Description,
            };
            return facultyDtos;
        }

        public void Update(FacultyUpdateDtos faculty)
        {
            var facultyModel = _facultyRepository.GetById(faculty.FID);

            facultyModel.Name = faculty.Name;
            facultyModel.Description = faculty.Description;

            _facultyRepository.Update(facultyModel);
        }
    }
}
