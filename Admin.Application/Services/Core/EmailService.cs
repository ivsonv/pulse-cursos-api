using Admin.Domain.Helpers;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Admin.Application.Services.Core
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void Send(Domain.Models.DTO.EmailDto dto)
        {
            if(dto.Body.IsEmpty())
                Task.Run(() => this.sendSMTP(dto));
        }

        private void sendSMTP(Domain.Models.DTO.EmailDto dto)
        {
            var _mail = new MailMessage()
            {
                From = new MailAddress(_configuration["email:user"], dto.Display ?? dto.Title),
                Priority = MailPriority.High,
                Subject = dto.Title,
                IsBodyHtml = true,
                Body = dto.Body
            };

            dto.Email.Split(';').ToList().ForEach(fe =>
            {
                _mail.To.Add(new MailAddress(fe));
            });

            //
            var _smtp = new SmtpClient()
            {
                Credentials = new NetworkCredential(_configuration["email:user"], _configuration["email:password"]),
                Port = _configuration["email:port"].ToInt(),
                Host = _configuration["email:host"],
                EnableSsl = true
            };
            _smtp.Send(_mail);
        }
    }
}
