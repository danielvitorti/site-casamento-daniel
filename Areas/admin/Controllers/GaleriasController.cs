using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using casamento.Areas.admin.Models;
using casamento.Areas.admin.Repository;

namespace casamento.Areas.admin.Controllers
{
    public class GaleriasController : Controller
    {

        private GaleriaRepository galeriaRepository;


        public GaleriasController()
        {
            galeriaRepository = new GaleriaRepository();
        }





        // GET: admin/Galerias
        public ActionResult Index()
        {
            var galeriasLista = galeriaRepository.listar();

            ViewBag.galeriasLista = galeriasLista;

            return View();

        }

        // GET: admin/Galerias/Details/5
        public ActionResult Details(int id)
        {
            var galerias = galeriaRepository.ListarPorId(id);

            if (galerias == null)
                return HttpNotFound();

            return View(galerias);
        }

        // GET: admin/Galerias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Galerias/Create
        [HttpPost]
        public ActionResult Create(Galeria galeria)
        {
            if (ModelState.IsValid)
            {
                galeria.destaque = Request.Form["destaque"];
                galeriaRepository.Salvar(galeria);

                return RedirectToAction("Index");
            }

            return View(galeria);
        }

        // GET: admin/Galerias/Edit/5
        public ActionResult Edit(int id)
        {
            var galerias = galeriaRepository.ListarPorId(id);

            if (galerias == null)
                return HttpNotFound();

            return View(galerias);
        }


        public ActionResult AdicionarImagem(int id)
        {
            var galerias = galeriaRepository.ListarPorId(id);

            if (galerias == null)
                return HttpNotFound();

            return View(galerias);


        }


        [HttpPost]
        public ActionResult AdicionarImagem()
        {

            if (!string.IsNullOrEmpty(Request.Form["nome"]))
            {

                ImagensGaleria imagensGaleria = new ImagensGaleria();

                imagensGaleria.idGaleria = Convert.ToInt16(Request.Form["idGaleria"]);

                var file = this.Request.Files[0];

                string savedFileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");

                savedFileName = System.IO.Path.Combine(savedFileName, System.IO.Path.GetFileName(file.FileName));

                file.SaveAs(savedFileName);
                //imagensDestaque.imagem = file.FileName;
                imagensGaleria.nomeImagemGaleria = Request.Form["nome"];
                imagensGaleria.imagemGaleria = file.FileName;

            }


            /*Tenho que trazer de volta as imagens da galeria =D */
            var galerias = galeriaRepository.ListarPorId(Convert.ToInt16(Request.Form["idGaleria"]));

            if (galerias == null)
                return HttpNotFound();



            return RedirectToAction("AdicionarImagem/"+Convert.ToString(galerias.id));
            //return View(galerias);


        }


        // POST: admin/Galerias/Edit/5
        [HttpPost]
        public ActionResult Edit(Galeria galeria)
        {
            if (ModelState.IsValid)
            {
                galeria.destaque = Request.Form["destaque"];
                galeriaRepository.Salvar(galeria);
                return RedirectToAction("Index");
            }
            return View(galeria);
        }

        // GET: admin/Galerias/Delete/5
        public ActionResult Delete(int id)
        {
            var galeria = galeriaRepository.ListarPorId(id);

            if (galeria == null)
            {
                return HttpNotFound();
            }


            return View(galeria);
        }

        // POST: admin/Galerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            galeriaRepository.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
