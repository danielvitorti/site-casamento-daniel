using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using casamento.Areas.admin.Models;

namespace casamento.Areas.admin.Repository
{
    public class ImagensDestaqueRepository
    {
        private readonly Contexto contexto;


        public ImagensDestaqueRepository()
        {
            contexto = new Contexto();
        }

        public List<ImagensDestaque> listarTodas()
        {
            var imagensDestaque = new List<ImagensDestaque>();
            const string strQuery = "SELECT id, imagem,dataCadastro,descricaoBreveImagem FROM tb_imagens_destaque";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);
            

            
            foreach (var row in rows)
            {
                var tempImagensDestaque = new ImagensDestaque
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    imagem = row["imagem"],
                    descricaoBreveImagem = row["descricaoBreveImagem"],
                    dataCadastro = DateTime.Parse(row["dataCadastro"])
                };
                imagensDestaque.Add(tempImagensDestaque);
            }

            return imagensDestaque;
        }


        //TODO: Arrumar este metodo aqui porque ele esta dando erro
        private int Inserir(ImagensDestaque imagensDestaque)
        {
            const string commandText = " Insert into tb_imagens_destaque(imagem,descricaoBreveImagem,dataCadastro) values (@imagem,@descricaoBreveImagem,now()) ";
         
            var parameters = new Dictionary<string, object>
            {
                {"imagem", imagensDestaque.imagem },
                {"descricaoBreveImagem", imagensDestaque.descricaoBreveImagem }
                
                
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public void Salvar(ImagensDestaque imagensDestaque)
        {

            if (imagensDestaque.id > 0)
            {

                Alterar(imagensDestaque);
            }
            else
            {
                Inserir(imagensDestaque);

            }
        }

        private int Alterar(ImagensDestaque imagensDestaque)
        {
            var commandText = " UPDATE tb_imagens_destaque SET ";
            commandText += " imagem = @imagem ";
            commandText += " descricaoBreveImagem = @descricaoBreveImagem ";
            commandText += " WHERE id = @id ";

            var parameters = new Dictionary<string, object>
            {
                {"id", imagensDestaque.id},
                {"imagem", imagensDestaque.imagem},
                {"descricaoBreveImagem", imagensDestaque.descricaoBreveImagem}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }


        public int Excluir(int id)
        {
            const string strQuery = "DELETE FROM tb_imagens_destaque WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }


        public ImagensDestaque ListarPorId(int id)
        {
            var imagensDestaque = new List<ImagensDestaque>();
            const string strQuery = "SELECT * FROM tb_imagens_destaque WHERE id = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempImagensDestaque = new ImagensDestaque
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    imagem = row["imagem"],
                    descricaoBreveImagem = row["descricaoBreveImagem"]                    
                };
                imagensDestaque.Add(tempImagensDestaque);
            }

            return imagensDestaque.FirstOrDefault();
        }


    }
}