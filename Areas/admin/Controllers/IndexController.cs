using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace casamento.Areas.admin.Controllers
{
    public class IndexController : Controller
    {
        // GET: admin/Home
        
        public ActionResult index()
        {

            if (Session["usuarioLogadoID"]!= null && Session["nomeUsuarioLogado"] != null)
            {
                
                return View();
            }
            else
            {
                return Redirect("~/admin/login/index");
            }


            
        }
    }
}