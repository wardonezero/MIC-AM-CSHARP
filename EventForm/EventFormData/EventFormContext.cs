using EventForm.Models;
using Microsoft.EntityFrameworkCore;

namespace EventForm.EventFormData;

public class EventFormContext(DbContextOptions<EventFormContext> options) : DbContext(options)
{
    public DbSet<GuestResponse> GuestResponses { get; set; }
}
