using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tansiqy.BLL.Dtos.FacultyDegreeDtos;
using Tansiqy.BLL.Manager;

namespace Tansiqy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyDegreeController : ControllerBase
    {
        private readonly IFacultyDegreeManager _facultyDegreeManager;

        public FacultyDegreeController(IFacultyDegreeManager facultyDegreeManager)
        {
            _facultyDegreeManager = facultyDegreeManager;
        }


        [HttpPost]
        public IActionResult Add(FacultyDegreeAddDtos facdegAddDtos)
        {
            _facultyDegreeManager.Add(facdegAddDtos);
            return NoContent();
        }

        [HttpGet("degrees/{facultyId}")]
        public IActionResult GetDegreesByFacultyId(int facultyId)
        {
            var degrees = _facultyDegreeManager.GetDegreesByFacultyId(facultyId);
            return Ok(degrees);
        }

        [HttpGet("faculties/{degreeId}")]
        public IActionResult GetFacultiesByDegreeId(int degreeId)
        {
            var faculties = _facultyDegreeManager.GetFacultiesByDegreeId(degreeId);
            return Ok(faculties);
        }

        [HttpPut("{facultyId}/{degreeId}")]
        public IActionResult Update(int facultyId, int degreeId, [FromBody] FacultyDegreeUpdateDtos updateDto)
        {
            var result = _facultyDegreeManager.Update(facultyId, degreeId, updateDto);

            if (!result)
                return BadRequest(new { message = "Update failed. Relationship not found or new combination already exists." });

            return NoContent();
        }

        [HttpDelete("{facultyId}/{degreeId}")]
        public IActionResult Delete(int facultyId, int degreeId)
        {
            _facultyDegreeManager.Remove(facultyId, degreeId);
            return NoContent();
        }
    }
}
