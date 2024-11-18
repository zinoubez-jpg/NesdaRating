using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Anade.Khadamat.Domain
{
    [NotMapped]
    public partial class ChiffreAffaire : IEntity<int>
    {
        public int Id { get; set; }

        public string DesignationProduitService { get; set; }

        public decimal Quantite01 { get; set; }
        public decimal Quantite02 { get; set; }
        public decimal Quantite03 { get; set; }
        public decimal Quantite04 { get; set; }
        public decimal Quantite05 { get; set; }
        public decimal Quantite06 { get; set; }
        public decimal Quantite07 { get; set; }

        public decimal PrixUnitaire01 { get; set; }
        public decimal PrixUnitaire02 { get; set; }
        public decimal PrixUnitaire03 { get; set; }
        public decimal PrixUnitaire04 { get; set; }
        public decimal PrixUnitaire05 { get; set; }
        public decimal PrixUnitaire06 { get; set; }
        public decimal PrixUnitaire07 { get; set; }

        public decimal ChiffreAffaire01 { get; set; }
        public decimal ChiffreAffaire02 { get; set; }
        public decimal ChiffreAffaire03 { get; set; }
        public decimal ChiffreAffaire04 { get; set; }
        public decimal ChiffreAffaire05 { get; set; }
        public decimal ChiffreAffaire06 { get; set; }
        public decimal ChiffreAffaire07 { get; set; }

        public virtual ICollection<ChiffreAffaire> ChiffresAffaire { get; set; }

    }
}