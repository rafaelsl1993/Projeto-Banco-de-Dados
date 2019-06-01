using MongoDB.Bson;
using MongoDB.Driver;
using Projeto_Banco_Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banco_Dados.Repository
{
    public class VendasRepository
    {
        private IMongoCollection<Vendas> InstanciarConexao()
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("Banco_Mongo");
                var colecao = database.GetCollection<Vendas>("Vendas");
                Console.WriteLine("Aplicação rodando.");
                return colecao;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
                return null;
            }
        }

        public bool Insert(Vendas c)
        {
            if (c != null)
            {
                var colecao = this.InstanciarConexao();
                colecao.InsertOne(c);
                return true;
            }
            return false;
        }
        public bool Update(Vendas c)
        {
            if (c != null)
            {
                var colecao = this.InstanciarConexao();
                /*
                 * Exemplo de update
                var filtro = Builders<Vendas>.Filter.Eq(x =>x.documento , "123456");
                var alteracao = Builders<Vendas>.Update.Set(x => x.documento, "987654");
                colecao.UpdateOne(filtro,alteracao);
                colecao.UpdateMany(filtro, alteracao);
                */
                return true;
            }
            return false;
        }
        public bool Delete(Vendas c)
        {
            if (c != null)
            {
                var colecao = this.InstanciarConexao();
                /*
                 * Exemplo de delete
                var filtro = Builders<Vendas>.Filter.Eq(x =>x.documento , "123456");
                colecao.DeleteOne(filtro);
                colecao.DeleteMany(filtro);
                Console.WriteLine($"{resultado.DeletedCount} documento(s) excluído(s).");
               */
                return true;
            }
            return false;
        }

        private IMongoCollection<Cliente> InstanciarConexaoCliente()
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("Banco_Mongo");
                var colecao = database.GetCollection<Cliente>("Cliente");
                Console.WriteLine("Aplicação rodando.");
                return colecao;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
                return null;
            }
        }
        public List<Vendas> Select()
        {
            var colecao = this.InstanciarConexao();
            var colecao2 = this.InstanciarConexaoCliente(); 
           

            return lista;
        }
    }
}