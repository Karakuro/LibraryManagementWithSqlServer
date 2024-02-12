namespace LibraryManagementWithSql.Data
{
    public class BookShelf
    {
        public int BookShelfId { get; set; }
        public string Code { get; set; }
        public List<Book> Books { get; set; }
    }
}
