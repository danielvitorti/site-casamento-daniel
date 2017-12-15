using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace casamento.Areas.admin.Models
{
    public class Noivos
    {

        public Noivos()
        {

            this.dataCadastro = System.DateTime.Now;
        }

        public int id { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Required]
        [Display(Name = "Introdução")]
        public string introducao { get; set; }
        [Required]
        [Display(Name = "Imagem")]
        public string imagem { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        public DateTime dataCadastro { get; set; }

        
    }
}