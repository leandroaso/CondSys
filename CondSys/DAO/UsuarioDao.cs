using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondSys.Models.Entidades;

namespace CondSys.DAO
{
    public class UsuarioDao
    {
        private List<Usuario> UsuariosListMock { get; set; }

        public UsuarioDao()
        {
            UsuariosListMock = new List<Usuario>()
            {
                new Usuario
                {
                    Nome = "Seu Zé",
                    Login = "seuze123",
                    Senha = "123456"
                },
                new Usuario
                {
                    Nome = "Maria",
                    Login = "maria123",
                    Senha = "123456"
                }
            };
        }
        public bool Autenticar( Usuario usuario)
        {
            var user = UsuariosListMock.FirstOrDefault(u => u.Login == usuario.Login && u.Senha == usuario.Senha);
            if (user == null) return false;
            UsuarioLogado.Usuario = user;
            return true;
        }
    }

    public static class UsuarioLogado
    {
        public static Usuario Usuario { get; set; }
    }
}
