using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using StudentClass;
using StudentClass.Data;
using StudentClass.Data.Helpers;
using StudentClass.Data.Interfaces;
using StudentClass.Data.Models;
using StudentClass.Data.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(x=>x.EnableEndpointRouting = false);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath = "/login");
builder.Services.AddAuthorization();

IConfigurationRoot _confString = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

ExtendedProgram.WebApplicationBuilder(builder); //builder.Services.AddTransient all there 
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    ApplicationContext appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    DbObjects.Initial(appContext);
}

app.UseAuthentication();
app.UseAuthorization();
app.UseMvcWithDefaultRoute();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "Account",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
