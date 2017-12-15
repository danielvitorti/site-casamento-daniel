using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Areas.admin.Models;

namespace casamento.Areas.admin.Repository
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
            const string strQuery = "select id from tb_frase order by frase desc";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);



            foreach (var row in rows)
            {
                var tmpFraseDestaque = new Frase
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    frase = row["frase"]

                };
                fraseDestaque.Add(tmpFraseDestaque);
            }

            return fraseDestaque;


        }

        //TODO: Arrumar este metodo aqui porque ele esta dando erro
        private int Inserir(Frase frase)
        {
            const string commandText = " Insert into tb_frase(frase) values (@frase) ";

            var parameters = new Dictionary<string, object>
            {
                {"frase", frase.frase }
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public void Salvar(Frase frase)
        {

            if (frase.id > 0)
            {

                Alterar(frase);
            }
            else
            {
                Inserir(frase);

            }
        }

        private int Alterar(Frase frase)
        {
            var commandText = " UPDATE tb_frase SET ";
            commandText += " nome = @frase ";
            commandText += " WHERE id = @id ";

            var parameters = new Dictionary<string, object>
            {
                {"id", frase.id},
                {"frase", frase.frase}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }


        public int Excluir(int id)
        {
            const string strQuery = "DELETE FROM tb_frase WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }


        public Frase ListarPorId(int id)
        {
            var frase = new List<Frase>();
            const string strQuery = "SELECT * FROM tb_frase WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempFrase = new Frase
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    frase = row["frase"]

                };
                frase.Add(tempFrase);
            }

            return frase.FirstOrDefault();
        }
    }
}