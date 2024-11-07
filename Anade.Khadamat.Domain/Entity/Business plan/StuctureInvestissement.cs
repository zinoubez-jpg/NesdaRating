using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class StuctureInvestissement : IEntity<int>
    {
        public int Id { get; set; }
        public decimal MaterielProduction { get; set; }
        public decimal MaterielBureau { get; set; }
        public decimal MaterielInformatique { get; set; }
        public decimal MaterielAudioVisuel { get; set; }
        public decimal MaterielCommunication { get; set; }
        public decimal InstallationsEquipements { get; set; }
        public decimal EquipementsImportes { get; set; }
        public decimal ActifsBiologique { get; set; }
        public decimal Amenagement { get; set; }
        public decimal MaterielRoulant { get; set; }
        public decimal FraisGeneraux { get; set; }
        public decimal AssurancesLieesCreation { get; set; }
        public decimal FondsGarantie { get; set; }
        public decimal FondsRoulement { get; set; }
        public decimal Total { get; set; }

        public int BusinessPlanId { get; set; }

        [ForeignKey("BusinessPlanId")]
        public virtual BusinessPlan BusinessPlan { get; set; }
    }
}
