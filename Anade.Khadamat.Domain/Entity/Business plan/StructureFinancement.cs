using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class StructureFinancement : IEntity<int>
    {
        public int Id { get; set; }
        public float ApportPersonnel { get; set; }
        public float CMT { get; set; }
        public float PNRClassique { get; set; }
        public float PNRSupplementaire { get; set; }
        public float ApportSupplementaire { get; set; }
        public float TauxIFU { get; set; }
        public float TauxIBS { get; set; }

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
