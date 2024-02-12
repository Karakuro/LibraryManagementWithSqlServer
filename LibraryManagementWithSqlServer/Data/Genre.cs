namespace LibraryManagementWithSql.Data
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Description { get; set; }
        public List<Book> Books { get; set; }
    }
}
