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
    public class EnderecoController : Controller
    {
        private EnderecoRepository enderecoRepository;


        public EnderecoController()
        {
            enderecoRepository = new EnderecoRepository();
        }


        // GET: admin/Endereco
        public ActionResult Index()
        {
            var enderecoLista = enderecoRepository.listar();

            ViewBag.enderecoLista = enderecoLista;

            return View();
        }

        // GET: admin/Endereco/Details/5
        public ActionResult Details(int id)
        {
            var endereco = enderecoRepository.ListarPorId(id);

            if (endereco == null)
                return HttpNotFound();

            return View(endereco);
        }

        // GET: admin/Endereco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Endereco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                enderecoRepository.Salvar(endereco);
                return RedirectToAction("Index");
            }

            return View(endereco);
        }

        // GET: admin/Endereco/Edit/5
        public ActionResult Edit(int id)
        {
            var endereco = enderecoRepository.ListarPorId(id);

            if (endereco == null)
                return HttpNotFound();

            return View(endereco);
        }

        // POST: admin/Endereco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Endereco endereco)
        {

            if (ModelState.IsValid)
            {
                enderecoRepository.Salvar(endereco);
                return RedirectToAction("Index");
            }
            return View(endereco);
        }

        // GET: admin/Endereco/Delete/5
        public ActionResult Delete(int id)
        {
            var endereco = enderecoRepository.ListarPorId(id);

            if (endereco == null)
            {
                return HttpNotFound();
            }


            return View(endereco);
        }

        // POST: admin/Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            enderecoRepository.Excluir(id);
            return RedirectToAction("Index");
        }

       
    }
}
