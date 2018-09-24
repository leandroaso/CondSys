using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondSys.Models.Entidades
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Apartamento Apartamento {get; set;}
        public Veiculo Veiculo {get; set;}
    }
}
