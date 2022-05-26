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
//builder.Services.AddTransient<IUser, UserRepository>();
//builder.Services.AddTransient<SecurityHelper>();
ExtendedProgram.WebApplicationBuilder(builder);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    ApplicationContext appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    DbObjects.Initial(appContext);
}

app.UseMvcWithDefaultRoute();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "Account",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
