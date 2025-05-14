using Microsoft.EntityFrameworkCore;
using UsingIdentity.Data;

namespace UsingIdentity.Areas.Identity.Data
{
    public class IdentityHostingStartup: IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<UsingIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UsingIdentityContextConnection")));

                services.AddDefaultIdentity<UsingIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<UsingIdentityContext>();
            });
        }
    }
}
