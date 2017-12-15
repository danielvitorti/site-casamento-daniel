using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace casamento.Areas.admin.Models
{
    public class ImagensGaleria
    {

            public ImagensGaleria()
            {
                this.dataCadastro = System.DateTime.Now;
            }    

            public int idImagensGaleria { get; set; }
            [Required]
            [Display(Name = "Nome")]
            public string nomeImagemGaleria { get; set; }

        [Required]
        [Display(Name = "Imagem")]
        public string imagemGaleria { get; set; }
            public DateTime dataCadastro { get; set; }
            public int idGaleria { get; set; }
            

        
    }
}
