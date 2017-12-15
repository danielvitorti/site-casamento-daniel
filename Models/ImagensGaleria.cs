using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace casamento.Models
{
    public class ImagensGaleria
    {

            public ImagensGaleria()
            {
                this.dataCadastro = System.DateTime.Now;
            }    

            public int idImagensGaleria { get; set; }
            public string nomeImagemGaleria { get; set; }
            public string imagemGaleria { get; set; }
            public DateTime dataCadastro { get; set; }
            public Galeria idGaleria { get; set; }
            

        
    }
}
