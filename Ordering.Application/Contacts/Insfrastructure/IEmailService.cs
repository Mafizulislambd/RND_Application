using Ordering.Application.Models;

namespace Ordering.Application.Contacts.Insfrastructure
{
    public  interface IEmailService
    {
        Task<bool> SenddEmailAsync(EmailMessage mail);
    }
}
