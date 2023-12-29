using System;
using MailKit.Net.Smtp;
using MimeKit;
using myServerBattleNet.Configuration;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace myServerBattleNet.Service
{
    public class EmailSender : IEmailSender
    {
        private AppSetConfig _config = ConfigerAppSet.AppSet;

        public void SendEmail(string passwrodUser, string emailUser, string subject)
        { 
                try
                {
                    using var emailSender = new MimeMessage();
                    var builder = new BodyBuilder();

                    emailSender.From.Add(new MailboxAddress(_config.FromName, _config.EmailSender));
                    emailSender.To.Add(new MailboxAddress("", emailUser));
                    emailSender.Subject = subject;

                    builder.HtmlBody =
                        $"<h4>This your password and email | Email: {emailUser} | Password: {passwrodUser}</h4>";
                    emailSender.Body = builder.ToMessageBody();

                    using var client = new SmtpClient();
                    client.Connect(_config.SmtpServerHost, _config.SmtpServerPort, true);
                    client.Authenticate(_config.EmailSender, _config.PasswordSender);
                    client.Send(emailSender);
                    client.Disconnect(true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

