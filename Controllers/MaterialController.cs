using Microsoft.AspNetCore.Mvc;

namespace SprintathonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        public MaterialController(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<List<Material>> Gets()
        {
            var material = await _dataContext.Materials.ToListAsync();
            //check
            return material;
        }
        [HttpGet("{id}")]
        public Task<Material> Get(int id)
        {
            var result = _dataContext.Materials.FirstOrDefaultAsync(x => x.Id == id);
            //check
            return result;
        }
        [HttpPost]
        public async Task<Material> Create(Material material)
        {
            _dataContext.Materials.Add(material);
            await _dataContext.SaveChangesAsync();
            //check
            return material;
        }
        
        [HttpPut]
        public async Task<Material> Update(Material updatedMaterial)
        {
            _dataContext.Materials.Update(updatedMaterial);
            await _dataContext.SaveChangesAsync();
            //check
            return updatedMaterial;
        }
        [HttpDelete("{id}")]
        public async Task DeleteMaterial(int id)
        {
            var material = _dataContext.Materials.FirstOrDefault(x => x.Id == id);
            _dataContext.Materials.Remove(material);
            await _dataContext.SaveChangesAsync();
        }
    }
}
