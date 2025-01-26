using DbOperationWithEFCoreApp.Data;
using DbOperationWithEFCoreApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEFCoreApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController(AppDbContext _dbContext) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] Book book)
        {
            if (book.Author != null)
            {
                var author = new Author()
                {
                    Name = book.Author.Name,
                    Email = book.Author.Email
                };
                book.Author = author;
            }
            book.CreatedOn = System.DateTime.Now;
            _dbContext.Book.Add(book);
            await _dbContext.SaveChangesAsync();
            return Ok(book);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _dbContext.Book.Select(b => new { Id = b.Id, Title = b.Title, Description = b.Description, NoOfPages = b.NoOfPages, IsActive = b.IsActive, CreatedOn = b.CreatedOn, LanguageId = b.LanguageId }).ToListAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBooks([FromBody] List<Book> books)
        {
            _dbContext.Book.AddRange(books);
            await _dbContext.SaveChangesAsync();
            return Ok(books);
        }
    }
}
