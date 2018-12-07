using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagensOnline.Repositoris.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagensOnline.Dominio;

namespace ViagensOnline.Repositoris.SqlServer.Tests
{
    [TestClass()]
    public class ViagensOnlineDbContextTests
    {
        private readonly ViagensOnlineDbContext db = new ViagensOnlineDbContext();

        [TestMethod()]
        public void InserirTeste()
        {
            var destino = new Destino();

            destino.Cidade = "Caieiras";
            destino.Nome = "Cidade dos pinheirais";
            destino.NomeImagem = "Caieiras.png";
            destino.Pais = "Brasil";

            db.Destinos.Add(destino);

            db.SaveChanges();
        }

        [TestMethod]
        public void AtualizarTeste()
        {
            var destino = db.Destinos.Find(3);

            destino.NomeImagem = "img10.jpg";            
            
            db.SaveChanges();

            destino = db.Destinos.Find(3);

            Assert.AreEqual(destino.NomeImagem, "img10.jpg");
        }

        [TestMethod]
        public void ExcluirTeste()
        {
            var destino = db.Destinos.Find(2);

            db.Destinos.Remove(destino);

            db.SaveChanges();
        }
    }
}