﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Processo_Seletivo_Programador.Models;

namespace Processo_Seletivo_Programador
{
    public class ContatosController : Controller
    {
        private ContatoContext db = new ContatoContext();

        // GET: Contatos
        public ActionResult Index()
        {
            return View(db.Contatos.ToList());
        }

        public ActionResult Listar()
        {
            return Json(db.Contatos.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Contatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return Json(contato);
        }

        // GET: Contatos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contatos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Telefone,Data")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                contato.Data = DateTime.Now;

                db.Contatos.Add(contato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return Json(contato);
        }

        // GET: Contatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: Contatos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Telefone,Data")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                contato.Data = DateTime.Now;

                db.Entry(contato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        // GET: Contatos/Delete/5
        public ActionResult DeleteFiend(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Contato contato = db.Contatos.Find(id);
            db.Contatos.Remove(contato);
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

        public ActionResult BuscarContato(int? id)
        {
            Contato contato = db.Contatos.Where(x => x.Id == id).FirstOrDefault();
            return Json(new
            {
                nome = contato.Nome,
                id = contato.Id,
                telefone = contato.Telefone
            });
        }
    }
}
