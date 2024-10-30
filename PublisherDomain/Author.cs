namespace PublisherDomain;
public class Author
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastLastName { get; set; }
    public List<Book> Books { get; set; } = [];
}