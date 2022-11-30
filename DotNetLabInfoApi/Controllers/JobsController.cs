using DotNetLabInfoApi.DataContext;
using DotNetLabInfoApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetLabInfoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public JobsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var jobs = await _databaseContext.Jobs.ToListAsync();
            return Ok(jobs);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Job newJob)
        {
            _databaseContext.Jobs.Add(newJob);
            await _databaseContext.SaveChangesAsync();
            return Ok(newJob);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var jobById = await _databaseContext
            .Jobs.Where(_ => _.Id == id)
            .FirstOrDefaultAsync();
            return Ok(jobById);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Job jobToUpdate)
        {
            _databaseContext.Jobs.Update(jobToUpdate);
            await _databaseContext.SaveChangesAsync();
            return Ok(jobToUpdate);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var jobToDelete = await _databaseContext.Jobs.FindAsync(id);
            if (jobToDelete == null)
            {
                return NotFound();
            }
            _databaseContext.Jobs.Remove(jobToDelete);
            await _databaseContext.SaveChangesAsync();
            return Ok();
        }
    }
}
