using LibraryManagementWithSql.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWithSqlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryDbContext _ctx;

        public BookController(LibraryDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_ctx.Books.ToList());

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id) 
        {
            var item = _ctx.Books.SingleOrDefault(x => x.BookShelfId == id);
            return item != null ? Ok(item) : BadRequest();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book item) 
        {

            item.BookId = 0;
            _ctx.Add(item);
            return _ctx.SaveChanges() > 0 ? Created() : BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book item)
        {
            var old = _ctx.Books.SingleOrDefault(x => x.BookId == item.BookId);
            if (old == null)
                return BadRequest();

            old.Title = item.Title;
            old.IsOut = item.IsOut;
            old.Price = item.Price;
            old.GenreId = item.GenreId;
            old.BookShelfId = item.BookShelfId;
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById(int id)
        {
            var item = _ctx.Books.SingleOrDefault(x => x.BookId == id);
            if (item == null)
                return BadRequest();
            _ctx.Remove(item);
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }
    }
}
