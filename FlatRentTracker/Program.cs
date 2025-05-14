using FlatRentTracker.Services;
using FlatRentTracker.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FlatRentTracker.Areas.Identity.Data;
using FlatRentTracker.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FlatRentTrackerContextConnection") ?? throw new InvalidOperationException("Connection string 'FlatRentTrackerContextConnection' not found.");

builder.Services.AddDbContext<FlatRentTrackerContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<FlatRentTrackerUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<FlatRentTrackerContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFlatService, FlatService>();
//builder.Services.AddScoped<IHttpClientFactory>();
builder.Services.AddHttpClient();
builder.Services.AddSession();
builder.Services.AddControllersWithViews(); // or AddRazorPages()
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.Cookie.Name = "MyApp.AuthToken";
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });

builder.Services.AddHttpClient();
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

var app = builder.Build();

app.UseSession();
app.UseRouting();
app.UseAuthentication(); // if using cookie fallback
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();
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
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.Run();
