using System.Collections.Generic;

namespace Anade.Khadamat.Domain
{
    public partial class Client : Referentiel
    {
        public Client()
        {
            this.FicheNotations = new HashSet<FicheNotation>();
        }
        public int Note { get; set; }
        public virtual ICollection<FicheNotation> FicheNotations { get; set; }
    }
}
