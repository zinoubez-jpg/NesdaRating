using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class DetailInvestissementBusinessService : GenericBusinessService<DetailInvestissement, int>
    {
        public DetailInvestissementBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public override Expression<Func<DetailInvestissement, object>>[] GetDefaultLoadProperties()
        {
            Expression<Func<DetailInvestissement, object>> loadAcquisitions = x => x.Acquisitions;

            return new Expression<Func<DetailInvestissement, object>>[] { loadAcquisitions };
        }
    }
}
