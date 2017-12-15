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
    public class PadrinhosController : Controller
    {
        
        private PadrinhosRepository padrinhosRepository;

        public PadrinhosController()
        {

            padrinhosRepository = new PadrinhosRepository();

        }

        // GET: admin/Padrinhos
        public ActionResult Index()
        {
            var padrinhosLista = padrinhosRepository.listar();

            ViewBag.padrinhosLista = padrinhosLista;

            return View();

        }

        // GET: admin/Padrinhos/Details/5
        public ActionResult Details(int id)
        {
            var padrinhos = padrinhosRepository.ListarPorId(id);

            if (padrinhos == null)
                return HttpNotFound();

            return View(padrinhos);
        }

        // GET: admin/Padrinhos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Padrinhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Padrinhos padrinhos)
        {
            if (ModelState.IsValid)          
            {

                var file = this.Request.Files[0];

                string savedFileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");

                savedFileName = System.IO.Path.Combine(savedFileName, System.IO.Path.GetFileName(file.FileName));

                file.SaveAs(savedFileName);
                padrinhos.imagem = file.FileName;
                
                padrinhosRepository.Salvar(padrinhos);

                return RedirectToAction("Index");
            }

            return View(padrinhos);
        }

        // GET: admin/Padrinhos/Edit/5
        public ActionResult Edit(int id)
        {
            var padrinhos = padrinhosRepository.ListarPorId(id);

            if (padrinhos == null)
                return HttpNotFound();

            return View(padrinhos);
        }

        // POST: admin/Padrinhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Padrinhos padrinhos)
        {
            if (ModelState.IsValid)
            {
                padrinhosRepository.Salvar(padrinhos);
                return RedirectToAction("Index");
            }
            return View(padrinhos);
        }

        // GET: admin/Padrinhos/Delete/5
        public ActionResult Delete(int id)
        {
            var padrinhos = padrinhosRepository.ListarPorId(id);

            if (padrinhos == null)
            {
                return HttpNotFound();
            }

         
            return View(padrinhos);
        }

        // POST: admin/Padrinhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            padrinhosRepository.Excluir(id);
            return RedirectToAction("Index");
        }

      
    }
}
