using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Areas.admin.Models;

namespace casamento.Areas.admin.Repository
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


        //TODO: Arrumar este metodo aqui porque ele esta dando erro
        private int Inserir(Historia historia)
        {
            const string commandText = " Insert into tb_historia(titulo,descricaoHistoria,imagemHistoria,ordem) values (@titulo,@descricaoHistoria,@imagemHistoria,@ordem) ";

            var parameters = new Dictionary<string, object>
            {
                {"titulo", historia.titulo },
                {"descricaoHistoria", historia.descricaoHistoria },
                {"imagemHistoria", historia.imagemHistoria },
                {"ordem", historia.ordem }
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public void Salvar(Historia historia)
        {

            if (historia.id > 0)
            {

                Alterar(historia);
            }
            else
            {
                Inserir(historia);

            }
        }

        private int Alterar(Historia historia)
        {
            var commandText = " UPDATE tb_historia SET ";
            commandText += " nome = @historia ";
            commandText += " WHERE id = @id ";

            var parameters = new Dictionary<string, object>
            {
                {"id", historia.id},
                {"titulo", historia.titulo},
                {"descricaoHistoria", historia.descricaoHistoria},
                {"imagemHistoria", historia.imagemHistoria},
                {"ordem", historia.ordem}
                
            };

            return contexto.ExecutaComando(commandText, parameters);
        }


        public int Excluir(int id)
        {
            const string strQuery = "DELETE FROM tb_historia WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }


        public Historia ListarPorId(int id)
        {
            var historia = new List<Historia>();
            const string strQuery = "SELECT * FROM tb_historia WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempHistoria = new Historia
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    titulo = row["titulo"],
                    descricaoHistoria = row["descricaoHistoria"],
                    imagemHistoria = row["imagemHistoria"],
                    ordem = int.Parse(!string.IsNullOrEmpty(row["ordem"]) ? row["ordem"] : "0")


                  
                };
                historia.Add(tempHistoria);
            }

            return historia.FirstOrDefault();
        }



    }
}