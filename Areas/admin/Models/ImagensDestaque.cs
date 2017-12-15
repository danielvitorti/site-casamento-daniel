using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace casamento.Areas.admin.Models
{
    public class ImagensDestaque
    {

        public ImagensDestaque()
        {
            this.dataCadastro = System.DateTime.Now;
        }

        public int id { get; set; }
        [Required(ErrorMessage = "*")]        
        [Display(Name = "Imagem")]
        public string imagem { get; set; }
        [Required]
        [Display(Name = "Breve descrição")]
        public string descricaoBreveImagem { get; set; }
        public DateTime dataCadastro { get; set; }
        
    }
}