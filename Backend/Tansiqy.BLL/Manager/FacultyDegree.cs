using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.FacultyDegreeDtos;
using Tansiqy.DAL.Database;
using Tansiqy.DAL.Models;

namespace Tansiqy.BLL.Manager
{
    public class FacultyDegreeManager : IFacultyDegreeManager
    {
        private readonly TansiqyContext _context;

        public FacultyDegreeManager(TansiqyContext context)
        {
            _context = context;
        }

        public void Add(FacultyDegreeAddDtos dto)
        {
            var entity = new FacultyDegree
            {
                FID = dto.FID,
                DegID = dto.DegID
            };
            _context.FacultyDegrees.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<int> GetDegreesByFacultyId(int facultyId)
        {
            return _context.FacultyDegrees
                          .Where(fu => fu.FID == facultyId)
                          .Select(fu => fu.DegID)
                          .ToList();
        }

        public IEnumerable<int> GetFacultiesByDegreeId(int degreeId)
        {
            return _context.FacultyDegrees
                          .Where(fu => fu.DegID == degreeId)
                          .Select(fu => fu.FID)
                          .ToList();
        }

        public void Remove(int fid, int uniId)
        {
            var entity = _context.FacultyDegrees.Find(fid, uniId);
            if (entity != null)
            {
                _context.FacultyDegrees.Remove(entity);
                _context.SaveChanges();
            }
        }

        public bool Update(int currentFID, int currentUniID, FacultyDegreeUpdateDtos updateDto)
        {
            var existingRelation = _context.FacultyDegrees
                .FirstOrDefault(fu => fu.FID == currentFID && fu.DegID == currentUniID);

            if (existingRelation == null)
                return false;

            // Check if the new combination already exists (to avoid duplicates)
            var duplicateExists = _context.FacultyDegrees
                .Any(fu => fu.FID == updateDto.FID && fu.DegID == updateDto.DegID);

            if (duplicateExists)
                return false;

            // Remove the old relationship
            _context.FacultyDegrees.Remove(existingRelation);

            // Add the new relationship
            _context.FacultyDegrees.Add(new FacultyDegree
            {
                FID = updateDto.FID,
                DegID = updateDto.DegID
            });

            _context.SaveChanges();
            return true;
        }
    }
}
