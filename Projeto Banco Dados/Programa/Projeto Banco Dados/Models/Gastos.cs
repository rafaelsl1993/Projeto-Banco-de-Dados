using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banco_Dados.Models
{
    public class Gastos
    {
        public int id_gastos;//pk
        public int id_plantio;//fk
        public int quantidade;
        public string tipo_produto;
    }
}