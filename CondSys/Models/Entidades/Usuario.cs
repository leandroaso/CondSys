using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondSys.Models.Entidades
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
