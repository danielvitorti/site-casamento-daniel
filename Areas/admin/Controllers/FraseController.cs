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
    public class FraseController : Controller
    {
        


        private FraseRepository fraseRepository;


        public FraseController()
        {
            fraseRepository = new FraseRepository();
        }



        // GET: admin/Frase
        public ActionResult Index()
        {
            

            var fraseLista = fraseRepository.listar();

            ViewBag.fraseLista = fraseLista;

            return View();
        }

        // GET: admin/Frase/Details/5
        public ActionResult Details(int id)
        {
            var frase = fraseRepository.ListarPorId(id);

            if (frase == null)
                return HttpNotFound();

            return View(frase);
        

        }

        // GET: admin/Frase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Frase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Frase frase)
        {
            if (ModelState.IsValid)
            {
                fraseRepository.Salvar(frase);
                return RedirectToAction("Index");
            }

            return View(frase);
        }

        // GET: admin/Frase/Edit/5
        public ActionResult Edit(int id)
        {
            var frase = fraseRepository.ListarPorId(id);

            if (frase == null)
                return HttpNotFound();

            return View(frase);
        }

        // POST: admin/Frase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Frase frase)
        {
            if (ModelState.IsValid)
            {
                fraseRepository.Salvar(frase);
                return RedirectToAction("Index");
            }
            return View(frase);
        }

        // GET: admin/Frase/Delete/5
        public ActionResult Delete(int id)
        {
            var frase = fraseRepository.ListarPorId(id);

            if (frase == null)
            {
                return HttpNotFound();
            }


            return View(frase);
        }

        // POST: admin/Frase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fraseRepository.Excluir(id);
            return RedirectToAction("Index");
        }

       
    }
}
