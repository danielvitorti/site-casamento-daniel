using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using casamento.Models;
using casamento.Repository;

namespace casamento.Controllers
{
    public class PadrinhosController : Controller
    {
        private PadrinhosRepository padrinhosRepository;
        private FraseRepository fraseRepository;
        private ImagensGaleriaRepository imagensGaleriaRepository;



        public PadrinhosController()
        {

            padrinhosRepository = new PadrinhosRepository();
            fraseRepository = new FraseRepository();
            
            imagensGaleriaRepository = new ImagensGaleriaRepository();

        }

        // GET: Padrinhos
        public ActionResult Index()
        {
            var padrinhosLista = padrinhosRepository.listar();
            ViewBag.padrinhosLista = padrinhosLista;

            var imagensGaleriaDestaque = imagensGaleriaRepository.listarGaleriaDestaque();
            ViewBag.imagensGaleriaDestaque = imagensGaleriaDestaque;


            var frase = fraseRepository.listar();
            ViewBag.frase = frase;

            


            return View();
        }

       
    }
}
