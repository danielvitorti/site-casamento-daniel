using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Areas.admin.Models;

namespace casamento.Areas.admin.Repository
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
            const string strQuery = "select id,nome,imagem,descricao from tb_noivos";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);



            foreach (var row in rows)
            {
                var tempNoivosDestaque = new Noivos
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    nome = row["nome"],
                    imagem = row["imagem"],
                    descricao = row["descricao"]
                    
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




        /*
         id
nome
introducao
descricao
dataCadastro
imagem
             */

        //TODO: Arrumar este metodo aqui porque ele esta dando erro
        private int Inserir(Noivos noivos)
        {
            const string commandText = " Insert into tb_noivos(nome,introducao,descricao,dataCadastro,imagem) values (@nome,@introducao,@descricao,now(),@imagem) ";

            var parameters = new Dictionary<string, object>
            {

                {"nome", noivos.nome},
                {"introducao", noivos.introducao},
                {"descricao", noivos.descricao},
                {"imagem", noivos.imagem}

            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public void Salvar(Noivos noivos)
        {

            if (noivos.id > 0)
            {

                Alterar(noivos);
            }
            else
            {
                Inserir(noivos);

            }
        }

        private int Alterar(Noivos noivos)
        {
            var commandText = " UPDATE tb_noivos SET ";
            commandText += " nome = @nome ";
            commandText += " introducao = @introducao ";
            commandText += " descricao = @descricao ";
            commandText += " imagem = @imagem ";
            commandText += " WHERE id = @id ";

            var parameters = new Dictionary<string, object>
            {
                {"id", noivos.id},
                {"introducao", noivos.introducao},
                {"descricao", noivos.descricao},
                {"imagem", noivos.imagem}

            };

            return contexto.ExecutaComando(commandText, parameters);
        }


        public int Excluir(int id)
        {
            const string strQuery = "DELETE FROM tb_noivos WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }






    }
}