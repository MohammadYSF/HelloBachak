using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers.EmailService
{
    public class GmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public GmailService(IConfiguration config)
        {
            _config = config;
        }
        public bool Send(MailMessage mailMessage, string destEmailAddress)
        {
            try
            {
                var host = _config["Smtp:Host"];
                int port = int.Parse(_config["Smtp:Port"]);

                var sourceEmailAddress = _config["Smtp:Username"];
                var sourceEmailPassword = _config["Smtp:Password"];
                var stmpClient = new SmtpClient(host: host, port: port);
                stmpClient.EnableSsl = true;
                stmpClient.Credentials = new NetworkCredential(sourceEmailAddress, sourceEmailPassword);
                mailMessage.From = new MailAddress(sourceEmailAddress);
                mailMessage.To.Add(destEmailAddress);
                stmpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
           
        }
    }
}
