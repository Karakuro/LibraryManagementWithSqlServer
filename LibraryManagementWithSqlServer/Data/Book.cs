namespace LibraryManagementWithSql.Data
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public bool IsOut { get; set; }
        public int? BookShelfId { get; set; }
        public int GenreId { get; set; }
        public BookShelf? BookShelf { get; set; }
        public Genre Genre { get; set; }
    }
}
