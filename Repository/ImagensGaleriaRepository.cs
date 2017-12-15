using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Models;

namespace casamento.Repository
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
                };
                imagesGaleriaDestaque.Add(tempImagensGaleriaDestaque);
            }

            
            return imagesGaleriaDestaque;

        }



    }
}