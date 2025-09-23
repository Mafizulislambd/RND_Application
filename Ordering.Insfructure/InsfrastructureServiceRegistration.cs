using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Contacts.Insfrastructure;
using Ordering.Application.Contacts.Persistence;
using Ordering.Insfructure.Mail;
using Ordering.Insfructure.Persistence;
using Ordering.Insfructure.Repository;

namespace Ordering.Insfructure
{
    public static class InsfrastructureServiceRegistration
    {
        public static IServiceCollection AddInsfructureService(this IServiceCollection services,IConfiguration configuration)
        {
            // Fixed missing semicolon and added required parameter for UseSqlServer
            services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("OrderDB")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddTransient<IEmailService, EmailService>();
            return services; // Added return statement to complete the method
        }
    }
}
