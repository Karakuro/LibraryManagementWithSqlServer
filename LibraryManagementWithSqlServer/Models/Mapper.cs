using LibraryManagementWithSql.Data;

namespace LibraryManagementWithSqlServer.Models
{
    public class Mapper
    {
        public BookModel MapEntityToModel(Book entity)
        {
            BookModel model = new BookModel()
            {
                Id = entity.BookId,
                GenreId = entity.GenreId,
                GenreName = entity.Genre?.Description,
                IsOut = entity.IsOut,
                Price = entity.Price,
                ShelfId = entity.BookShelfId,
                Title = entity.Title
            };
            return model;
        }

        public ShelfModel MapEntityToModel(BookShelf entity)
        {
            ShelfModel model = new ShelfModel()
            {
                Id = entity.BookShelfId,
                Code = entity.Code,
                Books = entity.Books?.ConvertAll(MapEntityToModel)
            };
            return model;
        }
    }
}
