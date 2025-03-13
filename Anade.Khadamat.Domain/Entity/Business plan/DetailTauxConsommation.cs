using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class DetailTauxConsommation : IEntity<int>
    {
        public int Id { get; set; }
        public decimal TauxConsommation { get; set; }
        public int AnneeId { get; set; }
        public int BusinessPlanId { get; set; }

        [ForeignKey("AnneeId")]
        public virtual Annee Annee { get; set; }
        public virtual BusinessPlan BusinessPlan { get; set; }

    }
}
