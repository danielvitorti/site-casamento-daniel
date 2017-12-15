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
    public class NoivosController : Controller
    {
        private NoivosRepository noivosRepository;


        public NoivosController()
        {
            noivosRepository = new NoivosRepository();
        }


        // GET: Noivos/Details/5
        public ActionResult Detalhe(int? id)
        {
            var noivo = noivosRepository.listarPorId(Convert.ToInt16(id));
            
            if(noivo == null )
            {
                return HttpNotFound();
            }

            ViewBag.noivo = noivo;

            return View();

           
        }

    }
}
