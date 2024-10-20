using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class DetailInvestissement : IEntity<int>
    {
        public DetailInvestissement()
        {
            this.Acquisitions = new HashSet<Acquisition>();
        }

        public int Id { get; set; }
        public string DesignationMateriel { get; set; }
        public int DureeAmortissement { get; set; }

        public int BusinessPlanId { get; set; }
        public int TypeMaterielId { get; set; }

        public virtual BusinessPlan BusinessPlan { get; set; }
        public virtual TypeMateriel TypeMateriel { get; set; }
        public virtual ICollection<Acquisition> Acquisitions { get; set; }
    }
}
