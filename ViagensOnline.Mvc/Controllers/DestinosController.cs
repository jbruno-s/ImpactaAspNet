﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViagensOnline.Dominio;
using ViagensOnline.Mvc.Models;
using ViagensOnline.Repositoris.SqlServer;

namespace ViagensOnline.Mvc.Controllers
{
    [Authorize]
    public class DestinosController : Controller
    {
        private ViagensOnlineDbContext db = new ViagensOnlineDbContext();
        private readonly string caminhoImagensDestinos = "/Content/Imagens/Destinos";

        // GET: Destinos
        public ActionResult Index()
        {
            return View(Mapear(db.Destinos.ToList()));
        }

        private List<DestinoViewModel> Mapear(List<Destino> destinos)
        {
            var viewModels = new List<DestinoViewModel>();

            foreach (var destino in destinos)
            {
                viewModels.Add(Mapear(destino));
            }

            return viewModels;
        }

        private DestinoViewModel Mapear(Destino destino)
        {
            var viewModel = new DestinoViewModel();

            viewModel.CaminhoImagem = Path.Combine(caminhoImagensDestinos,
                 destino.NomeImagem);
            viewModel.Cidade = destino.Cidade;
            viewModel.Id = destino.Id;
            viewModel.Nome = destino.Nome;
            viewModel.Pais = destino.Pais;

            return viewModel;
        }

        // GET: Destinos/Details/5
        [Authorize(Roles ="Master")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(Mapear(destino));
        }

        // GET: Destinos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destinos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Nome,Pais,Cidade,NomeImagem")] Destino destino)
        public ActionResult Create(DestinoViewModel viewModel)
        {
            if (viewModel.ArquivoFoto == null)
            {
                ModelState.AddModelError("", "É necessário enviar imagem.");
            }

            if (ModelState.IsValid)
            {
                var destino = Mapear(viewModel);

                SalvarFoto(viewModel.ArquivoFoto);

                db.Destinos.Add(destino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        private void SalvarFoto(HttpPostedFileBase arquivoFoto)
        {
            var caminhoVirtual = Path.Combine(caminhoImagensDestinos, arquivoFoto.FileName);
            var caminhoFisico = Server.MapPath(caminhoVirtual);

            arquivoFoto.SaveAs(caminhoFisico);
        }

        private Destino Mapear(DestinoViewModel viewModel)
        {
            var destino = new Destino();

            destino.Cidade = viewModel.Cidade;
            destino.Id = viewModel.Id;
            destino.Nome = viewModel.Nome;
            destino.NomeImagem = viewModel.ArquivoFoto.FileName;
            destino.Pais = viewModel.Pais;

            return destino;
        }

        // GET: Destinos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(Mapear(destino));
        }

        // POST: Destinos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Nome,Pais,Cidade,NomeImagem")] Destino destino)
        public ActionResult Edit(DestinoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var destino = db.Destinos.Find(viewModel.Id);

                db.Entry(destino).CurrentValues.SetValues(viewModel);

                if (viewModel.ArquivoFoto != null)
                {
                    SalvarFoto(viewModel.ArquivoFoto);
                    destino.NomeImagem = viewModel.ArquivoFoto.FileName;
                }

                //db.Entry(viewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Destinos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(Mapear(destino));
        }

        // POST: Destinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destino destino = db.Destinos.Find(id);

            System.IO.File.Delete(Server.MapPath(Path.Combine(caminhoImagensDestinos, destino.NomeImagem)));

            db.Destinos.Remove(destino);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
