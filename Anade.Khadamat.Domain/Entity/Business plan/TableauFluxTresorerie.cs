using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class TableauFluxTresorerie : IEntity<int>
    {
        public int Id { get; set; }
        public float EncaissementsRecuClients { get; set; }
        public float SommesVerseesFournisseurs { get; set; }
        public float SommesVerseesPrestataires { get; set; }
        public float SommesVerseesPersonnelCNAS_IRG { get; set; }
        public float DecaissementTVAPayer { get; set; }
        public float DecaissementIBS_IFU_IRG { get; set; }
        public float FluxTresorerieProvenantExploitation { get; set; }
        public float DecaissementAcquisitionEquipements { get; set; }
        public float FluxTresorerieProvenantInvestissement { get; set; }
        public float EncaissementsSuiteApportPersonnel { get; set; }
        public float EncaissementsProvenantEmprunts { get; set; }
        public float RemboursementsEmpruntsCMT { get; set; }
        public float RemboursementsEmpruntsPNR { get; set; }
        public float FluxTresorerieProvenantFinancement { get; set; }
        public float FluxTresorerieNet { get; set; }
        public float SoldeInitial { get; set; }
        public float SoldeFinal { get; set; }
        public float Equilibre { get; set; }

        public int AnneeId { get; set; }
        public int BusinessPlanId { get; set; }

        public virtual Annee Annee { get; set; }
        public virtual BusinessPlan BusinessPlan { get; set; }
    }
}
