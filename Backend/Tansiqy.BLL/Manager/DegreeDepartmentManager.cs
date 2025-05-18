using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.DegreeDepartmentDtos;
using Tansiqy.DAL.Database;
using Tansiqy.DAL.Models;

namespace Tansiqy.BLL.Manager
{
    public class DegreeDepartmentManager : IDegreeDepartmentManager
    {
        private readonly TansiqyContext _context;

        public DegreeDepartmentManager(TansiqyContext context)
        {
            _context = context;
        }

        public void Add(DegreeDepartmentAddDtos dto)
        {
            var entity = new DegreeDepartment
            {
                DegID = dto.DegID,
                DepID = dto.DepID
            };
            _context.DegreeDepartments.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<int> GetDepartmentsByDegreeId(int degreeId)
        {
            return _context.DegreeDepartments
                          .Where(fu => fu.DegID == degreeId)
                          .Select(fu => fu.DepID)
                          .ToList();
        }

        public IEnumerable<int> GetDegreesByDepartmentId(int departmentId)
        {
            return _context.DegreeDepartments
                          .Where(fu => fu.DepID == departmentId)
                          .Select(fu => fu.DegID)
                          .ToList();
        }

        public void Remove(int degid, int depid)
        {
            var entity = _context.FacultyUniversities.Find(degid, depid);
            if (entity != null)
            {
                _context.FacultyUniversities.Remove(entity);
                _context.SaveChanges();
            }
        }

        public bool Update(int currentDegID, int currentDepID, DegreeDepartmentUpdateDtos updateDto)
        {
            var existingRelation = _context.DegreeDepartments
                .FirstOrDefault(fu => fu.DegID == currentDegID && fu.DepID == currentDepID);

            if (existingRelation == null)
                return false;

            // Check if the new combination already exists (to avoid duplicates)
            var duplicateExists = _context.DegreeDepartments
                .Any(fu => fu.DegID == updateDto.NewDegID && fu.DepID == updateDto.NewDepID);

            if (duplicateExists)
                return false;

            // Remove the old relationship
            _context.DegreeDepartments.Remove(existingRelation);

            // Add the new relationship
            _context.DegreeDepartments.Add(new DegreeDepartment
            {
                DegID = updateDto.NewDegID,
                DepID = updateDto.NewDepID
            });

            _context.SaveChanges();
            return true;
        }
    }
}
