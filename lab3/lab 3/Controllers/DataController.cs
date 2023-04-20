using lab_3.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace lab_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        private readonly UserManager<Teacher> _userManager;
        public DataController(UserManager<Teacher> userManager) 
        { 
            _userManager = userManager;
        }
        [HttpGet]
        [Authorize]
        [Route("UsersInfo")]
        public async Task<ActionResult> GetUserInfo()
        {
            var user = await _userManager.GetUserAsync(User);
            return Ok(new
            {
                UserName=user.UserName,
                Email=user.Email,
                Salary=user.Salary,
            });
        }
        [HttpGet]
        [Authorize(Policy ="AdminsOnly")]
        [Route("AdminInfo")]
        public async Task<ActionResult> GetInfoForManager()
        {
            var user = await _userManager.GetUserAsync(User);
            return Ok(new
            {
                UserName = user.UserName,
                Email = user.Email,
                Salary = user.Salary,
            });
        }
        [HttpGet]
        [Authorize(Policy = "AdminsOrUsers")]
        [Route("UserInfo")]
        public async Task<ActionResult> GetInfoForUser()
        {
            var user = await _userManager.GetUserAsync(User);
            return Ok(new
            {
                UserName = user.UserName,
                Email = user.Email,
                Salary = user.Salary,
            });
        }
    }
}
