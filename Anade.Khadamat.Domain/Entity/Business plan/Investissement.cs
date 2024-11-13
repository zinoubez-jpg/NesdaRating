using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Anade.Khadamat.Domain
{
    [NotMapped]
    public partial class Investissement : IEntity<int>
    {
        public int Id { get; set; }

        public string DesignationMateriel { get; set; }
        public int DureeAmortissement { get; set; }

        public decimal Montant01 { get; set; }
        public decimal Montant02 { get; set; }
        public decimal Montant03 { get; set; }
        public decimal Montant04 { get; set; }
        public decimal Montant05 { get; set; }
        public decimal Montant06 { get; set; }
        public decimal Montant07 { get; set; }

        public decimal MontantMoyenne { get => Moyenne(); }

        public int TypeMaterielId { get; set; }
        public virtual TypeMateriel TypeMateriel { get; set; }

        public virtual ICollection<Investissement> Investissements { get; set; }


        public decimal Moyenne()
        {
            return (Montant01 + Montant02 + Montant03 + Montant04 + Montant05 + Montant06 + Montant07) / 7;
        }
    }
}