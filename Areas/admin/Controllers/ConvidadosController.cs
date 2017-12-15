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
    public class ConvidadosController : Controller
    {
        private ConvidadosRepository convidadosRepository;

        public ConvidadosController()
        {

            convidadosRepository = new ConvidadosRepository();

        }
        

        // GET: admin/Convidados
        public ActionResult Index()
        {
            
            var convidadosLista = convidadosRepository.listar();

            ViewBag.convidadosLista = convidadosLista;

            return View();
        }

        // GET: admin/Convidados/Details/5
        public ActionResult Details(int id)
        {
            var convidados = convidadosRepository.ListarPorId(id);

            if (convidados == null)
                return HttpNotFound();

            return View(convidados);
        }

        // GET: admin/Convidados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Convidados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Convidados convidados)
        {
            if (ModelState.IsValid)
            {
                convidadosRepository.Salvar(convidados);
                return RedirectToAction("Index");
            }

            return View(convidados);
        }

        // GET: admin/Convidados/Edit/5
        public ActionResult Edit(int id)
        {
            var convidados = convidadosRepository.ListarPorId(id);

            if (convidados == null)
                return HttpNotFound();

            return View(convidados);
        }

        // POST: admin/Convidados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Convidados convidados)
        {

            if (ModelState.IsValid)
            {
                convidadosRepository.Salvar(convidados);
                return RedirectToAction("Index");
            }
            return View(convidados);
        }

        // GET: admin/Convidados/Delete/5
        public ActionResult Delete(int id)
        {
            var convidados = convidadosRepository.ListarPorId(id);

            if (convidados == null)
            {
                return HttpNotFound();
            }


            return View(convidados);
        }

        // POST: admin/Convidados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            convidadosRepository.Excluir(id);
            return RedirectToAction("Index");
        }

     
    }
}
