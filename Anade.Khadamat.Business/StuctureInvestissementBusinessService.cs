using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class StuctureInvestissementBusinessService : GenericBusinessService<StuctureInvestissement, int>
    {
        public StuctureInvestissementBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

    }
}
