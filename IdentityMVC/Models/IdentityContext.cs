using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityMVC.Models;

public class IdentityContext(DbContextOptions<IdentityContext> options) : IdentityDbContext<AppUser>(options)
{
}
