using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Anade.Khadamat.Domain
{
    public partial class DetailActiviteMois : IEntity<int>
    {
        public int Id { get; set; }
        public float TauxActivite { get; set; }

        public int MoisId { get; set; }
        public int FrequenceActiviteId { get; set; }
        public int InformationBaseId { get; set; }

        public virtual Mois Mois { get; set; }
        public virtual FrequenceActivite FrequenceActivite { get; set; }
        public virtual InformationBase InformationBase { get; set; }
    }
}