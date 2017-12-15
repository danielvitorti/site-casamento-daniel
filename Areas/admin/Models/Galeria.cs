using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace casamento.Areas.admin.Models
{
    public class Galeria
    {

        public Galeria()
        {
            this.dataCadastro = System.DateTime.Now;
        }
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string nomeGaleria { get; set; }
        [Required]
        [Display(Name = "Marcar como destaque")]
        public string destaque { get; set; }
        public DateTime dataCadastro { get; set; }


    }
}
