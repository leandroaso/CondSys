using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondSys.Models.Entidades
{
    public class Assembleia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
