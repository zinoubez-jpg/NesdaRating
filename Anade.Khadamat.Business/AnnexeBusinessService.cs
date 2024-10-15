using Anade.Data.Abstractions;
using Anade.Domain.Core;
using Anade.Khadamat.Domain;
using Anade.Business.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class AnnexeBusinessService : ReferentielBusinessService<Annexe, int> 
    {
        public AnnexeBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public Expression<Func<Annexe, object>>[] GetDefaultLoadProperties()
        {
            Expression<Func<Annexe, object>> loadAntenne = x => x.Antenne;
           
            return new Expression<Func<Annexe, object>>[] { loadAntenne };
        }

    }
}
