using Projeto_Banco_Dados.Models;
using Projeto_Banco_Dados.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Projeto_Banco_Dados.Controllers
{
    public class HomeController : Controller
    {

        public ClienteRepository clienteRepository;
        public ComprasRepository ComprasRepository;
        public Estoque_ComprasRepository estoque_ComprasRepository;
        public Estoque_VendasRepository estoque_VendasRepository;
        public FornecedorRepository fornecedorRepository;
        public GastosRepository gastosRepository;
        public ProducaoRepository producaoRepository;
        public VendasRepository vendasRepository;
        public List<string> lista;

        public ActionResult Index()
        {
            //pagina inicial - por default vai retornar a Index.cshtml na pasta Views
            // para retornar outra pagina, vc pode usar return RedirectToAction(ViewQueVcQuerUsar);
            return View();
        }

        public ActionResult About()
        {
            //colocar o mer aqui
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //colocar o der aqui
            ViewBag.Message = "Your contact page.";

            return View();
        }


        #region Acoes_BancoEstruturado
        //Rafael coloque as acoes do banco SQL aqui!
        public ActionResult Select_MySQL() {
            var query = " use agricultura; select cliente.nome, cliente.telefone, vendas.tipo_plantio, vendas.valor_venda, " +
                "vendas.quantidade_venda, vendas.data_venda from cliente inner join vendas on " +
                "cliente.documento = vendas.documento_cliente where vendas.valor_venda > 500 order by vendas.data_venda desc";
            MySqlConnection conexaoSQL = new MySqlConnection("server=localhost;User Id=root;database=agricultura; password=SenhaIGOR!");
            MySqlCommand comandoSQL = new MySqlCommand(query, conexaoSQL);

            MySqlDataReader myReader; //cursor
            conexaoSQL.Open();
            myReader = comandoSQL.ExecuteReader();

            lista = new List<string>();
            lista.Add("Consulta realizada em: " + DateTime.Now.ToString());
            lista.Add("Nome|Telefone|Tipo Plantio|Valor Venda|Quantidade Vendas|Data Vendas");
            while (myReader.Read())
            {
                try
                {
                    lista.Add(myReader.GetString(0) + " | " + myReader.GetString(1) +
                        " | " + myReader.GetString(2) + " | " + myReader.GetString(3) +
                        " | " + myReader.GetString(4) + " | " + myReader.GetString(5)
                        );
                }catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            conexaoSQL.Close();
            string[] c = lista.ToArray();

            GravaArquivoMySQL(c);
            return RedirectToAction("Index");
        }

#endregion
        #region acoes_Mongo
         //Area do controller que chama classe repository para acesso as dmls do mongodb
        public ActionResult Select_Mongo()
        {
            vendasRepository = new VendasRepository();
            ComprasRepository = new ComprasRepository();
            //var lista = vendasRepository.Select();

            /*
            clienteRepository = new ClienteRepository();
            //Exemplo de select comum no mongo
            string documento = "123456";
            var lista = clienteRepository.Select(documento);
            lista.ForEach(u => Console.WriteLine(u));
            */
            this.Select_monstro();
            return RedirectToAction("Index");
        }
        public ActionResult Select_Mongo2()
        {
            clienteRepository = new ClienteRepository();
            //Exemplo de select comum no mongo
            string documento = "123456";
            var lista = clienteRepository.Select(documento);
            lista.ForEach(u => Console.WriteLine(u));
            return RedirectToAction("Index");
        }
        #endregion


        private bool GravaArquivoMySQL(string[] conteudo)
        {
            try
            {
                string path = @"C:\Users\alexa\Desktop\logs\arquivo_consulta_mysql.txt";
                System.IO.File.WriteAllLines(path, conteudo, Encoding.UTF8);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }
        private List<BsonDocument> Select_monstro()
        {
            var colecaoVendas = vendasRepository.InstanciarConexao();
            var gte = new BsonDocument { { "$gte", new BsonDocument { { "valor", "500" } } } };
            
            var result = colecaoVendas.Aggregate().Match(gte).Group(new BsonDocument { {"data_venda", } });
            
            return null;
        }
    }
}