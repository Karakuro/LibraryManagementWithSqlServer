using LibraryManagementWithSql.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWithSqlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly LibraryDbContext _ctx;

        public GenreController(LibraryDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_ctx.Genres.ToList());

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _ctx.Books.SingleOrDefault(x => x.BookId == id);
            return item != null ? Ok(item) : BadRequest();
        }

        [HttpGet]
        [Route("Report")]
        public IActionResult Report()
        {
            var report = _ctx.Genres.Select(g => new {
                g.GenreId,
                g.Description,
                BookCount = g.Books.Count()
            }).ToList();
            return Ok(report);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Genre item)
        {
            item.GenreId = 0;
            _ctx.Add(item);
            return _ctx.SaveChanges() > 0 ? Created() : BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Genre item)
        {
            var old = _ctx.Genres.SingleOrDefault(x => x.GenreId == item.GenreId);
            if (old == null)
                return BadRequest();

            old.Description = item.Description;
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById(int id)
        {
            var item = _ctx.Genres.SingleOrDefault(x => x.GenreId == id);
            if (item == null)
                return BadRequest();
            _ctx.Remove(item);
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }
    }
}
