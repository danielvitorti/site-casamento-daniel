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
    public class ImagensDestaqueController : Controller
    {
     

        private ImagensDestaqueRepository imagensDestaqueRepository;


        public ImagensDestaqueController()
        {
            imagensDestaqueRepository = new ImagensDestaqueRepository();
        }

        // GET: admin/ImagensDestaque
        public ActionResult Index()
        {
            var imagensDestaqueLista = imagensDestaqueRepository.listarTodas();

            ViewBag.imagensDestaqueLista = imagensDestaqueLista;

            return View();
        }

        // GET: admin/ImagensDestaque/Details/5
        public ActionResult Details(int id)
        {
            var imagensDestaque = imagensDestaqueRepository.ListarPorId(id);

            if (imagensDestaque == null)
                return HttpNotFound();

            return View(imagensDestaque);
        }

        // GET: admin/ImagensDestaque/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/ImagensDestaque/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImagensDestaque imagensDestaque)
        {
            if (ModelState.IsValid)
            {

                var file = this.Request.Files[0];

                string savedFileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");

                savedFileName = System.IO.Path.Combine(savedFileName, System.IO.Path.GetFileName(file.FileName));

                file.SaveAs(savedFileName);
                imagensDestaque.imagem = file.FileName;
                
                imagensDestaqueRepository.Salvar(imagensDestaque);
                return RedirectToAction("Index");
            }

            return View(imagensDestaque);
        }

        // GET: admin/ImagensDestaque/Edit/5
        public ActionResult Edit(int id)
        {
            var imagensDestaque = imagensDestaqueRepository.ListarPorId(id);

            if (imagensDestaque == null)
                return HttpNotFound();

            return View(imagensDestaque);
        }

        // POST: admin/ImagensDestaque/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ImagensDestaque imagensDestaque)
        {

            if (ModelState.IsValid)
            {
                imagensDestaqueRepository.Salvar(imagensDestaque);
                return RedirectToAction("Index");
            }
            return View(imagensDestaque);
        }

        // GET: admin/ImagensDestaque/Delete/5
        public ActionResult Delete(int id)
        {
            var imagensDestaque = imagensDestaqueRepository.ListarPorId(id);

            if (imagensDestaque == null)
            {
                return HttpNotFound();
            }


            return View(imagensDestaque);
        }

        // POST: admin/ImagensDestaque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            imagensDestaqueRepository.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
