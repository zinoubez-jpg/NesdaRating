using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class DetailPosteBusinessService : GenericBusinessService<DetailPoste, int>
    {
        public DetailPosteBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

    }
}
