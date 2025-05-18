using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tansiqy.BLL.Dtos.DegreeDtos;
using Tansiqy.BLL.Dtos.UserDtos;
using Tansiqy.BLL.Manager;

namespace Tansiqy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreesController : ControllerBase
    {
        private readonly IDegreeManager _degreeManager;

        public DegreesController(IDegreeManager degreeManager)
        {
            _degreeManager = degreeManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_degreeManager.GetAll());
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetByID(int Id)
        {
            try
            {
                var degreeDtos = _degreeManager.GetById(Id);

                return Ok(degreeDtos);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Add(DegreeAddDtos degreeAddDtos)
        {
            _degreeManager.Add(degreeAddDtos);
            return NoContent();
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, DegreeUpdateDtos degreeUpdateDtos)
        {
            _degreeManager.Update(Id, degreeUpdateDtos);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _degreeManager.Delete(Id);
            return NoContent();
        }
    }
}
