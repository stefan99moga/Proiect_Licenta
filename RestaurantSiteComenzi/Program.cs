using Microsoft.EntityFrameworkCore;
using RestaurantSiteComenzi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddMvc();

//Fetching Connection string from APPSETTINGS.JSON  
var ConnectionString = builder.Configuration.GetConnectionString("RestaurantConstr");

//Entity Framework  
builder.Services.AddDbContext<RestaurantContext>(options => options.UseSqlServer(ConnectionString));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        "default",
        "{controller=Home}/{action=Index}/{id?}");
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
