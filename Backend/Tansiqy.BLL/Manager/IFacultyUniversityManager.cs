using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.FacultyUniversityDtos;
using Tansiqy.DAL.Models;

namespace Tansiqy.BLL.Manager
{
    public interface IFacultyUniversityManager
    {
        void Add(FacultyUniversityAddDtos facuni);
        IEnumerable<int> GetUniversitiesByFacultyId(int facultyId);
        IEnumerable<int> GetFacultiesByUniversityId(int universityId);
        void Remove(int fid, int uniId);
        bool Update(int currentFID, int currentUniID, FacultyUniversityUpdateDtos updateDto);
    }
}
