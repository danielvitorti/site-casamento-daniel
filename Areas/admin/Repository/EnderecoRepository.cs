using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Areas.admin.Models;



namespace casamento.Areas.admin.Repository
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
            const string strQuery = "SELECT * FROM tb_localizacao order by nome asc";

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


        //TODO: Arrumar este metodo aqui porque ele esta dando erro
        private int Inserir(Endereco enderecoObj)
        {
            const string commandText = " Insert into tb_endereco(linkLocalizacao,tituloEndereco,descricaoEndereco,dataCadastro) values (@linkLocalizacao,@tituloEndereco,@descricaoEndereco,now()) ";

            
            var parameters = new Dictionary<string, object>
            {
                {"linkLocalizacao", enderecoObj.linkLocalizacao },
                { "tituloEndereco", enderecoObj.tituloEndereco },
                { "descricaoEndereco", enderecoObj.descricaoEndereco }


            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public void Salvar(Endereco endereco)
        {

            if (endereco.id > 0)
            {

                Alterar(endereco);
            }
            else
            {
                Inserir(endereco);

            }
        }

        private int Alterar(Endereco endereco)
        {
            var commandText = " UPDATE tb_endereco SET ";
            commandText += " linkLocalizacao = @linkLocalizacao ";
            commandText += " tituloEndereco = @tituloEndereco ";
            commandText += " descricaoEndereco = @descricaoEndereco ";
            commandText += " WHERE id = @id ";

            var parameters = new Dictionary<string, object>
            {
                {"linkLocalizacao", endereco.linkLocalizacao},
                {"tituloEndereco", endereco.tituloEndereco},
                {"descricaoEndereco", endereco.descricaoEndereco},
                {"id", endereco.id},
            };

            return contexto.ExecutaComando(commandText, parameters);
        }


        public int Excluir(int id)
        {
            const string strQuery = "DELETE FROM tb_endereco WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }


        public Endereco ListarPorId(int id)
        {
            var endereco = new List<Endereco>();
            const string strQuery = "SELECT * FROM tb_endereco WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempEndereco = new Endereco
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    linkLocalizacao = row["linkLocalizacao"],
                    descricaoEndereco = row["descricaoEndereco"],
                    tituloEndereco = row["tituloEndereco"]
                };
                endereco.Add(tempEndereco);
            }

            return endereco.FirstOrDefault();
        }
    }
}