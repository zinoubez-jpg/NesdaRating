using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class DetailAchatsDirectsBusinessService : GenericBusinessService<DetailAchatsDirects, int>
    {
        public DetailAchatsDirectsBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

    }
}
