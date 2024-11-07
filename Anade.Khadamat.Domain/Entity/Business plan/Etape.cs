using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class Etape : Referentiel
    {
        public Etape()
        {
            this.BusinessPlans = new HashSet<BusinessPlan>();
        }

        public virtual ICollection<BusinessPlan> BusinessPlans { get; set; }
    }
}
