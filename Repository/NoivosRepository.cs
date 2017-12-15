using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Models;

namespace casamento.Repository
{
    public class NoivosRepository
    {

        private readonly Contexto contexto;


        public NoivosRepository()
        {
            contexto = new Contexto();
        }

        public List<Noivos> listarNoivosInicial()
        {
            var noivosDestaque = new List<Noivos>();
            const string strQuery = "select id,nome,imagem,descricao,introducao from tb_noivos";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);



            foreach (var row in rows)
            {
                var tempNoivosDestaque = new Noivos
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    nome = row["nome"],
                    imagem = row["imagem"],
                    descricao = row["descricao"],
                    introducao = row["introducao"]
                    
                };
                noivosDestaque.Add(tempNoivosDestaque);
            }

            return noivosDestaque;
        }

        public Noivos listarPorId(int id)
        {
            var noivos = new List<Noivos>();

            const string sql = "select id,nome,descricao,imagem from tb_noivos where id = @id";

            var parametros = new Dictionary<string, object>
            {
                { "id",id}
            };

            var rows = contexto.ExecutaComandoComRetorno(sql, parametros);
            foreach (var row in rows)
            {
                var tempNoivos = new Noivos
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    nome = row["nome"],
                    descricao = row["descricao"],
                    imagem = row["imagem"]
                };
                noivos.Add(tempNoivos);
            }

            return noivos.FirstOrDefault();

        }


       

    }
}