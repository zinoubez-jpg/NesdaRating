using Anade.Domain.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    public partial class BusinessPlanReport : IEntity<int>
    {
        public int Id { get; set; }
        public int BusinessPlanId { get; set; }
        public string Code { get; set; }
        public System.DateTime Date_Creation { get; set; }
        public bool Complet { get; set; }
        public System.DateTime? Date_Generation { get; set; }
        public string Utilisateur { get; set; }
        public string NumeroSIEJE { get; set; }
        public string NomPrenom { get; set; }

        public decimal ApportPersonnel { get; set; }
        public decimal CMT { get; set; }
        public decimal PNRClassique { get; set; }
        public decimal PNRSupplementaire { get; set; }
        public decimal ApportSupplementaire { get; set; }

        public int TauxApportPersonnel { get; set; }
        public int TauxCMT { get; set; }
        public int TauxPNRClassique { get; set; }

        public string TypeFinancement { get; set; }
        public string DiffereEmprunt { get; set; }
        public string ExonerationFiscale { get; set; }

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

        public decimal ChiffreAffairesAnnee01 { get; set; }
        public decimal AchatsConsommesAnnee01 { get; set; }
        public decimal ChargesExternesAnnee01 { get; set; }
        public decimal ValeurAjouteeAnnee01 { get; set; }
        public decimal SalairesChargesSocialesAnnee01 { get; set; }
        public decimal ExcedentBrutExploitationAnnee01 { get; set; }
        public decimal AmortissementsProvisionsAnnee01 { get; set; }
        public decimal ResultatExploitationAnnee01 { get; set; }
        public decimal IBS_IFU_IRGAnnee01 { get; set; }
        public decimal ResultatNetAnnee01 { get; set; }
        public decimal EvolutionChiffreAffairesAnnee01 { get; set; }
        public decimal TauxVAAnnee01 { get; set; }
        public decimal TauxEBEAnnee01 { get; set; }
        public decimal CAFAnnee01 { get; set; }

        public decimal ChiffreAffairesAnnee02 { get; set; }
        public decimal AchatsConsommesAnnee02 { get; set; }
        public decimal ChargesExternesAnnee02 { get; set; }
        public decimal ValeurAjouteeAnnee02 { get; set; }
        public decimal SalairesChargesSocialesAnnee02 { get; set; }
        public decimal ExcedentBrutExploitationAnnee02 { get; set; }
        public decimal AmortissementsProvisionsAnnee02 { get; set; }
        public decimal ResultatExploitationAnnee02 { get; set; }
        public decimal IBS_IFU_IRGAnnee02 { get; set; }
        public decimal ResultatNetAnnee02 { get; set; }
        public decimal EvolutionChiffreAffairesAnnee02 { get; set; }
        public decimal TauxVAAnnee02 { get; set; }
        public decimal TauxEBEAnnee02 { get; set; }
        public decimal CAFAnnee02 { get; set; }

        public decimal ChiffreAffairesAnnee03 { get; set; }
        public decimal AchatsConsommesAnnee03 { get; set; }
        public decimal ChargesExternesAnnee03 { get; set; }
        public decimal ValeurAjouteeAnnee03 { get; set; }
        public decimal SalairesChargesSocialesAnnee03 { get; set; }
        public decimal ExcedentBrutExploitationAnnee03 { get; set; }
        public decimal AmortissementsProvisionsAnnee03 { get; set; }
        public decimal ResultatExploitationAnnee03 { get; set; }
        public decimal IBS_IFU_IRGAnnee03 { get; set; }
        public decimal ResultatNetAnnee03 { get; set; }
        public decimal EvolutionChiffreAffairesAnnee03 { get; set; }
        public decimal TauxVAAnnee03 { get; set; }
        public decimal TauxEBEAnnee03 { get; set; }
        public decimal CAFAnnee03 { get; set; }

        public decimal ChiffreAffairesAnnee04 { get; set; }
        public decimal AchatsConsommesAnnee04 { get; set; }
        public decimal ChargesExternesAnnee04 { get; set; }
        public decimal ValeurAjouteeAnnee04 { get; set; }
        public decimal SalairesChargesSocialesAnnee04 { get; set; }
        public decimal ExcedentBrutExploitationAnnee04 { get; set; }
        public decimal AmortissementsProvisionsAnnee04 { get; set; }
        public decimal ResultatExploitationAnnee04 { get; set; }
        public decimal IBS_IFU_IRGAnnee04 { get; set; }
        public decimal ResultatNetAnnee04 { get; set; }
        public decimal EvolutionChiffreAffairesAnnee04 { get; set; }
        public decimal TauxVAAnnee04 { get; set; }
        public decimal TauxEBEAnnee04 { get; set; }
        public decimal CAFAnnee04 { get; set; }

        public decimal ChiffreAffairesAnnee05 { get; set; }
        public decimal AchatsConsommesAnnee05 { get; set; }
        public decimal ChargesExternesAnnee05 { get; set; }
        public decimal ValeurAjouteeAnnee05 { get; set; }
        public decimal SalairesChargesSocialesAnnee05 { get; set; }
        public decimal ExcedentBrutExploitationAnnee05 { get; set; }
        public decimal AmortissementsProvisionsAnnee05 { get; set; }
        public decimal ResultatExploitationAnnee05 { get; set; }
        public decimal IBS_IFU_IRGAnnee05 { get; set; }
        public decimal ResultatNetAnnee05 { get; set; }
        public decimal EvolutionChiffreAffairesAnnee05 { get; set; }
        public decimal TauxVAAnnee05 { get; set; }
        public decimal TauxEBEAnnee05 { get; set; }
        public decimal CAFAnnee05 { get; set; }

        public decimal ChiffreAffairesAnnee06 { get; set; }
        public decimal AchatsConsommesAnnee06 { get; set; }
        public decimal ChargesExternesAnnee06 { get; set; }
        public decimal ValeurAjouteeAnnee06 { get; set; }
        public decimal SalairesChargesSocialesAnnee06 { get; set; }
        public decimal ExcedentBrutExploitationAnnee06 { get; set; }
        public decimal AmortissementsProvisionsAnnee06 { get; set; }
        public decimal ResultatExploitationAnnee06 { get; set; }
        public decimal IBS_IFU_IRGAnnee06 { get; set; }
        public decimal ResultatNetAnnee06 { get; set; }
        public decimal EvolutionChiffreAffairesAnnee06 { get; set; }
        public decimal TauxVAAnnee06 { get; set; }
        public decimal TauxEBEAnnee06 { get; set; }
        public decimal CAFAnnee06 { get; set; }

        public decimal ChiffreAffairesAnnee07 { get; set; }
        public decimal AchatsConsommesAnnee07 { get; set; }
        public decimal ChargesExternesAnnee07 { get; set; }
        public decimal ValeurAjouteeAnnee07 { get; set; }
        public decimal SalairesChargesSocialesAnnee07 { get; set; }
        public decimal ExcedentBrutExploitationAnnee07 { get; set; }
        public decimal AmortissementsProvisionsAnnee07 { get; set; }
        public decimal ResultatExploitationAnnee07 { get; set; }
        public decimal IBS_IFU_IRGAnnee07 { get; set; }
        public decimal ResultatNetAnnee07 { get; set; }
        public decimal EvolutionChiffreAffairesAnnee07 { get; set; }
        public decimal TauxVAAnnee07 { get; set; }
        public decimal TauxEBEAnnee07 { get; set; }
        public decimal CAFAnnee07 { get; set; }

        public decimal EncaissementsRecuClientsAnnee01 { get; set; }
        public decimal SommesVerseesFournisseursAnnee01 { get; set; }
        public decimal SommesVerseesPrestatairesAnnee01 { get; set; }
        public decimal SommesVerseesPersonnelCNAS_IRGAnnee01 { get; set; }
        public decimal DecaissementTVAPayerAnnee01 { get; set; }
        public decimal DecaissementIBS_IFU_IRGAnnee01 { get; set; }
        public decimal FluxTresorerieProvenantExploitationAnnee01 { get; set; }
        public decimal DecaissementAcquisitionEquipementsAnnee01 { get; set; }
        public decimal FluxTresorerieProvenantInvestissementAnnee01 { get; set; }
        public decimal EncaissementsSuiteApportPersonnelAnnee01 { get; set; }
        public decimal EncaissementsProvenantEmpruntsAnnee01 { get; set; }
        public decimal RemboursementsEmpruntsCMTAnnee01 { get; set; }
        public decimal RemboursementsEmpruntsPNRAnnee01 { get; set; }
        public decimal FluxTresorerieProvenantFinancementAnnee01 { get; set; }
        public decimal FluxTresorerieNetAnnee01 { get; set; }
        public decimal SoldeInitialAnnee01 { get; set; }
        public decimal SoldeFinalAnnee01 { get; set; }
        public decimal EquilibreAnnee01 { get; set; }

        public decimal EncaissementsRecuClientsAnnee02 { get; set; }
        public decimal SommesVerseesFournisseursAnnee02 { get; set; }
        public decimal SommesVerseesPrestatairesAnnee02 { get; set; }
        public decimal SommesVerseesPersonnelCNAS_IRGAnnee02 { get; set; }
        public decimal DecaissementTVAPayerAnnee02 { get; set; }
        public decimal DecaissementIBS_IFU_IRGAnnee02 { get; set; }
        public decimal FluxTresorerieProvenantExploitationAnnee02 { get; set; }
        public decimal DecaissementAcquisitionEquipementsAnnee02 { get; set; }
        public decimal FluxTresorerieProvenantInvestissementAnnee02 { get; set; }
        public decimal EncaissementsSuiteApportPersonnelAnnee02 { get; set; }
        public decimal EncaissementsProvenantEmpruntsAnnee02 { get; set; }
        public decimal RemboursementsEmpruntsCMTAnnee02 { get; set; }
        public decimal RemboursementsEmpruntsPNRAnnee02 { get; set; }
        public decimal FluxTresorerieProvenantFinancementAnnee02 { get; set; }
        public decimal FluxTresorerieNetAnnee02 { get; set; }
        public decimal SoldeInitialAnnee02 { get; set; }
        public decimal SoldeFinalAnnee02 { get; set; }
        public decimal EquilibreAnnee02 { get; set; }

        public decimal EncaissementsRecuClientsAnnee03 { get; set; }
        public decimal SommesVerseesFournisseursAnnee03 { get; set; }
        public decimal SommesVerseesPrestatairesAnnee03 { get; set; }
        public decimal SommesVerseesPersonnelCNAS_IRGAnnee03 { get; set; }
        public decimal DecaissementTVAPayerAnnee03 { get; set; }
        public decimal DecaissementIBS_IFU_IRGAnnee03 { get; set; }
        public decimal FluxTresorerieProvenantExploitationAnnee03 { get; set; }
        public decimal DecaissementAcquisitionEquipementsAnnee03 { get; set; }
        public decimal FluxTresorerieProvenantInvestissementAnnee03 { get; set; }
        public decimal EncaissementsSuiteApportPersonnelAnnee03 { get; set; }
        public decimal EncaissementsProvenantEmpruntsAnnee03 { get; set; }
        public decimal RemboursementsEmpruntsCMTAnnee03 { get; set; }
        public decimal RemboursementsEmpruntsPNRAnnee03 { get; set; }
        public decimal FluxTresorerieProvenantFinancementAnnee03 { get; set; }
        public decimal FluxTresorerieNetAnnee03 { get; set; }
        public decimal SoldeInitialAnnee03 { get; set; }
        public decimal SoldeFinalAnnee03 { get; set; }
        public decimal EquilibreAnnee03 { get; set; }

        public decimal EncaissementsRecuClientsAnnee04 { get; set; }
        public decimal SommesVerseesFournisseursAnnee04 { get; set; }
        public decimal SommesVerseesPrestatairesAnnee04 { get; set; }
        public decimal SommesVerseesPersonnelCNAS_IRGAnnee04 { get; set; }
        public decimal DecaissementTVAPayerAnnee04 { get; set; }
        public decimal DecaissementIBS_IFU_IRGAnnee04 { get; set; }
        public decimal FluxTresorerieProvenantExploitationAnnee04 { get; set; }
        public decimal DecaissementAcquisitionEquipementsAnnee04 { get; set; }
        public decimal FluxTresorerieProvenantInvestissementAnnee04 { get; set; }
        public decimal EncaissementsSuiteApportPersonnelAnnee04 { get; set; }
        public decimal EncaissementsProvenantEmpruntsAnnee04 { get; set; }
        public decimal RemboursementsEmpruntsCMTAnnee04 { get; set; }
        public decimal RemboursementsEmpruntsPNRAnnee04 { get; set; }
        public decimal FluxTresorerieProvenantFinancementAnnee04 { get; set; }
        public decimal FluxTresorerieNetAnnee04 { get; set; }
        public decimal SoldeInitialAnnee04 { get; set; }
        public decimal SoldeFinalAnnee04 { get; set; }
        public decimal EquilibreAnnee04 { get; set; }

        public decimal EncaissementsRecuClientsAnnee05 { get; set; }
        public decimal SommesVerseesFournisseursAnnee05 { get; set; }
        public decimal SommesVerseesPrestatairesAnnee05 { get; set; }
        public decimal SommesVerseesPersonnelCNAS_IRGAnnee05 { get; set; }
        public decimal DecaissementTVAPayerAnnee05 { get; set; }
        public decimal DecaissementIBS_IFU_IRGAnnee05 { get; set; }
        public decimal FluxTresorerieProvenantExploitationAnnee05 { get; set; }
        public decimal DecaissementAcquisitionEquipementsAnnee05 { get; set; }
        public decimal FluxTresorerieProvenantInvestissementAnnee05 { get; set; }
        public decimal EncaissementsSuiteApportPersonnelAnnee05 { get; set; }
        public decimal EncaissementsProvenantEmpruntsAnnee05 { get; set; }
        public decimal RemboursementsEmpruntsCMTAnnee05 { get; set; }
        public decimal RemboursementsEmpruntsPNRAnnee05 { get; set; }
        public decimal FluxTresorerieProvenantFinancementAnnee05 { get; set; }
        public decimal FluxTresorerieNetAnnee05 { get; set; }
        public decimal SoldeInitialAnnee05 { get; set; }
        public decimal SoldeFinalAnnee05 { get; set; }
        public decimal EquilibreAnnee05 { get; set; }

        public decimal EncaissementsRecuClientsAnnee06 { get; set; }
        public decimal SommesVerseesFournisseursAnnee06 { get; set; }
        public decimal SommesVerseesPrestatairesAnnee06 { get; set; }
        public decimal SommesVerseesPersonnelCNAS_IRGAnnee06 { get; set; }
        public decimal DecaissementTVAPayerAnnee06 { get; set; }
        public decimal DecaissementIBS_IFU_IRGAnnee06 { get; set; }
        public decimal FluxTresorerieProvenantExploitationAnnee06 { get; set; }
        public decimal DecaissementAcquisitionEquipementsAnnee06 { get; set; }
        public decimal FluxTresorerieProvenantInvestissementAnnee06 { get; set; }
        public decimal EncaissementsSuiteApportPersonnelAnnee06 { get; set; }
        public decimal EncaissementsProvenantEmpruntsAnnee06 { get; set; }
        public decimal RemboursementsEmpruntsCMTAnnee06 { get; set; }
        public decimal RemboursementsEmpruntsPNRAnnee06 { get; set; }
        public decimal FluxTresorerieProvenantFinancementAnnee06 { get; set; }
        public decimal FluxTresorerieNetAnnee06 { get; set; }
        public decimal SoldeInitialAnnee06 { get; set; }
        public decimal SoldeFinalAnnee06 { get; set; }
        public decimal EquilibreAnnee06 { get; set; }

        public decimal EncaissementsRecuClientsAnnee07 { get; set; }
        public decimal SommesVerseesFournisseursAnnee07 { get; set; }
        public decimal SommesVerseesPrestatairesAnnee07 { get; set; }
        public decimal SommesVerseesPersonnelCNAS_IRGAnnee07 { get; set; }
        public decimal DecaissementTVAPayerAnnee07 { get; set; }
        public decimal DecaissementIBS_IFU_IRGAnnee07 { get; set; }
        public decimal FluxTresorerieProvenantExploitationAnnee07 { get; set; }
        public decimal DecaissementAcquisitionEquipementsAnnee07 { get; set; }
        public decimal FluxTresorerieProvenantInvestissementAnnee07 { get; set; }
        public decimal EncaissementsSuiteApportPersonnelAnnee07 { get; set; }
        public decimal EncaissementsProvenantEmpruntsAnnee07 { get; set; }
        public decimal RemboursementsEmpruntsCMTAnnee07 { get; set; }
        public decimal RemboursementsEmpruntsPNRAnnee07 { get; set; }
        public decimal FluxTresorerieProvenantFinancementAnnee07 { get; set; }
        public decimal FluxTresorerieNetAnnee07 { get; set; }
        public decimal SoldeInitialAnnee07 { get; set; }
        public decimal SoldeFinalAnnee07 { get; set; }
        public decimal EquilibreAnnee07 { get; set; }

        public decimal MontantTresorerieNetAnnee01 { get; set; }
        public decimal MontantCashFlowActualisesAnnee01 { get; set; }
        public decimal MontantCumulCFActualisesAnnee01 { get; set; }

        public decimal MontantTresorerieNetAnnee02 { get; set; }
        public decimal MontantCashFlowActualisesAnnee02 { get; set; }
        public decimal MontantCumulCFActualisesAnnee02 { get; set; }

        public decimal MontantTresorerieNetAnnee03 { get; set; }
        public decimal MontantCashFlowActualisesAnnee03 { get; set; }
        public decimal MontantCumulCFActualisesAnnee03 { get; set; }

        public decimal MontantTresorerieNetAnnee04 { get; set; }
        public decimal MontantCashFlowActualisesAnnee04 { get; set; }
        public decimal MontantCumulCFActualisesAnnee04 { get; set; }

        public decimal MontantTresorerieNetAnnee05 { get; set; }
        public decimal MontantCashFlowActualisesAnnee05 { get; set; }
        public decimal MontantCumulCFActualisesAnnee05 { get; set; }

        public decimal MontantTresorerieNetAnnee06 { get; set; }
        public decimal MontantCashFlowActualisesAnnee06 { get; set; }
        public decimal MontantCumulCFActualisesAnnee06 { get; set; }

        public decimal MontantTresorerieNetAnnee07 { get; set; }
        public decimal MontantCashFlowActualisesAnnee07 { get; set; }
        public decimal MontantCumulCFActualisesAnnee07 { get; set; }

        public decimal MontantValeurActuelleNette { get; set; }
        public decimal TauxValeurActuelleNette { get; set; }
        public string DelaiRecuperation { get; set; }
        public decimal InvestissementInitial { get; set; }

    }
}
