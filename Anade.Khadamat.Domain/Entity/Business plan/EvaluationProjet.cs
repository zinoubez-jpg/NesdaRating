using Anade.Domain.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class EvaluationProjet : IEntity<int>
    {
        public EvaluationProjet()
        {
            this.DetailsEvaluationProjet = new HashSet<DetailEvaluationProjet>();
        }

        public int Id { get; set; }
        public decimal MontantValeurActuelleNette { get; set; }
        public string DelaiRecuperation { get; set; }
        public decimal InvestissementInitial { get; set; }
        public decimal TauxValeurActuelleNette { get; set; }

        public int BusinessPlanId { get; set; }

        [ForeignKey("BusinessPlanId")]
        public virtual BusinessPlan BusinessPlan { get; set; }

        public virtual ICollection<DetailEvaluationProjet> DetailsEvaluationProjet { get; set; }
    }
}
