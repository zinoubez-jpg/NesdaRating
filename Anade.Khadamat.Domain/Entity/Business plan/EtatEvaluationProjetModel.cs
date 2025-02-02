using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    [NotMapped]
    public partial class EtatEvaluationProjetModel : IEntity<int>
    {
        public int Id { get; set; }

        public string MontantTresorerieNetAnnee01 { get; set; }
        public string MontantCashFlowActualisesAnnee01 { get; set; }
        public string MontantCumulCFActualisesAnnee01 { get; set; }

        public string MontantTresorerieNetAnnee02 { get; set; }
        public string MontantCashFlowActualisesAnnee02 { get; set; }
        public string MontantCumulCFActualisesAnnee02 { get; set; }

        public string MontantTresorerieNetAnnee03 { get; set; }
        public string MontantCashFlowActualisesAnnee03 { get; set; }
        public string MontantCumulCFActualisesAnnee03 { get; set; }

        public string MontantTresorerieNetAnnee04 { get; set; }
        public string MontantCashFlowActualisesAnnee04 { get; set; }
        public string MontantCumulCFActualisesAnnee04 { get; set; }

        public string MontantTresorerieNetAnnee05 { get; set; }
        public string MontantCashFlowActualisesAnnee05 { get; set; }
        public string MontantCumulCFActualisesAnnee05 { get; set; }

        public string MontantTresorerieNetAnnee06 { get; set; }
        public string MontantCashFlowActualisesAnnee06 { get; set; }
        public string MontantCumulCFActualisesAnnee06 { get; set; }

        public string MontantTresorerieNetAnnee07 { get; set; }
        public string MontantCashFlowActualisesAnnee07 { get; set; }
        public string MontantCumulCFActualisesAnnee07 { get; set; }

        public string MontantValeurActuelleNette { get; set; }
        public string TauxValeurActuelleNette { get; set; }
        public string DelaiRecuperation { get; set; }
        public string InvestissementInitial { get; set; }

    }
}
