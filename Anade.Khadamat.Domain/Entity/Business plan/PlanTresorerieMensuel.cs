using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class PlanTresorerieMensuel : IEntity<int>
    {
        public int Id { get; set; }
        public decimal SoldeInitial { get; set; }
        public decimal ApportSupplementaire { get; set; }
        public decimal CMT { get; set; }
        public decimal PNRClassique { get; set; }
        public decimal ApportPersonnel { get; set; }
        public decimal PNRLoyer { get; set; }
        public decimal EncaissementRecusClients { get; set; }
        public decimal TotalRecette { get; set; }
        public decimal AcquisitionEquipementAmenagement { get; set; }
        public decimal DecaissementFournisseurs { get; set; }
        public decimal DecaissementPrestataires { get; set; }
        public decimal PaiementFGAssurancesFraisLieesCreation { get; set; }
        public decimal DecaissementSalairesNets { get; set; }
        public decimal CotisationsSociales { get; set; }
        public decimal IRGSalaires { get; set; }
        public decimal TVAPayer { get; set; }
        public decimal IBS_IFU { get; set; }
        public decimal TotalDepense { get; set; }
        public decimal SoldeFinal { get; set; }

        public int MoisId { get; set; }
        public int BusinessPlanId { get; set; }

        public virtual Mois Mois { get; set; }
        public virtual BusinessPlan BusinessPlan { get; set; }
    }
}
