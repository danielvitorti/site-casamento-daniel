using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Models;

namespace casamento.Repository
{
    public class HistoriaRepository
    {

        private readonly Contexto contexto;

        public HistoriaRepository()
        {
            contexto = new Contexto();
        }



        public List<Historia> listar()
        {

            var historiaDestaque = new List<Historia>();
            const string strQuery = "select id,titulo,descricaoHistoria,imagemHistoria,ordem from tb_historia order by ordem";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);



            foreach (var row in rows)
            {
                var tempHistoriaDestaque = new Historia
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    titulo = row["titulo"],
                    descricaoHistoria = row["descricaoHistoria"],
                    imagemHistoria = row["imagemHistoria"],
                    ordem = int.Parse(row["ordem"])
                };
                historiaDestaque.Add(tempHistoriaDestaque);
            }


            return historiaDestaque;

        }



    }
}