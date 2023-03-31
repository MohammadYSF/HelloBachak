using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers.EmailService
{
    public class MockEmailService : IEmailService
    {
        public bool Send(MailMessage mailMessage, string destEmailAddress)
        {
            return true;
        }
    }
}
