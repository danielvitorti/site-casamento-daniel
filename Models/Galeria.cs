using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace casamento.Models
{
    public class Galeria
    {

        public Galeria()
        {
            this.dataCadastro = System.DateTime.Now;
        }
        public int idGaleria { get; set; }
        public string nomeGaleria { get; set; }
        public string destaque { get; set; }
        public DateTime dataCadastro { get; set; }


    }
}
