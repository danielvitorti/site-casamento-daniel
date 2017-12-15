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
    public class MensagemController : Controller
    {
        

        private MensagemRepository mensagemRepository;



        public MensagemController()
        {

            mensagemRepository = new MensagemRepository();

        }

        // GET: admin/Mensagem
        public ActionResult Index()
        {
            var mensagemLista = mensagemRepository.listar();

            ViewBag.mensagemLista = mensagemLista;

            return View();
        }

        // GET: admin/Mensagem/Details/5
        public ActionResult Details(int id)
        {
            var mensagem = mensagemRepository.ListarPorId(id);

            if (mensagem == null)
                return HttpNotFound();

            return View(mensagem);
        }

        // GET: admin/Mensagem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Mensagem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                mensagemRepository.Salvar(mensagem);
                return RedirectToAction("Index");
            }

            return View(mensagem);
        }

        // GET: admin/Mensagem/Edit/5
        public ActionResult Edit(int id)
        {
            var mensagem = mensagemRepository.ListarPorId(id);

            if (mensagem == null)
                return HttpNotFound();

            return View(mensagem);
        }

        // POST: admin/Mensagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                mensagemRepository.Salvar(mensagem);
                return RedirectToAction("Index");
            }
            return View(mensagem);
        }

        // GET: admin/Mensagem/Delete/5
        public ActionResult Delete(int id)
        {
            var mensagem = mensagemRepository.ListarPorId(id);

            if (mensagem == null)
            {
                return HttpNotFound();
            }


            return View(mensagem);
        }

        // POST: admin/Mensagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mensagemRepository.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
