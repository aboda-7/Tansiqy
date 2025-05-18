using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tansiqy.BLL.Dtos.FacultyUniversityDtos;
using Tansiqy.BLL.Manager;

namespace Tansiqy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyUniversityController : ControllerBase
    {
        private readonly IFacultyUniversityManager _facultyUniversityManager;

        public FacultyUniversityController(IFacultyUniversityManager facultyUniversityManager)
        {
            _facultyUniversityManager = facultyUniversityManager;
        }


        [HttpPost]
        public IActionResult Add(FacultyUniversityAddDtos facuniAddDtos)
        {
            _facultyUniversityManager.Add(facuniAddDtos);
            return NoContent();
        }

        [HttpGet("universities/{facultyId}")]
        public IActionResult GetUniversitiesByFacultyId(int facultyId)
        {
            var universities = _facultyUniversityManager.GetUniversitiesByFacultyId(facultyId);
            return Ok(universities);
        }

        [HttpGet("faculties/{universityId}")]
        public IActionResult GetFacultiesByUniversityId(int universityId)
        {
            var faculties = _facultyUniversityManager.GetFacultiesByUniversityId(universityId);
            return Ok(faculties);
        }

        [HttpPut("{facultyId}/{universityId}")]
        public IActionResult Update(int facultyId, int universityId, [FromBody] FacultyUniversityUpdateDtos updateDto)
        {
            var result = _facultyUniversityManager.Update(facultyId, universityId, updateDto);

            if (!result)
                return BadRequest(new { message = "Update failed. Relationship not found or new combination already exists." });

            return NoContent();
        }

        [HttpDelete("{facultyId}/{universityId}")]
        public IActionResult Delete(int facultyId, int universityId)
        {
            _facultyUniversityManager.Remove(facultyId, universityId);
            return NoContent();
        }
    }
}
