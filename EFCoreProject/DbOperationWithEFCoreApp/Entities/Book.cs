﻿namespace DbOperationWithEFCoreApp.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NoOfPages { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}