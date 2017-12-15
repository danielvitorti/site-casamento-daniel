using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using casamento.Areas.admin.Models;

namespace casamento.Areas.admin.Repository
{
    public class UsuarioRepository
    {

        private readonly Contexto contexto;

        public UsuarioRepository()
        {
            contexto = new Contexto();
        }



        public Usuarios ListarPorEmailSenha(string email, string senha)
        {
            var usuarios = new List<Usuarios>();
            const string strQuery = "SELECT * FROM tb_usuarios WHERE email = @email and senha = @senha";

            var parametros = new Dictionary<string, object>
            {
                { "email", email},
                { "senha", senha}
                
            };

            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);

            foreach (var row in rows)
            {
                var tempUsuario = new Usuarios
                {
                    id = int.Parse(!string.IsNullOrEmpty(row["id"]) ? row["id"] : "0"),
                    nome = row["nome"],
                    email = row["email"],
                    senha = row["senha"]
                };
                usuarios.Add(tempUsuario);
            }

            return usuarios.FirstOrDefault();
        }
    }
}