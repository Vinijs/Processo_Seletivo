using Processo_Seletivo_Programador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Processo_Seletivo_Programador.DAL
{
    public class Conexao
    {
        public static void Main(string[] args)
        {
            using (var context = new ContatoContext())
            {
                var quantidade_contatos = context.Contatos.Count();
            }
        }
    }
}