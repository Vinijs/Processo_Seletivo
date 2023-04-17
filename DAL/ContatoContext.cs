using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Processo_Seletivo_Programador.Models
{
    public class ContatoContext: DbContext
    {

        public ContatoContext(): base("ContatoContext"){  }

        //DbSet<Contato> Contatos { get; set; }

        public System.Data.Entity.DbSet<Processo_Seletivo_Programador.Models.Contato> Contatos { get; set; }
    }
}