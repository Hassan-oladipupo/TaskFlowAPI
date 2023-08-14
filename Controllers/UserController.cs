using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlowAPI.Data;
using TaskFlowAPI.Model;
using TaskFlowAPI.Repository;
using TaskFlowAPI.Tools;

namespace TaskFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;

        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> userlogin([FromBody] Login user)
        {
            try
            {
                string password = Password.hashPassword(user.Password);
                var dbuser = _db.register.Where(u => u.UserName == user.UserName && u.Password == password).Select(u => new
                {
                    u.Id,
                    u.UserName

                }).FirstOrDefault();

                if (dbuser == null)
                {
                    return BadRequest("Username or Password in incorrect");
                }
                return Ok(dbuser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> userRegistration([FromBody] Registration registration)
        {
            try
            {
                var dbuser = _db.register.Where(u => u.UserName == registration.UserName).FirstOrDefault();
                if (dbuser != null)
                {
                    return BadRequest("Username already taken");

                }

                if (registration.Password != registration.RepeatPassword)
                {
                    ModelState.AddModelError("RepeatPassword", "Passwords must match.");
                    return BadRequest(ModelState);
                }

                registration.Password = Password.hashPassword(registration.Password);
                registration.RepeatPassword = Password.hashPassword(registration.Password);
                registration.IsActive = 1;
                _db.register.Add(registration);
                await _db.SaveChangesAsync();


                return Ok("User is successfully registered");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
