using Servicios.DAL.Contracts;
using Servicios.DAL.Factory;
using Servicios.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Servicios.DAL.Implementations.Decorator
{
    internal class EmailDecorator : BaseLoggerDecorator
    {
        public EmailDecorator(ILogger parent) : base(parent){ }

        public override List<Log> GetAll()
        {
            return wrapper.GetAll();
        }

        public override void Store(Log oneLog)
        {
            wrapper.Store(oneLog);
            if (oneLog.message.Contains("CriticalError")) {
                sendEmail(ApplicationSettings.getEmailCriticalErrorAddress(), "CriticalError", LogMapper.toString(oneLog));
            }
            if (oneLog.message.Contains("FatalError")) {
                sendEmail(ApplicationSettings.getEmailFatalErrorAddress(), "FatalError", LogMapper.toString(oneLog));
            }
        }

        private void sendEmail(string to, string title, string message) {
            using (MailMessage email = new MailMessage(ApplicationSettings.getEmailSenderAccount(), to)) {
                email.Subject = title;
                email.Body = message;
                email.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient(ApplicationSettings.getEmailHost(), ApplicationSettings.getEmailPort());
                smtp.EnableSsl = true;
                NetworkCredential credential = new NetworkCredential(ApplicationSettings.getEmailSenderAccount(), ApplicationSettings.getEmailSenderPassword());
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = credential;
                try {
                    smtp.Send(email);
                } catch (Exception ex) {
                    throw new Exception("No se pudo enviar el email", ex.InnerException);
                } finally {
                    smtp.Dispose();
                }
            }
        }

    }
}
