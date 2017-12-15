using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Models;

namespace casamento.Repository
{
    public class PadrinhosRepository
    {

        private readonly Contexto contexto;


        public PadrinhosRepository()
        {
            contexto = new Contexto();
        }



        public List<Padrinhos> listar()
        {   
            var padrinhosDestaque = new List<Padrinhos>();
            const string strQuery = "SELECT id,nome,imagem,descricaoPadrinho FROM tb_padrinhos order by nome asc";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);

            foreach (var row in rows)
            {
                var tempPadrinhosDestaque = new Padrinhos
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    nome = row["nome"],
                    imagem = row["imagem"],
                    descricaoPadrinho = row["descricaoPadrinho"]
                };
                padrinhosDestaque.Add(tempPadrinhosDestaque);
            }


            return padrinhosDestaque;

        }

    }
}