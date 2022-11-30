using DotNetLabInfoApi.DataContext;
using DotNetLabInfoApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetLabInfoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FunctionariesController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public FunctionariesController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var functionaries = await _databaseContext.Functionary.ToListAsync();
            return Ok(functionaries);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Functionary newFunctionary)
        {
            _databaseContext.Functionary.Add(newFunctionary);
            await _databaseContext.SaveChangesAsync();
            return Ok(newFunctionary);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var functionaryById = await _databaseContext
            .Functionary.Where(_ => _.Id == id)
            .FirstOrDefaultAsync();
            return Ok(functionaryById);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Functionary functionaryToUpdate)
        {
            _databaseContext.Functionary.Update(functionaryToUpdate);
            await _databaseContext.SaveChangesAsync();
            return Ok(functionaryToUpdate);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var functionaryToDelete = await _databaseContext.Functionary.FindAsync(id);
            if (functionaryToDelete == null)
            {
                return NotFound();
            }
            _databaseContext.Functionary.Remove(functionaryToDelete);
            await _databaseContext.SaveChangesAsync();
            return Ok();
        }
    }
}
