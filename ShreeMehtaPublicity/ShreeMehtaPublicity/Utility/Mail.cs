using System.Net.Mail;

namespace ShreeMehtaPublicity.Utility
{
    public class Mail
    {
        public Mail()
        {
            MailMessage message = new MailMessage();
            message.To.Add("sanghavimohit17@gmail.com");
            message.From = new MailAddress("sanghavimohit17@gmail.com");
            message.Subject = "Testing";
            message.Body = "sent successfully";
            message.IsBodyHtml = true;
            message.Attachments.Add(new Attachment("C:\\ShreeMehtaPublicity\\Cautation\\First iText PDF Document.pdf"));
            SmtpClient client = new SmtpClient("smtp.gmail.com",587);

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            
            client.Credentials = new System.Net.NetworkCredential("sanghavimohit17@gmail.com", "Mms@3250");
            string token = "Test token";
            //client.Timeout = 1000;
            try
            {
                client.Send(message);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
            }
        }
    }
}
