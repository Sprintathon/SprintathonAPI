using Microsoft.AspNetCore.Mvc;

namespace SprintathonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarmentTypeController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        public GarmentTypeController(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<List<GarmentType>> Gets()
        {
            var garmentType = await _dataContext.GarmentTypes.ToListAsync();
            //check
            return garmentType;
        }
        [HttpGet("{id}")]
        public Task<GarmentType> Get(int id)
        {
            var result = _dataContext.GarmentTypes.FirstOrDefaultAsync(x => x.Id == id);
            //check
            return result;
        }
        [HttpPost]
        public async Task<GarmentType> Create(GarmentType garmentType)
        {
            _dataContext.GarmentTypes.Add(garmentType);
            await _dataContext.SaveChangesAsync();
            //check
            return garmentType;
        }
        
        [HttpPut]
        public async Task<GarmentType> Update(GarmentType updatedGarmentType)
        {
            _dataContext.GarmentTypes.Update(updatedGarmentType);
            await _dataContext.SaveChangesAsync();
            //check
            return updatedGarmentType;
        }
        [HttpDelete("{id}")]
        public async Task DeleteGarmentType(int id)
        {
            var garmentType = _dataContext.GarmentTypes.FirstOrDefault(x => x.Id == id);
            _dataContext.GarmentTypes.Remove(garmentType);
            await _dataContext.SaveChangesAsync();
        }
    }
}
