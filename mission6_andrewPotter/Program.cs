using Microsoft.EntityFrameworkCore;
using mission6_andrewPotter.Models;

var builder = WebApplication.CreateBuilder(args);

// ? Configure Database Connection BEFORE building the app
builder.Services.AddDbContext<MoviesContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection"));
});

// ? Add services for MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
