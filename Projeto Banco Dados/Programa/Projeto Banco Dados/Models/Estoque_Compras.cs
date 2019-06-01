using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banco_Dados.Models
{
    public class Estoque_Compras
    {
        public ObjectId _id;
        public string tipo_produto;//pk
        public int quantidade;
        public string medida;
    }
}