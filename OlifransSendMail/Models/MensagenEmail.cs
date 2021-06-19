using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlifransSendMail.Models
{
    public class MensagenEmail
    {
        public List<string> Para { get; set; }
        public List<string> Cc { get; set; }
        public string Assunto { get; set; }
        public string CorpoEmail { get; set; }
    }
}
