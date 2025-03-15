using DbOperationWithEFCoreApp.Data;
using DbOperationWithEFCoreApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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

        //[HttpGet("")]
        //public async Task<IActionResult> GetAllBooks()
        //{
        //    var result = await _dbContext.Book.Select(b => new
        //    {
        //        BookId = b.Id,
        //        Title = b.Title,
        //        Description = b.Description,
        //        NoOfPages = b.NoOfPages,
        //        IsActive = b.IsActive,
        //        CreatedOn = b.CreatedOn,
        //        BookLanguageId = b.LanguageId,
        //        AuthorName = b.Author.Name,
        //        Language = b.Language.Title
        //    }).ToListAsync();
        //    if (result == null)
        //        return NotFound();
        //    return Ok(result);
        //}

        [HttpPost]
        public async Task<IActionResult> AddBooks([FromBody] List<Book> books)
        {
            _dbContext.Book.AddRange(books);
            await _dbContext.SaveChangesAsync();
            return Ok(books);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateBookAsync([FromRoute] int id, [FromBody] Book book)
        {
            var dbBook = await _dbContext.Book.FindAsync(id);
            if(dbBook == null) return NotFound();
            dbBook.Title = book.Title;
            dbBook.Description = book.Description;

            await _dbContext.SaveChangesAsync();

            return Ok(dbBook);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateInSingleHitAsync([FromBody] Book model)
        {
            _dbContext.Book.Update(model);
            await _dbContext.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> BulkUpdateAsync()
        {
           await _dbContext.Book.Where(b => b.LanguageId == 1).ExecuteUpdateAsync(x =>x.
           SetProperty(b => b.AuthorId, 1).
           SetProperty(b => b.CreatedOn, System.DateTime.Now)
            );
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            var book = await _dbContext.Book.FindAsync(id);
            if(book == null) return NotFound(); 
            _dbContext.Book.Remove(book);
            await _dbContext.SaveChangesAsync();
            return Ok(book);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBookInSingleHit([FromRoute] int id)
        {
            var book = new Book(){ Id = id };
            _dbContext.Entry(book).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return Ok();
            
        }

        [HttpDelete]
        [Route("BulkDelete")]
        public async Task<IActionResult> BulkDelete([FromBody] List<int> ids)
        {
            var book = await _dbContext.Book.Where(b => ids.Contains(b.Id)).ToListAsync();
            if(book == null) return NotFound();
            _dbContext.Book.RemoveRange(book);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("BulkDeleteSingleHit")]
        public async Task<IActionResult> BulkDeleteInSingleHit([FromBody] List<int> ids)
        {
            await _dbContext.Book.Where(b => ids.Contains(b.Id)).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBookWithAuthorAndLanguageEagerAsync()
        {
            var result = await _dbContext.Book.Include(b => b.Author).ThenInclude(a => a.Address).ToListAsync();
            if (result == null) return NotFound();
            return Ok(result);
        }

        //[HttpGet("")]
        //public async Task<IActionResult> GetAllBookExplicitAsync()
        //{
        //    var book = await _dbContext.Book.FirstOrDefaultAsync();

        //    await _dbContext.Entry(book).Reference(b => b.Author).LoadAsync();
        //    await _dbContext.Entry(book).Reference(b => b.Language).LoadAsync();
            
        //    return Ok(book);
        //}
    }
}
