using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tansiqy.BLL.Dtos.UniversityDepartmentDtos;
using Tansiqy.BLL.Manager;

namespace Tansiqy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityDepartmentController : ControllerBase
    {
        private readonly IUniversityDepartmentManager _universityDepartmentManager;

        public UniversityDepartmentController(IUniversityDepartmentManager universityDepartmentManager)
        {
            _universityDepartmentManager = universityDepartmentManager;
        }


        [HttpPost]
        public IActionResult Add(UniversityDepartmentAddDtos unidepAddDtos)
        {
            _universityDepartmentManager.Add(unidepAddDtos);
            return NoContent();
        }

        [HttpGet("departments/{universityId}")]
        public IActionResult GetUniversitiesByFacultyId(int universityId)
        {
            var departments = _universityDepartmentManager.GetDepartmentsByUniversityId(universityId);
            return Ok(departments);
        }

        [HttpGet("university/{departmentId}")]
        public IActionResult GetFacultiesByUniversityId(int departmentId)
        {
            var universities = _universityDepartmentManager.GetUniversitiesByDepartmentId(departmentId);
            return Ok(universities);
        }

        [HttpPut("{universityId}/{departmentId}")]
        public IActionResult Update(int universityId, int departmentId, [FromBody] UniversityDepartmentUpdateDtos updateDto)
        {
            var result = _universityDepartmentManager.Update(universityId, departmentId, updateDto);

            if (!result)
                return BadRequest(new { message = "Update failed. Relationship not found or new combination already exists." });

            return NoContent();
        }

        [HttpDelete("{universityId}/{departmentId}")]
        public IActionResult Delete(int universityId, int departmentId)
        {
            _universityDepartmentManager.Remove(universityId, departmentId);
            return NoContent();
        }
    }
}
