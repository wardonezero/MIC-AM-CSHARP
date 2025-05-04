using PublisherDomain;
using Microsoft.EntityFrameworkCore;

namespace PublisherData;
public class PubContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Heare You Need To Add Your Server Instead Of DESKTOP-S9KHPNV\\WARDONEZERO
        optionsBuilder.UseSqlServer("Server=DESKTOP-S9KHPNV\\WARDONEZERO;Database=PubDatabase;Trusted_Connection=True;TrustServerCertificate=True");
    }
}