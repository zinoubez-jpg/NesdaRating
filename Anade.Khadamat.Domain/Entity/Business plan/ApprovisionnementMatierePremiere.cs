using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Anade.Khadamat.Domain
{
    public partial class ApprovisionnementMatierePremiere : IEntity<int>
    {
        public ApprovisionnementMatierePremiere()
        {
            this.DetailsAchatsDirects = new HashSet<DetailAchatsDirects>();
        }

        public int Id { get; set; }
        public string Designation { get; set; }

        public virtual ICollection<DetailAchatsDirects> DetailsAchatsDirects { get; set; }
    }
}