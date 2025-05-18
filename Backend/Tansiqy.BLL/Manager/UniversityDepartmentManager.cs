using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.UniversityDepartmentDtos;
using Tansiqy.DAL.Database;
using Tansiqy.DAL.Models;

namespace Tansiqy.BLL.Manager
{
    public class UniversityDepartmentManager : IUniversityDepartmentManager
    {
        private readonly TansiqyContext _context;

        public UniversityDepartmentManager(TansiqyContext context)
        {
            _context = context;
        }

        public void Add(UniversityDepartmentAddDtos dto)
        {
            var entity = new UniversityDepartment
            {
                UniID = dto.UniID,
                DepID = dto.DepID
            };
            _context.UniversityDepartments.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<int> GetDepartmentsByUniversityId(int universityId)
        {
            return _context.UniversityDepartments
                          .Where(fu => fu.UniID == universityId)
                          .Select(fu => fu.DepID)
                          .ToList();
        }

        public IEnumerable<int> GetUniversitiesByDepartmentId(int departmentId)
        {
            return _context.UniversityDepartments
                          .Where(fu => fu.DepID == departmentId)
                          .Select(fu => fu.UniID)
                          .ToList();
        }

        public void Remove(int fid, int uniId)
        {
            var entity = _context.FacultyUniversities.Find(fid, uniId);
            if (entity != null)
            {
                _context.FacultyUniversities.Remove(entity);
                _context.SaveChanges();
            }
        }

        public bool Update(int currentUniID, int currentDepID, UniversityDepartmentUpdateDtos updateDto)
        {
            var existingRelation = _context.UniversityDepartments
                .FirstOrDefault(fu => fu.UniID == currentUniID && fu.DepID == currentDepID);

            if (existingRelation == null)
                return false;

            var duplicateExists = _context.UniversityDepartments
                .Any(fu => fu.UniID == updateDto.UniID && fu.DepID == updateDto.DepID);

            if (duplicateExists)
                return false;

            _context.UniversityDepartments.Remove(existingRelation);

            _context.UniversityDepartments.Add(new UniversityDepartment
            {
                UniID = updateDto.UniID,
                DepID = updateDto.DepID
            });

            _context.SaveChanges();
            return true;
        }
    }
}
