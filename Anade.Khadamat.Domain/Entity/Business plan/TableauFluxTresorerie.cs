using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class TableauFluxTresorerie : IEntity<int>
    {
        public int Id { get; set; }
        public decimal EncaissementsRecuClients { get; set; }
        public decimal SommesVerseesFournisseurs { get; set; }
        public decimal SommesVerseesPrestataires { get; set; }
        public decimal SommesVerseesPersonnelCNAS_IRG { get; set; }
        public decimal DecaissementTVAPayer { get; set; }
        public decimal DecaissementIBS_IFU_IRG { get; set; }
        public decimal FluxTresorerieProvenantExploitation { get; set; }
        public decimal DecaissementAcquisitionEquipements { get; set; }
        public decimal FluxTresorerieProvenantInvestissement { get; set; }
        public decimal EncaissementsSuiteApportPersonnel { get; set; }
        public decimal EncaissementsProvenantEmprunts { get; set; }
        public decimal RemboursementsEmpruntsCMT { get; set; }
        public decimal RemboursementsEmpruntsPNR { get; set; }
        public decimal FluxTresorerieProvenantFinancement { get; set; }
        public decimal FluxTresorerieNet { get; set; }
        public decimal SoldeInitial { get; set; }
        public decimal SoldeFinal { get; set; }
        public decimal Equilibre { get; set; }

        public int AnneeId { get; set; }
        public int BusinessPlanId { get; set; }

        public virtual Annee Annee { get; set; }
        public virtual BusinessPlan BusinessPlan { get; set; }
    }
}
