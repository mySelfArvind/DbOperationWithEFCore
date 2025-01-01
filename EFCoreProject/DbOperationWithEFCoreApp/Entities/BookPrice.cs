namespace DbOperationWithEFCoreApp.Entities
{
    public class BookPrice
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public double Amount { get; set; }
        public int CurrencyId { get; set; }
    }
}
