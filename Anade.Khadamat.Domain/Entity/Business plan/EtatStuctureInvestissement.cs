using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    [NotMapped]
    public partial class EtatStuctureInvestissement : IEntity<int>
    {
        public int Id { get; set; }
        public string MaterielProduction { get; set; }
        public string MaterielBureau { get; set; }
        public string MaterielInformatique { get; set; }
        public string MaterielAudioVisuel { get; set; }
        public string MaterielCommunication { get; set; }
        public string InstallationsEquipements { get; set; }
        public string EquipementsImportes { get; set; }
        public string ActifsBiologique { get; set; }
        public string Amenagement { get; set; }
        public string MaterielRoulant { get; set; }
        public string FraisGeneraux { get; set; }
        public string AssurancesLieesCreation { get; set; }
        public string FondsGarantie { get; set; }
        public string FondsRoulement { get; set; }
        public string Total { get; set; }

        public string ApportPersonnel { get; set; }
        public string CMT { get; set; }
        public string PNRClassique { get; set; }

        public string TauxApportPersonnel { get; set; }
        public string TauxCMT { get; set; }
        public string TauxPNRClassique { get; set; }

        public string PNRSupplementaire { get; set; }
        public string ApportSupplementaire { get; set; }
        public string TauxIFU { get; set; }
        public string TauxIBS { get; set; }

    }
}
