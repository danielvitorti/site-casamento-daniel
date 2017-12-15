using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Areas.admin.Models;

namespace casamento.Areas.admin.Repository
{
    public class MensagemRepository
    {
        private readonly Contexto contexto;

        public MensagemRepository()
        {

            contexto = new Contexto();

        }



        public List<Mensagem> listar()
        {

            var mensagemDestaque = new List<Mensagem>();
            const string strQuery = "SELECT id,nome,mensagem,dataEnvio FROM db_casamento.tb_mensagem order by dataEnvio desc";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);

            foreach (var row in rows)
            {
                var tempMensagemDestaque = new Mensagem
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    nome = row["nome"],
                    mensagem = row["mensagem"],
                    dataEnvio = DateTime.Parse(row["dataEnvio"])                    
                };
                mensagemDestaque.Add(tempMensagemDestaque);
            }


            return mensagemDestaque;

        }



        //TODO: Arrumar este metodo aqui porque ele esta dando erro
        private int Inserir(Mensagem mensagemObj)
        {
            const string commandText = " Insert into tb_mensagem(nome,mensagem) values (@nome,@mensagem) ";

            var parameters = new Dictionary<string, object>
            {
                
                {"nome", mensagemObj.nome},
                {"mensagem", mensagemObj.mensagem}

            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public void Salvar(Mensagem mensagem)
        {

            if (mensagem.id > 0)
            {

                Alterar(mensagem);
            }
            else
            {
                Inserir(mensagem);

            }
        }

        private int Alterar(Mensagem mensagem)
        {
            var commandText = " UPDATE tb_mensagem SET ";
                commandText += " nome = @nome ";
                commandText += " mensagem = @mensagem ";            
                commandText += " WHERE id = @id ";

            var parameters = new Dictionary<string, object>
            {
                {"id", mensagem.id},
                {"nome", mensagem.nome},
                {"mensagem", mensagem.mensagem}
              
            };

            return contexto.ExecutaComando(commandText, parameters);
        }


        public int Excluir(int id)
        {
            const string strQuery = "DELETE FROM tb_mensagem WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }


        public Mensagem ListarPorId(int id)
        {
            var mensagem = new List<Mensagem>();
            const string strQuery = "SELECT * FROM tb_mensagem WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempMensagem = new Mensagem
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    nome = row["nome"],
                    mensagem = row["mensagem"]
                };
                mensagem.Add(tempMensagem);
            }

            return mensagem.FirstOrDefault();
        }


    }
}