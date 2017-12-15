using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace casamento.Models
{
    public class ImagensDestaque
    {

        public ImagensDestaque()
        {
            this.dataCadastro = System.DateTime.Now;
        }

        public int id { get; set; }
        [Required(ErrorMessage = "*")]
        public string imagem { get; set; }
        public string descricaoBreveImagem { get; set; }
        public DateTime dataCadastro { get; set; }
        
    }
}