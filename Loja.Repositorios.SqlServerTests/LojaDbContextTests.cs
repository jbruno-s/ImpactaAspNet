using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Loja.Dominio;
using System.Data.Entity;

namespace Loja.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private readonly LojaDbContext db = new LojaDbContext();

        public LojaDbContextTests()
        {
            db.Database.Log = LogarQuery;
        }

        private void LogarQuery(string query)
        {
            Debug.WriteLine(query);
        }

        [TestMethod()]
        public void InserirCategoriaTeste()
        {
            var categoria = new Categoria();

            categoria.Nome = "Informática";

            db.Categorias.Add(categoria);
            db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoTeste()
        {
            var produto = new Produto();

            produto.Categoria = db.Categorias.Find(2);
            produto.Estoque = 100;
            produto.Nome = "PC";
            produto.Preco = 3.50m;

            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoComNovaCategoriaTeste()
        {
            var produto = new Produto();

            produto.Categoria = new Categoria { Nome = "Perfumaria" };
            produto.Estoque = 1;
            produto.Nome = "Ferrari";
            produto.Preco = 300.50m;

            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        [TestMethod]
        public void EditarProdutoTeste()
        {
            var produto = db.Produtos
                .Where(p => p.Nome.Contains("PC"))//não vai no banco
                                                  //.First();//vai direto no banco
                .FirstOrDefault();

            produto.Nome = "Computador";
            produto.Estoque = 1;

            db.SaveChanges();
        }

        [TestMethod]
        public void ExcluirProdutoTeste()
        {
            var produtos = db.Produtos
                .Where(p => p.Categoria.Id == 2)
                .ToList();

            db.Produtos.RemoveRange(produtos);

            db.SaveChanges();

            Assert.IsFalse(db.Produtos.Any(p => p.Categoria.Id == 2));
        }

        [TestMethod]
        public void LazyLoadDesligadoTeste()
        {
            var produto = db.Produtos
                .SingleOrDefault(p => p.Id == 2);

            Assert.IsNull(produto.Categoria);
        }

        [TestMethod]
        public void IncludeTeste()
        {
            var produto = db.Produtos.Include(p => p.Categoria)
                .SingleOrDefault(p => p.Id == 2);

            Console.WriteLine(produto.Categoria.Nome);

        }

        [TestMethod]
        [DataRow(2)]
        public void QueryableTeste(int estoque)
        {
            var query = db.Produtos.Where(p => p.Preco > 10);

            if (estoque > 0)
            {
                query = query.Where(p => p.Estoque >= estoque);
            }

            query.OrderByDescending(p => p.Preco);

            var primeiro = query.FirstOrDefault();
            //var ultimo = query.LastOrDefault();
            var ultimo = query.AsEnumerable().LastOrDefault();
            //var unico = query.SingleOrDefault();
            var todos = query.ToList();
        }
    }
}