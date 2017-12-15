using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace casamento.Areas.admin.Models
{
    public class Padrinhos
    {

        public int id { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string descricaoPadrinho { get; set; }
        public string imagem { get; set; }
        

        
    }
}