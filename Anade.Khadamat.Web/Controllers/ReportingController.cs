using Anade.Business.Core;
using Anade.Khadamat.Business;
using Anade.Khadamat.Domain;
using Anade.Khadamat.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Anade.Khadamat.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class ReportingController : Controller
    {
        private readonly ILoadProperties<FicheNotation, int> _loadFicheNotationProperties;
        private readonly IReportService _reportService;
        private readonly FicheNotationBusinessService _ficheNotationBusinessService;
        private readonly PromoteurApiService _promoteurApiService;
        private readonly ReferentielBusinessService<Annexe, int> _annexeBusinessService;
        private readonly BusinessPlanBusinessService _businessPlanBusinessService;
        private readonly BusinessPlanReportBusinessService _businessPlanReportBusinessService;
        private readonly ILoadProperties<BusinessPlan, int> _loadBusinessPlanProperties;
        private readonly ILoadProperties<BusinessPlanReport, int> _loadBusinessPlanReportProperties;

        public ReportingController(ILoadProperties<FicheNotation, int> loadFicheNotationProperties,
                                   IReportService reportService,
                                   FicheNotationBusinessService ficheNotationBusinessService,
                                   PromoteurApiService promoteurApiService,
                                   ReferentielBusinessService<Annexe, int> annexeBusinessService,
                                   BusinessPlanBusinessService businessPlanBusinessService,
                                   BusinessPlanReportBusinessService businessPlanReportBusinessService,
                                   ILoadProperties<BusinessPlan, int> loadBusinessPlanProperties,
                                   ILoadProperties<BusinessPlanReport, int> loadBusinessPlanReportProperties
                                   )

        {
            _loadFicheNotationProperties = loadFicheNotationProperties;
            _ficheNotationBusinessService = ficheNotationBusinessService;
            _reportService = reportService;
            _promoteurApiService = promoteurApiService;
            _annexeBusinessService = annexeBusinessService;
            _businessPlanBusinessService = businessPlanBusinessService;
            _businessPlanReportBusinessService = businessPlanReportBusinessService;
            _loadBusinessPlanProperties = loadBusinessPlanProperties;
            _loadBusinessPlanReportProperties = loadBusinessPlanReportProperties;
        }

        [Route("{id}")]
        public IActionResult Print(int id)//(int demandeId, int typeDocId = 1)
        {

            Dictionary<string, string> parameters = new();
            Dictionary<string, object> navWithList = new();
            string reportPrintName = "";
            string reportName = "FicheNotation";

            var ficheId = id;

            Type ConventionPropriete = typeof(FicheNotation);
            reportName = "FicheNotation";
            //récuperer la fiche
            var fiche = _ficheNotationBusinessService.GetAllFiltered(x => x.Id == ficheId, _ficheNotationBusinessService.GetDefaultLoadProperties());
            var fiche2 = _ficheNotationBusinessService.GetById(ficheId, _ficheNotationBusinessService.GetDefaultLoadProperties());
            var annexe = _annexeBusinessService.GetById(fiche2.AnnexeId, _annexeBusinessService.GetDefaultLoadProperties());
            fiche2.Annexe = annexe;



            reportPrintName = "FN_" + fiche2.Numero;
            navWithList = _loadFicheNotationProperties.GetAllNavProp(fiche2);
            //navWithList.Add("Baos", fiche.First());


            var returnReport = _reportService.GenerateReportAsync(reportName, "pdf", navWithList, parameters);
            return File(returnReport, System.Net.Mime.MediaTypeNames.Application.Octet, reportPrintName + ".pdf");

        }

        [Route("{id}")]
        public IActionResult PrintBusinessPlanTest(int id)//(int demandeId, int typeDocId = 1)
        {

            Dictionary<string, string> parameters = new();
            Dictionary<string, object> navWithList = new();
            string reportPrintName = "";
            string reportName = "FicheNotation";

            var BusinessPlanId = id;

            Type ConventionPropriete = typeof(FicheNotation);
            reportName = "BusinessPlan";
            //récuperer la fiche

            var businessPlan = _businessPlanBusinessService.GetById(BusinessPlanId, _businessPlanBusinessService.GetDefaultLoadProperties());
            //var annexe = _annexeBusinessService.GetById(fiche2.AnnexeId, _annexeBusinessService.GetDefaultLoadProperties());
            //fiche2.Annexe = annexe;

            //var businessPlanReport = _businessPlanReportBusinessService.GetById(BusinessPlanId, _businessPlanReportBusinessService.GetDefaultLoadProperties());

            BusinessPlanReport businessPlanReport = new();

            businessPlanReport.BusinessPlanId = businessPlan.Id;
            businessPlanReport.Code = businessPlan.Code;
            businessPlanReport.Date_Creation = businessPlan.Date_Creation;
            businessPlanReport.Complet = businessPlan.Complet;
            businessPlanReport.Date_Generation = businessPlan.Date_Generation;
            businessPlanReport.Utilisateur = businessPlan.Utilisateur;
            businessPlanReport.NumeroSIEJE = businessPlan.NumeroSIEJE;

            businessPlanReport.AchatsConsommesAnnee01 = 0;
            businessPlanReport.AchatsConsommesAnnee02 = 0;
            businessPlanReport.AchatsConsommesAnnee03 = 0;
            businessPlanReport.AchatsConsommesAnnee04 = 0;
            businessPlanReport.AchatsConsommesAnnee05 = 0;
            businessPlanReport.AchatsConsommesAnnee06 = 0;
            businessPlanReport.AchatsConsommesAnnee07 = 0;
            businessPlanReport.ActifsBiologique = 0;
            businessPlanReport.Amenagement = 0;
            businessPlanReport.AmortissementsProvisionsAnnee01 = 0;
            businessPlanReport.AmortissementsProvisionsAnnee02 = 0;
            businessPlanReport.AmortissementsProvisionsAnnee03 = 0;
            businessPlanReport.AmortissementsProvisionsAnnee04 = 0;
            businessPlanReport.AmortissementsProvisionsAnnee05 = 0;
            businessPlanReport.AmortissementsProvisionsAnnee06 = 0;
            businessPlanReport.AmortissementsProvisionsAnnee07 = 0;
            businessPlanReport.ApportPersonnel = 0;
            businessPlanReport.ApportSupplementaire = 0;
            businessPlanReport.AssurancesLieesCreation = 0;
            businessPlanReport.CAFAnnee01 = 0;
            businessPlanReport.CAFAnnee02 = 0;
            businessPlanReport.CAFAnnee03 = 0;
            businessPlanReport.CAFAnnee04 = 0;
            businessPlanReport.CAFAnnee05 = 0;
            businessPlanReport.CAFAnnee06 = 0;
            businessPlanReport.CAFAnnee07 = 0;
            businessPlanReport.ChargesExternesAnnee01 = 0;
            businessPlanReport.ChargesExternesAnnee02 = 0;
            businessPlanReport.ChargesExternesAnnee03 = 0;
            businessPlanReport.ChargesExternesAnnee04 = 0;
            businessPlanReport.ChargesExternesAnnee05 = 0;
            businessPlanReport.ChargesExternesAnnee06 = 0;
            businessPlanReport.ChargesExternesAnnee07 = 0;
            businessPlanReport.ChiffreAffairesAnnee01 = 0;
            businessPlanReport.ChiffreAffairesAnnee02 = 0;
            businessPlanReport.ChiffreAffairesAnnee03 = 0;
            businessPlanReport.ChiffreAffairesAnnee04 = 0;
            businessPlanReport.ChiffreAffairesAnnee05 = 0;
            businessPlanReport.ChiffreAffairesAnnee06 = 0;
            businessPlanReport.ChiffreAffairesAnnee07 = 0;
            businessPlanReport.CMT = 0;
            businessPlanReport.DecaissementAcquisitionEquipementsAnnee01 = 0;
            businessPlanReport.DecaissementAcquisitionEquipementsAnnee02 = 0;
            businessPlanReport.DecaissementAcquisitionEquipementsAnnee03 = 0;
            businessPlanReport.DecaissementAcquisitionEquipementsAnnee04 = 0;
            businessPlanReport.DecaissementAcquisitionEquipementsAnnee05 = 0;
            businessPlanReport.DecaissementAcquisitionEquipementsAnnee06 = 0;
            businessPlanReport.DecaissementAcquisitionEquipementsAnnee07 = 0;
            businessPlanReport.DecaissementIBS_IFU_IRGAnnee01 = 0;
            businessPlanReport.DecaissementIBS_IFU_IRGAnnee02 = 0;
            businessPlanReport.DecaissementIBS_IFU_IRGAnnee03 = 0;
            businessPlanReport.DecaissementIBS_IFU_IRGAnnee04 = 0;
            businessPlanReport.DecaissementIBS_IFU_IRGAnnee05 = 0;
            businessPlanReport.DecaissementIBS_IFU_IRGAnnee06 = 0;
            businessPlanReport.DecaissementIBS_IFU_IRGAnnee07 = 0;
            businessPlanReport.DecaissementTVAPayerAnnee01 = 0;
            businessPlanReport.DecaissementTVAPayerAnnee02 = 0;
            businessPlanReport.DecaissementTVAPayerAnnee03 = 0;
            businessPlanReport.DecaissementTVAPayerAnnee04 = 0;
            businessPlanReport.DecaissementTVAPayerAnnee05 = 0;
            businessPlanReport.DecaissementTVAPayerAnnee06 = 0;
            businessPlanReport.DecaissementTVAPayerAnnee07 = 0;
            businessPlanReport.EncaissementsProvenantEmpruntsAnnee01 = 0;
            businessPlanReport.EncaissementsProvenantEmpruntsAnnee02 = 0;
            businessPlanReport.EncaissementsProvenantEmpruntsAnnee03 = 0;
            businessPlanReport.EncaissementsProvenantEmpruntsAnnee04 = 0;
            businessPlanReport.EncaissementsProvenantEmpruntsAnnee05 = 0;
            businessPlanReport.EncaissementsProvenantEmpruntsAnnee06 = 0;
            businessPlanReport.EncaissementsProvenantEmpruntsAnnee07 = 0;
            businessPlanReport.EncaissementsRecuClientsAnnee01 = 0;
            businessPlanReport.EncaissementsRecuClientsAnnee02 = 0;
            businessPlanReport.EncaissementsRecuClientsAnnee03 = 0;
            businessPlanReport.EncaissementsRecuClientsAnnee04 = 0;
            businessPlanReport.EncaissementsRecuClientsAnnee05 = 0;
            businessPlanReport.EncaissementsRecuClientsAnnee06 = 0;
            businessPlanReport.EncaissementsRecuClientsAnnee07 = 0;
            businessPlanReport.EncaissementsSuiteApportPersonnelAnnee01 = 0;
            businessPlanReport.EncaissementsSuiteApportPersonnelAnnee02 = 0;
            businessPlanReport.EncaissementsSuiteApportPersonnelAnnee03 = 0;
            businessPlanReport.EncaissementsSuiteApportPersonnelAnnee04 = 0;
            businessPlanReport.EncaissementsSuiteApportPersonnelAnnee05 = 0;
            businessPlanReport.EncaissementsSuiteApportPersonnelAnnee06 = 0;
            businessPlanReport.EncaissementsSuiteApportPersonnelAnnee07 = 0;
            businessPlanReport.EquilibreAnnee01 = 0;
            businessPlanReport.EquilibreAnnee02 = 0;
            businessPlanReport.EquilibreAnnee03 = 0;
            businessPlanReport.EquilibreAnnee04 = 0;
            businessPlanReport.EquilibreAnnee05 = 0;
            businessPlanReport.EquilibreAnnee06 = 0;
            businessPlanReport.EquilibreAnnee07 = 0;
            businessPlanReport.EquipementsImportes = 0;
            businessPlanReport.EvolutionChiffreAffairesAnnee01 = 0;
            businessPlanReport.EvolutionChiffreAffairesAnnee02 = 0;
            businessPlanReport.EvolutionChiffreAffairesAnnee03 = 0;
            businessPlanReport.EvolutionChiffreAffairesAnnee04 = 0;
            businessPlanReport.EvolutionChiffreAffairesAnnee05 = 0;
            businessPlanReport.EvolutionChiffreAffairesAnnee06 = 0;
            businessPlanReport.EvolutionChiffreAffairesAnnee07 = 0;
            businessPlanReport.ExcedentBrutExploitationAnnee01 = 0;
            businessPlanReport.ExcedentBrutExploitationAnnee02 = 0;
            businessPlanReport.ExcedentBrutExploitationAnnee03 = 0;
            businessPlanReport.ExcedentBrutExploitationAnnee04 = 0;
            businessPlanReport.ExcedentBrutExploitationAnnee05 = 0;
            businessPlanReport.ExcedentBrutExploitationAnnee06 = 0;
            businessPlanReport.ExcedentBrutExploitationAnnee07 = 0;
            businessPlanReport.FluxTresorerieNetAnnee01 = 0;
            businessPlanReport.FluxTresorerieNetAnnee02 = 0;
            businessPlanReport.FluxTresorerieNetAnnee03 = 0;
            businessPlanReport.FluxTresorerieNetAnnee04 = 0;
            businessPlanReport.FluxTresorerieNetAnnee05 = 0;
            businessPlanReport.FluxTresorerieNetAnnee06 = 0;
            businessPlanReport.FluxTresorerieNetAnnee07 = 0;
            businessPlanReport.FluxTresorerieProvenantExploitationAnnee01 = 0;
            businessPlanReport.FluxTresorerieProvenantExploitationAnnee02 = 0;
            businessPlanReport.FluxTresorerieProvenantExploitationAnnee03 = 0;
            businessPlanReport.FluxTresorerieProvenantExploitationAnnee04 = 0;
            businessPlanReport.FluxTresorerieProvenantExploitationAnnee05 = 0;
            businessPlanReport.FluxTresorerieProvenantExploitationAnnee06 = 0;
            businessPlanReport.FluxTresorerieProvenantExploitationAnnee07 = 0;
            businessPlanReport.FluxTresorerieProvenantFinancementAnnee01 = 0;
            businessPlanReport.FluxTresorerieProvenantFinancementAnnee02 = 0;
            businessPlanReport.FluxTresorerieProvenantFinancementAnnee03 = 0;
            businessPlanReport.FluxTresorerieProvenantFinancementAnnee04 = 0;
            businessPlanReport.FluxTresorerieProvenantFinancementAnnee05 = 0;
            businessPlanReport.FluxTresorerieProvenantFinancementAnnee06 = 0;
            businessPlanReport.FluxTresorerieProvenantFinancementAnnee07 = 0;
            businessPlanReport.FluxTresorerieProvenantInvestissementAnnee01 = 0;
            businessPlanReport.FluxTresorerieProvenantInvestissementAnnee02 = 0;
            businessPlanReport.FluxTresorerieProvenantInvestissementAnnee03 = 0;
            businessPlanReport.FluxTresorerieProvenantInvestissementAnnee04 = 0;
            businessPlanReport.FluxTresorerieProvenantInvestissementAnnee05 = 0;
            businessPlanReport.FluxTresorerieProvenantInvestissementAnnee06 = 0;
            businessPlanReport.FluxTresorerieProvenantInvestissementAnnee07 = 0;
            businessPlanReport.FondsGarantie = 0;
            businessPlanReport.FondsRoulement = 0;
            businessPlanReport.FraisGeneraux = 0;
            businessPlanReport.IBS_IFU_IRGAnnee01 = 0;
            businessPlanReport.IBS_IFU_IRGAnnee02 = 0;
            businessPlanReport.IBS_IFU_IRGAnnee03 = 0;
            businessPlanReport.IBS_IFU_IRGAnnee04 = 0;
            businessPlanReport.IBS_IFU_IRGAnnee05 = 0;
            businessPlanReport.IBS_IFU_IRGAnnee06 = 0;
            businessPlanReport.IBS_IFU_IRGAnnee07 = 0;
            businessPlanReport.InstallationsEquipements = 0;
            businessPlanReport.InvestissementInitial = 0;
            businessPlanReport.MaterielAudioVisuel = 0;
            businessPlanReport.MaterielBureau = 0;
            businessPlanReport.MaterielCommunication = 0;
            businessPlanReport.MaterielInformatique = 0;
            businessPlanReport.MaterielProduction = 0;
            businessPlanReport.MaterielRoulant = 0;
            businessPlanReport.MontantCashFlowActualisesAnnee01 = 0;
            businessPlanReport.MontantCashFlowActualisesAnnee02 = 0;
            businessPlanReport.MontantCashFlowActualisesAnnee03 = 0;
            businessPlanReport.MontantCashFlowActualisesAnnee04 = 0;
            businessPlanReport.MontantCashFlowActualisesAnnee05 = 0;
            businessPlanReport.MontantCashFlowActualisesAnnee06 = 0;
            businessPlanReport.MontantCashFlowActualisesAnnee07 = 0;
            businessPlanReport.MontantCumulCFActualisesAnnee01 = 0;
            businessPlanReport.MontantCumulCFActualisesAnnee02 = 0;
            businessPlanReport.MontantCumulCFActualisesAnnee03 = 0;
            businessPlanReport.MontantCumulCFActualisesAnnee04 = 0;
            businessPlanReport.MontantCumulCFActualisesAnnee05 = 0;
            businessPlanReport.MontantCumulCFActualisesAnnee06 = 0;
            businessPlanReport.MontantCumulCFActualisesAnnee07 = 0;
            businessPlanReport.MontantTresorerieNetAnnee01 = 0;
            businessPlanReport.MontantTresorerieNetAnnee02 = 0;
            businessPlanReport.MontantTresorerieNetAnnee03 = 0;
            businessPlanReport.MontantTresorerieNetAnnee04 = 0;
            businessPlanReport.MontantTresorerieNetAnnee05 = 0;
            businessPlanReport.MontantTresorerieNetAnnee06 = 0;
            businessPlanReport.MontantTresorerieNetAnnee07 = 0;
            businessPlanReport.MontantValeurActuelleNette = 0;
            businessPlanReport.PNRClassique = 0;
            businessPlanReport.PNRSupplementaire = 0;
            businessPlanReport.RemboursementsEmpruntsCMTAnnee01 = 0;
            businessPlanReport.RemboursementsEmpruntsCMTAnnee02 = 0;
            businessPlanReport.RemboursementsEmpruntsCMTAnnee03 = 0;
            businessPlanReport.RemboursementsEmpruntsCMTAnnee04 = 0;
            businessPlanReport.RemboursementsEmpruntsCMTAnnee05 = 0;
            businessPlanReport.RemboursementsEmpruntsCMTAnnee06 = 0;
            businessPlanReport.RemboursementsEmpruntsCMTAnnee07 = 0;
            businessPlanReport.RemboursementsEmpruntsPNRAnnee01 = 0;
            businessPlanReport.RemboursementsEmpruntsPNRAnnee02 = 0;
            businessPlanReport.RemboursementsEmpruntsPNRAnnee03 = 0;
            businessPlanReport.RemboursementsEmpruntsPNRAnnee04 = 0;
            businessPlanReport.RemboursementsEmpruntsPNRAnnee05 = 0;
            businessPlanReport.RemboursementsEmpruntsPNRAnnee06 = 0;
            businessPlanReport.RemboursementsEmpruntsPNRAnnee07 = 0;
            businessPlanReport.ResultatExploitationAnnee01 = 0;
            businessPlanReport.ResultatExploitationAnnee02 = 0;
            businessPlanReport.ResultatExploitationAnnee03 = 0;
            businessPlanReport.ResultatExploitationAnnee04 = 0;
            businessPlanReport.ResultatExploitationAnnee05 = 0;
            businessPlanReport.ResultatExploitationAnnee06 = 0;
            businessPlanReport.ResultatExploitationAnnee07 = 0;
            businessPlanReport.ResultatNetAnnee01 = 0;
            businessPlanReport.ResultatNetAnnee02 = 0;
            businessPlanReport.ResultatNetAnnee03 = 0;
            businessPlanReport.ResultatNetAnnee04 = 0;
            businessPlanReport.ResultatNetAnnee05 = 0;
            businessPlanReport.ResultatNetAnnee06 = 0;
            businessPlanReport.ResultatNetAnnee07 = 0;
            businessPlanReport.SalairesChargesSocialesAnnee01 = 0;
            businessPlanReport.SalairesChargesSocialesAnnee02 = 0;
            businessPlanReport.SalairesChargesSocialesAnnee03 = 0;
            businessPlanReport.SalairesChargesSocialesAnnee04 = 0;
            businessPlanReport.SalairesChargesSocialesAnnee05 = 0;
            businessPlanReport.SalairesChargesSocialesAnnee06 = 0;
            businessPlanReport.SalairesChargesSocialesAnnee07 = 0;
            businessPlanReport.SoldeFinalAnnee01 = 0;
            businessPlanReport.SoldeFinalAnnee02 = 0;
            businessPlanReport.SoldeFinalAnnee03 = 0;
            businessPlanReport.SoldeFinalAnnee04 = 0;
            businessPlanReport.SoldeFinalAnnee05 = 0;
            businessPlanReport.SoldeFinalAnnee06 = 0;
            businessPlanReport.SoldeFinalAnnee07 = 0;
            businessPlanReport.SoldeInitialAnnee01 = 0;
            businessPlanReport.SoldeInitialAnnee02 = 0;
            businessPlanReport.SoldeInitialAnnee03 = 0;
            businessPlanReport.SoldeInitialAnnee04 = 0;
            businessPlanReport.SoldeInitialAnnee05 = 0;
            businessPlanReport.SoldeInitialAnnee06 = 0;
            businessPlanReport.SoldeInitialAnnee07 = 0;
            businessPlanReport.SommesVerseesFournisseursAnnee01 = 0;
            businessPlanReport.SommesVerseesFournisseursAnnee02 = 0;
            businessPlanReport.SommesVerseesFournisseursAnnee03 = 0;
            businessPlanReport.SommesVerseesFournisseursAnnee04 = 0;
            businessPlanReport.SommesVerseesFournisseursAnnee05 = 0;
            businessPlanReport.SommesVerseesFournisseursAnnee06 = 0;
            businessPlanReport.SommesVerseesFournisseursAnnee07 = 0;
            businessPlanReport.SommesVerseesPersonnelCNAS_IRGAnnee01 = 0;
            businessPlanReport.SommesVerseesPersonnelCNAS_IRGAnnee02 = 0;
            businessPlanReport.SommesVerseesPersonnelCNAS_IRGAnnee03 = 0;
            businessPlanReport.SommesVerseesPersonnelCNAS_IRGAnnee04 = 0;
            businessPlanReport.SommesVerseesPersonnelCNAS_IRGAnnee05 = 0;
            businessPlanReport.SommesVerseesPersonnelCNAS_IRGAnnee06 = 0;
            businessPlanReport.SommesVerseesPersonnelCNAS_IRGAnnee07 = 0;
            businessPlanReport.SommesVerseesPrestatairesAnnee01 = 0;
            businessPlanReport.SommesVerseesPrestatairesAnnee02 = 0;
            businessPlanReport.SommesVerseesPrestatairesAnnee03 = 0;
            businessPlanReport.SommesVerseesPrestatairesAnnee04 = 0;
            businessPlanReport.SommesVerseesPrestatairesAnnee05 = 0;
            businessPlanReport.SommesVerseesPrestatairesAnnee06 = 0;
            businessPlanReport.SommesVerseesPrestatairesAnnee07 = 0;
            businessPlanReport.TauxEBEAnnee01 = 0;
            businessPlanReport.TauxEBEAnnee02 = 0;
            businessPlanReport.TauxEBEAnnee03 = 0;
            businessPlanReport.TauxEBEAnnee04 = 0;
            businessPlanReport.TauxEBEAnnee05 = 0;
            businessPlanReport.TauxEBEAnnee06 = 0;
            businessPlanReport.TauxEBEAnnee07 = 0;
            businessPlanReport.TauxVAAnnee01 = 0;
            businessPlanReport.TauxVAAnnee02 = 0;
            businessPlanReport.TauxVAAnnee03 = 0;
            businessPlanReport.TauxVAAnnee04 = 0;
            businessPlanReport.TauxVAAnnee05 = 0;
            businessPlanReport.TauxVAAnnee06 = 0;
            businessPlanReport.TauxVAAnnee07 = 0;
            businessPlanReport.TauxValeurActuelleNette = 0;
            businessPlanReport.Total = 0;
            businessPlanReport.ValeurAjouteeAnnee01 = 0;
            businessPlanReport.ValeurAjouteeAnnee02 = 0;
            businessPlanReport.ValeurAjouteeAnnee03 = 0;
            businessPlanReport.ValeurAjouteeAnnee04 = 0;
            businessPlanReport.ValeurAjouteeAnnee05 = 0;
            businessPlanReport.ValeurAjouteeAnnee06 = 0;
            businessPlanReport.ValeurAjouteeAnnee07 = 0;

            businessPlanReport.TauxApportPersonnel = 0;
            businessPlanReport.TauxCMT = 0;
            businessPlanReport.TauxPNRClassique = 0;

            businessPlanReport.DelaiRecuperation = "0";
            businessPlanReport.DiffereEmprunt = "0";
            businessPlanReport.ExonerationFiscale = "0";
            businessPlanReport.TypeFinancement = "0";

            BusinessResult businessResult;

            businessResult = _businessPlanReportBusinessService.Add(businessPlanReport);

            if (businessResult.Succeeded)
            {
                reportPrintName = "FN_" + businessPlanReport.Code;
                navWithList = _loadBusinessPlanReportProperties.GetAllNavProp(businessPlanReport);
                //navWithList.Add("Baos", fiche.First());

                var returnReport = _reportService.GenerateReportAsync(reportName, "pdf", navWithList, parameters);
                return File(returnReport, System.Net.Mime.MediaTypeNames.Application.Octet, reportPrintName + ".pdf");
            }
            else
            {
                return Json(new { messages = businessResult.ToBootstrapAlerts() });
            }

        }

        [Route("{id}")]
        public IActionResult PrintBusinessPlan(int id)//(int demandeId, int typeDocId = 1)
        {

            Dictionary<string, string> parameters = new();
            Dictionary<string, object> navWithList = new();
            string reportPrintName = "";
            string reportName = "BusinessPlanReport";

            var BusinessPlanId = id;

            Type ConventionPropriete = typeof(FicheNotation);
            reportName = "BusinessPlanReport";
            //récuperer la fiche


            //var businessPlan = _businessPlanBusinessService.GetById(BusinessPlanId, _businessPlanBusinessService.GetDefaultLoadProperties());
            var businessPlan = _businessPlanReportBusinessService.GetSingle(x => x.BusinessPlanId == BusinessPlanId, _businessPlanReportBusinessService.GetDefaultLoadProperties());

            //var annexe = _annexeBusinessService.GetById(fiche2.AnnexeId, _annexeBusinessService.GetDefaultLoadProperties());
            //fiche2.Annexe = annexe;



            reportPrintName = "FN_" + businessPlan.Code;
            navWithList = _loadBusinessPlanReportProperties.GetAllNavProp(businessPlan);
            //navWithList.Add("Baos", fiche.First());


            var returnReport = _reportService.GenerateReportAsync(reportName, "pdf", navWithList, parameters);
            return File(returnReport, System.Net.Mime.MediaTypeNames.Application.Octet, reportPrintName + ".pdf");

        }
    }
}
