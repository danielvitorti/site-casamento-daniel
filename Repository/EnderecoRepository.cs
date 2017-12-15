using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Models;

namespace casamento.Repository
{
    public class EnderecoRepository
    {

        private readonly Contexto contexto;


        public EnderecoRepository()
        {
            contexto = new Contexto();
        }


        public List<Endereco> listar()
        {
            var enderecoDestaque = new List<Endereco>();
            const string strQuery = "select id,linkLocalizacao,descricaoEndereco,tituloEndereco from tb_localizacao order by id desc";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);



            foreach (var row in rows)
            {
                var tempEnderecoDestaque = new Endereco
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    linkLocalizacao = row["linkLocalizacao"],
                    descricaoEndereco = row["descricaoEndereco"],
                    tituloEndereco = row["tituloEndereco"]

                };
                enderecoDestaque.Add(tempEnderecoDestaque);
            }

            return enderecoDestaque;


        }

    }
}