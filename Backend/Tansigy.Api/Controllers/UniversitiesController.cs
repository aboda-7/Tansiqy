using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tansiqy.BLL.Dtos.UniversityDtos;
using Tansiqy.BLL.Dtos.UserDtos;
using Tansiqy.BLL.Manager;

namespace Tansiqy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversityManager _universityManager;

        public UniversitiesController(IUniversityManager universityManager)
        {
            _universityManager = universityManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_universityManager.GetAll());
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetByID(int Id)
        {
            try
            {
                var uniDtos = _universityManager.GetById(Id);

                return Ok(uniDtos);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Add(UniversityAddDtos universityAddDto)
        {
            _universityManager.Add(universityAddDto);
            return NoContent();
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, UniversityUpdateDtos universityUpdateDto)
        {
            if (Id != universityUpdateDto.UniID)
            {
                return BadRequest();
            }
            _universityManager.Update(universityUpdateDto);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _universityManager.Delete(Id);
            return NoContent();
        }
    }
}
