using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banco_Dados.Models
{
    public class Vendas
    {
        public ObjectId _id;
        public int id_venda;//pk
        public string tipo_plantio;//fk
        public string documento_cliente;
        public string status;
        public DateTime data_venda;
        public float valor;
        public int quantidade;
    }
}