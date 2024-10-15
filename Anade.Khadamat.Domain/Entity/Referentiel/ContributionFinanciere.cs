using System.Collections.Generic;

namespace Anade.Khadamat.Domain
{
    public partial class ContributionFinanciere : Referentiel
    {
        public ContributionFinanciere()
        {
            this.FicheNotations = new HashSet<FicheNotation>();
        }
        public int Note { get; set; }
        public virtual ICollection<FicheNotation> FicheNotations { get; set; }
    }
}

