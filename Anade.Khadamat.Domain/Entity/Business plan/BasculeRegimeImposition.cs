using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class BasculeRegimeImposition : Referentiel
    {
        public BasculeRegimeImposition()
        {
            this.ComptesResultatPrevisionnel = new HashSet<CompteResultatPrevisionnel>();
        }

        public virtual ICollection<CompteResultatPrevisionnel> ComptesResultatPrevisionnel { get; set; }
    }
}
