using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Linq.Expressions;

namespace Anade.Khadamat.Business
{
    public class DetailChiffreAffaireBusinessService : GenericBusinessService<DetailChiffreAffaire, int>
    {
        public DetailChiffreAffaireBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

    }
}
