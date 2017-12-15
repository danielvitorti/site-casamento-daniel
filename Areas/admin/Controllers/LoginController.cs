using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using casamento.Areas.admin.Models;
using casamento.Areas.admin.Repository;
using System.Security.Cryptography;
using System.Web.Security;


namespace casamento.Areas.admin.Controllers
{
    public class LoginController : Controller
    {

        private UsuarioRepository usuarioRepository;
        
        public LoginController()
        {
            usuarioRepository = new UsuarioRepository();
        }
        // GET: admin/Login
        public ActionResult Index()
        {
            return View();

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Usuarios usuarios,string returnUrl)
        {

            string email = Request.Form["email"];
            string senha = Request.Form["senha"];


            var listaUsuarios = usuarioRepository.ListarPorEmailSenha(email,senha);

            if (listaUsuarios!= null)
            {

                Session["usuarioLogadoID"] = listaUsuarios.id.ToString();
                Session["nomeUsuarioLogado"] = listaUsuarios.nome;
                


                return Redirect("~/admin/index");

                
            }

            return View();


        }

        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("~/admin/Login/Index");
        }



    }
}