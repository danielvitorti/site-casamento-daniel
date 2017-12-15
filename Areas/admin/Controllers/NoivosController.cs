using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using casamento.Areas.admin.Models;
using casamento.Areas.admin.Repository;

namespace casamento.Areas.admin.Controllers
{
    public class NoivosController : Controller
    {
        private NoivosRepository noivosRepository;


        public NoivosController()
        {
            noivosRepository = new NoivosRepository();
        }

        // GET: admin/Noivos
        public ActionResult Index()
        {
            var noivosLista = noivosRepository.listarNoivosInicial();

            ViewBag.noivosLista = noivosLista;

            return View();
        }

        // GET: admin/Noivos/Details/5
        public ActionResult Details(int id)
        {
            var noivos = noivosRepository.listarPorId(id);

            if (noivos == null)
                return HttpNotFound();

            return View(noivos);
        }

        // GET: admin/Noivos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Noivos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Noivos noivos)
        {
            if (ModelState.IsValid)
            {
                noivosRepository.Salvar(noivos);
                return RedirectToAction("Index");
            }

            return View(noivos);
        }

        // GET: admin/Noivos/Edit/5
        public ActionResult Edit(int id)
        {
            var noivos = noivosRepository.listarPorId(id);

            if (noivos == null)
                return HttpNotFound();

            return View(noivos);
        }

        // POST: admin/Noivos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Noivos noivos)
        {
            if (ModelState.IsValid)
            {
                noivosRepository.Salvar(noivos);
                return RedirectToAction("Index");
            }
            return View(noivos);
        }

        // GET: admin/Noivos/Delete/5
        public ActionResult Delete(int id)
        {
            var noivos = noivosRepository.listarPorId(id);

            if (noivos == null)
            {
                return HttpNotFound();
            }


            return View(noivos);
        }

        // POST: admin/Noivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            noivosRepository.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
