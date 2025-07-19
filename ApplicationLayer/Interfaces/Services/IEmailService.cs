using ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailrequest);
        Task<string> GenerateConfirmationEmailBodyAsync(string userName, string email, string token);
        string GenerateEmailConfirmationToken();
    }
}
