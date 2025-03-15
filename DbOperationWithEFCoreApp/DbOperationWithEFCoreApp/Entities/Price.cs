namespace DbOperationWithEFCoreApp.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public double Amount { get; set; }
        public int CurrencyTypeId { get; set; }

        public virtual Book Book { get; set; }
        public virtual CurrencyType CurrencyType { get; set; }
    }
}
