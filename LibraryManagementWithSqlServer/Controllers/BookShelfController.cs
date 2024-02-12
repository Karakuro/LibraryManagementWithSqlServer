using LibraryManagementWithSql.Data;
using LibraryManagementWithSqlServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementWithSqlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookShelfController : ControllerBase
    {
        private readonly LibraryDbContext _ctx;
        private readonly Mapper _mapper;

        public BookShelfController(LibraryDbContext ctx, Mapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_ctx.BookShelves.ToList());

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            BookShelf? item = _ctx.BookShelves.Include(s => s.Books).Include("Books.Genre").SingleOrDefault(x => x.BookShelfId == id);
            if (item == null)
                return BadRequest();


            return Ok(_mapper.MapEntityToModel(item));
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookShelf item)
        {
            item.BookShelfId = 0;
            _ctx.Add(item);
            return  _ctx.SaveChanges() > 0 ? Created() : BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookShelf item)
        {
            var old = _ctx.BookShelves.SingleOrDefault(x => x.BookShelfId == item.BookShelfId);
            if (old == null)
                return BadRequest();

            old.Code = item.Code;
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById(int id)
        {
            var item = _ctx.BookShelves.SingleOrDefault(x => x.BookShelfId == id);
            if (item == null)
                return BadRequest();
            _ctx.Remove(item);
            return _ctx.SaveChanges() > 0 ? Ok() : BadRequest();
        }
    }
}
