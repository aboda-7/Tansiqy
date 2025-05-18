using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.FacultyUniversityDtos;
using Tansiqy.DAL.Database;
using Tansiqy.DAL.Models;

namespace Tansiqy.BLL.Manager
{
    public class FacultyUniversityManager : IFacultyUniversityManager
    {
        private readonly TansiqyContext _context;

        public FacultyUniversityManager(TansiqyContext context)
        {
            _context = context;
        }

        public void Add(FacultyUniversityAddDtos dto)
        {
            var entity = new FacultyUniversity
            {
                FID = dto.FID,
                UniID = dto.UniID
            };
            _context.FacultyUniversities.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<int> GetUniversitiesByFacultyId(int facultyId)
        {
            return _context.FacultyUniversities
                          .Where(fu => fu.FID == facultyId)
                          .Select(fu => fu.UniID)
                          .ToList();
        }

        public IEnumerable<int> GetFacultiesByUniversityId(int universityId)
        {
            return _context.FacultyUniversities
                          .Where(fu => fu.UniID == universityId)
                          .Select(fu => fu.FID)
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

        public bool Update(int currentFID, int currentUniID, FacultyUniversityUpdateDtos updateDto)
        {
            var existingRelation = _context.FacultyUniversities
                .FirstOrDefault(fu => fu.FID == currentFID && fu.UniID == currentUniID);

            if (existingRelation == null)
                return false;

            // Check if the new combination already exists (to avoid duplicates)
            var duplicateExists = _context.FacultyUniversities
                .Any(fu => fu.FID == updateDto.FID && fu.UniID == updateDto.UniID);

            if (duplicateExists)
                return false;

            // Remove the old relationship
            _context.FacultyUniversities.Remove(existingRelation);

            // Add the new relationship
            _context.FacultyUniversities.Add(new FacultyUniversity
            {
                FID = updateDto.FID,
                UniID = updateDto.UniID
            });

            _context.SaveChanges();
            return true;
        }
    }
}
