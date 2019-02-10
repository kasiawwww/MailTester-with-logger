using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace MailService
{
    public static class MailService
    {
        public static bool Send(MailModel model)
        {
            Info info = new Info("SendMailInfo.txt");
            Error error = new Error("SendMailError.txt");
            try
            {
                info.Log("Próba wysłania wiadomości"); // Do pliku SendMailInfo.txt
                var message = new MailMessage();
                message.From = new MailAddress(model.MailFrom, model.MailFrom);
                model.MailTo.ForEach(m => message.To.Add(new MailAddress(m)));
                message.Subject = model.Title;
                message.Body = model.Body;
                var smtp = new SmtpClient(AppSettings.Get<string>("smtp")); //To do App.config
                smtp.UseDefaultCredentials = AppSettings.Get<bool>("UseDefaultCredentials"); //To do App.config
                smtp.Credentials = new NetworkCredential(AppSettings.Get<string>("Credentials"), AppSettings.Get<string>("Password")); //To do App.config
                smtp.EnableSsl = AppSettings.Get<bool>("EnableSsl"); //To do App.config
                smtp.Port = AppSettings.Get<int>("Port"); //To do App.config
                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                error.Log(ex.Message); // Do pliku SendMailError.txt
                return false;
            }
        }
    }
}
