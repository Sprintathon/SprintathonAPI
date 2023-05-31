using Microsoft.AspNetCore.Mvc;

namespace SprintathonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        public ServiceController(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<List<Service>> GetService()
        {
            var service = await _dataContext.Services.ToListAsync();
            //check
            return service;
        }
        [HttpGet("{id}")]
        public Task<Service> GetService(int id)
        {
            var result = _dataContext.Services.FirstOrDefaultAsync(x => x.Id == id);
            //check
            return result;
        }
        [HttpPost]
        public async Task<Service> CreateService(Service service)
        {
            _dataContext.Services.Add(service);
            await _dataContext.SaveChangesAsync();
            //check
            return service;
        }
        
        [HttpPut]
        public async Task<Service> UpdateService(Service updatedService)
        {
            _dataContext.Services.Update(updatedService);
            await _dataContext.SaveChangesAsync();
            //check
            return updatedService;
        }
        [HttpDelete("{id}")]
        public async Task DeleteService(int id)
        {
            var service = _dataContext.Services.FirstOrDefault(x => x.Id == id);
            _dataContext.Services.Remove(service);
            await _dataContext.SaveChangesAsync();
        }
    }
}
