using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Areas.admin.Models;


namespace casamento.Areas.admin.Repository
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


        //TODO: Arrumar este metodo aqui porque ele esta dando erro
        private int Inserir(Padrinhos padrinhosObj)
        {
            const string commandText = " Insert into tb_padrinhos(nome,descricaoPadrinho,imagem) values (@nome,@descricaoPadrinho,@imagem) ";

            var parameters = new Dictionary<string, object>
            {
                {"nome", padrinhosObj.nome },
                { "descricaoPadrinho", padrinhosObj.descricaoPadrinho },
                { "imagem", padrinhosObj.imagem }


            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public void Salvar(Padrinhos padrinhos)
        {
            
            if (padrinhos.id > 0)
            {
                
                Alterar(padrinhos);
            }
            else
            {
                Inserir(padrinhos);

            }
        }

        private int Alterar(Padrinhos padrinhos)
        {
            var commandText = " UPDATE tb_padrinhos SET ";
            commandText += " nome = @nome ";
            commandText += " descricaoPadrinho = @descricaoPadrinho ";
            commandText += " imagem = @imagem ";
            commandText += " WHERE id = @id ";

            var parameters = new Dictionary<string, object>
            {
                {"id", padrinhos.id},
                {"nome", padrinhos.nome},
                {"descricaoPadrinho", padrinhos.descricaoPadrinho},
                {"imagem", padrinhos.imagem},
            };

            return contexto.ExecutaComando(commandText, parameters);
        }


        public int Excluir(int id)
        {
            const string strQuery = "DELETE FROM tb_padrinhos WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }


        public Padrinhos ListarPorId(int id)
        {
            var padrinhos = new List<Padrinhos>();
            const string strQuery = "SELECT * FROM tb_padrinhos WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempPadrinhos = new Padrinhos
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    nome = row["nome"],
                    descricaoPadrinho = row["descricaoPadrinho"],
                    imagem = row["imagem"]
                };
                padrinhos.Add(tempPadrinhos);
            }

            return padrinhos.FirstOrDefault();
        }
    }
}