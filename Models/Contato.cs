using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Processo_Seletivo_Programador.Models
{
    public class Contato
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public DateTime Data { get; set; }
    }
}