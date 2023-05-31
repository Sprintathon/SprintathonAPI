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
        public async Task<List<User>> GetClinics()
        {
            var clinics = await _dataContext.Users.ToListAsync();
            //check
            return clinics;
        }
        [HttpGet("{id}")]
        public Task<User> GetClinic(int id)
        {
            var result = _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            //check
            return result;
        }
        [HttpPost]
        public async Task<User> CreateClinic(User newClinic)
        {
            _dataContext.Users.Add(newClinic);
            await _dataContext.SaveChangesAsync();
            //check
            return newClinic;
        }
        [HttpPut]
        public async Task<User> UpdateClinic(User updatedClinic)
        {
            _dataContext.Users.Update(updatedClinic);
            await _dataContext.SaveChangesAsync();
            //check
            return updatedClinic;
        }
        [HttpDelete("{id}")]
        public async Task DeleteClinic(int id)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == id);
            _dataContext.Users.Remove(user);
            await _dataContext.SaveChangesAsync();
        }
    }
}
