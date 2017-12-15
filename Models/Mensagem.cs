using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace casamento.Models
{
    public class Mensagem
    {

       

        public int id { get; set; }

        
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome")]
        public string nome { get; set; }
        
        [Display(Name = "Mensagem")]
        public string mensagem { get; set; }
        public DateTime dataEnvio { get; set; }


     
    }
}