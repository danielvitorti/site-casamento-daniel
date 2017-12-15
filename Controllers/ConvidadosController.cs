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
    public class ConvidadosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ConvidadosRepository convidadosRepository;
        private ImagensGaleriaRepository imagensGaleriaRepository;
        private FraseRepository fraseRepository;


        public ConvidadosController()
        {
            convidadosRepository = new ConvidadosRepository();
            imagensGaleriaRepository = new ImagensGaleriaRepository();
            fraseRepository = new FraseRepository();
        }

        public ActionResult Index()
        {

            
            var imagensGaleriaDestaque = imagensGaleriaRepository.listarGaleriaDestaque();
            ViewBag.imagensGaleriaDestaque = imagensGaleriaDestaque;

            var convidadosLista = convidadosRepository.listar();
            ViewBag.convidadosLista = convidadosLista;

            var frase = fraseRepository.listar();
            ViewBag.frase = frase;

            return View();
            
        }
        
    }
}
