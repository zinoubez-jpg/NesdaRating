using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Anade.Khadamat.Domain
{    
    public partial class Poste : IEntity<int>
    {
        public Poste()
        {
            this.DetailsPoste = new HashSet<DetailPoste>();
        }

        public int Id { get; set; }
        public string Designation { get; set; }
        public decimal SalaireBase { get; set; }
        public decimal IndemnitesPrimesCotisables { get; set; }
        public decimal IndemnitesPrimesImposables { get; set; }
        public decimal SLR_Indemnites_PrimesNonImplCotl { get; set; }

        public virtual ICollection<DetailPoste> DetailsPoste { get; set; }

    }
}