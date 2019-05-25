using Projeto_Banco_Dados.Models;
using Projeto_Banco_Dados.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        #endregion
        #region acoes_Mongo
        //Area do controller que chama classe repository para acesso as dmls do mongodb
        public ActionResult Select_Mongo()
        {
            //Exemplo de select comum no mongo
            string documento = "123456";
            var lista = clienteRepository.Select(documento);
            return View(lista);
        }
        public ActionResult Insert_Mongo()
        {
            //Exemplo de insert comum no mongo
             Cliente c = new Cliente(){
             documento = "123456",
             email = "teste@teste.com",
             endereco = "av humberto alencar castelo branco",
             nome = "Marcelo Donato",
             telefone = "44252525"
             };
            clienteRepository.Insert(c);
            return View();
        }
        public ActionResult Delete_Mongo()
        {
            //Exemplo de delete comum no mongo
            Cliente c = new Cliente()
            {
                documento = "123456",
                email = "teste@teste.com",
                endereco = "av humberto alencar castelo branco",
                nome = "Marcelo Donato",
                telefone = "44252525"
            };
            clienteRepository.Delete(c);
            return View();
        }
        public ActionResult Update_Mongo()
        {
            //Exemplo de update comum no mongo
            Cliente c = new Cliente()
            {
                documento = "123456",
                email = "teste@teste.com",
                endereco = "av humberto alencar castelo branco",
                nome = "Marcelo Donato",
                telefone = "44252525"
            };
            string filtro = "987654";
            clienteRepository.Update(filtro,c);
            return View();
        }
        #endregion
    }
}