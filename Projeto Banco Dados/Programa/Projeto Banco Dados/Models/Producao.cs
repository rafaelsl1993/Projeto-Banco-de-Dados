using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banco_Dados.Models
{
    public class Producao
    {
        public ObjectId _id;
        public int id_plantio;//pk
        public string tipo_plantio;//fk
        public string status;
        public int hectares;
        public int quantidade;
        public DateTime data_inicio;
        public DateTime data_fim;
    }
}