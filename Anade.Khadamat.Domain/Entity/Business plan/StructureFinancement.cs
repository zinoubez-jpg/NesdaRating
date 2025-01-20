using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class StructureFinancement : IEntity<int>
    {
        public int Id { get; set; }
        public decimal ApportPersonnel { get; set; }
        public decimal CMT { get; set; }
        public decimal PNRClassique { get; set; }
        public decimal PNRSupplementaire { get; set; }
        public decimal ApportSupplementaire { get; set; }
        public float TauxIFU { get; set; }
        public float TauxIBS { get; set; }

        [NotMapped]
        public string ApportPersonnelString { get; set; }
        [NotMapped]
        public string CMTString { get; set; }
        [NotMapped]
        public string PNRClassiqueString { get; set; }
        [NotMapped]
        public string PNRSupplementaireString { get; set; }
        [NotMapped]
        public string ApportSupplementaireString { get; set; }
        [NotMapped]
        public string TauxIFUString { get; set; }
        [NotMapped]
        public string TauxIBSString { get; set; }

        public int BusinessPlanId { get; set; }
        public int DiffereEmpruntId { get; set; }
        public int ExonerationFiscaleId { get; set; }
        public int TauxStructureFinancementId { get; set; }

        [ForeignKey("BusinessPlanId")]
        public virtual BusinessPlan BusinessPlan { get; set; }
        public virtual DiffereEmprunt DiffereEmprunt { get; set; }
        public virtual ExonerationFiscale ExonerationFiscale { get; set; }
        public virtual TauxStructureFinancement TauxStructureFinancement { get; set; }

    }
}
