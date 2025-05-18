using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tansiqy.BLL.Dtos.DegreeDepartmentDtos;
using Tansiqy.BLL.Manager;

namespace Tansiqy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeDepartmentController : ControllerBase
    {
        private readonly IDegreeDepartmentManager _degreeDepartmentManager;

        public DegreeDepartmentController(IDegreeDepartmentManager degreeDepartmentManager)
        {
            _degreeDepartmentManager = degreeDepartmentManager;
        }

        [HttpPost]
        public IActionResult Add([FromBody] DegreeDepartmentAddDtos degdepAddDtos)
        {
            _degreeDepartmentManager.Add(degdepAddDtos);
            return NoContent();
        }

        [HttpGet("departments/{degreeId}")]
        public IActionResult GetDepartmentsByDegreeId(int degreeId)
        {
            var departments = _degreeDepartmentManager.GetDepartmentsByDegreeId(degreeId);
            return Ok(departments);
        }

        [HttpGet("degree/{departmentId}")]
        public IActionResult GetDegreesByDepartmentId(int departmentId)
        {
            var degrees = _degreeDepartmentManager.GetDegreesByDepartmentId(departmentId);
            return Ok(degrees);
        }

        [HttpPut("{degreeId}/{departmentId}")]
        public IActionResult Update(int degreeId, int departmentId, [FromBody] DegreeDepartmentUpdateDtos updateDto)
        {
            var result = _degreeDepartmentManager.Update(degreeId, departmentId, updateDto);

            if (!result)
                return BadRequest(new { message = "Update failed. Relationship not found or new combination already exists." });

            return NoContent();
        }

        [HttpDelete("{degreeId}/{departmentId}")]
        public IActionResult Delete(int degreeId, int departmentId)
        {
            _degreeDepartmentManager.Remove(degreeId, departmentId);
            return NoContent();
        }
    }
}