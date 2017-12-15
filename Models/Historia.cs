using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace casamento.Models
{
    public class Historia
    {

        public int id { get; set; }

        public string titulo { get; set; }

        public string descricaoHistoria { get; set; }
        
        public string imagemHistoria { get; set; }
        

        public int ordem { get; set; }
    }
}