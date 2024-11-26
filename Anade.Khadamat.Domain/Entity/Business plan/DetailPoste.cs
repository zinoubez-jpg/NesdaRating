using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class DetailPoste : IEntity<int>
    {
        public int Id { get; set; }
        public int NombreEmploi { get; set; }
        
        public int AnneeId { get; set; }
        public int BusinessPlanId { get; set; }
        public int PosteId { get; set; }

        public virtual Annee Annee { get; set; }
        public virtual BusinessPlan BusinessPlan { get; set; }
        public virtual Poste Poste { get; set; }

    }
}
