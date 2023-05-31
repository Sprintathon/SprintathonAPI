using Microsoft.AspNetCore.Mvc;

namespace SprintathonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarmentController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        public GarmentController(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<List<Garment>> Gets()
        {
            var garment = await _dataContext.Garments.ToListAsync();
            //check
            return garment;
        }
        [HttpGet("{id}")]
        public Task<Garment> Get(int id)
        {
            var result = _dataContext.Garments.FirstOrDefaultAsync(x => x.Id == id);
            //check
            return result;
        }
        [HttpPost]
        public async Task<Garment> Create(Garment garment)
        {
            _dataContext.Garments.Add(garment);
            await _dataContext.SaveChangesAsync();
            //check
            return garment;
        }
        
        [HttpPut]
        public async Task<Garment> Update(Garment updatedGarment)
        {
            _dataContext.Garments.Update(updatedGarment);
            await _dataContext.SaveChangesAsync();
            //check
            return updatedGarment;
        }
        [HttpDelete("{id}")]
        public async Task DeleteGarment(int id)
        {
            var garment = _dataContext.Garments.FirstOrDefault(x => x.Id == id);
            _dataContext.Garments.Remove(garment);
            await _dataContext.SaveChangesAsync();
        }
    }
}
