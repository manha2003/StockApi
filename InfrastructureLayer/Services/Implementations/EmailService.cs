﻿using ApplicationLayer.DTOs;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Interfaces.Services;
using ApplicationLayer.Interfaces.Repositories;

namespace InfrastructureLayer.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings emailSettings;
        private readonly IUserRepository _userRepository;
        private readonly string _templatePath;

        public EmailService(IOptions<EmailSettings> options, IUserRepository userRepository)
        {
            emailSettings = options.Value;
            _userRepository = userRepository;
            _templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Services", "Templates", "ConfirmEmailTemplate.html");
        }

        public async Task SendEmailAsync(MailRequest mailrequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailSettings.Email);
            email.To.Add(MailboxAddress.Parse(mailrequest.ToEmail));
            email.Subject = mailrequest.Subject;
            var builder = new BodyBuilder();



            builder.HtmlBody = mailrequest.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailSettings.Email, emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task<bool> ConfirmEmailAsync(string email, string token)
        {
            var user = await _userRepository.GetByEmailAndTokenAsync(email, token);
            if (user == null || user.IsEmailConfirmed)
            {
                return false;
            }

            user.IsEmailConfirmed = true;
            user.EmailConfirmationToken = null;
            await _userRepository.UpdateAsync(user);

            return true;
        }

        public async Task<string> GenerateConfirmationEmailBodyAsync(string userName, string email, string token)
        {
            string template = await File.ReadAllTextAsync(_templatePath);
            return template.Replace("{{UserName}}", userName)
                           .Replace("{{ConfirmationLink}}", $"http://localhost:5218/api/Auth/confirm-email/?email={email}&token={token}");
        }


        public string GenerateEmailConfirmationToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
