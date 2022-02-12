using Microsoft.Extensions.Configuration;
using MonkLab_Test.Data;
using MonkLab_Test.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace MonkLab_Test.Common
{
    public class MainRouteLogic
    {
       

        public void sendMessage(Message data,IConfiguration Configuration,AppDbContext context)
        {
            SentMessage mes = new SentMessage();

            

            SmtpClient Smtp = new SmtpClient(Configuration["SmtpConfig:SmtpServer"], int.Parse(Configuration["SmtpConfig:SmtpPort"]));
            Smtp.Credentials = new NetworkCredential(Configuration["SmtpConfig:UserName"], Configuration["SmtpConfig:SmtpPassword"]);
            Smtp.EnableSsl = true;
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress(Configuration["SmtpConfig:UserName"]);
            Message.To.Add(new MailAddress(data.recipients[0]));
            Message.Subject = data.Subject;
            Message.Body = data.Body;
           
            string error_message = null;
            for (int i = 1; i < data.recipients.Length; i++)
            {
                Message.Bcc.Add(data.recipients[i]);
            }
            try
            {
                Smtp.Send(Message);
            }
            catch (SmtpException ex)
            {
                error_message = ex.Message;
                
            }

            if (error_message!=null)
            {
                mes.FailedMessage = error_message;
                mes.Result = RequestResult.Failed;
            }
            else
            {
                mes.Result = RequestResult.Ok;
            }
            mes.Body = data.Body;
            mes.Subject = data.Subject;
            mes.recipients = JsonConvert.SerializeObject(data.recipients);
            mes.CreatedDate = DateTime.Now;
            context.SentMessages.Add(mes);
            context.SaveChanges();

        }
        public IEnumerable<SentMessage> GetMessages(AppDbContext context)
        {
            return context.SentMessages.Select(x => x);
        }
    }
}
