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
    public class HistoriaController : Controller
    {
       

        private HistoriaRepository historiaRepository;

        public HistoriaController()
        {
            historiaRepository = new HistoriaRepository();
        }

        // GET: admin/Historia
        public ActionResult Index()
        {
            var historiaLista = historiaRepository.listar();

            ViewBag.historiaLista = historiaLista;

            return View();
        }

        // GET: admin/Historia/Details/5
        public ActionResult Details(int id)
        {
            var historia = historiaRepository.ListarPorId(id);

            if (historia == null)
                return HttpNotFound();

            return View(historia);
        }

        // GET: admin/Historia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Historia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Historia historia)
        {
            if (ModelState.IsValid)
            {
                historiaRepository.Salvar(historia);
                return RedirectToAction("Index");
            }

            return View(historia);
        }

        // GET: admin/Historia/Edit/5
        public ActionResult Edit(int id)
        {
            var historia = historiaRepository.ListarPorId(id);

            if (historia == null)
                return HttpNotFound();

            return View(historia);
        }

        // POST: admin/Historia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Historia historia)
        {
            if (ModelState.IsValid)
            {
                historiaRepository.Salvar(historia);
                return RedirectToAction("Index");
            }
            return View(historia);
        }

        // GET: admin/Historia/Delete/5
        public ActionResult Delete(int id)
        {
            var historia = historiaRepository.ListarPorId(id);

            if (historia == null)
            {
                return HttpNotFound();
            }


            return View(historia);
        }

        // POST: admin/Historia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            historiaRepository.Excluir(id);
            return RedirectToAction("Index");
        }

       
    }
}
