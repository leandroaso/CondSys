using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondSys.Models;
using CondSys.Models.Entidades;

namespace CondSys.DAO
{
    public class AssembleiaDao
    {
        private CodSysContext _context { get; set; }
        public AssembleiaDao(CodSysContext context)
        {
            _context = context;
        }

        public Assembleia Save(Assembleia assembleia)
        {
            if (assembleia.Id > 0)
            {
                return this.Update(assembleia);
            }
            else
            {
                var result = _context.Assembleia.Add(assembleia);
            _context.SaveChanges();
            return result.Entity;
            }

            
        }

        public Assembleia Update(Assembleia assembleia)
        {
            var result = _context.Assembleia.Update(assembleia);
            _context.SaveChanges();
            return result.Entity;
        }

        public bool Delete(int id)
        {
            var assembleia = FindById(id);
            _context.Assembleia.Remove(assembleia);
            _context.SaveChanges();
            return true;
        }

        public List<Assembleia> List()
        {
            var lista = _context.Assembleia.ToList();
            return lista;
        }


        public Assembleia FindById(int id)
        {
            var result = _context.Assembleia.SingleOrDefault(u => u.Id == id);
            return result;
        }

    }
}
