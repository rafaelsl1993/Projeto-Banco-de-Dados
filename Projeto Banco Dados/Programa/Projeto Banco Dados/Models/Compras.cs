using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banco_Dados.Models
{
    public class Compras
    {
        public int id_compra;//pk
        public string tipo_produto;//fk
        public float valor;
        public DateTime data_compra;
        public string documento_fornecedor;
        public int quantidade;
        public string status;
    }
}