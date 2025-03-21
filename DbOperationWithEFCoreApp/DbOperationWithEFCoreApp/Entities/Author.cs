﻿namespace DbOperationWithEFCoreApp.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? AddressId { get; set; }
        public virtual Address? Address { get; set; }

        //public List<Book>? Book { get; set; }
    }
}
