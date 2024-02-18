using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Mail
{
    public class EmailSender : IEmailSender<DomainUser>
    {
        private readonly SmtpClient _smtpClient;
        private readonly ILogger<EmailSender> _logger;
        public EmailSender(ILogger<EmailSender> logger)
        {
            _smtpClient = new SmtpClient
            {
                Host = "mail.rasha.co", // your smtp server
                Port = 465, // or your smtp port
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential("rs\\hesam", "H@53624")
            };
            _logger = logger;
        }
        public async Task SendConfirmationLinkAsync(DomainUser user, string email, string confirmationLink)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("mofidi@example.com"),
                Subject = "Confirm your email",
                Body = $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.",
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            await _smtpClient.SendMailAsync(mailMessage);
        }

        public async Task SendPasswordResetCodeAsync(DomainUser user, string email, string resetCode)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("mofidi@rasha.co"),
                Subject = "Reset Password",
                //Body = $"Your password reset code is: {resetCode}",
                Body = $"Hello its a test sender email",
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);
            _logger.LogInformation("Sending reset password code to {Email}", email);
            await _smtpClient.SendMailAsync(mailMessage);
            _logger.LogInformation("reset password code sent to {Email}", email);
        }

        public async Task SendPasswordResetLinkAsync(DomainUser user, string email, string resetLink)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("username@example.com"),
                Subject = "Reset Password",
                Body = $"Please reset your password by <a href='{resetLink}'>clicking here</a>.",
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);
            try
            {
                await _smtpClient.SendMailAsync(mailMessage);
            }
            catch (SmtpException ex)
            {
                _logger.LogError(ex, "Error sending email");
                throw;
            }
        }
    }
}
