using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace casamento.Models
{
    public class Noivos
    {

        public Noivos()
        {

            this.dataCadastro = System.DateTime.Now;
        }

        public int id { get; set; }
        [Required(ErrorMessage = "*")]
        public string nome { get; set; }
        [Required(ErrorMessage = "*")]
        public string introducao { get; set; }
        [Required(ErrorMessage = "*")]
        public string imagem { get; set; }
        [Required(ErrorMessage = "*")]
        public string descricao { get; set; }

        public DateTime dataCadastro { get; set; }

        
    }
}