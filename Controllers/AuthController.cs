namespace SprintathonAPI.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class AuthController : Controller 
     {
          private readonly ApplicationDbContext _dataContext;
          public AuthController(ApplicationDbContext dataContext)
          {
               _dataContext = dataContext;
          }
          [HttpPost("register")]
          public async Task<ActionResult<User>> Register(CreateUserDto user)
          {
               _dataContext.Users.Add(user);
               await _dataContext.SaveChangesAsync();
               return user;
          }

          [HttpPost("login")]
          public async Task<ActionResult<User>> Login(UserLogInDTo userLogInDTo)
          {
               var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == userLogInDTo.Email);
               if (user == null)
               {
                    return Unauthorized();
               }
               return user;
          }
     }
}