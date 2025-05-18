using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tansiqy.BLL.Dtos.FacultyDtos;
using Tansiqy.BLL.Dtos.UserDtos;
using Tansiqy.BLL.Manager;

namespace Tansiqy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultyManager _facultyManager;

        public FacultiesController(IFacultyManager faultyManager)
        {
            _facultyManager = faultyManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_facultyManager.GetAll());
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetByID(int Id)
        {
            try
            {
                var facultyDtos = _facultyManager.GetById(Id);

                return Ok(facultyDtos);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Add(FacultyAddDtos facultyAddDto)
        {
            _facultyManager.Add(facultyAddDto);
            return NoContent();
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, FacultyUpdateDtos facultyUpdateDto)
        {
            _facultyManager.Update(Id, facultyUpdateDto);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _facultyManager.Delete(Id);
            return NoContent();
        }
    }
}
