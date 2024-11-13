using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anade.Khadamat.Domain;

namespace Anade.Khadamat.Web.ViewModels
{
    public class AcquisitionDetailInvestissementVM
    {
        public Acquisition acquisition { get; set; }

        public DetailInvestissement detailInvestissement { get; set; }

        public virtual ICollection<Acquisition> acquisitions { get; set; }

    }
}
