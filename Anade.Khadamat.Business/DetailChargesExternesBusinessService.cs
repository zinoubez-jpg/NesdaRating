using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class DetailChargesExternesBusinessService : GenericBusinessService<DetailChargesExternes, int>
    {
        public DetailChargesExternesBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

    }
}
