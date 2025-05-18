using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tansiqy.BLL.Dtos.FacultyDegreeDtos;
using Tansiqy.DAL.Models;

namespace Tansiqy.BLL.Manager
{
    public interface IFacultyDegreeManager
    {
        void Add(FacultyDegreeAddDtos facdeg);
        IEnumerable<int> GetDegreesByFacultyId(int facultyId);
        IEnumerable<int> GetFacultiesByDegreeId(int degreeId);
        void Remove(int fid, int degId);
        bool Update(int currentFID, int currentDegID, FacultyDegreeUpdateDtos updateDto);
    }
}
