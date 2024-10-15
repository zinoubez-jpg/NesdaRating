using System.Collections.Generic;

namespace Anade.Khadamat.Domain
{
    public partial class Van : Referentiel
    {
        public Van()
        {
            this.FicheNotations = new HashSet<FicheNotation>();
        }
        public int Note { get; set; }
        public virtual ICollection<FicheNotation> FicheNotations { get; set; }
    }
}
