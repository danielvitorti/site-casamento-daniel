using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace casamento.Areas.admin.Models
{
    public class Frase
    {


        public int id { get; set; }
        [Required]
        [Display(Name = "Frase")]
        public string frase { get; set; }        
        
    }
}