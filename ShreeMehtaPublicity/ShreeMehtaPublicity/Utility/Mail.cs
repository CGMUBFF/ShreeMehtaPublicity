using ShreeMehtaPublicity.MODEL;
using System;
using System.Collections.ObjectModel;
using System.Net.Mail;

namespace ShreeMehtaPublicity.Utility
{
    public class Mail
    {
        private bool SendMail(MailMessage message)
        {
            String FromMailUserName = "sanghavimohit17@gmail.com";
            String FromMailPassword = "Mms@3250";
            message.From = new MailAddress(FromMailUserName);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,

                Credentials = new System.Net.NetworkCredential(FromMailUserName, FromMailPassword)
            };
            try
            {
                client.Send(message);
                return true;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                return false;
            }
        }

        public String SendCautation(ObservableCollection<ClientModel> clientList, string body, string subject, string cautationFileName)
        {
            MailMessage message = new MailMessage();

            foreach (ClientModel client in clientList)
            {
                message.To.Add(client.ClientMail);
            }
            message.Subject = subject;
            body = body.Replace("\r\n", "<br/>");
            message.Body = body;
            message.IsBodyHtml = true;
            message.Attachments.Add(new Attachment(cautationFileName));

            bool isMailSend = SendMail(message);

            if (isMailSend)
            {
                return Status.SUCC;
            }
            else
            {
                return Status.ERR;
            }
        }
    }
}
