﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banco_Dados.Models
{
    public class Estoque_Vendas
    {
        public ObjectId _id;
        public string tipo_plantio;//pk
        public int quantidade_total;
    }
}