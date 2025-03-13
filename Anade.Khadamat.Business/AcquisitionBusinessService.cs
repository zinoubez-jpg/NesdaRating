using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class AcquisitionBusinessService : GenericBusinessService<Acquisition, int>
    {
        public AcquisitionBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public override Expression<Func<Acquisition, object>>[] GetDefaultLoadProperties()
        {
            Expression<Func<Acquisition, object>> loadDetailInvestissement = x => x.DetailInvestissement;
            Expression<Func<Acquisition, object>> loadAnnne = x => x.Annee;

            return new Expression<Func<Acquisition, object>>[] { loadDetailInvestissement, loadAnnne };
        }
    }
}
