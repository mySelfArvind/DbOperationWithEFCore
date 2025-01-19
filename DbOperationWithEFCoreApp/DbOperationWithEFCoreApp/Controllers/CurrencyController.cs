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

        /// <summary>
        /// get unique currency by using title, and we're assuming that currency are not duplicate...
        /// if given title found duplicate currency then we'll get error[exception]...
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        //[HttpGet("{title}")]
        //public async Task<IActionResult> GetCurrencyByTitle([FromRoute] string title)
        //{
        //    //var result = await _appDbContext.CurrencyType.Where(c => c.Title == title).FirstOrDefaultAsync();
        //    var result = await _appDbContext.CurrencyType.SingleOrDefaultAsync(c => c.Title == title);
        //    if (result == null)
        //        return NotFound();
        //    return Ok(result);
        //}

        /// <summary>
        /// get currency based on title, if more than one record available with same title then first will be considered
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        //[HttpGet("{title}")]
        //public async Task<IActionResult> GetCurrencyByTitleAsync([FromRoute] string title)
        //{
        //    var result = await _appDbContext.CurrencyType.FirstOrDefaultAsync(c => c.Title == title);
        //    if (result == null)
        //        return NotFound();
        //    return Ok(result);
        //}

        /// <summary>
        /// get currency by passing title and description where both are part of Route and mandatory...
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        //[HttpGet("{title}/{description}")]
        //public async Task<IActionResult> GetCurrencyByTitleAndDescriptionAsync([FromRoute] string title, [FromRoute] string description)
        //{
        //    var result = await _appDbContext.CurrencyType.FirstOrDefaultAsync(c => c.Title == title && c.Description == description);
        //    if (result == null)
        //        return NotFound();
        //    return Ok(result);
        //}

        /// <summary>
        /// get currency by passing title[FromRoute] and description[FromQuery] where description is optioanl 
        /// if passed then will be used else will be ommited...
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        //[HttpGet("{title}")]
        //public async Task<IActionResult> GetCurrencyByTitleAndDescriptionAsync([FromRoute] string title, [FromQuery] string? description)
        //{
        //    var result = await _appDbContext.
        //        CurrencyType.
        //        FirstOrDefaultAsync(c => 
        //        c.Title == title &&
        //        (string.IsNullOrEmpty(description) || c.Description == description));
        //    if (result == null)
        //        return NotFound();
        //    return Ok(result);
        //}

        /// <summary>
        /// get all the currencies with the given title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        //[HttpGet("{title}")]
        //public async Task<IActionResult> GetAllCurrencyWithTitle([FromRoute] string title)
        //{
        //    var result = await _appDbContext.CurrencyType.Where(l => l.Title == title).ToListAsync();
        //    if(result == null)
        //        return NotFound();
        //    return Ok(result);
        //}

        ///<summary>
        ///getting all the currencies with given currency id; here we're using Contains() method which is checking if the given id is present in database
        [HttpPost("all")]
        public async Task<IActionResult> GetAllCurrenciesWithId([FromBody] List<int> ids)
        {
            var result = await _appDbContext.CurrencyType.Where(c => ids.Contains(c.Id)).ToListAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

    }
}
