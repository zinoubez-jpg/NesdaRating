using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class CompteResultatPrevisionnel : IEntity<int>
    {
        public int Id { get; set; }
        public float ChiffreAffaires { get; set; }
        public float AchatsConsommes { get; set; }
        public float ChargesExternes { get; set; }
        public float ValeurAjoutee { get; set; }
        public float SalairesChargesSociales { get; set; }
        public float ExcedentBrutExploitation { get; set; }
        public float AmortissementsProvisions { get; set; }
        public float ResultatExploitation { get; set; }
        public float IBS_IFU_IRG { get; set; }
        public float ResultatNet { get; set; }
        public float EvolutionChiffreAffaires { get; set; }
        public float TauxVA { get; set; }
        public float TauxEBE { get; set; }
        public float CAF { get; set; }

        public int AnneeId { get; set; }
        public int BusinessPlanId { get; set; }

        public virtual Annee Annee { get; set; }
        public virtual BusinessPlan BusinessPlan { get; set; }

    }
}
