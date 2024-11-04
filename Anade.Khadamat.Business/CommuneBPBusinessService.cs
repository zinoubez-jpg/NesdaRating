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
    public class CommuneBPBusinessService : ReferentielBusinessService<CommuneBP, int>
    {

        public CommuneBPBusinessService(IUnitOfWork unitOfWork , ReferentielBusinessService<WilayaBP, int> wilayaBusinessService) : base(unitOfWork)
        {

        }

        public override Expression<Func<CommuneBP, object>>[] GetDefaultLoadProperties()
        {
            Expression<Func<CommuneBP, object>> loadWilaya = x => x.WilayaBP;
            Expression<Func<CommuneBP, object>> loadTypeZone = x => x.TypeZone;

            return new Expression<Func<CommuneBP, object>>[] { loadWilaya, loadTypeZone };
        }

        public List<CommuneBP> GetByCodeWilaya (string CodeWilaya)
        {
            return GetAllFiltered(x => x.Code.Substring(0,2) == CodeWilaya);
        }
    }
}
