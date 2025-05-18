using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tansiqy.BLL.Dtos.UserDtos;
using Tansiqy.BLL.Manager;

namespace Tansiqy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userManager.GetAll());
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetByID(int Id)
        {
            try
            {
                var userDtos = _userManager.GetById(Id); 

                return Ok(userDtos);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Add(UserAddDtos userAddDto)
        {
            try
            {
                _userManager.Add(userAddDto);
                return Ok(new { message = "User Added Successfully" });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = "User with id or email already exists" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, UserUpdateDtos userUpdateDto)
        {
            _userManager.Update(Id, userUpdateDto);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _userManager.Delete(Id);
            return NoContent();
        }
    }
}
