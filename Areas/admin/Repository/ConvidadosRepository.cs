using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Areas.admin.Models;

namespace casamento.Areas.admin.Repository
{
    public class ConvidadosRepository
    {

        private readonly Contexto contexto;


        public ConvidadosRepository()
        {
            contexto = new Contexto();
        }


        public List<Convidados> listar()
        {
            var convidadosDestaque = new List<Convidados>();
            const string strQuery = "select id,nome from tb_convidados order by nome desc";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);



            foreach (var row in rows)
            {
                var tmpConvidadosDestaque = new Convidados
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    nome = row["nome"]

                };
                convidadosDestaque.Add(tmpConvidadosDestaque);
            }

            return convidadosDestaque;


        }

        //TODO: Arrumar este metodo aqui porque ele esta dando erro
        private int Inserir(Convidados convidados)
        {
            const string commandText = " Insert into tb_convidados(nome) values (@nome) ";

            var parameters = new Dictionary<string, object>
            {
                {"nome", convidados.nome }
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public void Salvar(Convidados convidados)
        {

            if (convidados.id > 0)
            {

                Alterar(convidados);
            }
            else
            {
                Inserir(convidados);

            }
        }

        private int Alterar(Convidados convidados)
        {
            var commandText = " UPDATE tb_convidados SET ";
            commandText += " nome = @nome ";
            commandText += " WHERE id = @id ";

            var parameters = new Dictionary<string, object>
            {
                {"id", convidados.id},
                {"nome", convidados.nome}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }


        public int Excluir(int id)
        {
            const string strQuery = "DELETE FROM tb_convidados WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }


        public Convidados ListarPorId(int id)
        {
            var convidados = new List<Convidados>();
            const string strQuery = "SELECT * FROM tb_convidados WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempConvidados = new Convidados
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    nome = row["nome"]

                };
                convidados.Add(tempConvidados);
            }

            return convidados.FirstOrDefault();
        }
    }
}