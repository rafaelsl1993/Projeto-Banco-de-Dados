using MongoDB.Driver;
using Projeto_Banco_Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Banco_Dados.Repository
{
    public class Estoque_VendasRepository
    {
        private IMongoCollection<Estoque_Vendas> InstanciarConexao()
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("Banco_Mongo");
                var colecao = database.GetCollection<Estoque_Vendas>("Estoque_Vendas");
                Console.WriteLine("Aplicação rodando.");
                return colecao;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
                return null;
            }
        }
        public bool Insert(Estoque_Vendas c)
        {
            if (c != null)
            {
                var colecao = this.InstanciarConexao();
                colecao.InsertOne(c);
                return true;
            }
            return false;
        }
        public bool Update(Estoque_Vendas c)
        {
            if (c != null)
            {
                var colecao = this.InstanciarConexao();
                /*
                 * Exemplo de update
                var filtro = Builders<Estoque_Vendas>.Filter.Eq(x =>x.documento , "123456");
                var alteracao = Builders<Estoque_Vendas>.Update.Set(x => x.documento, "987654");
                colecao.UpdateOne(filtro,alteracao);
                colecao.UpdateMany(filtro, alteracao);
                */
                return true;
            }
            return false;
        }
        public bool Delete(Estoque_Vendas c)
        {
            if (c != null)
            {
                var colecao = this.InstanciarConexao();
                /*
                 * Exemplo de delete
                var filtro = Builders<Estoque_Vendas>.Filter.Eq(x =>x.documento , "123456");
                colecao.DeleteOne(filtro);
                colecao.DeleteMany(filtro);
                Console.WriteLine($"{resultado.DeletedCount} documento(s) excluído(s).");
               */
                return true;
            }
            return false;
        }
        public List<Estoque_Vendas> Select(int q)
        {
            var colecao = this.InstanciarConexao();
            var filtro = Builders<Estoque_Vendas>.Filter.Where(x => x.quantidade_total == q);
            var lista = colecao.Find(filtro).ToList();
            return lista;
        }
    }
}