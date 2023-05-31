<<<<<<< HEAD
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
=======
﻿using Microsoft.AspNetCore.Mvc;

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
>>>>>>> master
