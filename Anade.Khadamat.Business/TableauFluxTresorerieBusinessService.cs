using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class TableauFluxTresorerieBusinessService : GenericBusinessService<TableauFluxTresorerie, int>
    {
        public TableauFluxTresorerieBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

    }
}
