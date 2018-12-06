using AspNetVS2017.Captiulo03.PortFolio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetVS2017.Captiulo03.PortFolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "JBS.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Mensagem = "Entre em contato";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContatoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var stringConexao = ConfigurationManager.ConnectionStrings["portfolioSqlServer"].ConnectionString;

            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                const string instrucao = @"
                                INSERT INTO[dbo].[Contato]
                                          ([Nome]
                                          ,[Email]
                                          ,[Mensagem])
                                    VALUES(@Nome               
                                          ,@Email               
                                          ,@Mensagem)
                                 ";
                using (var comando = new SqlCommand(instrucao, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", viewModel.Nome);
                    comando.Parameters.AddWithValue("@Email", viewModel.Email);
                    comando.Parameters.AddWithValue("@Mensagem", viewModel.Mensagem);

                    comando.ExecuteNonQuery();
                }

                //conexao.Close(); não precisa;
            }

            ModelState.Clear();

            return View();
        }
    }
}