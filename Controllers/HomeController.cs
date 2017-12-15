using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using casamento.Models;
using casamento.Repository;


namespace casamento.Controllers
{
    public class HomeController : Controller
    {
        private ImagensDestaqueRepository imagensDestaqueRepository;
        private NoivosRepository noivosRepository;
        private EnderecoRepository enderecoRepository;
        private FraseRepository fraseRepository;
        private ImagensGaleriaRepository imagensGaleriaRepository;
        private HistoriaRepository historiaRepository;


        
        public HomeController()
        {

            imagensDestaqueRepository = new ImagensDestaqueRepository();
            noivosRepository = new NoivosRepository();
            enderecoRepository = new EnderecoRepository();
            fraseRepository = new FraseRepository();
            imagensGaleriaRepository = new ImagensGaleriaRepository();
            historiaRepository = new HistoriaRepository();
        }


        public ActionResult Index()
        {
            var imagensDestaqueLista = imagensDestaqueRepository.listarTodas();
            var noivosDestaque = noivosRepository.listarNoivosInicial();
            var endereco = enderecoRepository.listar();
            var frase = fraseRepository.listar();
            var imagensGaleriaDestaque = imagensGaleriaRepository.listarGaleriaDestaque();
            var historiaDestaque = historiaRepository.listar();


            ViewBag.imagensDestaqueLista = imagensDestaqueLista;
            ViewBag.noivosDestaque = noivosDestaque;
            ViewBag.endereco = endereco;
            ViewBag.frase = frase;
            ViewBag.imagensGaleriaDestaque = imagensGaleriaDestaque;
            ViewBag.historiaDestaque = historiaDestaque;

            return View();
        }

       
    }
}