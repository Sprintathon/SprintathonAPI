using Microsoft.AspNetCore.Mvc;

namespace SprintathonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        public BasketController(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<List<Basket>> Gets()
        {
            var basket = await _dataContext.Baskets.ToListAsync();
            //check
            return basket;
        }
        [HttpGet("{id}")]
        public Task<Basket> Get(int id)
        {
            var result = _dataContext.Baskets.FirstOrDefaultAsync(x => x.Id == id);
            //check
            return result;
        }
        [HttpPost]
        public async Task<Basket> Create(Basket basket)
        {
            _dataContext.Baskets.Add(basket);
            await _dataContext.SaveChangesAsync();
            //check
            return basket;
        }
        
        [HttpPut]
        public async Task<Basket> Update(Basket updatedBasket)
        {
            _dataContext.Baskets.Update(updatedBasket);
            await _dataContext.SaveChangesAsync();
            //check
            return updatedBasket;
        }
        [HttpDelete("{id}")]
        public async Task DeleteBasket(int id)
        {
            var basket = _dataContext.Baskets.FirstOrDefault(x => x.Id == id);
            _dataContext.Baskets.Remove(basket);
            await _dataContext.SaveChangesAsync();
        }
    }
}
