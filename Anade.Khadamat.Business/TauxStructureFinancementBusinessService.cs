using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class TauxStructureFinancementBusinessService : GenericBusinessService<TauxStructureFinancement, int>
    {
        public TauxStructureFinancementBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

    }
}
