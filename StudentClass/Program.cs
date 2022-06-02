using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using StudentClass;
using StudentClass.Data;
using StudentClass.Data.Helpers;
using StudentClass.Data.Interfaces;
using StudentClass.Data.Models;
using StudentClass.Data.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(x=>x.EnableEndpointRouting = false);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/Login";
    });
builder.Services.AddAuthorization();
builder.Services.Configure<AuthorizationOptions>(options =>
{
    options.AddPolicy("AdminArea", policy => policy.RequireClaim("Role", "Admin"));
    options.AddPolicy("AdminArea", policy => policy.RequireClaim("Role", "Teacher"));

});
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
