using MongoDB.Driver;
using Projeto_Banco_Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banco_Dados.Repository
{
    public class GastosRepository
    {
        private IMongoCollection<Gastos> InstanciarConexao()
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("Banco_Mongo");
                var colecao = database.GetCollection<Gastos>("Gastos");
                Console.WriteLine("Aplicação rodando.");
                return colecao;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
                return null;
            }
        }
        public bool Insert(Gastos c)
        {
            if (c != null)
            {
                var colecao = this.InstanciarConexao();
                colecao.InsertOne(c);
                return true;
            }
            return false;
        }
        public bool Update(Gastos c)
        {
            if (c != null)
            {
                var colecao = this.InstanciarConexao();
                /*
                 * Exemplo de update
                var filtro = Builders<Gastos>.Filter.Eq(x =>x.documento , "123456");
                var alteracao = Builders<Gastos>.Update.Set(x => x.documento, "987654");
                colecao.UpdateOne(filtro,alteracao);
                colecao.UpdateMany(filtro, alteracao);
                */
                return true;
            }
            return false;
        }
        public bool Delete(Gastos c)
        {
            if (c != null)
            {
                var colecao = this.InstanciarConexao();
                /*
                 * Exemplo de delete
                var filtro = Builders<Gastos>.Filter.Eq(x =>x.documento , "123456");
                colecao.DeleteOne(filtro);
                colecao.DeleteMany(filtro);
                Console.WriteLine($"{resultado.DeletedCount} documento(s) excluído(s).");
               */
                return true;
            }
            return false;
        }
        public List<Gastos> Select(int doc)
        {
            var colecao = this.InstanciarConexao();
            var filtro = Builders<Gastos>.Filter.Where(x => x.id_gastos == doc);
            var lista = colecao.Find(filtro).ToList();
            return lista;
        }
    }
}