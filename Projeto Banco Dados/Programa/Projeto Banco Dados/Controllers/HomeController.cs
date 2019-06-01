using Projeto_Banco_Dados.Models;
using Projeto_Banco_Dados.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

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
            MySqlConnection conexaoSQL = new MySqlConnection("server=localhost;User Id=root;database=agricultura; password=NAO ESQUECE A SENHA IGOR!");
            MySqlCommand comandoSQL = new MySqlCommand(query, conexaoSQL);

            MySqlDataReader myReader; //cursor
            conexaoSQL.Open();
            myReader = comandoSQL.ExecuteReader();
            string c;
            while (myReader.Read())
            {
                c = myReader.GetString(1);
            }
            conexaoSQL.Close();
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
        public ActionResult Insert_Mongo()
        {
            clienteRepository = new ClienteRepository();
            //string x = "123456";
            //Exemplo de insert comum no mongo
            Cliente c = new Cliente() {
             documento = "123456",
             email = "teste@teste.com",
             endereco = "av humberto alencar castelo branco",
             nome = "Marcelo Donato",
             telefone = "44252525"
             };
            clienteRepository.Insert(c);
            return RedirectToAction("Index");
        }
        
        #endregion
    }
}