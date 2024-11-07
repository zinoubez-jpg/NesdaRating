using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Anade.Khadamat.Domain
{
    public partial class Acquisition : IEntity<int>
    {
        public int Id { get; set; }
        public decimal Montant { get; set; }

        public int AnneeId { get; set; }
        public int DetailInvestissementId { get; set; }

        [ForeignKey("AnneeId")]
        public virtual Annee Annee { get; set; }
        public virtual DetailInvestissement DetailInvestissement { get; set; }

    }
}