using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarbearia.Models
{
    public class clAtendimento
    {
        public string codAtend { get; set; }
        public string dataAtend { get; set; }
        public string horaAtend { get; set; }
        public string confAgendamento { get; set; }


        public string codBarbeiro { get; set; }
        public string codCli { get; set; }
    }
}