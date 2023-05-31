using Microsoft.IdentityModel.Tokens;
using SprintathonAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SprintathonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : Controller
    {
        public static User user = new User();
        private IConfiguration _configuration;
        private readonly ApplicationDbContext _dataContext;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //User Registration
        [HttpPost("register")]

        public async Task<ActionResult<string>> Register(CreateUserDto request)
        {   
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
            string token = CreateToken(user);

            return Ok(token);

        }


        //Login
        [HttpPost("Login")]

        public async Task<ActionResult<string>> Login(UserLogInDTo request)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (user.Email != request.Email)
            {
                return BadRequest("user not found");
            }

            if (user.Password != request.Password)
            {
                return BadRequest("Incorrect Password");
            }

            if (user == null)
            {
                return Unauthorized();
            }

            string token = CreateToken(user);
            return Ok(token);
        }
        //Creating a JSON Web Token using a Private Method
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Name, user.LastName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            //symmetric security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Appsettings:Token").Value!));


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
