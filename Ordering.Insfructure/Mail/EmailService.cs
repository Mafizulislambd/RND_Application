using Ordering.Application.Contacts.Insfrastructure;
using Ordering.Application.Models;
using QuickMailer;

namespace Ordering.Insfructure.Mail
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SenddEmailAsync(EmailMessage mailServices)
        {
            Email email = new Email();
            if (email.IsValidEmail(mailServices.To))
            {
                return email.SendEmail(mailServices.To, EmailCredential.EmailAddress,EmailCredential.Password, mailServices.Subject, mailServices.Body);

            }
            return false;
        }
    }
}
