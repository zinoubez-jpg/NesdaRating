using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class PlanTresorerieMensuel : IEntity<int>
    {
        public int Id { get; set; }
        public float SoldeInitial { get; set; }
        public float ApportSupplementaire { get; set; }
        public float CMT { get; set; }
        public float PNRClassique { get; set; }
        public float ApportPersonnel { get; set; }
        public float PNRLoyer { get; set; }
        public float EncaissementRecusClients { get; set; }
        public float TotalRecette { get; set; }
        public float AcquisitionEquipementAmenagement { get; set; }
        public float DecaissementFournisseurs { get; set; }
        public float DecaissementPrestataires { get; set; }
        public float PaiementFGAssurancesFraisLieesCreation { get; set; }
        public float DecaissementSalairesNets { get; set; }
        public float CotisationsSociales { get; set; }
        public float IRGSalaires { get; set; }
        public float TVAPayer { get; set; }
        public float IBS_IFU { get; set; }
        public float TotalDepense { get; set; }
        public float SoldeFinal { get; set; }

        public int MoisId { get; set; }
        public int BusinessPlanId { get; set; }

        public virtual Mois Mois { get; set; }
        public virtual BusinessPlan BusinessPlan { get; set; }
    }
}
