using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.DegreeDtos;
using Tansiqy.BLL.Dtos.Department;
using Tansiqy.DAL.Models;
using Tansiqy.DAL.Repository;

namespace Tansiqy.BLL.Manager
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public void Add(DepartmentAddDtos department)
        {

            var departmentModel = new Department
            {
                Name = department.Name,
                Description = department.Description,
                FID = department.FacultyID,
            };
            _departmentRepository.Add(departmentModel);
        }

        public void Delete(int id)
        {
            var departmentModel = _departmentRepository.GetById(id);
            _departmentRepository.Delete(departmentModel);
        }

        public IEnumerable<DepartmentReadDtos> GetAll()
        {
            var departmentModel = _departmentRepository.GetAll();
            var departmentDtos = departmentModel.Select(d => new DepartmentReadDtos
            {
                ID = d.ID,
                Description = d.Description,
                Name = d.Name,
                FacultyID = d.FID,
            }).ToList();

            return departmentDtos;
        }

        public DepartmentReadDtos GetById(int id)
        {
            var departmentModel = _departmentRepository.GetById(id);

            if (departmentModel == null)
            {
                throw new InvalidOperationException("Department Not Found");
            }

            var departmentDtos = new DepartmentReadDtos
            {
                ID = departmentModel.ID,
                Name = departmentModel.Name,
                Description = departmentModel.Description,
                FacultyID = departmentModel.FID,
            };
            return departmentDtos;
        }

        public void Update(int id, DepartmentUpdateDtos department)
        {
            var departmentModel = _departmentRepository.GetById(id);


            departmentModel.Name = department.Name;
            departmentModel.Description = department.Description;

            _departmentRepository.Update(departmentModel);
        }
    }
}
