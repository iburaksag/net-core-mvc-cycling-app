using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RunGroopWebApp.Data;
using RunGroopWebApp.Data.Abstract;
using RunGroopWebApp.Helpers;
using RunGroopWebApp.Models;
using RunGroopWebApp.Repository;
using RunGroopWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddScoped<IClubRepository, ClubRepository>();
builder.Services.AddScoped<IRaceRepository, RaceRepository>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//services for Identity framework.
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddMemoryCache(); //add this to avoid error
builder.Services.AddSession(); 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(); //adding this for cookie authentication

var app = builder.Build();

if(args.Length == 1 && args[0].ToLower() == "seeddata")
{
    await Seed.SeedUsersAndRolesAsync(app);
    //Seed.SeedData(app);
}

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

