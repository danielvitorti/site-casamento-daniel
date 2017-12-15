using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace casamento.Areas.admin.Models
{
    public class Usuarios
    {

        public int id { get; set; }

        [Required]
        public string nome {get;set;}
        [Required]
        [Display(Name = "E-mail")]
        public string email { get; set; }
        [Required]
        [Display(Name ="Senha")]
        public string senha { get; set; }
    }
}