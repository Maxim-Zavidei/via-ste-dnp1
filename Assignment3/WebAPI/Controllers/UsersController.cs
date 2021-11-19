using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase {
        private readonly IUserService userService;

        public UsersController(IUserService userService) {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password) {
            try {
                var user = userService.ValidateUser(username, password);
                return Ok(user);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] User user) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {
                userService.RegisterUser(user);
                return Ok();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}