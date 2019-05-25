using MongoDB.Driver;
using Projeto_Banco_Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banco_Dados.Repository
{
    public class ProducaoRepository
    {
        private IMongoCollection<Producao> InstanciarConexao()
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("Banco_Mongo");
                var colecao = database.GetCollection<Producao>("Producao");
                Console.WriteLine("Aplicação rodando.");
                return colecao;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
                return null;
            }
        }
        public bool Insert(Producao c)
        {
            if (c != null)
            {
                var colecao = this.InstanciarConexao();
                colecao.InsertOne(c);
                return true;
            }
            return false;
        }
        public bool Update(Producao c)
        {
            if (c != null)
            {
                var colecao = this.InstanciarConexao();
                /*
                 * Exemplo de update
                var filtro = Builders<Producao>.Filter.Eq(x =>x.documento , "123456");
                var alteracao = Builders<Producao>.Update.Set(x => x.documento, "987654");
                colecao.UpdateOne(filtro,alteracao);
                colecao.UpdateMany(filtro, alteracao);
                */
                return true;
            }
            return false;
        }
        public bool Delete(Producao c)
        {
            if (c != null)
            {
                var colecao = this.InstanciarConexao();
                /*
                 * Exemplo de delete
                var filtro = Builders<Producao>.Filter.Eq(x =>x.documento , "123456");
                colecao.DeleteOne(filtro);
                colecao.DeleteMany(filtro);
                Console.WriteLine($"{resultado.DeletedCount} documento(s) excluído(s).");
               */
                return true;
            }
            return false;
        }
        public List<Producao> Select(int doc)
        {
            var colecao = this.InstanciarConexao();
            var filtro = Builders<Producao>.Filter.Where(x => x.id_plantio == doc);
            var lista = colecao.Find(filtro).ToList();
            return lista;
        }
    }
}