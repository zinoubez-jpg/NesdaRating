using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class StuctureInvestissement : IEntity<int>
    {
        public int Id { get; set; }
        public float MaterielProduction { get; set; }
        public float MaterielBureau { get; set; }
        public float MaterielInformatique { get; set; }
        public float MaterielAudioVisuel { get; set; }
        public float MaterielCommunication { get; set; }
        public float InstallationsEquipements { get; set; }
        public float EquipementsImportes { get; set; }
        public float ActifsBiologique { get; set; }
        public float Amenagement { get; set; }
        public float MaterielRoulant { get; set; }
        public float FraisGeneraux { get; set; }
        public float AssurancesLieesCreation { get; set; }
        public float FondsGarantie { get; set; }
        public float FondsRoulement { get; set; }
        public float Total { get; set; }

        public int BusinessPlanId { get; set; }

        [ForeignKey("BusinessPlanId")]
        public virtual BusinessPlan BusinessPlan { get; set; }
    }
}
