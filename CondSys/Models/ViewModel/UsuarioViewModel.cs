using CondSys.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondSys.Models.ViewModel
{
    public class UsuarioViewModel
    {
        public List<Usuario> Usuarios {get; set;}
        public Usuario Usuario {get; set;} 
    }
}
