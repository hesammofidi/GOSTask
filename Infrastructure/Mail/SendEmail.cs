using Aspose.Email.Clients.Exchange.Dav;
using Aspose.Email.Clients.Exchange.WebService;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aspose.Email.Clients.Exchange;
using Aspose.Email.Mime;
using System.Threading.Tasks;
using Aspose.Email.Clients.Smtp;
using System.Web;
namespace Infrastructure.Mail
{
    public class SendEmail : IEmailSender<User>
    {
        private SmtpClient _smtpClient;
        private IEWSClient _exchangeClient;

        public SendEmail()
        {
            //var currentUser = HttpUtility.UrlEncode("rs\\hesam");
            _smtpClient = new SmtpClient("mail.rasha.co");
            _smtpClient.Timeout = 20000;
            _exchangeClient = EWSClient.GetEWSClient("https://mail.rasha.co/EWS/Exchange.asmx", "hesam", "H@53624","rasha.co");
        }


        public Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
        {
            throw new NotImplementedException();
        }

        public Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
        {
            var mailMessage = new Aspose.Email.MailMessage("Mofidi@rasha.co", email, "Password Reset Code",
                $"Hello {user.Email},\n\nYour password reset code is: {resetCode}");

            _smtpClient.Send(mailMessage);
            _exchangeClient.Send(mailMessage);

            return Task.CompletedTask;
        }

        public Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
        {
            throw new NotImplementedException();
        }
    }
}
