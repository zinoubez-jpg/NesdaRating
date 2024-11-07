using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class DetailEvaluationProjet : IEntity<int>
    {
        public int Id { get; set; }
        public decimal MontantTresorerieNet { get; set; }
        public decimal MontantCashFlowActualises { get; set; }
        public decimal MontantCumulCFActualises { get; set; }

        public int AnneeId { get; set; }
        public int EvaluationProjetId { get; set; }

        public virtual Annee Annee { get; set; }
        public virtual EvaluationProjet EvaluationProjet { get; set; }

    }
}
