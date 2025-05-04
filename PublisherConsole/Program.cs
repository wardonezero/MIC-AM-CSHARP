using PublisherData;
using PublisherDomain;
using static System.Console;

using (PubContext context = new())
{
    context.Database.EnsureCreated();
}

while (true)
{
    WriteLine(">>> Existing Authors <<<");
    GetAuthors();
    WriteLine();
    AddAuthors();
    WriteLine();
}

void AddAuthors()
{
    Write("Add Author Name: ");
    string? firstname = ReadLine();
    Write("Add Author Lastname: ");
    string? lastname = ReadLine();
    var author = new Author { FirstName = firstname, LastName = lastname };
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();
    foreach (var author in authors)
    {
        WriteLine(author.FirstName + " " + author.LastName);
    }
}