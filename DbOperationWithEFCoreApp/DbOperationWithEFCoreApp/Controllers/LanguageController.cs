using DbOperationWithEFCoreApp.Data;
using DbOperationWithEFCoreApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEFCoreApp.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public LanguageController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLanguages()
        {
            return Ok(await _appDbContext.Language.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLanguageWithId([FromRoute] int id)
        {
            var language = await _appDbContext.Language.FirstOrDefaultAsync(l => l.Id == id);
            if (language == null)
                return NotFound();
            return Ok(language);
        }
        [HttpGet("{title}")]
        public async Task<IActionResult> GetLanguageWithTitle([FromRoute] string title)
        {
            var language = await _appDbContext.Language.FirstOrDefaultAsync(l => l.Title == title);
            if (language == null)
                return NotFound();
            return Ok(language);
        }

        //[HttpGet("GetAllLanguagesExplicit")]
        //public async Task<IActionResult> GetAllLanguagesExplicitAsync()
        //{
        //    var languages = await _appDbContext.Language.ToListAsync();
        //    foreach(var language in languages)
        //    {
        //        await _appDbContext.Entry(language).Collection(l => l.Book).LoadAsync();
        //    }
        //    return Ok(languages);
        //}
    }
}
