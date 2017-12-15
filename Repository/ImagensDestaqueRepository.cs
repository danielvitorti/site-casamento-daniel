using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Models;
using casamento.Repository;

namespace casamento.Repository
{
    public class ImagensDestaqueRepository
    {
        private readonly Contexto contexto;


        public ImagensDestaqueRepository()
        {
            contexto = new Contexto();
        }

        public List<ImagensDestaque> listarTodas()
        {
            var imagensDestaque = new List<ImagensDestaque>();
            const string strQuery = "SELECT id, imagem,dataCadastro,descricaoBreveImagem FROM tb_imagens_destaque";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);
            

            
            foreach (var row in rows)
            {
                var tempImagensDestaque = new ImagensDestaque
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    imagem = row["imagem"],
                    descricaoBreveImagem = row["descricaoBreveImagem"],
                    dataCadastro = DateTime.Parse(row["dataCadastro"])
                };
                imagensDestaque.Add(tempImagensDestaque);
            }

            return imagensDestaque;
        }

    }
}