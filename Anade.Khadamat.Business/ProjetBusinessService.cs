using Anade.Business.Core;
using Anade.Data.Abstractions;
using Anade.Khadamat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Anade.Khadamat.Business
{
   public class ProjetBusinessService : GenericBusinessService<PROMOTEUR, string>
    {
        private readonly ResourceManager _resourceManager;

        public ProjetBusinessService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _resourceManager = new ResourceManager("Anade.Khadamat.Business.Resources.BusinessMessage", this.GetType().Assembly);
        }











    }
}
