namespace DbOperationWithEFCoreApp.Entities
{
    public class CurrencyType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual List<Price> Price { get; set; }
    }
}
