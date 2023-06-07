using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BookBaazar.Application.Endpoints.ForgotPassword;
using BookBaazar.Application.Endpoints.Mail;
using BookBaazar.Application.Interfaces.Persistence.DataServices.Mail;
using BookBaazar.Infrastructure.Persistence.DataServices.ForgotPassword;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;

namespace BookBaazar.Infrastructure.Persistence.DataServices.Mail
{
    public class MailService:IMailService
    {
        private readonly BookBazaarDbContext _dbContext;
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettingsOptions, BookBazaarDbContext bookBazaarDbContext)
        {
            _mailSettings = mailSettingsOptions.Value;
            _dbContext = bookBazaarDbContext;
        }
       

        public async Task<bool> SendMailAsync([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            MailData mailData = new MailData();
            var user = await _dbContext.Users.FirstOrDefaultAsync(c=>c.Email==forgotPasswordDto.Email);
            if (user == null)
            {
                return false;
            }
            var temp_pass = RandomPasswordGenerator.GeneratePassword(10);
            user.Temp_Password = BCrypt.Net.BCrypt.HashPassword(temp_pass);
            user.IsTemp = true;
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            string subject = "User Credentials For Forgot Password: ";
            string body = $"Temp Passsword for resetting is :{temp_pass} ";
            //Task emailsender = _emailSenderService.SendEmailAsync(forgotPasswordDto.Email, subject, body);
            mailData.EmailToId = user.Email;
            mailData.EmailToName = user.FirstName + " " + user.LastName;
            mailData.EmailSubject = subject;
            mailData.EmailBody = body;
            try
            {
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    MailboxAddress emailFrom = new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail);
                    emailMessage.From.Add(emailFrom);
                    MailboxAddress emailTo = new MailboxAddress(mailData.EmailToName, mailData.EmailToId);
                    emailMessage.To.Add(emailTo);

                    //emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "adityago563@gmail.com"));
                    //emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "adityago563@gmail.com"));

                    emailMessage.Subject = mailData.EmailSubject;

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.TextBody = mailData.EmailBody;

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();
                    //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        await mailClient.ConnectAsync(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                        await mailClient.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
                        await mailClient.SendAsync(emailMessage);
                        await mailClient.DisconnectAsync(true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Exception Details
                return false;
            }
        }
    }
}
