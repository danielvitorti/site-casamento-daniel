using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace casamento.Areas.admin.Models
{
    public class Historia
    {

        public int id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string titulo { get; set; }
        [Required]
        [Display(Name = "Breve descrição")]
        public string descricaoHistoria { get; set; }
        [Required]
        [Display(Name = "Imagem")]
        public string imagemHistoria { get; set; }

        [Required]
        [Display(Name = "Ordem")]
        public int ordem { get; set; }
    }
}