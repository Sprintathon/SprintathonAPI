using Microsoft.AspNetCore.Mvc;
using SprintathonAPI.Models;
using SprintathonAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace SprintathonAPI.Controllers;

[Route("api/[contoller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IConfiguration _configuration;

    public ServiceController(ApplicationDbContext context, IConfiguration configuration)
    {
        _db = context;
        _configuration = configuration;
    }

    //GET 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Service>>> GetServices()
    {
        return await _db.Services.ToListAsync();   
    }

    //GET
    [HttpGet("{id}")]
    public async Task<ActionResult<Service>> GetServiceObj(int id)
    {   
        var serviceObj = await _db.Services.FindAsync(id);
        
        if(serviceObj ==null)
            return NotFound();
        
        return serviceObj;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Service>> PutServiceObj(int id, Service serviceObj)
    {   
        if(id != serviceObj.Id)
        {
            return BadRequest();
        }

        _db.Entry(serviceObj).State = EntityState.Modified;

        
        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            // if (!ServiceExists(serviceObj.Id))
            // {
            //     return NotFound();
            // }
            // else
            // {
            //     throw;
            // }
        }
        return NoContent();
        
    }

    [HttpPost]
    public async Task<ActionResult<Service>> PostServiceObj(Service serviceObj)
    {
        _db.Services.Add(serviceObj);
        await _db.SaveChangesAsync();

        return CreatedAtAction("GetExampleEntity", new { id = serviceObj.Id }, serviceObj);
    }

    // DELETE: api/Example/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> DeleteServiceObj(int id)
        {
            var serviceObj = await _db.Services.FindAsync(id);
            if (serviceObj == null)
            {
                return NotFound();
            }

            _db.Services.Remove(serviceObj);
            await _db.SaveChangesAsync();

            return serviceObj;
        }

        

}