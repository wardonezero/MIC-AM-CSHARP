﻿namespace PublisherDomain;
public class Book
{
    public int BookID { get; set; }
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public decimal BasePrice { get; set; }
    public int AutherID { get; set; }
}