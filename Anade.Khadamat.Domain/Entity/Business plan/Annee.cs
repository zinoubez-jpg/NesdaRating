using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class Annee : IEntity<int>
    {
        public Annee()
        {
            this.Mois = new HashSet<Mois>();
        }

        public int Id { get; set; }
        public string Numero { get; set; }

        public virtual ICollection<Mois> Mois { get; set; }
    }
}
