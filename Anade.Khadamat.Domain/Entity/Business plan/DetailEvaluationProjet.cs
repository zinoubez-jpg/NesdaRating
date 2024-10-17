using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class DetailEvaluationProjet : IEntity<int>
    {
        public int Id { get; set; }
        public float MontantTresorerieNet { get; set; }
        public float MontantCashFlowActualises { get; set; }
        public float MontantCumulCFActualises { get; set; }

        public int AnneeId { get; set; }
        public int EvaluationProjetId { get; set; }

        public virtual Annee Annee { get; set; }
        public virtual EvaluationProjet EvaluationProjet { get; set; }
    }
}
