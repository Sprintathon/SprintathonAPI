using Microsoft.IdentityModel.Tokens;
using SprintathonAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SprintathonAPI.Controllers
{
<<<<<<< HEAD
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

        public async Task<ActionResult<User>> Register(CreateUserDto request)
        {
            string password
                = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Password = password;
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
            return Ok(user);

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

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return BadRequest("Wrong Password");
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
