using lab_3.Data.Models;
using lab_3.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace lab_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Teacher> _userManager;
        public UserController(IConfiguration configuration,UserManager<Teacher> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            
        }
        [HttpPost]
        public async Task<ActionResult<TokenDto>> Login(LoginDto login)
        {
            var user=await _userManager.FindByNameAsync(login.UserName);
            if(user==null)
                return Unauthorized();
            var isAuthenticated=await _userManager.CheckPasswordAsync(user,login.Password);
            if(!isAuthenticated)
                return Unauthorized();


            var climsList = await _userManager.GetClaimsAsync(user);
            var secretKey =new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey")!));

            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            var exp = DateTime.Now.AddDays(1);
            var tokenObj=new JwtSecurityToken(
                claims:climsList,
                signingCredentials:signingCredentials,
                expires:exp);

            var tokenHandler=new JwtSecurityTokenHandler();
            var token=tokenHandler.WriteToken(tokenObj);

            return new TokenDto(token,exp);

        }
        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<ActionResult> RegisterAdmin(RegisterAdminDto registerAdmin)
        {
            var teacher = new Teacher
            {
                UserName = registerAdmin.UserName,
                Email = registerAdmin.Email,
                Salary = registerAdmin.Salary,
            };
            var result=await _userManager.CreateAsync(teacher, registerAdmin.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, teacher.UserName),
                new Claim(ClaimTypes.NameIdentifier,teacher.Id),
                new Claim(ClaimTypes.Role,"Admin"),

            };
            await _userManager.AddClaimsAsync(teacher, claims);

            return Ok();
        }
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ActionResult> RegisterUser(RegisterUserDto registerUser)
        {
            var teacher = new Teacher
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
                Salary = registerUser.Salary,
            };
            var result = await _userManager.CreateAsync(teacher, registerUser.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, teacher.UserName),
                new Claim(ClaimTypes.NameIdentifier,teacher.Id),
                new Claim(ClaimTypes.Role,"User"),

            };
            await _userManager.AddClaimsAsync(teacher, claims);

            return Ok();
        }
    }
}
