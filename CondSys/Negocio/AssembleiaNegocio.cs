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
        private const int PrazoLimiteAssembleia = 15;

        public AssembleiaNegocio(AssembleiaDao dao)
        {
            this._dao = dao;
        }

        public void SalvarAssembleia(Assembleia assembleia)
        {
            try
            {
                var ultimasAssembleias = _dao.GetAssembleiasUltimosDias(assembleia, PrazoLimiteAssembleia);
                if (ultimasAssembleias.Count > 0)
                    throw new Exception($"A assembleia só pode ser marcada em um prazo de {PrazoLimiteAssembleia} dias");

                _dao.Save(assembleia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
