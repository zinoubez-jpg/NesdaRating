using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Anade.Khadamat.Domain
{
    [NotMapped]
    public partial class ChargeExterne : IEntity<int>
    {
        public int Id { get; set; }

        public string DesignationRubrique { get; set; }

        public decimal Montant01 { get; set; }
        public decimal Montant02 { get; set; }
        public decimal Montant03 { get; set; }
        public decimal Montant04 { get; set; }
        public decimal Montant05 { get; set; }
        public decimal Montant06 { get; set; }
        public decimal Montant07 { get; set; }

        public virtual ICollection<ChargeExterne> ChargesExternes { get; set; }

    }
}