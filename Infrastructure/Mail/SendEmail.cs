using Aspose.Email.Clients.Exchange.WebService;
using Aspose.Email.Clients.Smtp;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using MimeKit;

using MailKit.Net.Smtp;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Infrastructure.Mail
{
    public class SendEmail : IEmailSender<DomainUser>
    {

        private string exchangeServer = "smtp.office365.com";
        private int exchangePort = 587;
        private string username = "notify@rasha.co";
        private string password = "Cav81872";

        public async Task SendConfirmationLinkAsync(DomainUser user, string email, string confirmationLink)
        {
            await SendEmailAsync(user, email, "Confirmation Link", confirmationLink);
        }

        public async Task SendPasswordResetCodeAsync(DomainUser user, string email, string resetCode)
        {
            await SendEmailAsync(user, email, "Password Reset Code", resetCode);
        }

        public async Task SendPasswordResetLinkAsync(DomainUser user, string email, string resetLink)
        {
            await SendEmailAsync(user, email, "Password Reset Link", resetLink);
        }

        private async Task SendEmailAsync(DomainUser user, string email, string subject, string message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("rasha.co", "info@rasha.co"));
            mimeMessage.To.Add(new MailboxAddress(user.FullName, email));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart("plain")
            {
                Text = message
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(exchangeServer, exchangePort, false);
                await client.AuthenticateAsync(username, password);
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
