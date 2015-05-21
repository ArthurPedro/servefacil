using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ServeFacil.Controllers
{
    public class ContatoController : Controller
    {
        public ActionResult EnviarContato(string nome,string emailRemetente, string assunto,string mensagen)
        {                    
            string email = "servefacil@gmail.com";
            string senha = "servefacil2015";            

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(email, nome, System.Text.Encoding.UTF8);
            mail.Subject = assunto;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = mensagen + "<br/>E-mail: " + emailRemetente;
            mail.BodyEncoding = (System.Text.Encoding.UTF8);
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(email, senha);
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);                                                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
                //return JavaScript ("\$( ’\# divResultText ’). html (’ JavaScript Passed ’);");
            }            
        }        
    }
}

