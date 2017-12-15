using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace casamento.Models
{
    public class Endereco
    {
        
        public int id { get; set; }
        public string linkLocalizacao { get; set; }
        public string descricaoEndereco { get; set; }
        public string tituloEndereco { get; set; }


    }
}