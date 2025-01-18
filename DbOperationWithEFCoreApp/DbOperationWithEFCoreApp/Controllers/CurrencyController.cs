using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DbOperationWithEFCoreApp.Data;
using Microsoft.EntityFrameworkCore;
namespace DbOperationWithEFCoreApp.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCurrencies()
        {
            //var result = await _appDbContext.CurrencyType.ToListAsync();
            var result = await (from currencies in _appDbContext.CurrencyType
                                select new { currencies.Id, currencies.Title, currencies.Description }).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCurrencyByIdAsync([FromRoute] int id)
        {
            var result = await _appDbContext.CurrencyType.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{title}")]
        public async Task<IActionResult> GetCurrencyByTitle([FromRoute] string title)
        {
            //var result = await _appDbContext.CurrencyType.Where(c => c.Title == title).FirstOrDefaultAsync();
            var result = await _appDbContext.CurrencyType.SingleOrDefaultAsync(c => c.Title == title);
            if(result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
