using HomeRentTracker.Models;
using HomeRentTracker.Services.Contract;
using HomeRentTracker.Services.Repos;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//    .AddUserStore<CustomUserStore>() // Use your custom store
//    .AddDefaultTokenProviders();
builder.Services.AddIdentity<UserInfo, IdentityRole>()
    .AddUserStore<AuthRepos>() // Use your custom store
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IUserStore<UserInfo>, AuthRepos>();
builder.Services.AddScoped<IPasswordHasher<UserInfo>, PasswordHasher<UserInfo>>();
builder.Services.AddScoped<IRoleStore<IdentityRole>, RoleStore>();

//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//    .AddDefaultTokenProviders();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IFlatService, FlatService>();
builder.Services.AddScoped<IUserServices, UserRepository>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Accont/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});
builder.Services.AddSession
    (options =>
{
    // Set a short timeout for easy testing.
    //options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    // Make the session cookie essential
    options.Cookie.IsEssential = true;
});
builder.Services.Configure<IdentityOptions>(opt =>
{  // Password settings.
    //opt.Password.RequireDigit = true;
    //opt.Password.RequireLowercase = true;
    //opt.Password.RequireNonAlphanumeric = true;
    //opt.Password.RequireUppercase = true;
    //opt.Password.RequiredLength = 6;
    //opt.Password.RequiredUniqueChars = 1;
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequiredLength = 1;
    opt.Password.RequiredUniqueChars = 0;

    // Lockout settings.
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    opt.Lockout.MaxFailedAccessAttempts = 5;
    opt.Lockout.AllowedForNewUsers = true;

    //USer Setting
    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    opt.User.RequireUniqueEmail = false;
});
builder.Services.AddHttpContextAccessor();
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
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
