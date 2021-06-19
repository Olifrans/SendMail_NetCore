using Microsoft.AspNetCore.Mvc;
using QuickMailer;
using OlifransSendMail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlifransSendMail.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Enviar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Enviar(MensagenEmail mensagenEmail)
        {
            try
            {
                List<string>emailAdresses = new List<string>();
                Email email = new Email();


                if (!string.IsNullOrEmpty(mensagenEmail.Para))
                {
                    var mails = mensagenEmail.Para.Split(',');
                    foreach (var mail in mails)
                    {
                        bool isValid = mail.IsValidEmail(mail);
                        //bool isValid = mail.IsValidEmail(mail);
                    }
                }
                string msg = "Falha ao enviar email.";

             
                bool isSend = email.SendEmail(mensagenEmail.Para, CredencialEmail.Email, CredencialEmail.Senha, mensagenEmail.Assunto,
                    mensagenEmail.CorpoEmail);
                
                if (true)
                {
                   msg = "Email enviado com sucesso.";
                }
                ViewBag.Msg = msg;
                return View();
            }
            catch (Exception fr)
            {
                Console.WriteLine(fr);
                throw;
                //Less secure apps - Sign in - Google Accounts
            }


        }
    }
}
