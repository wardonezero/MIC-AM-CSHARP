using IdentityMVC.Infrastructure;
using IdentityMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IPasswordValidator<AppUser>,CustomPasswordValidator>();

builder.Services.AddDbContext<IdentityContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddIdentity<AppUser,IdentityRole>()
//    .AddEntityFrameworkStores<IdentityContext>()
//    .AddDefaultTokenProviders();


builder.Services.AddIdentity<AppUser, IdentityRole>(option =>
{
    option.Password.RequiredLength = 12;
    option.Password.RequireNonAlphanumeric = true;
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = true;
    option.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<IdentityContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
