using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsingIdentity.Areas.Identity;
using UsingIdentity.Areas.Identity.Data;
using UsingIdentity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("UsingIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'UsingIdentityContextConnection' not found.");

builder.Services.AddDbContext<UsingIdentityContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<UsingIdentityContext>();
//builder.Services.AddDefaultIdentity<UsingIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<UsingIdentityContext>();
builder.Services.AddIdentityCore<UsingIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UsingIdentityContext>()
    .AddDefaultTokenProviders();
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<UsingIdentityContext>()
//    .AddDefaultTokenProviders()
//    .AddDefaultUI();

builder.Services.Configure<IdentityOptions>(opt => {
    opt.Password.RequiredLength = 6;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = false;
    opt.User.RequireUniqueEmail = true;
    opt.Lockout.MaxFailedAccessAttempts = 3;
    opt.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(10);
});
//builder.Services.AddHttpContextAccessor();
//builder.Services.ConfigureApplicationCookie(options => {
//    options.LoginPath = "/Auth/SignIn";
//});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
