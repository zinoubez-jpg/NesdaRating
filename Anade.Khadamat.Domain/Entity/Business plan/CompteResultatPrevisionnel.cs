using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class CompteResultatPrevisionnel : IEntity<int>
    {
        public int Id { get; set; }
        public decimal ChiffreAffaires { get; set; }
        public decimal AchatsConsommes { get; set; }
        public decimal ChargesExternes { get; set; }
        public decimal ValeurAjoutee { get; set; }
        public decimal SalairesChargesSociales { get; set; }
        public decimal ExcedentBrutExploitation { get; set; }
        public decimal AmortissementsProvisions { get; set; }
        public decimal ResultatExploitation { get; set; }
        public decimal IBS_IFU_IRG { get; set; }
        public decimal ResultatNet { get; set; }
        public decimal EvolutionChiffreAffaires { get; set; }
        public decimal TauxVA { get; set; }
        public decimal TauxEBE { get; set; }
        public decimal CAF { get; set; }

        public int AnneeId { get; set; }
        public int BusinessPlanId { get; set; }

        public virtual Annee Annee { get; set; }
        public virtual BusinessPlan BusinessPlan { get; set; }

    }
}
