using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Anade.Khadamat.Domain
{
    public partial class ProduitService : IEntity<int>
    {
        public ProduitService()
        {
            this.DetailsChiffreAffaire = new HashSet<DetailChiffreAffaire>();
        }

        public int Id { get; set; }
        public string Designation { get; set; }

        public virtual ICollection<DetailChiffreAffaire> DetailsChiffreAffaire { get; set; }
    }
}