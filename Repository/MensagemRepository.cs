using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Models;

namespace casamento.Repository
{
    public class MensagemRepository
    {
        private readonly Contexto contexto;

        public MensagemRepository()
        {

            contexto = new Contexto();

        }

        //TODO: Arrumar este metodo aqui porque ele esta dando erro
        private int Inserir(Mensagem mensagemObj)
        {
            const string commandText = " INSERT INTO tb_mensagem (nome,mensagem,dataEnvio) VALUES (@nome,@mensagem,now()) ";

            var parameters = new Dictionary<string, object>
            {
                {"nome", mensagemObj.nome },
                { "mensagem", mensagemObj.mensagem }
                
                
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public void Salvar(Mensagem mensagem)
        {
            /*if (mensagem.Id > 0)
                Alterar(mensagem);
            else */
                Inserir(mensagem);
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


    }
}