using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    [NotMapped]
    public partial class EtatTFTModel : IEntity<int>
    {
        public int Id { get; set; }

        public string EncaissementsRecuClients01 { get; set; }
        public string SommesVerseesFournisseurs01 { get; set; }
        public string SommesVerseesPrestataires01 { get; set; }
        public string SommesVerseesPersonnelCNAS_IRG01 { get; set; }
        public string DecaissementTVAPayer01 { get; set; }
        public string DecaissementIBS_IFU_IRG01 { get; set; }
        public string FluxTresorerieProvenantExploitation01 { get; set; }
        public string DecaissementAcquisitionEquipements01 { get; set; }
        public string FluxTresorerieProvenantInvestissement01 { get; set; }
        public string EncaissementsSuiteApportPersonnel01 { get; set; }
        public string EncaissementsProvenantEmprunts01 { get; set; }
        public string RemboursementsEmpruntsCMT01 { get; set; }
        public string RemboursementsEmpruntsPNR01 { get; set; }
        public string FluxTresorerieProvenantFinancement01 { get; set; }
        public string FluxTresorerieNet01 { get; set; }
        public string SoldeInitial01 { get; set; }
        public string SoldeFinal01 { get; set; }
        public string Equilibre01 { get; set; }

        public string EncaissementsRecuClients02 { get; set; }
        public string SommesVerseesFournisseurs02 { get; set; }
        public string SommesVerseesPrestataires02 { get; set; }
        public string SommesVerseesPersonnelCNAS_IRG02 { get; set; }
        public string DecaissementTVAPayer02 { get; set; }
        public string DecaissementIBS_IFU_IRG02 { get; set; }
        public string FluxTresorerieProvenantExploitation02 { get; set; }
        public string DecaissementAcquisitionEquipements02 { get; set; }
        public string FluxTresorerieProvenantInvestissement02 { get; set; }
        public string EncaissementsSuiteApportPersonnel02 { get; set; }
        public string EncaissementsProvenantEmprunts02 { get; set; }
        public string RemboursementsEmpruntsCMT02 { get; set; }
        public string RemboursementsEmpruntsPNR02 { get; set; }
        public string FluxTresorerieProvenantFinancement02 { get; set; }
        public string FluxTresorerieNet02 { get; set; }
        public string SoldeInitial02 { get; set; }
        public string SoldeFinal02 { get; set; }
        public string Equilibre02 { get; set; }

        public string EncaissementsRecuClients03 { get; set; }
        public string SommesVerseesFournisseurs03 { get; set; }
        public string SommesVerseesPrestataires03 { get; set; }
        public string SommesVerseesPersonnelCNAS_IRG03 { get; set; }
        public string DecaissementTVAPayer03 { get; set; }
        public string DecaissementIBS_IFU_IRG03 { get; set; }
        public string FluxTresorerieProvenantExploitation03 { get; set; }
        public string DecaissementAcquisitionEquipements03 { get; set; }
        public string FluxTresorerieProvenantInvestissement03 { get; set; }
        public string EncaissementsSuiteApportPersonnel03 { get; set; }
        public string EncaissementsProvenantEmprunts03 { get; set; }
        public string RemboursementsEmpruntsCMT03 { get; set; }
        public string RemboursementsEmpruntsPNR03 { get; set; }
        public string FluxTresorerieProvenantFinancement03 { get; set; }
        public string FluxTresorerieNet03 { get; set; }
        public string SoldeInitial03 { get; set; }
        public string SoldeFinal03 { get; set; }
        public string Equilibre03 { get; set; }

        public string EncaissementsRecuClients04 { get; set; }
        public string SommesVerseesFournisseurs04 { get; set; }
        public string SommesVerseesPrestataires04 { get; set; }
        public string SommesVerseesPersonnelCNAS_IRG04 { get; set; }
        public string DecaissementTVAPayer04 { get; set; }
        public string DecaissementIBS_IFU_IRG04 { get; set; }
        public string FluxTresorerieProvenantExploitation04 { get; set; }
        public string DecaissementAcquisitionEquipements04 { get; set; }
        public string FluxTresorerieProvenantInvestissement04 { get; set; }
        public string EncaissementsSuiteApportPersonnel04 { get; set; }
        public string EncaissementsProvenantEmprunts04 { get; set; }
        public string RemboursementsEmpruntsCMT04 { get; set; }
        public string RemboursementsEmpruntsPNR04 { get; set; }
        public string FluxTresorerieProvenantFinancement04 { get; set; }
        public string FluxTresorerieNet04 { get; set; }
        public string SoldeInitial04 { get; set; }
        public string SoldeFinal04 { get; set; }
        public string Equilibre04 { get; set; }

        public string EncaissementsRecuClients05 { get; set; }
        public string SommesVerseesFournisseurs05 { get; set; }
        public string SommesVerseesPrestataires05 { get; set; }
        public string SommesVerseesPersonnelCNAS_IRG05 { get; set; }
        public string DecaissementTVAPayer05 { get; set; }
        public string DecaissementIBS_IFU_IRG05 { get; set; }
        public string FluxTresorerieProvenantExploitation05 { get; set; }
        public string DecaissementAcquisitionEquipements05 { get; set; }
        public string FluxTresorerieProvenantInvestissement05 { get; set; }
        public string EncaissementsSuiteApportPersonnel05 { get; set; }
        public string EncaissementsProvenantEmprunts05 { get; set; }
        public string RemboursementsEmpruntsCMT05 { get; set; }
        public string RemboursementsEmpruntsPNR05 { get; set; }
        public string FluxTresorerieProvenantFinancement05 { get; set; }
        public string FluxTresorerieNet05 { get; set; }
        public string SoldeInitial05 { get; set; }
        public string SoldeFinal05 { get; set; }
        public string Equilibre05 { get; set; }

        public string EncaissementsRecuClients06 { get; set; }
        public string SommesVerseesFournisseurs06 { get; set; }
        public string SommesVerseesPrestataires06 { get; set; }
        public string SommesVerseesPersonnelCNAS_IRG06 { get; set; }
        public string DecaissementTVAPayer06 { get; set; }
        public string DecaissementIBS_IFU_IRG06 { get; set; }
        public string FluxTresorerieProvenantExploitation06 { get; set; }
        public string DecaissementAcquisitionEquipements06 { get; set; }
        public string FluxTresorerieProvenantInvestissement06 { get; set; }
        public string EncaissementsSuiteApportPersonnel06 { get; set; }
        public string EncaissementsProvenantEmprunts06 { get; set; }
        public string RemboursementsEmpruntsCMT06 { get; set; }
        public string RemboursementsEmpruntsPNR06 { get; set; }
        public string FluxTresorerieProvenantFinancement06 { get; set; }
        public string FluxTresorerieNet06 { get; set; }
        public string SoldeInitial06 { get; set; }
        public string SoldeFinal06 { get; set; }
        public string Equilibre06 { get; set; }

        public string EncaissementsRecuClients07 { get; set; }
        public string SommesVerseesFournisseurs07 { get; set; }
        public string SommesVerseesPrestataires07 { get; set; }
        public string SommesVerseesPersonnelCNAS_IRG07 { get; set; }
        public string DecaissementTVAPayer07 { get; set; }
        public string DecaissementIBS_IFU_IRG07 { get; set; }
        public string FluxTresorerieProvenantExploitation07 { get; set; }
        public string DecaissementAcquisitionEquipements07 { get; set; }
        public string FluxTresorerieProvenantInvestissement07 { get; set; }
        public string EncaissementsSuiteApportPersonnel07 { get; set; }
        public string EncaissementsProvenantEmprunts07 { get; set; }
        public string RemboursementsEmpruntsCMT07 { get; set; }
        public string RemboursementsEmpruntsPNR07 { get; set; }
        public string FluxTresorerieProvenantFinancement07 { get; set; }
        public string FluxTresorerieNet07 { get; set; }
        public string SoldeInitial07 { get; set; }
        public string SoldeFinal07 { get; set; }
        public string Equilibre07 { get; set; }

    }
}
