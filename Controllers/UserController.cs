global using Microsoft.AspNetCore.Mvc;
global using SprintathonAPI.Data;
global using SprintathonAPI.Models;
global using Microsoft.EntityFrameworkCore;

namespace SprintathonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        public UserController(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<List<User>> GetUser()
        {
            var user = await _dataContext.Users.ToListAsync();
            //check
            return user;
        }
        [HttpGet("{id}")]
        public Task<User> GetUser(int id)
        {
            var result = _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            //check
            return result;
        }
        [HttpPost]
        public async Task<User> CreateUser(User newUser)
        {
            _dataContext.Users.Add(newUser);
            await _dataContext.SaveChangesAsync();
            //check
            return newUser;
        }
        [HttpPut]
        public async Task<User> UpdateUser(User updatedUser)
        {
            _dataContext.Users.Update(updatedUser);
            await _dataContext.SaveChangesAsync();
            //check
            return updatedUser;
        }
        [HttpDelete("{id}")]
        public async Task DeleteUser(int id)
        {
            var user = _dataContext.Users.FirstOrDefault(z => z.Id == id);
            _dataContext.Users.Remove(user);
            await _dataContext.SaveChangesAsync();
        }
    }
}
