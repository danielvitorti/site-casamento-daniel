using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace casamento.Areas.admin.Models
{
    public class Endereco
    {
        
        public int id { get; set; }
        [Required]
        [Display(Name = "Link do google maps")]
        public string linkLocalizacao { get; set; }
        [Required]
        [Display(Name = "Breve descrição do endereço")]
        public string descricaoEndereco { get; set; }
        [Required]
        [Display(Name = "Título do endereço")]
        public string tituloEndereco { get; set; }


    }
}