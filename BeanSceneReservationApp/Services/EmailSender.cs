using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System.Threading.Tasks;

namespace BeanSceneReservationApp.Services
{
    // Outer class EmailSender
    // This class implements the IEmailSender interface to send emails using SMTP
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        // Constructor for the outer class EmailSender
        // Initializes an instance of EmailConfiguration with the provided parameters
        public EmailSender(string smtpServer, int port, string username, string password)
        {
            _emailConfig = new EmailConfiguration(smtpServer, port, username, password);
        }

        // Method to send an email asynchronously
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Create a new email message
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your Name", _emailConfig.Username));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;

            // Set the HTML body of the email
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = htmlMessage
            };
            message.Body = bodyBuilder.ToMessageBody();

            // Send the email using the SMTP client
            using (var client = new SmtpClient())
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.StartTls);
                client.Authenticate(_emailConfig.Username, _emailConfig.Password);
                client.Send(message);
                client.Disconnect(true);
            }

            return Task.CompletedTask;
        }

        // Inner class: EmailConfiguration
        // This class holds the SMTP configuration details
        private class EmailConfiguration
        {
            // Constructor for the inner class EmailConfiguration
            // Initializes the SMTP server settings
            public EmailConfiguration(string smtpServer, int port, string username, string password)
            {
                SmtpServer = smtpServer;
                Port = port;
                Username = username;
                Password = password;
            }

            // Properties to hold the SMTP server settings
            public string SmtpServer { get; }
            public int Port { get; }
            public string Username { get; }
            public string Password { get; }
        }
    }
}
