using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class Mois : Referentiel
    {
        public Mois()
        {
            this.PlansTresorerieMensuel = new HashSet<PlanTresorerieMensuel>();
        }

        public virtual ICollection<PlanTresorerieMensuel> PlansTresorerieMensuel { get; set; }

    }
}
