using DbOperationWithEFCoreApp.Data;
using DbOperationWithEFCoreApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEFCoreApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController(AppDbContext _dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var result = await _dbContext.Author.ToListAsync();
            if(result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            _dbContext.Author.Add(author);
            await _dbContext.SaveChangesAsync();
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthors([FromBody] List<Author> authors)
        {
            _dbContext.Author.AddRange(authors);
            await _dbContext.SaveChangesAsync();
            return Ok(authors);
        }
    }
}
