using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Models;

namespace casamento.Repository
{
    public class FraseRepository
    {
        private readonly Contexto contexto;


        public FraseRepository()
        {
            contexto = new Contexto();
        }

        public List<Frase> listar()
        {
            var fraseDestaque = new List<Frase>();
            const string strQuery = "select id,frase from tb_frase_destaque order by id desc limit 1";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);



            foreach (var row in rows)
            {
                var tempFraseDestaque = new Frase
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    frase = row["frase"]

                };
                fraseDestaque.Add(tempFraseDestaque);
            }

            return fraseDestaque;


        }
    }
}