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
                List<string>toMailAdress = new List<string>();
                Email email = new Email();
                toMailAdress = GetValidMail(mensagenEmail.Para);

                string msg = "Falha ao enviar email.";
                
                bool isSend = email.SendEmail(toMailAdress, CredencialEmail.Email, CredencialEmail.Password, mensagenEmail.Assunto,
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
                
            }
        }


        public List<string> GetValidMail(List<string> mails)
        {
            List<string>validMails = new List<string>();
            Email email = new Email();

            if (mails.Any())
            {
                foreach (var mail in mails)
                {
                    bool isValid = email.IsValidEmail(mail);
                    if (isValid)
                    {
                        validMails.Add(mail);
                    }
                }              
            }
            return validMails;
        }

        //Suport
        //Less secure apps - Sign in - Google Accounts - permissão aap google
        //https://select2.org/ 
    }
}
