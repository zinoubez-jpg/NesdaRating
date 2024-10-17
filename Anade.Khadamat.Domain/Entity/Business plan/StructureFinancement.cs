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
        public int DiffereEmprunt { get; set; }
        public float ExonerationFiscale { get; set; }

        public int BusinessPlanId { get; set; }

        [ForeignKey("BusinessPlanId")]
        public virtual BusinessPlan BusinessPlan { get; set; }
    }
}
