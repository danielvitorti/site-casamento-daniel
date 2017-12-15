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
using casamento.Library;

namespace casamento.Controllers
{
    public class MensagemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private MensagemRepository mensagemRepository;
        private FraseRepository fraseRepository;
        private ImagensGaleriaRepository imagensGaleriaRepository;

        public MensagemController()
        {
            mensagemRepository = new MensagemRepository();
            fraseRepository = new FraseRepository();
            imagensGaleriaRepository = new ImagensGaleriaRepository();
        }

        public CaptchaResult GetCaptcha()
        {
            string captchaText = Captcha.GenerateRandomCode();
            HttpContext.Session.Add("captcha", captchaText);
            return new CaptchaResult(captchaText);
        }

        // GET: Mensagem
        public ActionResult Index()
        {
            
            var mensagensLista = mensagemRepository.listar();
            var frase = fraseRepository.listar();

            
            var imagensGaleriaDestaque = imagensGaleriaRepository.listarGaleriaDestaque();
            ViewBag.imagensGaleriaDestaque = imagensGaleriaDestaque;

            ViewBag.mensagensLista = mensagensLista;


            ViewBag.frase = frase;

            
            

            string captchaText = Captcha.GenerateRandomCode();
            HttpContext.Session.Add("captcha",captchaText);

            return View();
        }

      

        // POST: Mensagem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Mensagem mensagem)
        {

            if (HttpContext.Session["captcha"].ToString() == Request.Form["captcha"])
            {
                if (!String.IsNullOrEmpty(Request.Form["nome"]) && !String.IsNullOrEmpty(Request.Form["mensagem"]))
                //if(ModelState.IsValid)
                {
                    Mensagem mensagemInsert = new Mensagem();
                    mensagemInsert.nome = Request.Form["nome"];
                    mensagemInsert.mensagem = Request.Form["mensagem"];
                    mensagemInsert.dataEnvio = System.DateTime.Now;

                    mensagemRepository.Salvar(mensagemInsert);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.mensagem = "Valor do CAPTCHA inválido.";
            }

            var mensagensLista = mensagemRepository.listar();

            ViewBag.mensagensLista = mensagensLista;

            return View();
        }

        
    }
}
