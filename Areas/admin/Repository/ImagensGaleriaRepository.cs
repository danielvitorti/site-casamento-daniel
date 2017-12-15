using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Areas.admin.Models;

namespace casamento.Areas.admin.Repository
{
    public class ImagensGaleriaRepository
    {
        private readonly Contexto contexto;


        public ImagensGaleriaRepository()
        {
            contexto = new Contexto();
        }

        public List<ImagensGaleria> listarGaleriaDestaque()
        {

            var imagesGaleriaDestaque = new List<ImagensGaleria>();
            const string strQuery = "select ig.* "+
                                        "from tb_galeria g "+
                                    " inner " +
                                    "    join " +
                                   "   tb_imagens_galeria ig on g.idGaleria = ig.idGaleria" +
                                   " where g.destaque = '1' order by ig.idImagensGaleria desc";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);



            foreach (var row in rows)
            {
                var tempImagensGaleriaDestaque = new ImagensGaleria
                {
                    idImagensGaleria = int.Parse(!string.IsNullOrEmpty(row["idImagensGaleria"]) ? row["idImagensGaleria"] : "0"),
                    nomeImagemGaleria = row["nomeImagemGaleria"],
                    imagemGaleria = row["imagemGaleria"],
                    idGaleria = int.Parse(row["idGaleria"])
                };
                imagesGaleriaDestaque.Add(tempImagensGaleriaDestaque);

            }


            return imagesGaleriaDestaque;

        }




        //TODO: Arrumar este metodo aqui porque ele esta dando erro
        private int Inserir(ImagensGaleria imagensGaleria)
        {
            const string commandText = " Insert into tb_imagens_galeria(nomeImagemGaleria,imagemGaleria,dataCadastro,idGaleria) values (@nomeImagemGaleria,@imagemGaleria,now(),@idGaleria) ";

            var parameters = new Dictionary<string, object>
            {
               
                {"nomeImagemGaleria", imagensGaleria.nomeImagemGaleria },
                {"imagemGaleria", imagensGaleria.imagemGaleria },
                {"idGaleria", imagensGaleria.idGaleria }
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public void Salvar(ImagensGaleria imagensGaleria)
        {

            if (imagensGaleria.idImagensGaleria > 0)
            {

                Alterar(imagensGaleria);
            }
            else
            {
                Inserir(imagensGaleria);

            }
        }

        private int Alterar(ImagensGaleria imagensGaleria)
        {

            var commandText = " UPDATE tb_imagens_galeria SET ";
                commandText += " nomeImagemGaleria = @nomeImagemGaleria ";
                commandText += " imagemGaleria = @imagemGaleria ";
                commandText += " idGaleria = @idGaleria ";
                commandText += " WHERE idImagensGaleria = @idImagensGaleria ";

            var parameters = new Dictionary<string, object>
            {
                {"idImagensGaleria", imagensGaleria.idImagensGaleria},
                {"nomeImagemGaleria", imagensGaleria.nomeImagemGaleria},
                {"imagemGaleria", imagensGaleria.imagemGaleria},                
                {"idGaleria", imagensGaleria.idGaleria}

            };

            return contexto.ExecutaComando(commandText, parameters);
        }


        public int Excluir(int id)
        {
            const string strQuery = "DELETE FROM tb_imagens_galeria WHERE idImagensGaleria = @id";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }


        public ImagensGaleria ListarPorId(int id)
        {
            var imagensGaleria = new List<ImagensGaleria>();
            const string strQuery = "SELECT * FROM tb_imagens_galeria WHERE id = @idImagensGaleria";
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempImagensGaleria = new ImagensGaleria
                {
                   
                    idImagensGaleria = int.Parse(!string.IsNullOrEmpty(row["idImagensGaleria"]) ? row["idImagensGaleria"] : "0"),
                    nomeImagemGaleria = row["nomeImagemGaleria"],
                    imagemGaleria = row["imagemGaleria"],
                    idGaleria = int.Parse(row["idGaleria"])
                    
                };
                imagensGaleria.Add(tempImagensGaleria);
            }

            return imagensGaleria.FirstOrDefault();
        }




    }
}