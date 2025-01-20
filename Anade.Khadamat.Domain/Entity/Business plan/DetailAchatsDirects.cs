using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class DetailAchatsDirects : IEntity<int>
    {
        public int Id { get; set; }
        public float Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }
        public decimal Montant { get; set; }
        public decimal TauxConsommation { get; set; }

        public int AnneeId { get; set; }
        public int BusinessPlanId { get; set; }
        public int MatierePremiereApprovisionnementId { get; set; }

        [ForeignKey("AnneeId")]
        public virtual Annee Annee { get; set; }
        public virtual BusinessPlan BusinessPlan { get; set; }
        public virtual MatierePremiereApprovisionnement MatierePremiereApprovisionnement { get; set; }

    }
}
