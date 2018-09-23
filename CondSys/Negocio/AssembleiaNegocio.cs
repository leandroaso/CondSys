using CondSys.DAO;
using CondSys.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondSys.Negocio
{
    public class AssembleiaNegocio
    {
        private readonly AssembleiaDao _dao;
        private const int PRAZO_LIMITE_ASSEMBLEIA = 15;  

        public AssembleiaNegocio(AssembleiaDao dao)
        {
            this._dao = dao;
        }

        public void SalvarAssembleia(Assembleia assembleia)
        {
            try
            {
                var ultimaAssembleia = _dao.List().LastOrDefault();
                var periodo = assembleia.Data - ultimaAssembleia.Data;

                if(periodo.Days <= PRAZO_LIMITE_ASSEMBLEIA)
                {
                    throw new Exception($"A assembleia só pode ser marcada em um prazo de {PRAZO_LIMITE_ASSEMBLEIA} dias");
                }

                _dao.Save(assembleia);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
