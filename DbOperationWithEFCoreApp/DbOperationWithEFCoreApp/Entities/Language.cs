namespace DbOperationWithEFCoreApp.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Book> Book { get; set; }
    }
}
