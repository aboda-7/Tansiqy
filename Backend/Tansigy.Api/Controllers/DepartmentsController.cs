using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tansiqy.BLL.Dtos.Department;
using Tansiqy.BLL.Dtos.UserDtos;
using Tansiqy.BLL.Manager;

namespace Tansiqy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentManager _departmentManager;

        public DepartmentsController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_departmentManager.GetAll());
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetByID(int Id)
        {
            try
            {
                var depDtos = _departmentManager.GetById(Id);

                return Ok(depDtos);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Add(DepartmentAddDtos departmentAddDtos)
        {
            _departmentManager.Add(departmentAddDtos);
            return NoContent();
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, DepartmentUpdateDtos departmentUpdateDtos)
        {
            _departmentManager.Update(Id, departmentUpdateDtos);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _departmentManager.Delete(Id);
            return NoContent();
        }
    }
}
