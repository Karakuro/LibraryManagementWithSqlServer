namespace LibraryManagementWithSqlServer.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public bool IsOut { get; set; }
        public int GenreId { get; set; }
        public int? ShelfId { get; set; }
        public string? GenreName { get; set; }
    }
}
