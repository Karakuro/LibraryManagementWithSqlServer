namespace LibraryManagementWithSqlServer.Models
{
    public class ShelfModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public List<BookModel>? Books { get; set; }
    }
}
