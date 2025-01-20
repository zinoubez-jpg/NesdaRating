using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class StructureFinancementBusinessService : GenericBusinessService<StructureFinancement, int>
    {
        public StructureFinancementBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public override Expression<Func<StructureFinancement, object>>[] GetDefaultLoadProperties()
        {
            Expression<Func<StructureFinancement, object>> loadTauxStructureFinancement = x => x.TauxStructureFinancement;

            return new Expression<Func<StructureFinancement, object>>[] { loadTauxStructureFinancement };
        }
    }
}
