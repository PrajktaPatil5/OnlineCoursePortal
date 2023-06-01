using OnlineCoursePortalWeb.Services;
using OnlineCoursePortalWeb.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineCoursePortal.DataAccess.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
//using OnlineCoursePortalWeb.Data;
//using OnlineCoursePortal.DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'OnlineCoursePortalWebContextConnection' not found.");



builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddHttpClient<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddHttpClient<ICourseBookingService, CourseBookingService>();
builder.Services.AddScoped<ICourseBookingService, CourseBookingService>();
builder.Services.AddHttpClient<IApplicationUserService, ApplicationUserService>();
builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.SlidingExpiration = true;
    });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});
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
app.MapRazorPages();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Course}/{action=Index}/{id?}");

app.Run();
