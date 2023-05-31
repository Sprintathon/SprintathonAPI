using Microsoft.IdentityModel.Tokens;
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

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //User Registration
        [HttpPost("register")]

        public ActionResult<User> Register(CreateUserDto request)
        {
            string password
                = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Password = password;

            return Ok(user);

        }


        //Login
        [HttpPost("Login")]

        public ActionResult<User> Login(UserLogInDTo request)
        {
            if (user.Email != request.Email)
            {
                return BadRequest("user not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return BadRequest("Wrong Password");
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

////////////////////////////////////////////////////////////
//public class AuthController : Controller 
//     {
//          private readonly ApplicationDbContext _dataContext;
//          public AuthController(ApplicationDbContext dataContext)
//          {
//               _dataContext = dataContext;
//          }
//        //user registration
//          [HttpPost("register")]
//          public async Task<ActionResult<User>> Register(CreateUserDto user)
//          {
//               _dataContext.Users.Add(user);
//               await _dataContext.SaveChangesAsync();
//               return user;
//          }

//          [HttpPost("login")]
//          public async Task<ActionResult<User>> Login(UserLogInDTo userLogInDTo)
//          {
//               var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == userLogInDTo.Email);
//               if (user == null)
//               {
//                    return Unauthorized();
//               }
//               return user;
//          }
//     }
