global using Order = SprintathonAPI.Models.Order;
using Microsoft.AspNetCore.Mvc;

namespace SprintathonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        public OrderController(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<List<Order>> Gets()
        {
            var order = await _dataContext.Orders.ToListAsync();
            //check
            return order;
        }
        [HttpGet("{id}")]
        public Task<Order> Get(int id)
        {
            var result = _dataContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            //check
            return result;
        }
        [HttpPost]
        public async Task<Order> Create(Order order)
        {
            _dataContext.Orders.Add(order);
            await _dataContext.SaveChangesAsync();
            //check
            return order;
        }
        
        [HttpPut]
        public async Task<Order> Update(Order updatedOrder)
        {
            _dataContext.Orders.Update(updatedOrder);
            await _dataContext.SaveChangesAsync();
            //check
            return updatedOrder;
        }
        [HttpDelete("{id}")]
        public async Task DeleteOrder(int id)
        {
            var order = _dataContext.Orders.FirstOrDefault(x => x.Id == id);
            _dataContext.Orders.Remove(order);
            await _dataContext.SaveChangesAsync();
        }
    }
}
