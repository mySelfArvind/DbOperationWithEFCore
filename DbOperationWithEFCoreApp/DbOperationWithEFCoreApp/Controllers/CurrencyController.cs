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
    }
}
