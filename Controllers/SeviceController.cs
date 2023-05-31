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
        public async Task<List<Service>> GetClinics()
        {
            var service = await _dataContext.Services.ToListAsync();
            //check
            return service;
        }
        [HttpGet("{id}")]
        public Task<Service> GetClinic(int id)
        {
            var result = _dataContext.Services.FirstOrDefaultAsync(x => x.Id == id);
            //check
            return result;
        }
        [HttpPost]
        public async Task<Service> CreateClinic(Service service)
        {
            _dataContext.Services.Add(service);
            await _dataContext.SaveChangesAsync();
            //check
            return service;
        }
        
        [HttpPut]
        public async Task<Service> UpdateClinic(Service updatedService)
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
