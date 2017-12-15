using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Areas.admin.Models;

namespace casamento.Areas.admin.Repository
{
    public class GaleriaRepository
    {


        private readonly Contexto contexto;


        public GaleriaRepository()
        {
            contexto = new Contexto();
        }



        public List<Galeria> listar()
        {
            var galeriasDestaque = new List<Galeria>();
            const string strQuery = "SELECT * FROM tb_galeria order by nomeGaleria asc";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);

            foreach (var row in rows)
            {
                var tempGaleria = new Galeria
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["idGaleria"]) ? row["idGaleria"] : "0"),
                    nomeGaleria = row["nomeGaleria"],
                    destaque = row["destaque"]
                  
                };
                galeriasDestaque.Add(tempGaleria);
            }


            return galeriasDestaque;

        }


        //TODO: Arrumar este metodo aqui porque ele esta dando erro
        private int Inserir(Galeria galeriaObj)
        {
            const string commandText = " Insert into tb_galeria(nomeGaleria,dataCadastro,destaque) values (@nomeGaleria,now(),@destaque) ";

            var parameters = new Dictionary<string, object>
            {
                {"nomeGaleria", galeriaObj.nomeGaleria },
                { "destaque", galeriaObj.destaque }

            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public void Salvar(Galeria galeria)
        {

            if (galeria.id > 0)
            {

                Alterar(galeria);
            }
            else
            {
                Inserir(galeria);

            }
        }

        private int Alterar(Galeria galeria)
        {
            var commandText = " UPDATE tb_galeria SET ";
            commandText += " nomeGaleria = @nomeGaleria ";
            commandText += " destaque = @destaque ";
            commandText += " WHERE idGaleria = @idGaleria ";

            var parameters = new Dictionary<string, object>
            {
                {"nomeGaleria", galeria.nomeGaleria},
                {"destaque", galeria.destaque},
                {"idGaleria", galeria.id}
                
            };

            return contexto.ExecutaComando(commandText, parameters);
        }


        public int Excluir(int id)
        {
            const string strQuery = "DELETE FROM tb_galeria WHERE idGaleria = @idGaleria";
            var parametros = new Dictionary<string, object>
            {
                {"idGaleria", id}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }


        public Galeria ListarPorId(int id)
        {
            var galerias = new List<Galeria>();
            const string strQuery = "SELECT * FROM tb_galeria WHERE idGaleria = @idGaleria";
            var parametros = new Dictionary<string, object>
            {
                {"idGaleria", id}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempGaleria = new Galeria
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["idGaleria"]) ? row["idGaleria"] : "0"),
                    nomeGaleria = row["nomeGaleria"],
                    destaque = row["destaque"]
                };
                galerias.Add(tempGaleria);
            }

            return galerias.FirstOrDefault();
        }



    }
}