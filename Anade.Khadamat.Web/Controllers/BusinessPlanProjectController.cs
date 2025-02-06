using Anade.Business.Core;
using Anade.Khadamat.Business;
using Anade.Khadamat.Domain;
using Anade.Khadamat.Identity;
using Anade.Khadamat.Web.Services;
using Anade.Khadamat.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anade.Khadamat.Web.Controllers
{

    [Route("[controller]/[action]")]
    public class BusinessPlanProjectController : Controller
    {
        private readonly UserService _userService;
        private readonly AnnexeBusinessService _annexeBusinessService;
        private readonly ReferentielBusinessService<Antenne, int> _antenneBusinessService;
        private readonly NesdaProjectBusinessService _nesdaProjectBusinessService;
        private readonly FicheNotationBusinessService _ficheNotationBusinessService;
        private readonly PromoteurApiService _promoteurApiService;

        private readonly ReferentielBusinessService<Client, int> _clientBusinessService;
        private readonly ReferentielBusinessService<ContributionFinanciere, int> _contributionFinanciereBusinessService;
        private readonly ReferentielBusinessService<ExperienceProfessionnel, int> _experienceProfessionnelBusinessService;
        private readonly ReferentielBusinessService<Dr, int> _drBusinessService;
        private readonly ReferentielBusinessService<Van, int> _vanBusinessService;
        private readonly ReferentielBusinessService<Marketing, int> _marketingBusinessService;
        private readonly ReferentielBusinessService<NiveauFormation, int> _niveauFormationBusinessService;
        private readonly ReferentielBusinessService<Pricing, int> _pricingBusinessService;
        private readonly ReferentielBusinessService<Concorrdence, int> _concorrdenceBusinessService;

        private readonly WilayaApiService _wilayaApiService;
        private readonly PaysApiService _paysApiService;

        private readonly BusinessPlanBusinessService _businessPlanBusinessService;
        private readonly ReferentielBusinessService<Categorie, int> _categorieBusinessService;
        private readonly ReferentielBusinessService<TypeActivite, int> _typeActiviteBusinessService;

        private readonly ReferentielBusinessService<FormeJuridique, int> _formeJuridiqueBusinessService;
        private readonly ReferentielBusinessService<TypeFinancement, int> _typeFinancementBusinessService;
        private readonly CommuneBPBusinessService _communeBPBusinessService;
        private readonly ReferentielBusinessService<RegimeImposition, int> _regimeImpositionBusinessService;
        private readonly ReferentielBusinessService<TauxTVA, int> _tauxTVABusinessService;
        private readonly ReferentielBusinessService<FrequenceActivite, int> _frequenceActiviteBusinessService;

        private readonly ReferentielBusinessService<DiffereEmprunt, int> _differeEmpruntBusinessService;
        private readonly ReferentielBusinessService<ExonerationFiscale, int> _exonerationFiscaleBusinessService;
        private readonly TauxStructureFinancementBusinessService _tauxStructureFinancementBusinessService;
        private readonly ReferentielBusinessService<TypeMateriel, int> _typeMaterielBusinessService;
        private readonly ReferentielBusinessService<Annee, int> _anneeBusinessService;
        private readonly ReferentielBusinessService<RubriqueChargesExternes, int> _rubriqueChargesExternesBusinessService;

        private readonly StuctureInvestissementBusinessService _stuctureInvestissementBusinessService;
        private readonly DetailChargesExternesBusinessService _detailChargesExternesBusinessService;
        private readonly DetailInvestissementBusinessService _detailInvestissementBusinessService;
        private readonly AcquisitionBusinessService _acquisitionBusinessService;
        private readonly StructureFinancementBusinessService _structureFinancementBusinessService;
        private readonly DetailChiffreAffaireBusinessService _detailChiffreAffaireBusinessService;
        private readonly DetailAchatsDirectsBusinessService _detailAchatsDirectsBusinessService;
        private readonly PosteBusinessService _posteBusinessService;

        public BusinessPlanProjectController(UserService userService,
                                             AnnexeBusinessService annexeBusinessService,
                                             ReferentielBusinessService<Antenne, int> antenneBusinessService,
                                             NesdaProjectBusinessService nesdaProjectBusinessService,
                                             FicheNotationBusinessService ficheNotationBusinessService,
                                             PromoteurApiService promoteurApiService,
                                             ReferentielBusinessService<Client, int> clientBusinessService,
                                             ReferentielBusinessService<ContributionFinanciere, int> contributionFinanciereBusinessService,
                                             ReferentielBusinessService<ExperienceProfessionnel, int> experienceProfessionnelBusinessService,
                                             ReferentielBusinessService<Dr, int> drBusinessService,
                                             ReferentielBusinessService<Van, int> vanBusinessService,
                                             ReferentielBusinessService<Marketing, int> marketingBusinessService,
                                             ReferentielBusinessService<NiveauFormation, int> niveauFormationBusinessService,
                                             ReferentielBusinessService<Pricing, int> pricingBusinessService,
                                             ReferentielBusinessService<Concorrdence, int> concorrdenceBusinessService,

                                             WilayaApiService wilayaApiService,
                                             PaysApiService paysApiService,

                                             BusinessPlanBusinessService businessPlanBusinessService,
                                             ReferentielBusinessService<Categorie, int> categorieBusinessService,
                                             ReferentielBusinessService<TypeActivite, int> typeActiviteBusinessService,
                                             ReferentielBusinessService<FormeJuridique, int> formeJuridiqueBusinessService,
                                             ReferentielBusinessService<TypeFinancement, int> typeFinancementBusinessService,
                                             CommuneBPBusinessService communeBPBusinessService,
                                             ReferentielBusinessService<RegimeImposition, int> regimeImpositionBusinessService,
                                             ReferentielBusinessService<TauxTVA, int> tauxTVABusinessService,
                                             ReferentielBusinessService<FrequenceActivite, int> frequenceActiviteBusinessService,
                                             ReferentielBusinessService<DiffereEmprunt, int> differeEmpruntBusinessService,
                                             ReferentielBusinessService<ExonerationFiscale, int> exonerationFiscaleBusinessService,
                                             TauxStructureFinancementBusinessService tauxStructureFinancementBusinessService,
                                             ReferentielBusinessService<TypeMateriel, int> typeMaterielBusinessService,
                                             ReferentielBusinessService<Annee, int> anneeBusinessService,
                                             ReferentielBusinessService<RubriqueChargesExternes, int> rubriqueChargesExternesBusinessService,
                                             StuctureInvestissementBusinessService stuctureInvestissementBusinessService,
                                             DetailChargesExternesBusinessService detailChargesExternesBusinessService,
                                             DetailInvestissementBusinessService detailInvestissementBusinessService,
                                             AcquisitionBusinessService acquisitionBusinessService,
                                             StructureFinancementBusinessService structureFinancementBusinessService,
                                             DetailChiffreAffaireBusinessService detailChiffreAffaireBusinessService,
                                             DetailAchatsDirectsBusinessService detailAchatsDirectsBusinessService,
                                             PosteBusinessService posteBusinessService

                                             )
        {
            _userService = userService;
            _annexeBusinessService = annexeBusinessService;
            _antenneBusinessService = antenneBusinessService;
            _nesdaProjectBusinessService = nesdaProjectBusinessService;
            _ficheNotationBusinessService = ficheNotationBusinessService;
            _promoteurApiService = promoteurApiService;
            _clientBusinessService = clientBusinessService;
            _contributionFinanciereBusinessService = contributionFinanciereBusinessService;
            _experienceProfessionnelBusinessService = experienceProfessionnelBusinessService;
            _drBusinessService = drBusinessService;
            _vanBusinessService = vanBusinessService;
            _marketingBusinessService = marketingBusinessService;
            _niveauFormationBusinessService = niveauFormationBusinessService;
            _pricingBusinessService = pricingBusinessService;
            _concorrdenceBusinessService = concorrdenceBusinessService;

            _wilayaApiService = wilayaApiService;
            _paysApiService = paysApiService;

            _businessPlanBusinessService = businessPlanBusinessService;
            _categorieBusinessService = categorieBusinessService;
            _typeActiviteBusinessService = typeActiviteBusinessService;
            _formeJuridiqueBusinessService = formeJuridiqueBusinessService;
            _typeFinancementBusinessService = typeFinancementBusinessService;
            _communeBPBusinessService = communeBPBusinessService;
            _regimeImpositionBusinessService = regimeImpositionBusinessService;
            _tauxTVABusinessService = tauxTVABusinessService;
            _frequenceActiviteBusinessService = frequenceActiviteBusinessService;
            _differeEmpruntBusinessService = differeEmpruntBusinessService;
            _exonerationFiscaleBusinessService = exonerationFiscaleBusinessService;
            _tauxStructureFinancementBusinessService = tauxStructureFinancementBusinessService;
            _typeMaterielBusinessService = typeMaterielBusinessService;
            _anneeBusinessService = anneeBusinessService;
            _rubriqueChargesExternesBusinessService = rubriqueChargesExternesBusinessService;
            _stuctureInvestissementBusinessService = stuctureInvestissementBusinessService;
            _detailChargesExternesBusinessService = detailChargesExternesBusinessService;
            _detailInvestissementBusinessService = detailInvestissementBusinessService;
            _acquisitionBusinessService = acquisitionBusinessService;
            _structureFinancementBusinessService = structureFinancementBusinessService;
            _detailChiffreAffaireBusinessService = detailChiffreAffaireBusinessService;
            _detailAchatsDirectsBusinessService = detailAchatsDirectsBusinessService;
            _posteBusinessService = posteBusinessService;
        }

        [Authorize(Roles = "Analyste,DG,Admin,AdminAgence,Utilisateur-Rating")]
        public async Task<IActionResult> Index()
        {

            var user = await _userService.GetUserEagerLoadedAsync(User);
            var structure = await _userService.GetStructureFromUserAsync(user.Id);
            var designationToCode = new Dictionary<string, string>
            {
                { "ANTENNE ROUIBA", "1606" },
                { "ANTENNE EL HARRACH", "1607" },
                { "ANTENNE HUSSEIN DEY", "1604" },
                { "ANTENNE DAR EL BEIDA", "1614" },
                { "ANTENNE SIDI M''HAMED", "1602" },
                { "ANTENNE BOUZAREAH", "1612" },
                { "ANTENNE BAB EL OUED", "1609" },
                { "ANTENNE ZERALDA", "1605" },
                { "ANTENNE CHERAGA", "1610" },
                { "ANTENNE DRARIA", "1611" },
                { "ANTENNE BIRTOUTA", "1603" },
                { "ANTENNE BIR MOURAD RAIS", "1608" },
                { "ANTENNE BARAKI", "1613" }
            };

            if (designationToCode.TryGetValue(structure.Designation, out var code))
            {
                structure.CodeStructure = code;
            }

            if (structure.Designation == "DG")
            {
                List<PROMOTEUR> promoteurs = new List<PROMOTEUR>();
                var fiches = _ficheNotationBusinessService.GetAllPaged();
                var fichesFiltredByNumDoss = RemoveDuplicatesFiche(fiches.Items);
                foreach (var item in fichesFiltredByNumDoss) promoteurs.Add(await _promoteurApiService.GetByNumDossAsync(item.PromoteurId));
                return View(promoteurs);

            }
            else
            {
                List<PROMOTEUR> promoteurs = new List<PROMOTEUR>();
                var fiches = _ficheNotationBusinessService.GetAllFilteredPaged(x => x.Annexe.Code.StartsWith(structure.CodeStructure) || x.Annexe.Antenne.Code.StartsWith(structure.CodeStructure));
                var fichesFiltredByNumDoss = RemoveDuplicatesFiche(fiches.Items);
                foreach (var item in fichesFiltredByNumDoss) promoteurs.Add(await _promoteurApiService.GetByNumDossAsync(item.PromoteurId));
                return View(promoteurs);

            }
        }

        [Authorize(Roles = "Analyste")]
        public virtual IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Analyste")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(PROMOTEUR model)
        {

            var user = await _userService.GetUserEagerLoadedAsync(User);
            var structure = await _userService.GetStructureFromUserAsync(user.Id);
            var designationToCode = new Dictionary<string, string>
            {
                { "ANTENNE ROUIBA", "1606" },
                { "ANTENNE EL HARRACH", "1607" },
                { "ANTENNE HUSSEIN DEY", "1604" },
                { "ANTENNE DAR EL BEIDA", "1614" },
                { "ANTENNE SIDI M''HAMED", "1602" },
                { "ANTENNE BOUZAREAH", "1612" },
                { "ANTENNE BAB EL OUED", "1609" },
                { "ANTENNE ZERALDA", "1605" },
                { "ANTENNE CHERAGA", "1610" },
                { "ANTENNE DRARIA", "1611" },
                { "ANTENNE BIRTOUTA", "1603" },
                { "ANTENNE BIR MOURAD RAIS", "1608" },
                { "ANTENNE BARAKI", "1613" }
            };

            if (designationToCode.TryGetValue(structure.Designation, out var code))
            {
                structure.CodeStructure = code;
            }



            var promoteur = await _promoteurApiService.GetByIdAsync(model.Id);

            if (promoteur.NUM_DOSS.StartsWith(structure.CodeStructure))
            {
                model = promoteur;
                model.Id = promoteur.NUM_DOSS;

                return RedirectToAction("Details", new { id = model.NUM_DOSS });

            }

            return RedirectToAction("Erreur");


        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{promoteurId}")]
        public async Task<IActionResult> Fiche(string promoteurId)
        {
            ViewData["AnnexeID"] = new SelectList(_annexeBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["AntenneID"] = new SelectList(_antenneBusinessService.GetAll(), "Id", "DesignationFr");

            var user = await _userService.GetUserEagerLoadedAsync(User);
            var structure = _userService.GetStructureFromUserAsync(user.Id).Result;
            var designationToCode = new Dictionary<string, string>
            {
                { "ANTENNE ROUIBA", "1606" },
                { "ANTENNE EL HARRACH", "1607" },
                { "ANTENNE HUSSEIN DEY", "1604" },
                { "ANTENNE DAR EL BEIDA", "1614" },
                { "ANTENNE SIDI M''HAMED", "1602" },
                { "ANTENNE BOUZAREAH", "1612" },
                { "ANTENNE BAB EL OUED", "1609" },
                { "ANTENNE ZERALDA", "1605" },
                { "ANTENNE CHERAGA", "1610" },
                { "ANTENNE DRARIA", "1611" },
                { "ANTENNE BIRTOUTA", "1603" },
                { "ANTENNE BIR MOURAD RAIS", "1608" },
                { "ANTENNE BARAKI", "1613" }
            };

            if (designationToCode.TryGetValue(structure.Designation, out var code))
            {
                structure.CodeStructure = code;
            }

            var model = _ficheNotationBusinessService.GetAllFiltered(x => x.PromoteurId == promoteurId && (x.Annexe.Code == structure.CodeStructure || x.Annexe.Antenne.Code == structure.CodeStructure), _ficheNotationBusinessService.GetDefaultLoadProperties());


            return PartialView($"_{nameof(Fiche)}", model);
        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{promoteurId}")]
        public async Task<IActionResult> InfosBusinessPlan(string promoteurId)
        {
            ViewData["AnnexeID"] = new SelectList(_annexeBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["AntenneID"] = new SelectList(_antenneBusinessService.GetAll(), "Id", "DesignationFr");

            var user = await _userService.GetUserEagerLoadedAsync(User);
            var structure = _userService.GetStructureFromUserAsync(user.Id).Result;
            var designationToCode = new Dictionary<string, string>
            {
                { "ANTENNE ROUIBA", "1606" },
                { "ANTENNE EL HARRACH", "1607" },
                { "ANTENNE HUSSEIN DEY", "1604" },
                { "ANTENNE DAR EL BEIDA", "1614" },
                { "ANTENNE SIDI M''HAMED", "1602" },
                { "ANTENNE BOUZAREAH", "1612" },
                { "ANTENNE BAB EL OUED", "1609" },
                { "ANTENNE ZERALDA", "1605" },
                { "ANTENNE CHERAGA", "1610" },
                { "ANTENNE DRARIA", "1611" },
                { "ANTENNE BIRTOUTA", "1603" },
                { "ANTENNE BIR MOURAD RAIS", "1608" },
                { "ANTENNE BARAKI", "1613" }
            };

            if (designationToCode.TryGetValue(structure.Designation, out var code))
            {
                structure.CodeStructure = code;
            }

            var model = _businessPlanBusinessService.GetAllFiltered(x => x.NumeroSIEJE == promoteurId, _businessPlanBusinessService.GetDefaultLoadProperties());

            return PartialView($"_{nameof(InfosBusinessPlan)}", model);
        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{promoteurId}")]
        public IActionResult AddBusinessPlan(string promoteurId)
        {
            ViewData["AnnexeID"] = new SelectList(_annexeBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["AntenneID"] = new SelectList(_antenneBusinessService.GetAll(), "Id", "DesignationFr");

            ViewData["ClientID"] = new SelectList(_clientBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["ContributionFinanciereID"] = new SelectList(_contributionFinanciereBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["ExperienceProfessionnelID"] = new SelectList(_experienceProfessionnelBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["DrID"] = new SelectList(_drBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["MarketingID"] = new SelectList(_marketingBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["VanID"] = new SelectList(_vanBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["NiveauFormationID"] = new SelectList(_niveauFormationBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["PricingID"] = new SelectList(_pricingBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["ConcorrdenceID"] = new SelectList(_concorrdenceBusinessService.GetAll(), "Id", "DesignationFr");

            ViewData["CategorieID"] = new SelectList(_categorieBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["TypeActiviteID"] = new SelectList(_typeActiviteBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["FormeJuridiqueID"] = new SelectList(_formeJuridiqueBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["TypeFinancementID"] = new SelectList(_typeFinancementBusinessService.GetAll(), "Id", "DesignationFr");

            ViewData["RegimeImpositionID"] = new SelectList(_regimeImpositionBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["TauxTVAID"] = new SelectList(_tauxTVABusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["FrequenceActiviteID"] = new SelectList(_frequenceActiviteBusinessService.GetAll(), "Id", "DesignationFr");

            ViewData["TauxStructureFinancementID"] = new SelectList(_tauxStructureFinancementBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["DiffereEmpruntID"] = new SelectList(_differeEmpruntBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["ExonerationFiscaleID"] = new SelectList(_exonerationFiscaleBusinessService.GetAll(), "Id", "DesignationFr");

            ViewData["CommuneBPID"] = new SelectList(_communeBPBusinessService.GetByCodeWilaya(promoteurId.Substring(0, 2)), "Id", "DesignationFr");

            ViewData["NumeroSIEJE"] = promoteurId;

            var fiche = new BusinessPlan { NumeroSIEJE = promoteurId };
            return PartialView($"_{nameof(AddBusinessPlan)}");
        }

        [Authorize(Roles = "Analyste")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{promoteurId}")]
        public async Task<IActionResult> AddBusinessPlan(string promoteurId, BusinessPlan model)
        {
            BusinessResult businessResult;
            var user = await _userService.GetUserEagerLoadedAsync(User);
            var structure = await _userService.GetStructureFromUserAsync(user.Id);

            string CoutProjetstring;

            try
            {
                model.InformationBase.CoutProjet = Math.Round(Convert.ToDecimal(model.InformationBase.CoutProjetString.Replace(".", ",")), 2);
                model.InformationBase.FondsRoulement = Math.Round(Convert.ToDecimal(model.InformationBase.FondsRoulementString.Replace(".", ",")), 2);
                model.StructureFinancement.ApportPersonnel = Math.Round(Convert.ToDecimal(model.StructureFinancement.ApportPersonnelString.Replace(".", ",")), 2);
                model.StructureFinancement.CMT = Math.Round(Convert.ToDecimal(model.StructureFinancement.CMTString.Replace(".", ",")), 2);
                model.StructureFinancement.PNRClassique = Math.Round(Convert.ToDecimal(model.StructureFinancement.PNRClassiqueString.Replace(".", ",")), 2);
                model.StructureFinancement.PNRSupplementaire = Math.Round(Convert.ToDecimal(model.StructureFinancement.PNRSupplementaireString.Replace(".", ",")), 2);
                model.StructureFinancement.ApportSupplementaire = Math.Round(Convert.ToDecimal(model.StructureFinancement.ApportSupplementaireString.Replace(".", ",")), 2);

                model.StructureFinancement.TauxIFU = Convert.ToInt32(model.StructureFinancement.TauxIFUString.Replace(".", ","));
                model.StructureFinancement.TauxIBS = Convert.ToInt32(model.StructureFinancement.TauxIBSString.Replace(".", ","));
            }
            catch (Exception e)
            {
                CoutProjetstring = e.Message;
            }

            var designationToCode = new Dictionary<string, string>
            {
                { "ANTENNE ROUIBA", "1606" },
                { "ANTENNE EL HARRACH", "1607" },
                { "ANTENNE HUSSEIN DEY", "1604" },
                { "ANTENNE DAR EL BEIDA", "1614" },
                { "ANTENNE SIDI M''HAMED", "1602" },
                { "ANTENNE BOUZAREAH", "1612" },
                { "ANTENNE BAB EL OUED", "1609" },
                { "ANTENNE ZERALDA", "1605" },
                { "ANTENNE CHERAGA", "1610" },
                { "ANTENNE DRARIA", "1611" },
                { "ANTENNE BIRTOUTA", "1603" },
                { "ANTENNE BIR MOURAD RAIS", "1608" },
                { "ANTENNE BARAKI", "1613" }
            };

            if (designationToCode.TryGetValue(structure.Designation, out var code))
            {
                structure.CodeStructure = code;
            }

            var annexe = _annexeBusinessService.GetSingle(x => x.Code == structure.CodeStructure, _annexeBusinessService.GetDefaultLoadProperties());
            var promoteur = await _promoteurApiService.GetByNumDossAsync(model.NumeroSIEJE);
            model.Date_Creation = System.DateTime.Now;
            model.Utilisateur = user.FullName;
            model.EtapeId = 1;

            //DiffereEmprunt differeEmprunt = new();
            //ExonerationFiscale exonerationFiscale = new();

            //differeEmprunt = _differeEmpruntBusinessService.GetById(1);
            //exonerationFiscale = _exonerationFiscaleBusinessService.GetById(1);

            //var projetBusinessPlan = _businessPlanBusinessService.GetSingle(x => x.NumeroSIEJE == promoteurId);

            var lastFiche = _ficheNotationBusinessService.GetAllFiltered(x => x.Annexe.Code == structure.CodeStructure, _ficheNotationBusinessService.GetDefaultLoadProperties()).Max(x => x.Numero);

            if (lastFiche == null)
            {
                int numSeq = 0;
                var newNumero = _ficheNotationBusinessService.GenererNumero(structure.CodeStructure, numSeq);
                model.Code = newNumero;
            }
            else
            {
                var lastNumeroFiche = lastFiche.Substring(4);
                var numSeq = int.Parse(lastNumeroFiche);
                var newNumero = _ficheNotationBusinessService.GenererNumero(structure.CodeStructure, numSeq);
                model.Code = newNumero;
            }

            if (ModelState.IsValid)
            {
                businessResult = _businessPlanBusinessService.Add(model);

                if (businessResult.Succeeded)
                {
                    TempData["Message"] = businessResult.ToBootstrapAlerts();
                    return RedirectToAction(nameof(InfosBusinessPlan), new { promoteurId });
                }
                else
                {
                    return Json(new { messages = businessResult.ToBootstrapAlerts() });
                }
            }
            else
            {
                return PartialView($"_{nameof(AddBusinessPlan)}", model);
            }
        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> EditBusinessPlan(int id)
        {
            //var model = _ficheNotationBusinessService.GetById(id, _ficheNotationBusinessService.GetDefaultLoadProperties());
            var modelBusinessPlan = _businessPlanBusinessService.GetById(id);

            ViewData["TypeMaterielID"] = new SelectList(_typeMaterielBusinessService.GetAll(), "Id", "DesignationFr");

            var listeAnnee = new SelectList(_anneeBusinessService.GetAll(), "Id", "DesignationFr");

            ViewData["AnneeID"] = listeAnnee;

            if (modelBusinessPlan.Complet)
            {
                ViewData["CompletOuiNon"] = "Oui";
            }
            else
            {
                ViewData["CompletOuiNon"] = "Non";
            }

            return PartialView($"_{nameof(EditBusinessPlan)}", modelBusinessPlan);
        }

        [Authorize(Roles = "Analyste")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id}")]
        public async Task<IActionResult> EditBusinessPlan(int id, FicheNotation model)
        {

            BusinessResult businessResult;
            var user = await _userService.GetUserEagerLoadedAsync(User);
            var structure = await _userService.GetStructureFromUserAsync(user.Id);
            var designationToCode = new Dictionary<string, string>
            {
                { "ANTENNE ROUIBA", "1606" },
                { "ANTENNE EL HARRACH", "1607" },
                { "ANTENNE HUSSEIN DEY", "1604" },
                { "ANTENNE DAR EL BEIDA", "1614" },
                { "ANTENNE SIDI M''HAMED", "1602" },
                { "ANTENNE BOUZAREAH", "1612" },
                { "ANTENNE BAB EL OUED", "1609" },
                { "ANTENNE ZERALDA", "1605" },
                { "ANTENNE CHERAGA", "1610" },
                { "ANTENNE DRARIA", "1611" },
                { "ANTENNE BIRTOUTA", "1603" },
                { "ANTENNE BIR MOURAD RAIS", "1608" },
                { "ANTENNE BARAKI", "1613" }
            };

            if (designationToCode.TryGetValue(structure.Designation, out var code))
            {
                structure.CodeStructure = code;
            }

            var annexe = _annexeBusinessService.GetSingle(x => x.Code == structure.CodeStructure, _annexeBusinessService.GetDefaultLoadProperties());
            model.AnnexeId = annexe.Id;
            model.Annexe = annexe;
            model.NomAnnexe = annexe.DesignationFr;
            model.NomAntenne = annexe.Antenne.DesignationFr;
            var promoteur = await _promoteurApiService.GetByNumDossAsync(model.PromoteurId);
            model.Activite = promoteur.ACTIVITE;
            model.NOM_P = promoteur.NOM_P;
            model.PRENOM_P = promoteur.PRENOM_P;
            model.DDN_P = promoteur.DDN_P;
            model.RAISON_SOCIALE = promoteur.RAISON_SOCIALE;
            model.DATE_DEPOT = promoteur.DATE_DEPOT;
            model.Analyste = user.FullName;


            model.NoteNiveauFormation = _niveauFormationBusinessService.GetById(model.NiveauFormationId).Note;
            model.NoteExperienceprofessionnelle = _experienceProfessionnelBusinessService.GetById(model.ExperienceProfessionnelId).Note;
            model.NoteConcordance = _concorrdenceBusinessService.GetById(model.ConcorrdenceId).Note;
            model.NoteContributionFinanciere = _contributionFinanciereBusinessService.GetById(model.ContributionFinanciereId).Note;
            model.ScorePorteurProjet = model.NoteNiveauFormation +
                                       model.NoteExperienceprofessionnelle +
                                       model.NoteConcordance +
                                       model.NoteContributionFinanciere +
                                       model.CapaciteDefendreProjet;


            model.NoteClients = _clientBusinessService.GetById(model.ClientId).Note;
            model.NoteMarketing = _marketingBusinessService.GetById(model.MarketingId).Note;
            model.NotePricing = _pricingBusinessService.GetById(model.PricingId).Note;
            if (model.EtudeTechnicoEconomique == true)
            {
                model.NoteEtudeTechnicoEconomique = 3;
            }
            else
            {
                model.NoteEtudeTechnicoEconomique = 0;
            }
            model.ScoreEtudeMarche = model.Marche +
                                     model.Concurrents +
                                     model.NoteClients +
                                     model.NoteMarketing +
                                     model.NotePricing +
                                     model.NoteEtudeTechnicoEconomique;


            model.NoteDr = _drBusinessService.GetById(model.DrId).Note;
            model.NoteVan = _vanBusinessService.GetById(model.VanId).Note;
            model.ScoreBusinessPlan = model.NoteDr + model.NoteVan;

            model.ScoreSousTotal = model.ScorePorteurProjet + model.ScoreEtudeMarche +
                                   model.ScoreBusinessPlan + model.CreationEmploi;

            if (model.ProduitTemoin == true)
            {
                model.NoteProduitTemoin = 3;
            }
            else
            {
                model.NoteProduitTemoin = 0;
            }

            model.ScoreTotal = model.ScoreSousTotal + model.NoteProduitTemoin;

            if (model.ScoreTotal >= 42.5)
            {
                model.Deliberation = "Admis (e)";
            }
            else
            {
                model.Deliberation = "Non Admis (e)";
            }



            if (ModelState.IsValid)
            {
                businessResult = _nesdaProjectBusinessService.UpdateFiche(model);

                if (businessResult.Succeeded)
                {
                    TempData["Message"] = businessResult.ToBootstrapAlerts();
                    return RedirectToAction(nameof(InfosBusinessPlan), new { id = model.PromoteurId });
                }
                else
                {
                    return Json(new { messages = businessResult.ToBootstrapAlerts() });
                }
            }
            else
            {
                return PartialView($"_{nameof(EditBusinessPlan)}", model);
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("{id}/{promoteurId}")]
        [HttpPost]
        public IActionResult DeleteFiche(int id, string promoteurId)
        {
            BusinessResult businessResult;

            businessResult = _nesdaProjectBusinessService.DeleteFiche(id);

            if (businessResult.Succeeded)
            {
                TempData["Message"] = businessResult.ToBootstrapAlerts();
                return RedirectToAction(nameof(Fiche), new { promoteurId });
            }


            return Json(new { messages = businessResult.ToBootstrapAlerts() });
        }
        public virtual IActionResult Erreur()
        {


            return View();
        }

        public static List<FicheNotation> RemoveDuplicatesFiche(List<FicheNotation> items)
        {
            List<FicheNotation> result = new List<FicheNotation>();
            for (int i = 0; i < items.Count; i++)
            {
                // Assume not duplicate.
                bool duplicate = false;
                for (int z = 0; z < i; z++)
                {
                    if (items[z].PromoteurId == items[i].PromoteurId)
                    {
                        // This is a duplicate.
                        duplicate = true;
                        break;
                    }
                }
                // If not duplicate, add to result.
                if (!duplicate)
                {
                    result.Add(items[i]);
                }
            }
            return result;
        }

        [Authorize(Roles = "Analyste,DG,Admin,AdminAgence,Utilisateur-Rating")]
        public virtual async Task<IActionResult> Details(string id)
        {
            ViewData["AnnexeID"] = new SelectList(_annexeBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["AntenneID"] = new SelectList(_antenneBusinessService.GetAll(), "Id", "DesignationFr");


            var promoteur = await _promoteurApiService.GetByNumDossAsync(id);

            var businessPlans = _businessPlanBusinessService.GetAllFiltered(x => x.NumeroSIEJE == promoteur.NUM_DOSS, _businessPlanBusinessService.GetDefaultLoadProperties());

            promoteur.BusinessPlans = businessPlans;

            if (promoteur == null)
                return NotFound();
            return View(promoteur);
        }

        [Route("{communeId}")]
        public virtual async Task<IActionResult> GetCommune(int communeId)
        {
            return Json(_communeBPBusinessService.GetById(communeId, _communeBPBusinessService.GetDefaultLoadProperties()));
        }

        public virtual async Task<IActionResult> GetCommuneAll()
        {
            return Json(_communeBPBusinessService.GetAll(_communeBPBusinessService.GetDefaultLoadProperties()));
        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> AddInvestissement(int id)
        {
            //var model = _ficheNotationBusinessService.GetById(id, _ficheNotationBusinessService.GetDefaultLoadProperties());
            var modelBusinessPlan = _businessPlanBusinessService.GetById(id);

            ViewData["TypeMaterielID"] = new SelectList(_typeMaterielBusinessService.GetAll(), "Id", "DesignationFr");

            var listeAnnee = new SelectList(_anneeBusinessService.GetAll(), "Id", "DesignationFr");

            ViewData["AnneeID"] = listeAnnee;

            if (modelBusinessPlan.Complet)
            {
                ViewData["CompletOuiNon"] = "Oui";
            }
            else
            {
                ViewData["CompletOuiNon"] = "Non";
            }






            AcquisitionDetailInvestissementVM model = new();
            DetailInvestissement detailInvestissement = new();
            Acquisition acquisition1 = new();
            Acquisition acquisition2 = new();
            Acquisition acquisition3 = new();
            List<Acquisition> acquisitions = new();

            detailInvestissement.DesignationMateriel = "test";
            detailInvestissement.DureeAmortissement = 10;
            detailInvestissement.BusinessPlan = modelBusinessPlan;
            detailInvestissement.BusinessPlanId = id;

            acquisition1.Montant = 10;
            acquisition1.DetailInvestissement = detailInvestissement;

            model.acquisition = acquisition1;
            model.detailInvestissement = detailInvestissement;

            acquisitions.Add(acquisition1);

            acquisition2.Montant = 20;
            acquisition2.AnneeId = 1;
            acquisition2.DetailInvestissement = detailInvestissement;
            acquisitions.Add(acquisition2);

            acquisition3.Montant = 30;
            acquisition3.AnneeId = 1;
            acquisition3.DetailInvestissement = detailInvestissement;
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);
            acquisitions.Add(acquisition3);

            model.acquisitions = acquisitions;

            return PartialView($"_{nameof(AddInvestissement)}", model);

        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{promoteurId}")]
        public async Task<IActionResult> DetailInvestissement(string promoteurId)
        {

            ViewData["AnnexeID"] = new SelectList(_annexeBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["AntenneID"] = new SelectList(_antenneBusinessService.GetAll(), "Id", "DesignationFr");

            var user = await _userService.GetUserEagerLoadedAsync(User);
            var structure = _userService.GetStructureFromUserAsync(user.Id).Result;
            var designationToCode = new Dictionary<string, string>
            {
                { "ANTENNE ROUIBA", "1606" },
                { "ANTENNE EL HARRACH", "1607" },
                { "ANTENNE HUSSEIN DEY", "1604" },
                { "ANTENNE DAR EL BEIDA", "1614" },
                { "ANTENNE SIDI M''HAMED", "1602" },
                { "ANTENNE BOUZAREAH", "1612" },
                { "ANTENNE BAB EL OUED", "1609" },
                { "ANTENNE ZERALDA", "1605" },
                { "ANTENNE CHERAGA", "1610" },
                { "ANTENNE DRARIA", "1611" },
                { "ANTENNE BIRTOUTA", "1603" },
                { "ANTENNE BIR MOURAD RAIS", "1608" },
                { "ANTENNE BARAKI", "1613" }
            };

            if (designationToCode.TryGetValue(structure.Designation, out var code))
            {
                structure.CodeStructure = code;
            }

            DetailInvestissement detailInvestissement = new();
            Acquisition acquisition = new();

            acquisition.DetailInvestissement = detailInvestissement;

            var model = detailInvestissement;

            return PartialView($"_{nameof(DetailInvestissement)}");
        }

        [Authorize(Roles = "Analyste")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{promoteurId}")]
        public async Task<IActionResult> DetailInvestissement(int Id)
        {
            DetailInvestissement detailInvestissement = new();
            Acquisition acquisition = new();

            acquisition.DetailInvestissement = detailInvestissement;

            var model = detailInvestissement;
            return PartialView($"_{nameof(DetailInvestissement)}", model);
        }









        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> AddInvestissement2(int id)
        {
            var modelBusinessPlan = _businessPlanBusinessService.GetById(id);

            ViewData["TypeMaterielID"] = new SelectList(_typeMaterielBusinessService.GetAll(), "Id", "CodeDesignationFr");
            ViewData["BusinessPlanID"] = id;
            ViewData["NumeroSIEJE"] = modelBusinessPlan.NumeroSIEJE;

            var listeAnnee = new SelectList(_anneeBusinessService.GetAll(), "Id", "DesignationFr");

            ViewData["AnneeID"] = listeAnnee;

            if (modelBusinessPlan.Complet)
            {
                ViewData["CompletOuiNon"] = "Oui";
            }
            else
            {
                ViewData["CompletOuiNon"] = "Non";
            }

            Investissement model1 = new();

            model1.Investissements = new List<Investissement>();

            return PartialView($"_{nameof(AddInvestissement2)}", model1);

        }

        [Authorize(Roles = "Analyste")]
        [HttpPost]
        public async Task<IActionResult> AddInvestissement2([FromBody] string[] model)
        {
            int businessPlanId = Int32.Parse(model[0]);
            BusinessPlan businessPlan = _businessPlanBusinessService.GetById(businessPlanId);

            BusinessResult businessResult;


            List<DetailInvestissement> detailsInvestissement = new();

            for (int i = 1; i < model.Length; i += 10)
            {
                TypeMateriel typesMateriel = new();
                DetailInvestissement detailInvestissement = new();
                List<Acquisition> acquisitions = new();

                typesMateriel = _typeMaterielBusinessService.GetSingle(x => x.Code == model[i].Substring(1, 2));

                detailInvestissement.BusinessPlanId = businessPlanId;
                detailInvestissement.TypeMaterielId = typesMateriel.Id;
                detailInvestissement.DesignationMateriel = model[i + 1];
                detailInvestissement.DureeAmortissement = Int32.Parse(model[i + 2]);

                for (int j = 0; j < 7; j++)
                {
                    Acquisition acquisitionItem = new();

                    acquisitionItem.AnneeId = j + 1;
                    acquisitionItem.Montant = Math.Round(Convert.ToDecimal(model[i + 3 + j].Replace(".", ",")), 2);
                    acquisitions.Add(acquisitionItem);
                }

                detailInvestissement.Acquisitions = acquisitions;

                detailsInvestissement.Add(detailInvestissement);
            }

            businessPlan.EtapeId = 2;
            businessPlan.DetailsInvestissement = detailsInvestissement;

            businessResult = _businessPlanBusinessService.Update(businessPlan);

            if (businessResult.Succeeded)
            {
                TempData["Message"] = businessResult.ToBootstrapAlerts();
                //return RedirectToAction(nameof(InfosBusinessPlan), new { id = businessPlan.NumeroSIEJE });
                return Json(new { messages = businessResult.ToBootstrapAlerts() });
            }
            else
            {
                return Json(new { messages = businessResult.ToBootstrapAlerts() });
            }


        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> AddChiffreAcffaires(int id)
        {
            var modelBusinessPlan = _businessPlanBusinessService.GetById(id);


            ViewData["BusinessPlanID"] = id;
            ViewData["NumeroSIEJE"] = modelBusinessPlan.NumeroSIEJE;

            var listeAnnee = new SelectList(_anneeBusinessService.GetAll(), "Id", "DesignationFr");

            ViewData["AnneeID"] = listeAnnee;

            if (modelBusinessPlan.Complet)
            {
                ViewData["CompletOuiNon"] = "Oui";
            }
            else
            {
                ViewData["CompletOuiNon"] = "Non";
            }


            ChiffreAffaire model = new();

            model.ChiffresAffaire = new List<ChiffreAffaire>();

            return PartialView($"_{nameof(AddChiffreAcffaires)}", model);

        }

        [Authorize(Roles = "Analyste")]
        [HttpPost]
        public async Task<IActionResult> AddChiffreAcffaires([FromBody] string[] model)
        {
            int businessPlanId = Int32.Parse(model[0]);
            BusinessPlan businessPlan = _businessPlanBusinessService.GetById(businessPlanId);

            BusinessResult businessResult;

            List<DetailChiffreAffaire> detailsChiffreAffaire = new();

            int indexCodeProduitService = 1;

            for (int i = 1; i < model.Length; i += 29)
            {
                int anneeIndex = 1;

                ProduitService produitService = new();

                produitService.Code = produitService.GetCode(businessPlan.Code, indexCodeProduitService);

                produitService.Designation = model[i];

                for (int j = 0; j < 27; j += 4)
                {
                    DetailChiffreAffaire detailChiffreAffaire = new();
                    detailChiffreAffaire.BusinessPlanId = businessPlanId;
                    detailChiffreAffaire.AnneeId = anneeIndex;
                    detailChiffreAffaire.Quantite = (float)Math.Round(Convert.ToDouble(model[i + 2 + j].Replace(".", ",")), 2);
                    detailChiffreAffaire.PrixUnitaire = Math.Round(Convert.ToDecimal(model[i + 3 + j].Replace(".", ",")), 2);
                    detailChiffreAffaire.Montant = Math.Round(Convert.ToDecimal(model[i + 4 + j].Replace(".", ",")), 2);
                    detailChiffreAffaire.ProduitService = produitService;

                    detailsChiffreAffaire.Add(detailChiffreAffaire);
                    anneeIndex++;
                }
                indexCodeProduitService++;
            }

            businessPlan.EtapeId = 3;

            businessPlan.DetailsChiffreAffaire = detailsChiffreAffaire;

            businessResult = _businessPlanBusinessService.Update(businessPlan);

            if (businessResult.Succeeded)
            {
                TempData["Message"] = businessResult.ToBootstrapAlerts();
                return Json(new { messages = businessResult.ToBootstrapAlerts() });
            }

            else
            {
                return Json(new { messages = businessResult.ToBootstrapAlerts() });
            }

        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> AddAchatsDirects(int id)
        {
            var modelBusinessPlan = _businessPlanBusinessService.GetById(id);


            ViewData["BusinessPlanID"] = id;
            ViewData["NumeroSIEJE"] = modelBusinessPlan.NumeroSIEJE;

            var listeAnnee = new SelectList(_anneeBusinessService.GetAll(), "Id", "DesignationFr");

            ViewData["AnneeID"] = listeAnnee;

            if (modelBusinessPlan.Complet)
            {
                ViewData["CompletOuiNon"] = "Oui";
            }
            else
            {
                ViewData["CompletOuiNon"] = "Non";
            }


            AchatsDirects model = new();

            model.AchatssDirectss = new List<AchatsDirects>();

            return PartialView($"_{nameof(AddAchatsDirects)}", model);

        }

        [Authorize(Roles = "Analyste")]
        [HttpPost]
        public async Task<IActionResult> AddAchatsDirects([FromBody] string[] model)
        {
            int businessPlanId = Int32.Parse(model[0]);
            BusinessPlan businessPlan = _businessPlanBusinessService.GetById(businessPlanId);

            BusinessResult businessResult;

            List<DetailAchatsDirects> detailsAchatsDirects = new();

            int indexCodeMatiereApprov = 1;

            for (int i = 1; i < model.Length; i += 36)
            {
                int anneeIndex = 1;

                MatierePremiereApprovisionnement matierePremiereApprovisionnement = new();

                matierePremiereApprovisionnement.Code = matierePremiereApprovisionnement.GetCode(businessPlan.Code, indexCodeMatiereApprov);

                matierePremiereApprovisionnement.Designation = model[i];

                for (int j = 0; j < 34; j += 5)
                {
                    DetailAchatsDirects detailAchatsDirects = new();
                    detailAchatsDirects.BusinessPlanId = businessPlanId;
                    detailAchatsDirects.AnneeId = anneeIndex;
                    detailAchatsDirects.Quantite = (float)Math.Round(Convert.ToDouble(model[i + 2 + j].Replace(".", ",")), 2);
                    detailAchatsDirects.PrixUnitaire = Math.Round(Convert.ToDecimal(model[i + 3 + j].Replace(".", ",")), 2);
                    detailAchatsDirects.Montant = Math.Round(Convert.ToDecimal(model[i + 4 + j].Replace(".", ",")), 2);
                    detailAchatsDirects.TauxConsommation = Math.Round(Convert.ToDecimal((model[i + 5 + j].Replace("%", "")).Replace(".", ",")), 2);

                    detailAchatsDirects.MatierePremiereApprovisionnement = matierePremiereApprovisionnement;

                    detailsAchatsDirects.Add(detailAchatsDirects);
                    anneeIndex++;
                }

                indexCodeMatiereApprov++;
            }

            businessPlan.EtapeId = 4;

            businessPlan.DetailsAchatsDirects = detailsAchatsDirects;

            businessResult = _businessPlanBusinessService.Update(businessPlan);

            if (businessResult.Succeeded)
            {
                TempData["Message"] = businessResult.ToBootstrapAlerts();
                return Json(new { messages = businessResult.ToBootstrapAlerts() });
            }

            else
            {
                return Json(new { messages = businessResult.ToBootstrapAlerts() });
            }

        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> AddMasseSalariale(int id)
        {
            var modelBusinessPlan = _businessPlanBusinessService.GetById(id);


            ViewData["BusinessPlanID"] = id;
            ViewData["NumeroSIEJE"] = modelBusinessPlan.NumeroSIEJE;

            var listeAnnee = new SelectList(_anneeBusinessService.GetAll(), "Id", "DesignationFr");

            ViewData["AnneeID"] = listeAnnee;

            if (modelBusinessPlan.Complet)
            {
                ViewData["CompletOuiNon"] = "Oui";
            }
            else
            {
                ViewData["CompletOuiNon"] = "Non";
            }

            Poste model = new();
            DetailPoste detailPoste = new();

            return PartialView($"_{nameof(AddMasseSalariale)}", detailPoste);

        }

        [Authorize(Roles = "Analyste")]
        [HttpPost]
        public async Task<IActionResult> AddMasseSalariale([FromBody] string[] model)
        {
            int businessPlanId = Int32.Parse(model[0]);
            BusinessPlan businessPlan = _businessPlanBusinessService.GetById(businessPlanId);

            BusinessResult businessResult;

            List<DetailPoste> detailsPoste = new();

            int indexCodePoste = 1;

            for (int i = 1; i < model.Length; i += 14)
            {
                int anneeIndex = 1;

                Poste poste = new();

                poste.Code = poste.GetCode(businessPlan.Code, indexCodePoste);

                poste.Designation = model[i];
                poste.SalaireBase = Math.Round(Convert.ToDecimal(model[i + 1].Replace(".", ",")), 2);
                poste.IndemnitesPrimesCotisables = Math.Round(Convert.ToDecimal(model[i + 2].Replace(".", ",")), 2);
                poste.IndemnitesPrimesImposables = Math.Round(Convert.ToDecimal(model[i + 3].Replace(".", ",")), 2);
                poste.SLR_Indemnites_PrimesNonImplCotl = Math.Round(Convert.ToDecimal(model[i + 4].Replace(".", ",")), 2);
                poste.NetPayer = Math.Round(Convert.ToDecimal(model[i + 5].Replace(".", ",")), 2);
                poste.RetenueIRG = Math.Round(Convert.ToDecimal(model[i + 6].Replace(".", ",")), 2);

                for (int j = 0; j < 7; j++)
                {
                    DetailPoste detailPoste = new();
                    detailPoste.BusinessPlanId = businessPlanId;
                    detailPoste.AnneeId = anneeIndex;
                    detailPoste.NombreEmploi = Convert.ToInt32(model[i + 7 + j]);
                    detailPoste.Poste = poste;

                    detailsPoste.Add(detailPoste);
                    anneeIndex++;
                }

                indexCodePoste++;
            }

            businessPlan.EtapeId = 5;

            businessPlan.DetailsPoste = detailsPoste;

            businessResult = _businessPlanBusinessService.Update(businessPlan);

            if (businessResult.Succeeded)
            {
                TempData["Message"] = businessResult.ToBootstrapAlerts();
                return Json(new { messages = businessResult.ToBootstrapAlerts() });
            }

            else
            {
                return Json(new { messages = businessResult.ToBootstrapAlerts() });
            }

        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> AddChargesExternes(int id)
        {
            var modelBusinessPlan = _businessPlanBusinessService.GetById(id);

            ViewData["BusinessPlanID"] = id;
            ViewData["NumeroSIEJE"] = modelBusinessPlan.NumeroSIEJE;

            var listeRubriqueChargesExternes = new SelectList(_rubriqueChargesExternesBusinessService.GetAll(), "Id", "CodeDesignationFr");

            ViewData["RubriqueChargesExternesID"] = listeRubriqueChargesExternes;

            if (modelBusinessPlan.Complet)
            {
                ViewData["CompletOuiNon"] = "Oui";
            }
            else
            {
                ViewData["CompletOuiNon"] = "Non";
            }

            ChargeExterne model = new();

            model.ChargesExternes = new List<ChargeExterne>();

            return PartialView($"_{nameof(AddChargesExternes)}", model);
        }

        [Authorize(Roles = "Analyste")]
        [HttpPost]
        public async Task<IActionResult> AddChargesExternes([FromBody] string[] model)
        {
            int businessPlanId = Int32.Parse(model[0]);
            BusinessPlan businessPlan = _businessPlanBusinessService.GetById(businessPlanId);

            BusinessResult businessResult;

            List<DetailChargesExternes> DetailsChargesExternes = new();

            for (int i = 1; i < model.Length; i += 8)
            {
                RubriqueChargesExternes rubriqueChargesExternes = new();
                rubriqueChargesExternes = _rubriqueChargesExternesBusinessService.GetSingle(x => x.Code == model[i].Substring(1, 2));

                for (int j = 0; j < 7; j++)
                {
                    DetailChargesExternes detailChargesExternes = new();

                    detailChargesExternes.BusinessPlanId = businessPlanId;
                    detailChargesExternes.RubriqueChargesExternesId = rubriqueChargesExternes.Id;
                    detailChargesExternes.AnneeId = j + 1;
                    detailChargesExternes.Montant = Math.Round(Convert.ToDecimal(model[i + j + 1].Replace(".", ",")), 2);
                    DetailsChargesExternes.Add(detailChargesExternes);
                }
            }

            businessPlan.EtapeId = 6;
            businessPlan.Complet = true;
            businessPlan.DetailsChargesExternes = DetailsChargesExternes;

            businessResult = _businessPlanBusinessService.Update(businessPlan);

            if (businessResult.Succeeded)
            {
                TempData["Message"] = businessResult.ToBootstrapAlerts();
                return Json(new { messages = businessResult.ToBootstrapAlerts() });
            }

            else
            {
                return Json(new { messages = businessResult.ToBootstrapAlerts() });
            }

        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> EtatsSyntheseBusinessPlan(int id)
        {
            //var modelBusinessPlan = _businessPlanBusinessService.GetById(id);
            var modelBusinessPlan = _businessPlanBusinessService.GetById(id, _businessPlanBusinessService.GetDefaultLoadProperties());

            ViewData["BusinessPlanID"] = id;
            ViewData["NumeroSIEJE"] = modelBusinessPlan.NumeroSIEJE;

            var listeRubriqueChargesExternes = new SelectList(_rubriqueChargesExternesBusinessService.GetAll(), "Id", "CodeDesignationFr");

            ViewData["RubriqueChargesExternesID"] = listeRubriqueChargesExternes;

            if (modelBusinessPlan.Complet)
            {
                ViewData["CompletOuiNon"] = "Oui";
            }
            else
            {
                ViewData["CompletOuiNon"] = "Non";
            }

            return PartialView($"_{nameof(EtatsSyntheseBusinessPlan)}", modelBusinessPlan);
        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> EtatStructureInvestissement(int id)
        {
            //var modelBusinessPlan = _businessPlanBusinessService.GetById(id);
            var modelBusinessPlan = _businessPlanBusinessService.GetById(id, _businessPlanBusinessService.GetDefaultLoadProperties());

            ViewData["BusinessPlanID"] = id;
            ViewData["NumeroSIEJE"] = modelBusinessPlan.NumeroSIEJE;

            var listeRubriqueChargesExternes = new SelectList(_rubriqueChargesExternesBusinessService.GetAll(), "Id", "CodeDesignationFr");

            ViewData["RubriqueChargesExternesID"] = listeRubriqueChargesExternes;

            if (modelBusinessPlan.Complet)
            {
                ViewData["CompletOuiNon"] = "Oui";
            }

            else
            {
                ViewData["CompletOuiNon"] = "Non";
            }

            List<DetailChargesExternes> detailsChargesExternes = _detailChargesExternesBusinessService.GetAllFiltered(x => x.BusinessPlanId == id && x.AnneeId == 1);

            List<DetailInvestissement> detailsInvestissement = _detailInvestissementBusinessService.GetAllFiltered(x => x.BusinessPlanId == id);

            StructureFinancement structureFinancement = _structureFinancementBusinessService.GetSingle(x => x.BusinessPlanId == id, _structureFinancementBusinessService.GetDefaultLoadProperties());

            decimal EquipementsImportes = 0;
            decimal ActifsBiologique = 0;
            decimal MaterielProduction = 0;
            decimal MaterielBureau = 0;
            decimal MaterielInformatique = 0;
            decimal MaterielAudioVisuel = 0;
            decimal MaterielCommunication = 0;
            decimal InstallationsEquipements = 0;
            decimal MaterielRoulant = 0;
            decimal Amenagement = 0;

            decimal FraisGeneraux = 0;
            decimal AssurancesLieesCreation = 0;
            decimal FondsGarantie = 0;
            decimal FondsRoulement = 0;
            decimal Total = 0;

            decimal ApportPersonnel = 0;
            decimal CMT = 0;
            decimal PNRClassique = 0;
            decimal PNRSupplementaire = 0;
            decimal ApportSupplementaire = 0;
            float TauxIFU = 0;
            float TauxIBS = 0;

            decimal CoutProjetReel = 0;
            decimal MontantCMTReel = 0;
            decimal MontantPNRReel = 0;
            decimal MontantApportReel = 0;

            if (detailsInvestissement.Count != 0)
            {
                for (int i = 0; i < detailsInvestissement.Count; i++)
                {
                    List<Acquisition> listAcquisitions = _acquisitionBusinessService.GetAllFiltered(x => x.DetailInvestissementId == detailsInvestissement[i].Id && x.AnneeId == 1);

                    if (detailsInvestissement[i].TypeMaterielId == 1)
                    {
                        for (int j = 0; j < listAcquisitions.Count; j++)
                        {
                            EquipementsImportes += listAcquisitions[j].Montant;
                        }
                    }

                    if (detailsInvestissement[i].TypeMaterielId == 2)
                    {
                        for (int j = 0; j < listAcquisitions.Count; j++)
                        {
                            ActifsBiologique += listAcquisitions[j].Montant;
                        }
                    }

                    if (detailsInvestissement[i].TypeMaterielId == 3)
                    {
                        for (int j = 0; j < listAcquisitions.Count; j++)
                        {
                            MaterielProduction += listAcquisitions[j].Montant;
                        }
                    }

                    if (detailsInvestissement[i].TypeMaterielId == 4)
                    {
                        for (int j = 0; j < listAcquisitions.Count; j++)
                        {
                            MaterielBureau += listAcquisitions[j].Montant;
                        }
                    }

                    if (detailsInvestissement[i].TypeMaterielId == 5)
                    {
                        for (int j = 0; j < listAcquisitions.Count; j++)
                        {
                            MaterielInformatique += listAcquisitions[j].Montant;
                        }
                    }

                    if (detailsInvestissement[i].TypeMaterielId == 6)
                    {
                        for (int j = 0; j < listAcquisitions.Count; j++)
                        {
                            MaterielAudioVisuel += listAcquisitions[j].Montant;
                        }
                    }

                    if (detailsInvestissement[i].TypeMaterielId == 7)
                    {
                        for (int j = 0; j < listAcquisitions.Count; j++)
                        {
                            MaterielCommunication += listAcquisitions[j].Montant;
                        }
                    }

                    if (detailsInvestissement[i].TypeMaterielId == 8)
                    {
                        for (int j = 0; j < listAcquisitions.Count; j++)
                        {
                            InstallationsEquipements += listAcquisitions[j].Montant;
                        }
                    }

                    if (detailsInvestissement[i].TypeMaterielId == 9)
                    {
                        for (int j = 0; j < listAcquisitions.Count; j++)
                        {
                            MaterielRoulant += listAcquisitions[j].Montant;
                        }
                    }

                    if (detailsInvestissement[i].TypeMaterielId == 10)
                    {
                        for (int j = 0; j < listAcquisitions.Count; j++)
                        {
                            Amenagement += listAcquisitions[j].Montant;
                        }
                    }
                }
            }

            if (detailsChargesExternes.Count != 0)
            {
                for (int i = 0; i < detailsChargesExternes.Count; i++)
                {
                    if (detailsChargesExternes[i].RubriqueChargesExternesId == 11)
                    {
                        FraisGeneraux = detailsChargesExternes[i].Montant;
                    }

                    if (detailsChargesExternes[i].RubriqueChargesExternesId == 6)
                    {
                        AssurancesLieesCreation = detailsChargesExternes[i].Montant;
                    }

                    if (detailsChargesExternes[i].RubriqueChargesExternesId == 12)
                    {
                        FondsGarantie = detailsChargesExternes[i].Montant;
                    }
                }
            }

            FondsRoulement = modelBusinessPlan.InformationBase.FondsRoulement;

            CoutProjetReel = (Amenagement +
                              MaterielRoulant +
                              InstallationsEquipements +
                              MaterielCommunication +
                              MaterielAudioVisuel +
                              MaterielInformatique +
                              MaterielBureau +
                              MaterielProduction +
                              ActifsBiologique +
                              EquipementsImportes
                              ) +
                              FondsRoulement +
                              FraisGeneraux +
                              AssurancesLieesCreation;

            MontantCMTReel = CoutProjetReel * structureFinancement.TauxStructureFinancement.CMT / 100;

            double TauxFG = 1.11476776436927;

            double MontantTauxFG = TauxFG * (double)MontantCMTReel / 100;

            MontantTauxFG += (double)MontantCMTReel;

            MontantTauxFG = (MontantTauxFG * 4.5) * 0.0035;

            CoutProjetReel += (decimal)MontantTauxFG;

            FondsGarantie = (decimal)MontantTauxFG;

            MontantCMTReel = CoutProjetReel * structureFinancement.TauxStructureFinancement.CMT / 100;

            MontantPNRReel = CoutProjetReel * structureFinancement.TauxStructureFinancement.PNRClassique / 100;

            MontantApportReel = CoutProjetReel * structureFinancement.TauxStructureFinancement.ApportPersonnel / 100;

            Total = EquipementsImportes
                + ActifsBiologique
                + MaterielProduction
                + MaterielBureau
                + MaterielInformatique
                + MaterielAudioVisuel
                + MaterielCommunication
                + InstallationsEquipements
                + MaterielRoulant
                + Amenagement
                + FraisGeneraux
                + AssurancesLieesCreation
                + FondsGarantie
                + FondsRoulement;

            ApportPersonnel = MontantApportReel;
            CMT = MontantCMTReel;
            PNRClassique = MontantPNRReel;
            PNRSupplementaire = structureFinancement.PNRSupplementaire;
            ApportSupplementaire = structureFinancement.ApportSupplementaire;
            TauxIFU = structureFinancement.TauxIFU;
            TauxIBS = structureFinancement.TauxIBS;

            EtatStuctureInvestissement etatStuctureInvestissement = new();

            System.Globalization.CultureInfo frCult = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");

            etatStuctureInvestissement.EquipementsImportes = string.Format(frCult, "{0:n}", EquipementsImportes);
            etatStuctureInvestissement.ActifsBiologique = string.Format(frCult, "{0:n}", ActifsBiologique);
            etatStuctureInvestissement.MaterielProduction = string.Format(frCult, "{0:n}", MaterielProduction);
            etatStuctureInvestissement.MaterielBureau = string.Format(frCult, "{0:n}", MaterielBureau);
            etatStuctureInvestissement.MaterielInformatique = string.Format(frCult, "{0:n}", MaterielInformatique);
            etatStuctureInvestissement.MaterielAudioVisuel = string.Format(frCult, "{0:n}", MaterielAudioVisuel);
            etatStuctureInvestissement.MaterielCommunication = string.Format(frCult, "{0:n}", MaterielCommunication);
            etatStuctureInvestissement.InstallationsEquipements = string.Format(frCult, "{0:n}", InstallationsEquipements);
            etatStuctureInvestissement.MaterielRoulant = string.Format(frCult, "{0:n}", MaterielRoulant);
            etatStuctureInvestissement.Amenagement = string.Format(frCult, "{0:n}", Amenagement);

            etatStuctureInvestissement.FraisGeneraux = string.Format(frCult, "{0:n}", FraisGeneraux);
            etatStuctureInvestissement.AssurancesLieesCreation = string.Format(frCult, "{0:n}", AssurancesLieesCreation);
            etatStuctureInvestissement.FondsGarantie = string.Format(frCult, "{0:n}", FondsGarantie);
            etatStuctureInvestissement.FondsRoulement = string.Format(frCult, "{0:n}", FondsRoulement);
            etatStuctureInvestissement.Total = string.Format(frCult, "{0:n}", Total);

            etatStuctureInvestissement.ApportPersonnel = string.Format(frCult, "{0:n}", ApportPersonnel);
            etatStuctureInvestissement.CMT = string.Format(frCult, "{0:n}", CMT);
            etatStuctureInvestissement.PNRClassique = string.Format(frCult, "{0:n}", PNRClassique);
            etatStuctureInvestissement.TauxApportPersonnel = structureFinancement.TauxStructureFinancement.ApportPersonnel.ToString();
            etatStuctureInvestissement.TauxCMT = structureFinancement.TauxStructureFinancement.CMT.ToString();
            etatStuctureInvestissement.TauxPNRClassique = structureFinancement.TauxStructureFinancement.PNRClassique.ToString();

            etatStuctureInvestissement.PNRSupplementaire = string.Format(frCult, "{0:n}", PNRSupplementaire);
            etatStuctureInvestissement.ApportSupplementaire = string.Format(frCult, "{0:n}", ApportSupplementaire);
            etatStuctureInvestissement.TauxIFU = string.Format(frCult, "{0:n}", TauxIFU);
            etatStuctureInvestissement.TauxIBS = string.Format(frCult, "{0:n}", TauxIBS);

            return PartialView($"_{nameof(EtatStructureInvestissement)}", etatStuctureInvestissement);
        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> EtatCompteResultat(int id)
        {
            //var modelBusinessPlan = _businessPlanBusinessService.GetById(id);
            var modelBusinessPlan = _businessPlanBusinessService.GetById(id, _businessPlanBusinessService.GetDefaultLoadProperties());

            ViewData["BusinessPlanID"] = id;
            ViewData["NumeroSIEJE"] = modelBusinessPlan.NumeroSIEJE;

            var listeRubriqueChargesExternes = new SelectList(_rubriqueChargesExternesBusinessService.GetAll(), "Id", "CodeDesignationFr");

            ViewData["RubriqueChargesExternesID"] = listeRubriqueChargesExternes;

            if (modelBusinessPlan.Complet)
            {
                ViewData["CompletOuiNon"] = "Oui";
            }
            else
            {
                ViewData["CompletOuiNon"] = "Non";
            }

            EtatCompteResultatPrevisionnel etatCompteResultatPrevisionnel = new();

            List<DetailChiffreAffaire> detailChiffreAffaire = _detailChiffreAffaireBusinessService.GetAllFiltered(x => x.BusinessPlanId == id);

            List<DetailAchatsDirects> detailAchatsDirects = _detailAchatsDirectsBusinessService.GetAllFiltered(x => x.BusinessPlanId == id);

            List<DetailChargesExternes> detailsChargesExternes = _detailChargesExternesBusinessService.GetAllFiltered(x => x.BusinessPlanId == id);

            List<Poste> postes = _posteBusinessService.GetAllFiltered(x => x.DetailsPoste.Any(d => d.BusinessPlanId == id), _posteBusinessService.GetDefaultLoadProperties());

            List<DetailInvestissement> detailInvestissement = _detailInvestissementBusinessService.GetAllFiltered(x => x.BusinessPlanId == id, _detailInvestissementBusinessService.GetDefaultLoadProperties());

            System.Globalization.CultureInfo frCult = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");

            #region Données EtatCompteResultat

            decimal MontantChiffreAffaire01 = 0;
            decimal MontantChiffreAffaire02 = 0;
            decimal MontantChiffreAffaire03 = 0;
            decimal MontantChiffreAffaire04 = 0;
            decimal MontantChiffreAffaire05 = 0;
            decimal MontantChiffreAffaire06 = 0;
            decimal MontantChiffreAffaire07 = 0;

            decimal MontantAchatsConsommes01 = 0;
            decimal MontantAchatsConsommes02 = 0;
            decimal MontantAchatsConsommes03 = 0;
            decimal MontantAchatsConsommes04 = 0;
            decimal MontantAchatsConsommes05 = 0;
            decimal MontantAchatsConsommes06 = 0;
            decimal MontantAchatsConsommes07 = 0;

            decimal MontantChargesExternes01 = 0;
            decimal MontantChargesExternes02 = 0;
            decimal MontantChargesExternes03 = 0;
            decimal MontantChargesExternes04 = 0;
            decimal MontantChargesExternes05 = 0;
            decimal MontantChargesExternes06 = 0;
            decimal MontantChargesExternes07 = 0;

            decimal ValeurAjoutee01 = 0;
            decimal ValeurAjoutee02 = 0;
            decimal ValeurAjoutee03 = 0;
            decimal ValeurAjoutee04 = 0;
            decimal ValeurAjoutee05 = 0;
            decimal ValeurAjoutee06 = 0;
            decimal ValeurAjoutee07 = 0;

            decimal SalairesChargesSociales01 = 0;
            decimal SalairesChargesSociales02 = 0;
            decimal SalairesChargesSociales03 = 0;
            decimal SalairesChargesSociales04 = 0;
            decimal SalairesChargesSociales05 = 0;
            decimal SalairesChargesSociales06 = 0;
            decimal SalairesChargesSociales07 = 0;

            decimal ExcedentBrutExploitation01 = 0;
            decimal ExcedentBrutExploitation02 = 0;
            decimal ExcedentBrutExploitation03 = 0;
            decimal ExcedentBrutExploitation04 = 0;
            decimal ExcedentBrutExploitation05 = 0;
            decimal ExcedentBrutExploitation06 = 0;
            decimal ExcedentBrutExploitation07 = 0;

            decimal AmortissementsProvisions01 = 0;
            decimal AmortissementsProvisions02 = 0;
            decimal AmortissementsProvisions03 = 0;
            decimal AmortissementsProvisions04 = 0;
            decimal AmortissementsProvisions05 = 0;
            decimal AmortissementsProvisions06 = 0;
            decimal AmortissementsProvisions07 = 0;

            decimal ResultatExploitation01 = 0;
            decimal ResultatExploitation02 = 0;
            decimal ResultatExploitation03 = 0;
            decimal ResultatExploitation04 = 0;
            decimal ResultatExploitation05 = 0;
            decimal ResultatExploitation06 = 0;
            decimal ResultatExploitation07 = 0;

            decimal IBS_IFU_IRG01 = 0;
            decimal IBS_IFU_IRG02 = 0;
            decimal IBS_IFU_IRG03 = 0;
            decimal IBS_IFU_IRG04 = 0;
            decimal IBS_IFU_IRG05 = 0;
            decimal IBS_IFU_IRG06 = 0;
            decimal IBS_IFU_IRG07 = 0;

            decimal ResultatNet01 = 0;
            decimal ResultatNet02 = 0;
            decimal ResultatNet03 = 0;
            decimal ResultatNet04 = 0;
            decimal ResultatNet05 = 0;
            decimal ResultatNet06 = 0;
            decimal ResultatNet07 = 0;

            decimal EvolutionChiffreAffaires02 = 0;
            decimal EvolutionChiffreAffaires03 = 0;
            decimal EvolutionChiffreAffaires04 = 0;
            decimal EvolutionChiffreAffaires05 = 0;
            decimal EvolutionChiffreAffaires06 = 0;
            decimal EvolutionChiffreAffaires07 = 0;

            decimal TauxVA01 = 0;
            decimal TauxVA02 = 0;
            decimal TauxVA03 = 0;
            decimal TauxVA04 = 0;
            decimal TauxVA05 = 0;
            decimal TauxVA06 = 0;
            decimal TauxVA07 = 0;

            decimal TauxEBE01 = 0;
            decimal TauxEBE02 = 0;
            decimal TauxEBE03 = 0;
            decimal TauxEBE04 = 0;
            decimal TauxEBE05 = 0;
            decimal TauxEBE06 = 0;
            decimal TauxEBE07 = 0;

            decimal CAF01 = 0;
            decimal CAF02 = 0;
            decimal CAF03 = 0;
            decimal CAF04 = 0;
            decimal CAF05 = 0;
            decimal CAF06 = 0;
            decimal CAF07 = 0;

            string Forfait_Bascul02 = "";
            string Forfait_Bascul03 = "";
            string Forfait_Bascul04 = "";
            string Forfait_Bascul05 = "";
            string Forfait_Bascul06 = "";
            string Forfait_Bascul07 = "";


            #endregion

            #region Données pour test
            //decimal MontantChiffreAffaire01 = 2820000;
            //decimal MontantChiffreAffaire02 = 6750000;
            //decimal MontantChiffreAffaire03 = 15720000;
            //decimal MontantChiffreAffaire04 = 17940000;
            //decimal MontantChiffreAffaire05 = 19050000;
            //decimal MontantChiffreAffaire06 = 17340000;
            //decimal MontantChiffreAffaire07 = 18540000;

            //decimal MontantAchatsConsommes01 = 720720;
            //decimal MontantAchatsConsommes02 = 1751750;
            //decimal MontantAchatsConsommes03 = 4124120;
            //decimal MontantAchatsConsommes04 = 4744740;
            //decimal MontantAchatsConsommes05 = 5055050;
            //decimal MontantAchatsConsommes06 = 4644640;
            //decimal MontantAchatsConsommes07 = 4844840;

            //decimal MontantChargesExternes01 = 180500;
            //decimal MontantChargesExternes02 = 421200;
            //decimal MontantChargesExternes03 = 962600;
            //decimal MontantChargesExternes04 = 1083000;
            //decimal MontantChargesExternes05 = 1143200;
            //decimal MontantChargesExternes06 = 1022800;
            //decimal MontantChargesExternes07 = 1143200;

            //decimal ValeurAjoutee01 = 0;
            //decimal ValeurAjoutee02 = 0;
            //decimal ValeurAjoutee03 = 0;
            //decimal ValeurAjoutee04 = 0;
            //decimal ValeurAjoutee05 = 0;
            //decimal ValeurAjoutee06 = 0;
            //decimal ValeurAjoutee07 = 0;

            //decimal SalairesChargesSociales01 = 327960;
            //decimal SalairesChargesSociales02 = 344352;
            //decimal SalairesChargesSociales03 = 361572;
            //decimal SalairesChargesSociales04 = 379656;
            //decimal SalairesChargesSociales05 = 398640;
            //decimal SalairesChargesSociales06 = 418572;
            //decimal SalairesChargesSociales07 = 439500;

            //decimal ExcedentBrutExploitation01 = 0;
            //decimal ExcedentBrutExploitation02 = 0;
            //decimal ExcedentBrutExploitation03 = 0;
            //decimal ExcedentBrutExploitation04 = 0;
            //decimal ExcedentBrutExploitation05 = 0;
            //decimal ExcedentBrutExploitation06 = 0;
            //decimal ExcedentBrutExploitation07 = 0;

            //decimal AmortissementsProvisions01 = 675000;
            //decimal AmortissementsProvisions02 = 675000;
            //decimal AmortissementsProvisions03 = 675000;
            //decimal AmortissementsProvisions04 = 675000;
            //decimal AmortissementsProvisions05 = 675000;
            //decimal AmortissementsProvisions06 = 15000;
            //decimal AmortissementsProvisions07 = 15000;

            //decimal ResultatExploitation01 = 0;
            //decimal ResultatExploitation02 = 0;
            //decimal ResultatExploitation03 = 0;
            //decimal ResultatExploitation04 = 0;
            //decimal ResultatExploitation05 = 0;
            //decimal ResultatExploitation06 = 0;
            //decimal ResultatExploitation07 = 0;

            //decimal IBS_IFU_IRG01 = 10000;
            //decimal IBS_IFU_IRG02 = 10000;
            //decimal IBS_IFU_IRG03 = 10000;
            //decimal IBS_IFU_IRG04 = 3632560;
            //decimal IBS_IFU_IRG05 = 3884737;
            //decimal IBS_IFU_IRG06 = 3696044;
            //decimal IBS_IFU_IRG07 = 3996510;

            //decimal ResultatNet01 = 0;
            //decimal ResultatNet02 = 0;
            //decimal ResultatNet03 = 0;
            //decimal ResultatNet04 = 0;
            //decimal ResultatNet05 = 0;
            //decimal ResultatNet06 = 0;
            //decimal ResultatNet07 = 0;

            //decimal EvolutionChiffreAffaires02 = 0;
            //decimal EvolutionChiffreAffaires03 = 0;
            //decimal EvolutionChiffreAffaires04 = 0;
            //decimal EvolutionChiffreAffaires05 = 0;
            //decimal EvolutionChiffreAffaires06 = 0;
            //decimal EvolutionChiffreAffaires07 = 0;

            //decimal TauxVA01 = 0;
            //decimal TauxVA02 = 0;
            //decimal TauxVA03 = 0;
            //decimal TauxVA04 = 0;
            //decimal TauxVA05 = 0;
            //decimal TauxVA06 = 0;
            //decimal TauxVA07 = 0;

            //decimal TauxEBE01 = 0;
            //decimal TauxEBE02 = 0;
            //decimal TauxEBE03 = 0;
            //decimal TauxEBE04 = 0;
            //decimal TauxEBE05 = 0;
            //decimal TauxEBE06 = 0;
            //decimal TauxEBE07 = 0;

            //decimal CAF01 = 0;
            //decimal CAF02 = 0;
            //decimal CAF03 = 0;
            //decimal CAF04 = 0;
            //decimal CAF05 = 0;
            //decimal CAF06 = 0;
            //decimal CAF07 = 0;
            #endregion

            #region Calcule Données EtatCompteResultat

            if (detailChiffreAffaire.Count != 0)
            {
                for (int i = 0; i < detailChiffreAffaire.Count; i++)
                {
                    if (detailChiffreAffaire[i].AnneeId == 1)
                    {
                        MontantChiffreAffaire01 += detailChiffreAffaire[i].Montant;
                    }
                    if (detailChiffreAffaire[i].AnneeId == 2)
                    {
                        MontantChiffreAffaire02 += detailChiffreAffaire[i].Montant;
                    }
                    if (detailChiffreAffaire[i].AnneeId == 3)
                    {
                        MontantChiffreAffaire03 += detailChiffreAffaire[i].Montant;
                    }
                    if (detailChiffreAffaire[i].AnneeId == 4)
                    {
                        MontantChiffreAffaire04 += detailChiffreAffaire[i].Montant;
                    }
                    if (detailChiffreAffaire[i].AnneeId == 5)
                    {
                        MontantChiffreAffaire05 += detailChiffreAffaire[i].Montant;
                    }
                    if (detailChiffreAffaire[i].AnneeId == 6)
                    {
                        MontantChiffreAffaire06 += detailChiffreAffaire[i].Montant;
                    }
                    if (detailChiffreAffaire[i].AnneeId == 7)
                    {
                        MontantChiffreAffaire07 += detailChiffreAffaire[i].Montant;
                    }
                }
            }

            if (detailAchatsDirects.Count != 0)
            {
                for (int i = 0; i < detailAchatsDirects.Count; i++)
                {
                    if (detailAchatsDirects[i].AnneeId == 1)
                    {
                        MontantAchatsConsommes01 += detailAchatsDirects[i].Montant * detailAchatsDirects[i].TauxConsommation / 100;
                    }
                    if (detailAchatsDirects[i].AnneeId == 2)
                    {
                        MontantAchatsConsommes02 += detailAchatsDirects[i].Montant * detailAchatsDirects[i].TauxConsommation / 100;
                    }
                    if (detailAchatsDirects[i].AnneeId == 3)
                    {
                        MontantAchatsConsommes03 += detailAchatsDirects[i].Montant * detailAchatsDirects[i].TauxConsommation / 100;
                    }
                    if (detailAchatsDirects[i].AnneeId == 4)
                    {
                        MontantAchatsConsommes04 += detailAchatsDirects[i].Montant * detailAchatsDirects[i].TauxConsommation / 100;
                    }
                    if (detailAchatsDirects[i].AnneeId == 5)
                    {
                        MontantAchatsConsommes05 += detailAchatsDirects[i].Montant * detailAchatsDirects[i].TauxConsommation / 100;
                    }
                    if (detailAchatsDirects[i].AnneeId == 6)
                    {
                        MontantAchatsConsommes06 += detailAchatsDirects[i].Montant * detailAchatsDirects[i].TauxConsommation / 100;
                    }
                    if (detailAchatsDirects[i].AnneeId == 7)
                    {
                        MontantAchatsConsommes07 += detailAchatsDirects[i].Montant * detailAchatsDirects[i].TauxConsommation / 100;
                    }
                }
            }

            if (detailsChargesExternes.Count != 0)
            {
                for (int i = 0; i < detailsChargesExternes.Count; i++)
                {
                    if (detailsChargesExternes[i].AnneeId == 1)
                    {
                        MontantChargesExternes01 += detailsChargesExternes[i].Montant;
                    }
                    if (detailsChargesExternes[i].AnneeId == 2)
                    {
                        MontantChargesExternes02 += detailsChargesExternes[i].Montant;
                    }
                    if (detailsChargesExternes[i].AnneeId == 3)
                    {
                        MontantChargesExternes03 += detailsChargesExternes[i].Montant;
                    }
                    if (detailsChargesExternes[i].AnneeId == 4)
                    {
                        MontantChargesExternes04 += detailsChargesExternes[i].Montant;
                    }
                    if (detailsChargesExternes[i].AnneeId == 5)
                    {
                        MontantChargesExternes05 += detailsChargesExternes[i].Montant;
                    }
                    if (detailsChargesExternes[i].AnneeId == 6)
                    {
                        MontantChargesExternes06 += detailsChargesExternes[i].Montant;
                    }
                    if (detailsChargesExternes[i].AnneeId == 7)
                    {
                        MontantChargesExternes07 += detailsChargesExternes[i].Montant;
                    }
                }
            }

            if (postes.Count != 0)
            {
                for (int i = 0; i < postes.Count; i++)
                {
                    decimal MasseSalarialleAnnuelle = 0;

                    MasseSalarialleAnnuelle = postes[i].SalaireBase + postes[i].IndemnitesPrimesCotisables;

                    MasseSalarialleAnnuelle = MasseSalarialleAnnuelle * 26 / 100;

                    MasseSalarialleAnnuelle = (MasseSalarialleAnnuelle
                                                + postes[i].SalaireBase
                                                + postes[i].IndemnitesPrimesCotisables
                                                + postes[i].IndemnitesPrimesImposables
                                                + postes[i].SLR_Indemnites_PrimesNonImplCotl)
                                                * 12;

                    if (postes[i].DetailsPoste.Count != 0)
                    {
                        List<DetailPoste> detailPostes = postes[i].DetailsPoste.ToList();

                        for (int j = 0; j < detailPostes.Count; j++)
                        {
                            if (detailPostes[j].AnneeId == 1)
                            {
                                SalairesChargesSociales01 += MasseSalarialleAnnuelle * detailPostes[j].NombreEmploi;
                            }
                            if (detailPostes[j].AnneeId == 2)
                            {
                                SalairesChargesSociales02 += MasseSalarialleAnnuelle * detailPostes[j].NombreEmploi;
                            }
                            if (detailPostes[j].AnneeId == 3)
                            {
                                SalairesChargesSociales03 += MasseSalarialleAnnuelle * detailPostes[j].NombreEmploi;
                            }
                            if (detailPostes[j].AnneeId == 4)
                            {
                                SalairesChargesSociales04 += MasseSalarialleAnnuelle * detailPostes[j].NombreEmploi;
                            }
                            if (detailPostes[j].AnneeId == 5)
                            {
                                SalairesChargesSociales05 += MasseSalarialleAnnuelle * detailPostes[j].NombreEmploi;
                            }
                            if (detailPostes[j].AnneeId == 6)
                            {
                                SalairesChargesSociales06 += MasseSalarialleAnnuelle * detailPostes[j].NombreEmploi;
                            }
                            if (detailPostes[j].AnneeId == 7)
                            {
                                SalairesChargesSociales07 += MasseSalarialleAnnuelle * detailPostes[j].NombreEmploi;
                            }
                        }
                    }
                }
            }

            if (detailInvestissement.Count != 0)
            {
                for (int i = 0; i < detailInvestissement.Count; i++)
                {
                    if (detailInvestissement[i].Acquisitions.Count != 0)
                    {
                        List<Acquisition> acquisitions = detailInvestissement[i].Acquisitions.ToList();

                        if (acquisitions.Count != 0)
                        {
                            #region Montant amortissements Année01

                            decimal MontantAmortissements01 = acquisitions[0].Montant / detailInvestissement[i].DureeAmortissement;

                            if (detailInvestissement[i].DureeAmortissement > 1)
                            {
                                AmortissementsProvisions01 += MontantAmortissements01;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 2)
                            {
                                AmortissementsProvisions02 += MontantAmortissements01;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 3)
                            {
                                AmortissementsProvisions03 += MontantAmortissements01;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 4)
                            {
                                AmortissementsProvisions04 += MontantAmortissements01;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 5)
                            {
                                AmortissementsProvisions05 += MontantAmortissements01;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 6)
                            {
                                AmortissementsProvisions06 += MontantAmortissements01;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 7)
                            {
                                AmortissementsProvisions07 += MontantAmortissements01;
                            }

                            #endregion

                            #region Montant amortissements Année02

                            decimal MontantAmortissements02 = acquisitions[1].Montant / detailInvestissement[i].DureeAmortissement;

                            if (detailInvestissement[i].DureeAmortissement > 1)
                            {
                                AmortissementsProvisions02 += MontantAmortissements02;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 2)
                            {
                                AmortissementsProvisions03 += MontantAmortissements02;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 3)
                            {
                                AmortissementsProvisions04 += MontantAmortissements02;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 4)
                            {
                                AmortissementsProvisions05 += MontantAmortissements02;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 5)
                            {
                                AmortissementsProvisions06 += MontantAmortissements02;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 6)
                            {
                                AmortissementsProvisions07 += MontantAmortissements02;
                            }

                            #endregion

                            #region Montant amortissements Année03

                            decimal MontantAmortissements03 = acquisitions[2].Montant / detailInvestissement[i].DureeAmortissement;

                            if (detailInvestissement[i].DureeAmortissement > 1)
                            {
                                AmortissementsProvisions03 += MontantAmortissements03;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 2)
                            {
                                AmortissementsProvisions04 += MontantAmortissements03;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 3)
                            {
                                AmortissementsProvisions05 += MontantAmortissements03;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 4)
                            {
                                AmortissementsProvisions06 += MontantAmortissements03;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 5)
                            {
                                AmortissementsProvisions07 += MontantAmortissements03;
                            }

                            #endregion

                            #region Montant amortissements Année04

                            decimal MontantAmortissements04 = acquisitions[3].Montant / detailInvestissement[i].DureeAmortissement;

                            if (detailInvestissement[i].DureeAmortissement > 1)
                            {
                                AmortissementsProvisions04 += MontantAmortissements04;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 2)
                            {
                                AmortissementsProvisions05 += MontantAmortissements04;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 3)
                            {
                                AmortissementsProvisions06 += MontantAmortissements04;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 4)
                            {
                                AmortissementsProvisions07 += MontantAmortissements04;
                            }

                            #endregion

                            #region Montant amortissements Année05

                            decimal MontantAmortissements05 = acquisitions[4].Montant / detailInvestissement[i].DureeAmortissement;

                            if (detailInvestissement[i].DureeAmortissement > 1)
                            {
                                AmortissementsProvisions05 += MontantAmortissements05;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 2)
                            {
                                AmortissementsProvisions06 += MontantAmortissements05;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 3)
                            {
                                AmortissementsProvisions07 += MontantAmortissements05;
                            }

                            #endregion

                            #region Montant amortissements Année06

                            decimal MontantAmortissements06 = acquisitions[5].Montant / detailInvestissement[i].DureeAmortissement;

                            if (detailInvestissement[i].DureeAmortissement > 1)
                            {
                                AmortissementsProvisions06 += MontantAmortissements06;
                            }
                            if (detailInvestissement[i].DureeAmortissement >= 2)
                            {
                                AmortissementsProvisions07 += MontantAmortissements06;
                            }

                            #endregion

                            #region Montant amortissements Année07

                            decimal MontantAmortissements07 = acquisitions[6].Montant / detailInvestissement[i].DureeAmortissement;

                            if (detailInvestissement[i].DureeAmortissement > 1)
                            {
                                AmortissementsProvisions07 += MontantAmortissements07;
                            }

                            #endregion

                        }

                    }
                }
            }

            ValeurAjoutee01 = MontantChiffreAffaire01 - MontantAchatsConsommes01 - MontantChargesExternes01;
            ValeurAjoutee02 = MontantChiffreAffaire02 - MontantAchatsConsommes02 - MontantChargesExternes02;
            ValeurAjoutee03 = MontantChiffreAffaire03 - MontantAchatsConsommes03 - MontantChargesExternes03;
            ValeurAjoutee04 = MontantChiffreAffaire04 - MontantAchatsConsommes04 - MontantChargesExternes04;
            ValeurAjoutee05 = MontantChiffreAffaire05 - MontantAchatsConsommes05 - MontantChargesExternes05;
            ValeurAjoutee06 = MontantChiffreAffaire06 - MontantAchatsConsommes06 - MontantChargesExternes06;
            ValeurAjoutee07 = MontantChiffreAffaire07 - MontantAchatsConsommes07 - MontantChargesExternes07;

            ExcedentBrutExploitation01 = ValeurAjoutee01 - SalairesChargesSociales01;
            ExcedentBrutExploitation02 = ValeurAjoutee02 - SalairesChargesSociales02;
            ExcedentBrutExploitation03 = ValeurAjoutee03 - SalairesChargesSociales03;
            ExcedentBrutExploitation04 = ValeurAjoutee04 - SalairesChargesSociales04;
            ExcedentBrutExploitation05 = ValeurAjoutee05 - SalairesChargesSociales05;
            ExcedentBrutExploitation06 = ValeurAjoutee06 - SalairesChargesSociales06;
            ExcedentBrutExploitation07 = ValeurAjoutee07 - SalairesChargesSociales07;

            ResultatExploitation01 = ExcedentBrutExploitation01 - AmortissementsProvisions01;
            ResultatExploitation02 = ExcedentBrutExploitation02 - AmortissementsProvisions02;
            ResultatExploitation03 = ExcedentBrutExploitation03 - AmortissementsProvisions03;
            ResultatExploitation04 = ExcedentBrutExploitation04 - AmortissementsProvisions04;
            ResultatExploitation05 = ExcedentBrutExploitation05 - AmortissementsProvisions05;
            ResultatExploitation06 = ExcedentBrutExploitation06 - AmortissementsProvisions06;
            ResultatExploitation07 = ExcedentBrutExploitation07 - AmortissementsProvisions07;

            ResultatNet01 = ResultatExploitation01 - IBS_IFU_IRG01;
            ResultatNet02 = ResultatExploitation02 - IBS_IFU_IRG02;
            ResultatNet03 = ResultatExploitation03 - IBS_IFU_IRG03;
            ResultatNet04 = ResultatExploitation04 - IBS_IFU_IRG04;
            ResultatNet05 = ResultatExploitation05 - IBS_IFU_IRG05;
            ResultatNet06 = ResultatExploitation06 - IBS_IFU_IRG06;
            ResultatNet07 = ResultatExploitation07 - IBS_IFU_IRG07;

            EvolutionChiffreAffaires02 = ((MontantChiffreAffaire02 - MontantChiffreAffaire01) / MontantChiffreAffaire01) * 100;
            EvolutionChiffreAffaires03 = ((MontantChiffreAffaire03 - MontantChiffreAffaire02) / MontantChiffreAffaire02) * 100;
            EvolutionChiffreAffaires04 = ((MontantChiffreAffaire04 - MontantChiffreAffaire03) / MontantChiffreAffaire03) * 100;
            EvolutionChiffreAffaires05 = ((MontantChiffreAffaire05 - MontantChiffreAffaire04) / MontantChiffreAffaire04) * 100;
            EvolutionChiffreAffaires06 = ((MontantChiffreAffaire06 - MontantChiffreAffaire05) / MontantChiffreAffaire05) * 100;
            EvolutionChiffreAffaires07 = ((MontantChiffreAffaire07 - MontantChiffreAffaire06) / MontantChiffreAffaire06) * 100;

            TauxVA01 = ValeurAjoutee01 / MontantChiffreAffaire01 * 100;
            TauxVA02 = ValeurAjoutee02 / MontantChiffreAffaire02 * 100;
            TauxVA03 = ValeurAjoutee03 / MontantChiffreAffaire03 * 100;
            TauxVA04 = ValeurAjoutee04 / MontantChiffreAffaire04 * 100;
            TauxVA05 = ValeurAjoutee05 / MontantChiffreAffaire05 * 100;
            TauxVA06 = ValeurAjoutee06 / MontantChiffreAffaire06 * 100;
            TauxVA07 = ValeurAjoutee07 / MontantChiffreAffaire07 * 100;

            TauxEBE01 = ResultatExploitation01 / MontantChiffreAffaire01 * 100;
            TauxEBE02 = ResultatExploitation02 / MontantChiffreAffaire02 * 100;
            TauxEBE03 = ResultatExploitation03 / MontantChiffreAffaire03 * 100;
            TauxEBE04 = ResultatExploitation04 / MontantChiffreAffaire04 * 100;
            TauxEBE05 = ResultatExploitation05 / MontantChiffreAffaire05 * 100;
            TauxEBE06 = ResultatExploitation06 / MontantChiffreAffaire06 * 100;
            TauxEBE07 = ResultatExploitation07 / MontantChiffreAffaire07 * 100;

            CAF01 = ResultatNet01 + AmortissementsProvisions01;
            CAF02 = ResultatNet02 + AmortissementsProvisions02;
            CAF03 = ResultatNet03 + AmortissementsProvisions03;
            CAF04 = ResultatNet04 + AmortissementsProvisions04;
            CAF05 = ResultatNet05 + AmortissementsProvisions05;
            CAF06 = ResultatNet06 + AmortissementsProvisions06;
            CAF07 = ResultatNet07 + AmortissementsProvisions07;

            // Calcule IRG
            decimal IRG_Annee04 = 0;
            decimal IRG_Annee05 = 0;
            decimal IRG_Annee06 = 0;
            decimal IRG_Annee07 = 0;

            // Année 04
            if (ResultatExploitation04 > 3840000)
            {
                IRG_Annee04 = (ResultatExploitation04 - 3840000) * (decimal)0.35
                            + (decimal)55199.77
                            + (decimal)129599.73
                            + (decimal)287999.70
                            + (decimal)633599.67;
            }
            else
            {
                if ((ResultatExploitation04 > 1920000) && (ResultatExploitation04 <= 3840000))
                {
                    IRG_Annee04 = (ResultatExploitation04 - 1920000) * (decimal)0.33
                                + (decimal)55199.77
                                + (decimal)129599.73
                                + (decimal)287999.70;
                }
                else
                {
                    if ((ResultatExploitation04 > 960000) && (ResultatExploitation04 <= 1920000))
                    {
                        IRG_Annee04 = (ResultatExploitation04 - 960000) * (decimal)0.3
                                    + (decimal)55199.77
                                    + (decimal)129599.73;
                    }
                    else
                    {
                        if ((ResultatExploitation04 > 480000) && (ResultatExploitation04 <= 960000))
                        {
                            IRG_Annee04 = (ResultatExploitation04 - 480000) * (decimal)0.27
                                        + (decimal)55199.77;
                        }
                        else
                        {
                            if ((ResultatExploitation04 > 240000) && (ResultatExploitation04 <= 480000))
                            {
                                IRG_Annee04 = (ResultatExploitation04 - 240000) * (decimal)0.23;
                            }
                            else
                            {
                                IRG_Annee04 = 0;
                            }
                        }
                    }
                }
            }

            if (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == true)
            {
                IRG_Annee04 /= 2;
            }

            // Année 05
            if (ResultatExploitation05 > 3840000)
            {
                IRG_Annee05 = (ResultatExploitation05 - 3840000) * (decimal)0.35
                            + (decimal)55199.77
                            + (decimal)129599.73
                            + (decimal)287999.70
                            + (decimal)633599.67;
            }
            else
            {
                if ((ResultatExploitation05 > 1920000) && (ResultatExploitation05 <= 3840000))
                {
                    IRG_Annee05 = (ResultatExploitation05 - 1920000) * (decimal)0.33
                                + (decimal)55199.77
                                + (decimal)129599.73
                                + (decimal)287999.70;
                }
                else
                {
                    if ((ResultatExploitation05 > 960000) && (ResultatExploitation05 <= 1920000))
                    {
                        IRG_Annee05 = (ResultatExploitation05 - 960000) * (decimal)0.3
                                    + (decimal)55199.77
                                    + (decimal)129599.73;
                    }
                    else
                    {
                        if ((ResultatExploitation05 > 480000) && (ResultatExploitation05 <= 960000))
                        {
                            IRG_Annee05 = (ResultatExploitation05 - 480000) * (decimal)0.27
                                        + (decimal)55199.77;
                        }
                        else
                        {
                            if ((ResultatExploitation05 > 240000) && (ResultatExploitation05 <= 480000))
                            {
                                IRG_Annee05 = (ResultatExploitation05 - 240000) * (decimal)0.23;
                            }
                            else
                            {
                                IRG_Annee05 = 0;
                            }
                        }
                    }
                }
            }

            if (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == true)
            {
                IRG_Annee05 /= 2;
            }

            // Année 06
            if (ResultatExploitation06 > 3840000)
            {
                IRG_Annee06 = (ResultatExploitation06 - 3840000) * (decimal)0.35
                            + (decimal)55199.77
                            + (decimal)129599.73
                            + (decimal)287999.70
                            + (decimal)633599.67;
            }
            else
            {
                if ((ResultatExploitation06 > 1920000) && (ResultatExploitation06 <= 3840000))
                {
                    IRG_Annee06 = (ResultatExploitation06 - 1920000) * (decimal)0.33
                                + (decimal)55199.77
                                + (decimal)129599.73
                                + (decimal)287999.70;
                }
                else
                {
                    if ((ResultatExploitation06 > 960000) && (ResultatExploitation06 <= 1920000))
                    {
                        IRG_Annee06 = (ResultatExploitation06 - 960000) * (decimal)0.3
                                    + (decimal)55199.77
                                    + (decimal)129599.73;
                    }
                    else
                    {
                        if ((ResultatExploitation06 > 480000) && (ResultatExploitation06 <= 960000))
                        {
                            IRG_Annee06 = (ResultatExploitation06 - 480000) * (decimal)0.27
                                        + (decimal)55199.77;
                        }
                        else
                        {
                            if ((ResultatExploitation06 > 240000) && (ResultatExploitation06 <= 480000))
                            {
                                IRG_Annee06 = (ResultatExploitation06 - 240000) * (decimal)0.23;
                            }
                            else
                            {
                                IRG_Annee06 = 0;
                            }
                        }
                    }
                }
            }

            if (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == true)
            {
                IRG_Annee06 /= 2;
            }

            // Année 07
            if (ResultatExploitation07 > 3840000)
            {
                IRG_Annee07 = (ResultatExploitation07 - 3840000) * (decimal)0.35
                            + (decimal)55199.77
                            + (decimal)129599.73
                            + (decimal)287999.70
                            + (decimal)633599.67;
            }
            else
            {
                if ((ResultatExploitation07 > 1920000) && (ResultatExploitation07 <= 3840000))
                {
                    IRG_Annee07 = (ResultatExploitation07 - 1920000) * (decimal)0.33
                                + (decimal)55199.77
                                + (decimal)129599.73
                                + (decimal)287999.70;
                }
                else
                {
                    if ((ResultatExploitation07 > 960000) && (ResultatExploitation07 <= 1920000))
                    {
                        IRG_Annee07 = (ResultatExploitation07 - 960000) * (decimal)0.3
                                    + (decimal)55199.77
                                    + (decimal)129599.73;
                    }
                    else
                    {
                        if ((ResultatExploitation07 > 480000) && (ResultatExploitation07 <= 960000))
                        {
                            IRG_Annee07 = (ResultatExploitation07 - 480000) * (decimal)0.27
                                        + (decimal)55199.77;
                        }
                        else
                        {
                            if ((ResultatExploitation07 > 240000) && (ResultatExploitation07 <= 480000))
                            {
                                IRG_Annee07 = (ResultatExploitation07 - 240000) * (decimal)0.23;
                            }
                            else
                            {
                                IRG_Annee07 = 0;
                            }
                        }
                    }
                }
            }

            if (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == true)
            {
                IRG_Annee07 /= 2;
            }


            // RegimeImpositionId == 2 Forfaitaire
            if (modelBusinessPlan.InformationBase.RegimeImpositionId == 2)
            {
                if (MontantChiffreAffaire01 > 8000000)
                {
                    Forfait_Bascul02 = "Bascul";
                }
                else
                {
                    Forfait_Bascul02 = "IFU";
                }

                if ((MontantChiffreAffaire02 > 8000000) || (Forfait_Bascul02 == "Bascul"))
                {
                    Forfait_Bascul03 = "Bascul";
                }
                else
                {
                    Forfait_Bascul03 = "IFU";
                }

                if ((MontantChiffreAffaire03 > 8000000) || (Forfait_Bascul03 == "Bascul"))
                {
                    Forfait_Bascul04 = "Bascul";
                }
                else
                {
                    Forfait_Bascul04 = "IFU";
                }

                if ((MontantChiffreAffaire04 > 8000000) || (Forfait_Bascul04 == "Bascul"))
                {
                    Forfait_Bascul05 = "Bascul";
                }
                else
                {
                    Forfait_Bascul05 = "IFU";
                }

                if ((MontantChiffreAffaire05 > 8000000) || (Forfait_Bascul05 == "Bascul"))
                {
                    Forfait_Bascul06 = "Bascul";
                }
                else
                {
                    Forfait_Bascul06 = "IFU";
                }

                if ((MontantChiffreAffaire06 > 8000000) || (Forfait_Bascul06 == "Bascul"))
                {
                    Forfait_Bascul07 = "Bascul";
                }
                else
                {
                    Forfait_Bascul07 = "IFU";
                }
            }

            decimal Calcul_Imposition_Annee01_03 = 30000;
            decimal Calcul_Imposition_Annee04 = 0;
            decimal Calcul_Imposition_Annee05 = 0;
            decimal Calcul_Imposition_Annee06 = 0;
            decimal Calcul_Imposition_Annee07 = 0;

            // Identificationla durée d'exonération fiscale : Imposition ExonerationFiscaleId = 1 => 3 ans
            if (modelBusinessPlan.StructureFinancement.ExonerationFiscaleId == 1)
            {
                // RegimeImpositionId == 2 Forfaitaire
                if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul04 == "IFU"))
                {
                    Calcul_Imposition_Annee04 = MontantChiffreAffaire04 * (decimal)modelBusinessPlan.StructureFinancement.TauxIFU/100;
                }
                else
                {
                    // RegimeImpositionId == 2 Forfaitaire
                    if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul04 == "Bascul") && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == false) && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 1))
                    {
                        Calcul_Imposition_Annee04 = ResultatExploitation04 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100;
                    }
                    else
                    {
                        if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul04 == "Bascul") && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == true) && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 1))
                        {
                            Calcul_Imposition_Annee04 = (ResultatExploitation04 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100) / 2;
                        }
                        else
                        {
                            // RegimeImpositionId == 2 Forfaitaire
                            if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul04 == "Bascul") && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 2))
                            {
                                Calcul_Imposition_Annee04 = IRG_Annee04;
                            }
                            else
                            {
                                // RegimeImpositionId == 1 Réel
                                if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 1) && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == false))
                                {
                                    Calcul_Imposition_Annee04 = ResultatExploitation04 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100;
                                }
                                else
                                {
                                    // RegimeImpositionId == 1 Réel
                                    if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 1) && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == true))
                                    {
                                        Calcul_Imposition_Annee04 = (ResultatExploitation04 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100) / 2;
                                    }
                                    else
                                    {
                                        // RegimeImpositionId == 3 IRG(régime simplifié)
                                        if (modelBusinessPlan.InformationBase.RegimeImpositionId == 3)
                                        {
                                            Calcul_Imposition_Annee04 = IRG_Annee04;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // RegimeImpositionId == 2 Forfaitaire
                if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul05 == "IFU"))
                {
                    Calcul_Imposition_Annee05 = MontantChiffreAffaire05 * (decimal)modelBusinessPlan.StructureFinancement.TauxIFU/100;
                }
                else
                {
                    // RegimeImpositionId == 2 Forfaitaire
                    if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul05 == "Bascul") && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == false) && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 1))
                    {
                        Calcul_Imposition_Annee05 = ResultatExploitation05 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100;
                    }
                    else
                    {
                        if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul05 == "Bascul") && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == true) && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 1))
                        {
                            Calcul_Imposition_Annee05 = (ResultatExploitation05 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100) / 2;
                        }
                        else
                        {
                            // RegimeImpositionId == 2 Forfaitaire
                            if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul05 == "Bascul") && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 2))
                            {
                                Calcul_Imposition_Annee05 = IRG_Annee05;
                            }
                            else
                            {
                                // RegimeImpositionId == 1 Réel
                                if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 1) && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == false))
                                {
                                    Calcul_Imposition_Annee05 = ResultatExploitation05 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100;
                                }
                                else
                                {
                                    // RegimeImpositionId == 1 Réel
                                    if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 1) && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == true))
                                    {
                                        Calcul_Imposition_Annee05 = (ResultatExploitation05 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100) / 2;
                                    }
                                    else
                                    {
                                        // RegimeImpositionId == 3 IRG(régime simplifié)
                                        if (modelBusinessPlan.InformationBase.RegimeImpositionId == 3)
                                        {
                                            Calcul_Imposition_Annee05 = IRG_Annee05;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // RegimeImpositionId == 2 Forfaitaire
                if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul06 == "IFU"))
                {
                    Calcul_Imposition_Annee06 = MontantChiffreAffaire06 * (decimal)modelBusinessPlan.StructureFinancement.TauxIFU/100;
                }
                else
                {
                    // RegimeImpositionId == 2 Forfaitaire
                    if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul06 == "Bascul") && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == false) && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 1))
                    {
                        Calcul_Imposition_Annee06 = ResultatExploitation06 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100;
                    }
                    else
                    {
                        if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul06 == "Bascul") && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == true) && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 1))
                        {
                            Calcul_Imposition_Annee06 = (ResultatExploitation06 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100) / 2;
                        }
                        else
                        {
                            // RegimeImpositionId == 2 Forfaitaire
                            if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul06 == "Bascul") && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 2))
                            {
                                Calcul_Imposition_Annee06 = IRG_Annee06;
                            }
                            else
                            {
                                // RegimeImpositionId == 1 Réel
                                if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 1) && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == false))
                                {
                                    Calcul_Imposition_Annee06 = ResultatExploitation06 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100;
                                }
                                else
                                {
                                    // RegimeImpositionId == 1 Réel
                                    if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 1) && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == true))
                                    {
                                        Calcul_Imposition_Annee06 = (ResultatExploitation06 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100) / 2;
                                    }
                                    else
                                    {
                                        // RegimeImpositionId == 3 IRG(régime simplifié)
                                        if (modelBusinessPlan.InformationBase.RegimeImpositionId == 3)
                                        {
                                            Calcul_Imposition_Annee06 = IRG_Annee06;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // RegimeImpositionId == 2 Forfaitaire
                if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul07 == "IFU"))
                {
                    Calcul_Imposition_Annee07 = MontantChiffreAffaire07 * (decimal)modelBusinessPlan.StructureFinancement.TauxIFU/100;
                }
                else
                {
                    // RegimeImpositionId == 2 Forfaitaire
                    if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul07 == "Bascul") && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == false) && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 1))
                    {
                        Calcul_Imposition_Annee07 = ResultatExploitation07 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100;
                    }
                    else
                    {
                        if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul07 == "Bascul") && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == true) && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 1))
                        {
                            Calcul_Imposition_Annee07 = (ResultatExploitation07 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100) / 2;
                        }
                        else
                        {
                            // RegimeImpositionId == 2 Forfaitaire
                            if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul07 == "Bascul") && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 2))
                            {
                                Calcul_Imposition_Annee07 = IRG_Annee07;
                            }
                            else
                            {
                                // RegimeImpositionId == 1 Réel
                                if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 1) && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == false))
                                {
                                    Calcul_Imposition_Annee07 = ResultatExploitation07 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100;
                                }
                                else
                                {
                                    // RegimeImpositionId == 1 Réel
                                    if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 1) && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == true))
                                    {
                                        Calcul_Imposition_Annee07 = (ResultatExploitation07 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100) / 2;
                                    }
                                    else
                                    {
                                        // RegimeImpositionId == 3 IRG(régime simplifié)
                                        if (modelBusinessPlan.InformationBase.RegimeImpositionId == 3)
                                        {
                                            Calcul_Imposition_Annee07 = IRG_Annee07;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                // Identificationla durée d'exonération fiscale : Imposition ExonerationFiscaleId = 2 => 6 ans
                if (modelBusinessPlan.StructureFinancement.ExonerationFiscaleId == 2)
                {
                    Calcul_Imposition_Annee04 = Calcul_Imposition_Annee01_03;
                    Calcul_Imposition_Annee05 = Calcul_Imposition_Annee01_03;
                    Calcul_Imposition_Annee06 = Calcul_Imposition_Annee01_03;

                    // RegimeImpositionId == 2 Forfaitaire
                    if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul07 == "IFU"))
                    {
                        Calcul_Imposition_Annee07 = MontantChiffreAffaire07 * (decimal)modelBusinessPlan.StructureFinancement.TauxIFU/100;
                    }
                    else
                    {
                        // RegimeImpositionId == 2 Forfaitaire
                        if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul07 == "Bascul") && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == false) && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 1))
                        {
                            Calcul_Imposition_Annee07 = ResultatExploitation07 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100;
                        }
                        else
                        {
                            if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul07 == "Bascul") && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == true) && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 1))
                            {
                                Calcul_Imposition_Annee07 = (ResultatExploitation07 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100) / 2;
                            }
                            else
                            {
                                // RegimeImpositionId == 2 Forfaitaire
                                if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 2) && (Forfait_Bascul07 == "Bascul") && (modelBusinessPlan.InformationBase.FormeJuridiqueId == 2))
                                {
                                    Calcul_Imposition_Annee07 = IRG_Annee07;
                                }
                                else
                                {
                                    // RegimeImpositionId == 1 Réel
                                    if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 1) && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == false))
                                    {
                                        Calcul_Imposition_Annee07 = ResultatExploitation07 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100;
                                    }
                                    else
                                    {
                                        // RegimeImpositionId == 1 Réel
                                        if ((modelBusinessPlan.InformationBase.RegimeImpositionId == 1) && (modelBusinessPlan.InformationBase.CommuneBP.WilayaBP.GrandSud == true))
                                        {
                                            Calcul_Imposition_Annee07 = (ResultatExploitation07 * (decimal)modelBusinessPlan.StructureFinancement.TauxIBS/100) / 2;
                                        }
                                        else
                                        {
                                            // RegimeImpositionId == 3 IRG(régime simplifié)
                                            if (modelBusinessPlan.InformationBase.RegimeImpositionId == 3)
                                            {
                                                Calcul_Imposition_Annee07 = IRG_Annee07;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                // Identificationla durée d'exonération fiscale : Imposition ExonerationFiscaleId = 3 => 10 ans
                else
                {
                    Calcul_Imposition_Annee04 = Calcul_Imposition_Annee01_03;
                    Calcul_Imposition_Annee05 = Calcul_Imposition_Annee01_03;
                    Calcul_Imposition_Annee06 = Calcul_Imposition_Annee01_03;
                    Calcul_Imposition_Annee07 = Calcul_Imposition_Annee01_03;
                }
            }

            IBS_IFU_IRG01 = Calcul_Imposition_Annee01_03;
            IBS_IFU_IRG02 = Calcul_Imposition_Annee01_03;
            IBS_IFU_IRG03 = Calcul_Imposition_Annee01_03;
            IBS_IFU_IRG04 = Calcul_Imposition_Annee04;
            IBS_IFU_IRG05 = Calcul_Imposition_Annee05;
            IBS_IFU_IRG06 = Calcul_Imposition_Annee06;
            IBS_IFU_IRG07 = Calcul_Imposition_Annee07;


            if (modelBusinessPlan.InformationBase.RegimeImpositionId != 2)
            {
                if (ResultatExploitation04 <= 0)
                {
                    IBS_IFU_IRG04 = Calcul_Imposition_Annee01_03;
                }
                if (ResultatExploitation05 <= 0)
                {
                    IBS_IFU_IRG05 = Calcul_Imposition_Annee01_03;
                }
                if (ResultatExploitation06 <= 0)
                {
                    IBS_IFU_IRG06 = Calcul_Imposition_Annee01_03;
                }
                if (ResultatExploitation07 <= 0)
                {
                    IBS_IFU_IRG07 = Calcul_Imposition_Annee01_03;
                }
            }












            #endregion

                #region Données EtatCompteResultat

                etatCompteResultatPrevisionnel.ChiffreAffaires01 = string.Format(frCult, "{0:n}", MontantChiffreAffaire01);
            etatCompteResultatPrevisionnel.ChiffreAffaires02 = string.Format(frCult, "{0:n}", MontantChiffreAffaire02);
            etatCompteResultatPrevisionnel.ChiffreAffaires03 = string.Format(frCult, "{0:n}", MontantChiffreAffaire03);
            etatCompteResultatPrevisionnel.ChiffreAffaires04 = string.Format(frCult, "{0:n}", MontantChiffreAffaire04);
            etatCompteResultatPrevisionnel.ChiffreAffaires05 = string.Format(frCult, "{0:n}", MontantChiffreAffaire05);
            etatCompteResultatPrevisionnel.ChiffreAffaires06 = string.Format(frCult, "{0:n}", MontantChiffreAffaire06);
            etatCompteResultatPrevisionnel.ChiffreAffaires07 = string.Format(frCult, "{0:n}", MontantChiffreAffaire07);

            etatCompteResultatPrevisionnel.AchatsConsommes01 = string.Format(frCult, "{0:n}", MontantAchatsConsommes01);
            etatCompteResultatPrevisionnel.AchatsConsommes02 = string.Format(frCult, "{0:n}", MontantAchatsConsommes02);
            etatCompteResultatPrevisionnel.AchatsConsommes03 = string.Format(frCult, "{0:n}", MontantAchatsConsommes03);
            etatCompteResultatPrevisionnel.AchatsConsommes04 = string.Format(frCult, "{0:n}", MontantAchatsConsommes04);
            etatCompteResultatPrevisionnel.AchatsConsommes05 = string.Format(frCult, "{0:n}", MontantAchatsConsommes05);
            etatCompteResultatPrevisionnel.AchatsConsommes06 = string.Format(frCult, "{0:n}", MontantAchatsConsommes06);
            etatCompteResultatPrevisionnel.AchatsConsommes07 = string.Format(frCult, "{0:n}", MontantAchatsConsommes07);

            etatCompteResultatPrevisionnel.ChargesExternes01 = string.Format(frCult, "{0:n}", MontantChargesExternes01);
            etatCompteResultatPrevisionnel.ChargesExternes02 = string.Format(frCult, "{0:n}", MontantChargesExternes02);
            etatCompteResultatPrevisionnel.ChargesExternes03 = string.Format(frCult, "{0:n}", MontantChargesExternes03);
            etatCompteResultatPrevisionnel.ChargesExternes04 = string.Format(frCult, "{0:n}", MontantChargesExternes04);
            etatCompteResultatPrevisionnel.ChargesExternes05 = string.Format(frCult, "{0:n}", MontantChargesExternes05);
            etatCompteResultatPrevisionnel.ChargesExternes06 = string.Format(frCult, "{0:n}", MontantChargesExternes06);
            etatCompteResultatPrevisionnel.ChargesExternes07 = string.Format(frCult, "{0:n}", MontantChargesExternes07);

            etatCompteResultatPrevisionnel.ValeurAjoutee01 = string.Format(frCult, "{0:n}", ValeurAjoutee01);
            etatCompteResultatPrevisionnel.ValeurAjoutee02 = string.Format(frCult, "{0:n}", ValeurAjoutee02);
            etatCompteResultatPrevisionnel.ValeurAjoutee03 = string.Format(frCult, "{0:n}", ValeurAjoutee03);
            etatCompteResultatPrevisionnel.ValeurAjoutee04 = string.Format(frCult, "{0:n}", ValeurAjoutee04);
            etatCompteResultatPrevisionnel.ValeurAjoutee05 = string.Format(frCult, "{0:n}", ValeurAjoutee05);
            etatCompteResultatPrevisionnel.ValeurAjoutee06 = string.Format(frCult, "{0:n}", ValeurAjoutee06);
            etatCompteResultatPrevisionnel.ValeurAjoutee07 = string.Format(frCult, "{0:n}", ValeurAjoutee07);

            etatCompteResultatPrevisionnel.SalairesChargesSociales01 = string.Format(frCult, "{0:n}", SalairesChargesSociales01);
            etatCompteResultatPrevisionnel.SalairesChargesSociales02 = string.Format(frCult, "{0:n}", SalairesChargesSociales02);
            etatCompteResultatPrevisionnel.SalairesChargesSociales03 = string.Format(frCult, "{0:n}", SalairesChargesSociales03);
            etatCompteResultatPrevisionnel.SalairesChargesSociales04 = string.Format(frCult, "{0:n}", SalairesChargesSociales04);
            etatCompteResultatPrevisionnel.SalairesChargesSociales05 = string.Format(frCult, "{0:n}", SalairesChargesSociales05);
            etatCompteResultatPrevisionnel.SalairesChargesSociales06 = string.Format(frCult, "{0:n}", SalairesChargesSociales06);
            etatCompteResultatPrevisionnel.SalairesChargesSociales07 = string.Format(frCult, "{0:n}", SalairesChargesSociales07);

            etatCompteResultatPrevisionnel.ExcedentBrutExploitation01 = string.Format(frCult, "{0:n}", ExcedentBrutExploitation01);
            etatCompteResultatPrevisionnel.ExcedentBrutExploitation02 = string.Format(frCult, "{0:n}", ExcedentBrutExploitation02);
            etatCompteResultatPrevisionnel.ExcedentBrutExploitation03 = string.Format(frCult, "{0:n}", ExcedentBrutExploitation03);
            etatCompteResultatPrevisionnel.ExcedentBrutExploitation04 = string.Format(frCult, "{0:n}", ExcedentBrutExploitation04);
            etatCompteResultatPrevisionnel.ExcedentBrutExploitation05 = string.Format(frCult, "{0:n}", ExcedentBrutExploitation05);
            etatCompteResultatPrevisionnel.ExcedentBrutExploitation06 = string.Format(frCult, "{0:n}", ExcedentBrutExploitation06);
            etatCompteResultatPrevisionnel.ExcedentBrutExploitation07 = string.Format(frCult, "{0:n}", ExcedentBrutExploitation07);

            etatCompteResultatPrevisionnel.AmortissementsProvisions01 = string.Format(frCult, "{0:n}", AmortissementsProvisions01);
            etatCompteResultatPrevisionnel.AmortissementsProvisions02 = string.Format(frCult, "{0:n}", AmortissementsProvisions02);
            etatCompteResultatPrevisionnel.AmortissementsProvisions03 = string.Format(frCult, "{0:n}", AmortissementsProvisions03);
            etatCompteResultatPrevisionnel.AmortissementsProvisions04 = string.Format(frCult, "{0:n}", AmortissementsProvisions04);
            etatCompteResultatPrevisionnel.AmortissementsProvisions05 = string.Format(frCult, "{0:n}", AmortissementsProvisions05);
            etatCompteResultatPrevisionnel.AmortissementsProvisions06 = string.Format(frCult, "{0:n}", AmortissementsProvisions06);
            etatCompteResultatPrevisionnel.AmortissementsProvisions07 = string.Format(frCult, "{0:n}", AmortissementsProvisions07);

            etatCompteResultatPrevisionnel.ResultatExploitation01 = string.Format(frCult, "{0:n}", ResultatExploitation01);
            etatCompteResultatPrevisionnel.ResultatExploitation02 = string.Format(frCult, "{0:n}", ResultatExploitation02);
            etatCompteResultatPrevisionnel.ResultatExploitation03 = string.Format(frCult, "{0:n}", ResultatExploitation03);
            etatCompteResultatPrevisionnel.ResultatExploitation04 = string.Format(frCult, "{0:n}", ResultatExploitation04);
            etatCompteResultatPrevisionnel.ResultatExploitation05 = string.Format(frCult, "{0:n}", ResultatExploitation05);
            etatCompteResultatPrevisionnel.ResultatExploitation06 = string.Format(frCult, "{0:n}", ResultatExploitation06);
            etatCompteResultatPrevisionnel.ResultatExploitation07 = string.Format(frCult, "{0:n}", ResultatExploitation07);

            etatCompteResultatPrevisionnel.IBS_IFU_IRG01 = string.Format(frCult, "{0:n}", IBS_IFU_IRG01);
            etatCompteResultatPrevisionnel.IBS_IFU_IRG02 = string.Format(frCult, "{0:n}", IBS_IFU_IRG02);
            etatCompteResultatPrevisionnel.IBS_IFU_IRG03 = string.Format(frCult, "{0:n}", IBS_IFU_IRG03);
            etatCompteResultatPrevisionnel.IBS_IFU_IRG04 = string.Format(frCult, "{0:n}", IBS_IFU_IRG04);
            etatCompteResultatPrevisionnel.IBS_IFU_IRG05 = string.Format(frCult, "{0:n}", IBS_IFU_IRG05);
            etatCompteResultatPrevisionnel.IBS_IFU_IRG06 = string.Format(frCult, "{0:n}", IBS_IFU_IRG06);
            etatCompteResultatPrevisionnel.IBS_IFU_IRG07 = string.Format(frCult, "{0:n}", IBS_IFU_IRG07);

            etatCompteResultatPrevisionnel.ResultatNet01 = string.Format(frCult, "{0:n}", ResultatNet01);
            etatCompteResultatPrevisionnel.ResultatNet02 = string.Format(frCult, "{0:n}", ResultatNet02);
            etatCompteResultatPrevisionnel.ResultatNet03 = string.Format(frCult, "{0:n}", ResultatNet03);
            etatCompteResultatPrevisionnel.ResultatNet04 = string.Format(frCult, "{0:n}", ResultatNet04);
            etatCompteResultatPrevisionnel.ResultatNet05 = string.Format(frCult, "{0:n}", ResultatNet05);
            etatCompteResultatPrevisionnel.ResultatNet06 = string.Format(frCult, "{0:n}", ResultatNet06);
            etatCompteResultatPrevisionnel.ResultatNet07 = string.Format(frCult, "{0:n}", ResultatNet07);

            etatCompteResultatPrevisionnel.EvolutionChiffreAffaires01 = "-";
            etatCompteResultatPrevisionnel.EvolutionChiffreAffaires02 = string.Format(frCult, "{0:n}", EvolutionChiffreAffaires02);
            etatCompteResultatPrevisionnel.EvolutionChiffreAffaires03 = string.Format(frCult, "{0:n}", EvolutionChiffreAffaires03);
            etatCompteResultatPrevisionnel.EvolutionChiffreAffaires04 = string.Format(frCult, "{0:n}", EvolutionChiffreAffaires04);
            etatCompteResultatPrevisionnel.EvolutionChiffreAffaires05 = string.Format(frCult, "{0:n}", EvolutionChiffreAffaires05);
            etatCompteResultatPrevisionnel.EvolutionChiffreAffaires06 = string.Format(frCult, "{0:n}", EvolutionChiffreAffaires06);
            etatCompteResultatPrevisionnel.EvolutionChiffreAffaires07 = string.Format(frCult, "{0:n}", EvolutionChiffreAffaires07);

            etatCompteResultatPrevisionnel.TauxVA01 = string.Format(frCult, "{0:n}", TauxVA01);
            etatCompteResultatPrevisionnel.TauxVA02 = string.Format(frCult, "{0:n}", TauxVA02);
            etatCompteResultatPrevisionnel.TauxVA03 = string.Format(frCult, "{0:n}", TauxVA03);
            etatCompteResultatPrevisionnel.TauxVA04 = string.Format(frCult, "{0:n}", TauxVA04);
            etatCompteResultatPrevisionnel.TauxVA05 = string.Format(frCult, "{0:n}", TauxVA05);
            etatCompteResultatPrevisionnel.TauxVA06 = string.Format(frCult, "{0:n}", TauxVA06);
            etatCompteResultatPrevisionnel.TauxVA07 = string.Format(frCult, "{0:n}", TauxVA07);

            etatCompteResultatPrevisionnel.TauxEBE01 = string.Format(frCult, "{0:n}", TauxEBE01);
            etatCompteResultatPrevisionnel.TauxEBE02 = string.Format(frCult, "{0:n}", TauxEBE02);
            etatCompteResultatPrevisionnel.TauxEBE03 = string.Format(frCult, "{0:n}", TauxEBE03);
            etatCompteResultatPrevisionnel.TauxEBE04 = string.Format(frCult, "{0:n}", TauxEBE04);
            etatCompteResultatPrevisionnel.TauxEBE05 = string.Format(frCult, "{0:n}", TauxEBE05);
            etatCompteResultatPrevisionnel.TauxEBE06 = string.Format(frCult, "{0:n}", TauxEBE06);
            etatCompteResultatPrevisionnel.TauxEBE07 = string.Format(frCult, "{0:n}", TauxEBE07);

            etatCompteResultatPrevisionnel.CAF01 = string.Format(frCult, "{0:n}", CAF01);
            etatCompteResultatPrevisionnel.CAF02 = string.Format(frCult, "{0:n}", CAF02);
            etatCompteResultatPrevisionnel.CAF03 = string.Format(frCult, "{0:n}", CAF03);
            etatCompteResultatPrevisionnel.CAF04 = string.Format(frCult, "{0:n}", CAF04);
            etatCompteResultatPrevisionnel.CAF05 = string.Format(frCult, "{0:n}", CAF05);
            etatCompteResultatPrevisionnel.CAF06 = string.Format(frCult, "{0:n}", CAF06);
            etatCompteResultatPrevisionnel.CAF07 = string.Format(frCult, "{0:n}", CAF07);

            #endregion

            return PartialView($"_{nameof(EtatCompteResultat)}", etatCompteResultatPrevisionnel);
        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> EtatTFT(int id)
        {
            //var modelBusinessPlan = _businessPlanBusinessService.GetById(id);
            var modelBusinessPlan = _businessPlanBusinessService.GetById(id, _businessPlanBusinessService.GetDefaultLoadProperties());

            ViewData["BusinessPlanID"] = id;
            ViewData["NumeroSIEJE"] = modelBusinessPlan.NumeroSIEJE;

            var listeRubriqueChargesExternes = new SelectList(_rubriqueChargesExternesBusinessService.GetAll(), "Id", "CodeDesignationFr");

            ViewData["RubriqueChargesExternesID"] = listeRubriqueChargesExternes;

            if (modelBusinessPlan.Complet)
            {
                ViewData["CompletOuiNon"] = "Oui";
            }
            else
            {
                ViewData["CompletOuiNon"] = "Non";
            }

            System.Globalization.CultureInfo frCult = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");

            #region Données EtatTFT

            decimal EncaissementsRecuClients01 = 0;
            decimal SommesVerseesFournisseurs01 = 0;
            decimal SommesVerseesPrestataires01 = 0;
            decimal SommesVerseesPersonnelCNAS_IRG01 = 0;
            decimal DecaissementTVAPayer01 = 0;
            decimal DecaissementIBS_IFU_IRG01 = 0;
            decimal FluxTresorerieProvenantExploitation01 = 0;
            decimal DecaissementAcquisitionEquipements01 = 0;
            decimal FluxTresorerieProvenantInvestissement01 = 0;
            decimal EncaissementsSuiteApportPersonnel01 = 0;
            decimal EncaissementsProvenantEmprunts01 = 0;
            decimal RemboursementsEmpruntsCMT01 = 0;
            decimal RemboursementsEmpruntsPNR01 = 0;
            decimal FluxTresorerieProvenantFinancement01 = 0;
            decimal FluxTresorerieNet01 = 0;
            decimal SoldeInitial01 = 0;
            decimal SoldeFinal01 = 0;
            decimal Equilibre01 = 0;

            decimal EncaissementsRecuClients02 = 0;
            decimal SommesVerseesFournisseurs02 = 0;
            decimal SommesVerseesPrestataires02 = 0;
            decimal SommesVerseesPersonnelCNAS_IRG02 = 0;
            decimal DecaissementTVAPayer02 = 0;
            decimal DecaissementIBS_IFU_IRG02 = 0;
            decimal FluxTresorerieProvenantExploitation02 = 0;
            decimal DecaissementAcquisitionEquipements02 = 0;
            decimal FluxTresorerieProvenantInvestissement02 = 0;
            decimal EncaissementsSuiteApportPersonnel02 = 0;
            decimal EncaissementsProvenantEmprunts02 = 0;
            decimal RemboursementsEmpruntsCMT02 = 0;
            decimal RemboursementsEmpruntsPNR02 = 0;
            decimal FluxTresorerieProvenantFinancement02 = 0;
            decimal FluxTresorerieNet02 = 0;
            decimal SoldeInitial02 = 0;
            decimal SoldeFinal02 = 0;
            decimal Equilibre02 = 0;

            decimal EncaissementsRecuClients03 = 0;
            decimal SommesVerseesFournisseurs03 = 0;
            decimal SommesVerseesPrestataires03 = 0;
            decimal SommesVerseesPersonnelCNAS_IRG03 = 0;
            decimal DecaissementTVAPayer03 = 0;
            decimal DecaissementIBS_IFU_IRG03 = 0;
            decimal FluxTresorerieProvenantExploitation03 = 0;
            decimal DecaissementAcquisitionEquipements03 = 0;
            decimal FluxTresorerieProvenantInvestissement03 = 0;
            decimal EncaissementsSuiteApportPersonnel03 = 0;
            decimal EncaissementsProvenantEmprunts03 = 0;
            decimal RemboursementsEmpruntsCMT03 = 0;
            decimal RemboursementsEmpruntsPNR03 = 0;
            decimal FluxTresorerieProvenantFinancement03 = 0;
            decimal FluxTresorerieNet03 = 0;
            decimal SoldeInitial03 = 0;
            decimal SoldeFinal03 = 0;
            decimal Equilibre03 = 0;

            decimal EncaissementsRecuClients04 = 0;
            decimal SommesVerseesFournisseurs04 = 0;
            decimal SommesVerseesPrestataires04 = 0;
            decimal SommesVerseesPersonnelCNAS_IRG04 = 0;
            decimal DecaissementTVAPayer04 = 0;
            decimal DecaissementIBS_IFU_IRG04 = 0;
            decimal FluxTresorerieProvenantExploitation04 = 0;
            decimal DecaissementAcquisitionEquipements04 = 0;
            decimal FluxTresorerieProvenantInvestissement04 = 0;
            decimal EncaissementsSuiteApportPersonnel04 = 0;
            decimal EncaissementsProvenantEmprunts04 = 0;
            decimal RemboursementsEmpruntsCMT04 = 0;
            decimal RemboursementsEmpruntsPNR04 = 0;
            decimal FluxTresorerieProvenantFinancement04 = 0;
            decimal FluxTresorerieNet04 = 0;
            decimal SoldeInitial04 = 0;
            decimal SoldeFinal04 = 0;
            decimal Equilibre04 = 0;

            decimal EncaissementsRecuClients05 = 0;
            decimal SommesVerseesFournisseurs05 = 0;
            decimal SommesVerseesPrestataires05 = 0;
            decimal SommesVerseesPersonnelCNAS_IRG05 = 0;
            decimal DecaissementTVAPayer05 = 0;
            decimal DecaissementIBS_IFU_IRG05 = 0;
            decimal FluxTresorerieProvenantExploitation05 = 0;
            decimal DecaissementAcquisitionEquipements05 = 0;
            decimal FluxTresorerieProvenantInvestissement05 = 0;
            decimal EncaissementsSuiteApportPersonnel05 = 0;
            decimal EncaissementsProvenantEmprunts05 = 0;
            decimal RemboursementsEmpruntsCMT05 = 0;
            decimal RemboursementsEmpruntsPNR05 = 0;
            decimal FluxTresorerieProvenantFinancement05 = 0;
            decimal FluxTresorerieNet05 = 0;
            decimal SoldeInitial05 = 0;
            decimal SoldeFinal05 = 0;
            decimal Equilibre05 = 0;

            decimal EncaissementsRecuClients06 = 0;
            decimal SommesVerseesFournisseurs06 = 0;
            decimal SommesVerseesPrestataires06 = 0;
            decimal SommesVerseesPersonnelCNAS_IRG06 = 0;
            decimal DecaissementTVAPayer06 = 0;
            decimal DecaissementIBS_IFU_IRG06 = 0;
            decimal FluxTresorerieProvenantExploitation06 = 0;
            decimal DecaissementAcquisitionEquipements06 = 0;
            decimal FluxTresorerieProvenantInvestissement06 = 0;
            decimal EncaissementsSuiteApportPersonnel06 = 0;
            decimal EncaissementsProvenantEmprunts06 = 0;
            decimal RemboursementsEmpruntsCMT06 = 0;
            decimal RemboursementsEmpruntsPNR06 = 0;
            decimal FluxTresorerieProvenantFinancement06 = 0;
            decimal FluxTresorerieNet06 = 0;
            decimal SoldeInitial06 = 0;
            decimal SoldeFinal06 = 0;
            decimal Equilibre06 = 0;

            decimal EncaissementsRecuClients07 = 0;
            decimal SommesVerseesFournisseurs07 = 0;
            decimal SommesVerseesPrestataires07 = 0;
            decimal SommesVerseesPersonnelCNAS_IRG07 = 0;
            decimal DecaissementTVAPayer07 = 0;
            decimal DecaissementIBS_IFU_IRG07 = 0;
            decimal FluxTresorerieProvenantExploitation07 = 0;
            decimal DecaissementAcquisitionEquipements07 = 0;
            decimal FluxTresorerieProvenantInvestissement07 = 0;
            decimal EncaissementsSuiteApportPersonnel07 = 0;
            decimal EncaissementsProvenantEmprunts07 = 0;
            decimal RemboursementsEmpruntsCMT07 = 0;
            decimal RemboursementsEmpruntsPNR07 = 0;
            decimal FluxTresorerieProvenantFinancement07 = 0;
            decimal FluxTresorerieNet07 = 0;
            decimal SoldeInitial07 = 0;
            decimal SoldeFinal07 = 0;
            decimal Equilibre07 = 0;

            #endregion

            EtatTFTModel etatTFTModel = new();

            #region Calcule Données EtatTFT

            FluxTresorerieProvenantExploitation01 = EncaissementsRecuClients01
                                                  - SommesVerseesFournisseurs01
                                                  - SommesVerseesPrestataires01
                                                  - SommesVerseesPersonnelCNAS_IRG01
                                                  - DecaissementTVAPayer01
                                                  - DecaissementIBS_IFU_IRG01;

            FluxTresorerieProvenantInvestissement01 = DecaissementAcquisitionEquipements01;

            FluxTresorerieProvenantFinancement01 = EncaissementsSuiteApportPersonnel01
                                                 + EncaissementsProvenantEmprunts01
                                                 - RemboursementsEmpruntsCMT01
                                                 - RemboursementsEmpruntsPNR01;

            FluxTresorerieNet01 = FluxTresorerieProvenantExploitation01
                                + FluxTresorerieProvenantInvestissement01
                                + FluxTresorerieProvenantFinancement01;

            #endregion

            #region Données etatTFTModel

            etatTFTModel.EncaissementsRecuClients01 = string.Format(frCult, "{0:n}", EncaissementsRecuClients01);
            etatTFTModel.SommesVerseesFournisseurs01 = string.Format(frCult, "{0:n}", SommesVerseesFournisseurs01);
            etatTFTModel.SommesVerseesPrestataires01 = string.Format(frCult, "{0:n}", SommesVerseesPrestataires01);
            etatTFTModel.SommesVerseesPersonnelCNAS_IRG01 = string.Format(frCult, "{0:n}", SommesVerseesPersonnelCNAS_IRG01);
            etatTFTModel.DecaissementTVAPayer01 = string.Format(frCult, "{0:n}", DecaissementTVAPayer01);
            etatTFTModel.DecaissementIBS_IFU_IRG01 = string.Format(frCult, "{0:n}", DecaissementIBS_IFU_IRG01);
            etatTFTModel.FluxTresorerieProvenantExploitation01 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantExploitation01);
            etatTFTModel.DecaissementAcquisitionEquipements01 = string.Format(frCult, "{0:n}", DecaissementAcquisitionEquipements01);
            etatTFTModel.FluxTresorerieProvenantInvestissement01 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantInvestissement01);
            etatTFTModel.EncaissementsSuiteApportPersonnel01 = string.Format(frCult, "{0:n}", EncaissementsSuiteApportPersonnel01);
            etatTFTModel.EncaissementsProvenantEmprunts01 = string.Format(frCult, "{0:n}", EncaissementsProvenantEmprunts01);
            etatTFTModel.RemboursementsEmpruntsCMT01 = string.Format(frCult, "{0:n}", RemboursementsEmpruntsCMT01);
            etatTFTModel.RemboursementsEmpruntsPNR01 = string.Format(frCult, "{0:n}", RemboursementsEmpruntsPNR01);
            etatTFTModel.FluxTresorerieProvenantFinancement01 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantFinancement01);
            etatTFTModel.FluxTresorerieNet01 = string.Format(frCult, "{0:n}", FluxTresorerieNet01);
            etatTFTModel.SoldeInitial01 = string.Format(frCult, "{0:n}", SoldeInitial01);
            etatTFTModel.SoldeFinal01 = string.Format(frCult, "{0:n}", SoldeFinal01);
            etatTFTModel.Equilibre01 = string.Format(frCult, "{0:n}", Equilibre01);

            etatTFTModel.EncaissementsRecuClients02 = string.Format(frCult, "{0:n}", EncaissementsRecuClients02);
            etatTFTModel.SommesVerseesFournisseurs02 = string.Format(frCult, "{0:n}", SommesVerseesFournisseurs02);
            etatTFTModel.SommesVerseesPrestataires02 = string.Format(frCult, "{0:n}", SommesVerseesPrestataires02);
            etatTFTModel.SommesVerseesPersonnelCNAS_IRG02 = string.Format(frCult, "{0:n}", SommesVerseesPersonnelCNAS_IRG02);
            etatTFTModel.DecaissementTVAPayer02 = string.Format(frCult, "{0:n}", DecaissementTVAPayer02);
            etatTFTModel.DecaissementIBS_IFU_IRG02 = string.Format(frCult, "{0:n}", DecaissementIBS_IFU_IRG02);
            etatTFTModel.FluxTresorerieProvenantExploitation02 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantExploitation02);
            etatTFTModel.DecaissementAcquisitionEquipements02 = string.Format(frCult, "{0:n}", DecaissementAcquisitionEquipements02);
            etatTFTModel.FluxTresorerieProvenantInvestissement02 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantInvestissement02);
            etatTFTModel.EncaissementsSuiteApportPersonnel02 = string.Format(frCult, "{0:n}", EncaissementsSuiteApportPersonnel02);
            etatTFTModel.EncaissementsProvenantEmprunts02 = string.Format(frCult, "{0:n}", EncaissementsProvenantEmprunts02);
            etatTFTModel.RemboursementsEmpruntsCMT02 = string.Format(frCult, "{0:n}", RemboursementsEmpruntsCMT02);
            etatTFTModel.RemboursementsEmpruntsPNR02 = string.Format(frCult, "{0:n}", RemboursementsEmpruntsPNR02);
            etatTFTModel.FluxTresorerieProvenantFinancement02 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantFinancement02);
            etatTFTModel.FluxTresorerieNet02 = string.Format(frCult, "{0:n}", FluxTresorerieNet02);
            etatTFTModel.SoldeInitial02 = string.Format(frCult, "{0:n}", SoldeInitial02);
            etatTFTModel.SoldeFinal02 = string.Format(frCult, "{0:n}", SoldeFinal02);
            etatTFTModel.Equilibre02 = string.Format(frCult, "{0:n}", Equilibre02);

            etatTFTModel.EncaissementsRecuClients03 = string.Format(frCult, "{0:n}", EncaissementsRecuClients03);
            etatTFTModel.SommesVerseesFournisseurs03 = string.Format(frCult, "{0:n}", SommesVerseesFournisseurs03);
            etatTFTModel.SommesVerseesPrestataires03 = string.Format(frCult, "{0:n}", SommesVerseesPrestataires03);
            etatTFTModel.SommesVerseesPersonnelCNAS_IRG03 = string.Format(frCult, "{0:n}", SommesVerseesPersonnelCNAS_IRG03);
            etatTFTModel.DecaissementTVAPayer03 = string.Format(frCult, "{0:n}", DecaissementTVAPayer03);
            etatTFTModel.DecaissementIBS_IFU_IRG03 = string.Format(frCult, "{0:n}", DecaissementIBS_IFU_IRG03);
            etatTFTModel.FluxTresorerieProvenantExploitation03 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantExploitation03);
            etatTFTModel.DecaissementAcquisitionEquipements03 = string.Format(frCult, "{0:n}", DecaissementAcquisitionEquipements03);
            etatTFTModel.FluxTresorerieProvenantInvestissement03 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantInvestissement03);
            etatTFTModel.EncaissementsSuiteApportPersonnel03 = string.Format(frCult, "{0:n}", EncaissementsSuiteApportPersonnel03);
            etatTFTModel.EncaissementsProvenantEmprunts03 = string.Format(frCult, "{0:n}", EncaissementsProvenantEmprunts03);
            etatTFTModel.RemboursementsEmpruntsCMT03 = string.Format(frCult, "{0:n}", RemboursementsEmpruntsCMT03);
            etatTFTModel.RemboursementsEmpruntsPNR03 = string.Format(frCult, "{0:n}", RemboursementsEmpruntsPNR03);
            etatTFTModel.FluxTresorerieProvenantFinancement03 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantFinancement03);
            etatTFTModel.FluxTresorerieNet03 = string.Format(frCult, "{0:n}", FluxTresorerieNet03);
            etatTFTModel.SoldeInitial03 = string.Format(frCult, "{0:n}", SoldeInitial03);
            etatTFTModel.SoldeFinal03 = string.Format(frCult, "{0:n}", SoldeFinal03);
            etatTFTModel.Equilibre03 = string.Format(frCult, "{0:n}", Equilibre03);

            etatTFTModel.EncaissementsRecuClients04 = string.Format(frCult, "{0:n}", EncaissementsRecuClients04);
            etatTFTModel.SommesVerseesFournisseurs04 = string.Format(frCult, "{0:n}", SommesVerseesFournisseurs04);
            etatTFTModel.SommesVerseesPrestataires04 = string.Format(frCult, "{0:n}", SommesVerseesPrestataires04);
            etatTFTModel.SommesVerseesPersonnelCNAS_IRG04 = string.Format(frCult, "{0:n}", SommesVerseesPersonnelCNAS_IRG04);
            etatTFTModel.DecaissementTVAPayer04 = string.Format(frCult, "{0:n}", DecaissementTVAPayer04);
            etatTFTModel.DecaissementIBS_IFU_IRG04 = string.Format(frCult, "{0:n}", DecaissementIBS_IFU_IRG04);
            etatTFTModel.FluxTresorerieProvenantExploitation04 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantExploitation04);
            etatTFTModel.DecaissementAcquisitionEquipements04 = string.Format(frCult, "{0:n}", DecaissementAcquisitionEquipements04);
            etatTFTModel.FluxTresorerieProvenantInvestissement04 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantInvestissement04);
            etatTFTModel.EncaissementsSuiteApportPersonnel04 = string.Format(frCult, "{0:n}", EncaissementsSuiteApportPersonnel04);
            etatTFTModel.EncaissementsProvenantEmprunts04 = string.Format(frCult, "{0:n}", EncaissementsProvenantEmprunts04);
            etatTFTModel.RemboursementsEmpruntsCMT04 = string.Format(frCult, "{0:n}", RemboursementsEmpruntsCMT04);
            etatTFTModel.RemboursementsEmpruntsPNR04 = string.Format(frCult, "{0:n}", RemboursementsEmpruntsPNR04);
            etatTFTModel.FluxTresorerieProvenantFinancement04 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantFinancement04);
            etatTFTModel.FluxTresorerieNet04 = string.Format(frCult, "{0:n}", FluxTresorerieNet04);
            etatTFTModel.SoldeInitial04 = string.Format(frCult, "{0:n}", SoldeInitial04);
            etatTFTModel.SoldeFinal04 = string.Format(frCult, "{0:n}", SoldeFinal04);
            etatTFTModel.Equilibre04 = string.Format(frCult, "{0:n}", Equilibre04);

            etatTFTModel.EncaissementsRecuClients05 = string.Format(frCult, "{0:n}", EncaissementsRecuClients05);
            etatTFTModel.SommesVerseesFournisseurs05 = string.Format(frCult, "{0:n}", SommesVerseesFournisseurs05);
            etatTFTModel.SommesVerseesPrestataires05 = string.Format(frCult, "{0:n}", SommesVerseesPrestataires05);
            etatTFTModel.SommesVerseesPersonnelCNAS_IRG05 = string.Format(frCult, "{0:n}", SommesVerseesPersonnelCNAS_IRG05);
            etatTFTModel.DecaissementTVAPayer05 = string.Format(frCult, "{0:n}", DecaissementTVAPayer05);
            etatTFTModel.DecaissementIBS_IFU_IRG05 = string.Format(frCult, "{0:n}", DecaissementIBS_IFU_IRG05);
            etatTFTModel.FluxTresorerieProvenantExploitation05 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantExploitation05);
            etatTFTModel.DecaissementAcquisitionEquipements05 = string.Format(frCult, "{0:n}", DecaissementAcquisitionEquipements05);
            etatTFTModel.FluxTresorerieProvenantInvestissement05 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantInvestissement05);
            etatTFTModel.EncaissementsSuiteApportPersonnel05 = string.Format(frCult, "{0:n}", EncaissementsSuiteApportPersonnel05);
            etatTFTModel.EncaissementsProvenantEmprunts05 = string.Format(frCult, "{0:n}", EncaissementsProvenantEmprunts05);
            etatTFTModel.RemboursementsEmpruntsCMT05 = string.Format(frCult, "{0:n}", RemboursementsEmpruntsCMT05);
            etatTFTModel.RemboursementsEmpruntsPNR05 = string.Format(frCult, "{0:n}", RemboursementsEmpruntsPNR05);
            etatTFTModel.FluxTresorerieProvenantFinancement05 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantFinancement05);
            etatTFTModel.FluxTresorerieNet05 = string.Format(frCult, "{0:n}", FluxTresorerieNet05);
            etatTFTModel.SoldeInitial05 = string.Format(frCult, "{0:n}", SoldeInitial05);
            etatTFTModel.SoldeFinal05 = string.Format(frCult, "{0:n}", SoldeFinal05);
            etatTFTModel.Equilibre05 = string.Format(frCult, "{0:n}", Equilibre05);

            etatTFTModel.EncaissementsRecuClients06 = string.Format(frCult, "{0:n}", EncaissementsRecuClients06);
            etatTFTModel.SommesVerseesFournisseurs06 = string.Format(frCult, "{0:n}", SommesVerseesFournisseurs06);
            etatTFTModel.SommesVerseesPrestataires06 = string.Format(frCult, "{0:n}", SommesVerseesPrestataires06);
            etatTFTModel.SommesVerseesPersonnelCNAS_IRG06 = string.Format(frCult, "{0:n}", SommesVerseesPersonnelCNAS_IRG06);
            etatTFTModel.DecaissementTVAPayer06 = string.Format(frCult, "{0:n}", DecaissementTVAPayer06);
            etatTFTModel.DecaissementIBS_IFU_IRG06 = string.Format(frCult, "{0:n}", DecaissementIBS_IFU_IRG06);
            etatTFTModel.FluxTresorerieProvenantExploitation06 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantExploitation06);
            etatTFTModel.DecaissementAcquisitionEquipements06 = string.Format(frCult, "{0:n}", DecaissementAcquisitionEquipements06);
            etatTFTModel.FluxTresorerieProvenantInvestissement06 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantInvestissement06);
            etatTFTModel.EncaissementsSuiteApportPersonnel06 = string.Format(frCult, "{0:n}", EncaissementsSuiteApportPersonnel06);
            etatTFTModel.EncaissementsProvenantEmprunts06 = string.Format(frCult, "{0:n}", EncaissementsProvenantEmprunts06);
            etatTFTModel.RemboursementsEmpruntsCMT06 = string.Format(frCult, "{0:n}", RemboursementsEmpruntsCMT06);
            etatTFTModel.RemboursementsEmpruntsPNR06 = string.Format(frCult, "{0:n}", RemboursementsEmpruntsPNR06);
            etatTFTModel.FluxTresorerieProvenantFinancement06 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantFinancement06);
            etatTFTModel.FluxTresorerieNet06 = string.Format(frCult, "{0:n}", FluxTresorerieNet06);
            etatTFTModel.SoldeInitial06 = string.Format(frCult, "{0:n}", SoldeInitial06);
            etatTFTModel.SoldeFinal06 = string.Format(frCult, "{0:n}", SoldeFinal06);
            etatTFTModel.Equilibre06 = string.Format(frCult, "{0:n}", Equilibre06);

            etatTFTModel.EncaissementsRecuClients07 = string.Format(frCult, "{0:n}", EncaissementsRecuClients07);
            etatTFTModel.SommesVerseesFournisseurs07 = string.Format(frCult, "{0:n}", SommesVerseesFournisseurs07);
            etatTFTModel.SommesVerseesPrestataires07 = string.Format(frCult, "{0:n}", SommesVerseesPrestataires07);
            etatTFTModel.SommesVerseesPersonnelCNAS_IRG07 = string.Format(frCult, "{0:n}", SommesVerseesPersonnelCNAS_IRG07);
            etatTFTModel.DecaissementTVAPayer07 = string.Format(frCult, "{0:n}", DecaissementTVAPayer07);
            etatTFTModel.DecaissementIBS_IFU_IRG07 = string.Format(frCult, "{0:n}", DecaissementIBS_IFU_IRG07);
            etatTFTModel.FluxTresorerieProvenantExploitation07 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantExploitation07);
            etatTFTModel.DecaissementAcquisitionEquipements07 = string.Format(frCult, "{0:n}", DecaissementAcquisitionEquipements07);
            etatTFTModel.FluxTresorerieProvenantInvestissement07 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantInvestissement07);
            etatTFTModel.EncaissementsSuiteApportPersonnel07 = string.Format(frCult, "{0:n}", EncaissementsSuiteApportPersonnel07);
            etatTFTModel.EncaissementsProvenantEmprunts07 = string.Format(frCult, "{0:n}", EncaissementsProvenantEmprunts07);
            etatTFTModel.RemboursementsEmpruntsCMT07 = string.Format(frCult, "{0:n}", RemboursementsEmpruntsCMT07);
            etatTFTModel.RemboursementsEmpruntsPNR07 = string.Format(frCult, "{0:n}", RemboursementsEmpruntsPNR07);
            etatTFTModel.FluxTresorerieProvenantFinancement07 = string.Format(frCult, "{0:n}", FluxTresorerieProvenantFinancement07);
            etatTFTModel.FluxTresorerieNet07 = string.Format(frCult, "{0:n}", FluxTresorerieNet07);
            etatTFTModel.SoldeInitial07 = string.Format(frCult, "{0:n}", SoldeInitial07);
            etatTFTModel.SoldeFinal07 = string.Format(frCult, "{0:n}", SoldeFinal07);
            etatTFTModel.Equilibre07 = string.Format(frCult, "{0:n}", Equilibre07);

            #endregion

            return PartialView($"_{nameof(EtatTFT)}", etatTFTModel);
        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> EtatPlanTresorerie(int id)
        {

            //var modelBusinessPlan = _businessPlanBusinessService.GetById(id);
            var modelBusinessPlan = _businessPlanBusinessService.GetById(id, _businessPlanBusinessService.GetDefaultLoadProperties());

            ViewData["BusinessPlanID"] = id;
            ViewData["NumeroSIEJE"] = modelBusinessPlan.NumeroSIEJE;

            ViewData["AnneeID"] = new SelectList(_anneeBusinessService.GetAll(), "Id", "DesignationFr");

            var listeRubriqueChargesExternes = new SelectList(_rubriqueChargesExternesBusinessService.GetAll(), "Id", "CodeDesignationFr");

            ViewData["RubriqueChargesExternesID"] = listeRubriqueChargesExternes;

            if (modelBusinessPlan.Complet)
            {
                ViewData["CompletOuiNon"] = "Oui";
            }
            else
            {
                ViewData["CompletOuiNon"] = "Non";
            }

            System.Globalization.CultureInfo frCult = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");

            #region Données EtatPlanTresorerie

            #region Données EtatPlanTresorerie Année01

            #region Données EtatPlanTresorerie Année01 Mois01
            decimal SoldeInitial_01_01 = 0;
            decimal ApportSupplementaire_01_01 = 0;
            decimal CMT_01_01 = 0;
            decimal PNRClassique_01_01 = 0;
            decimal ApportPersonnel_01_01 = 0;
            decimal PNRLoyer_01_01 = 0;
            decimal EncaissementRecusClients_01_01 = 0;
            decimal TotalRecette_01_01 = 0;
            decimal AcquisitionEquipementAmenagement_01_01 = 0;
            decimal DecaissementFournisseurs_01_01 = 0;
            decimal DecaissementPrestataires_01_01 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_01_01 = 0;
            decimal DecaissementSalairesNets_01_01 = 0;
            decimal CotisationsSociales_01_01 = 0;
            decimal IRGSalaires_01_01 = 0;
            decimal TVAPayer_01_01 = 0;
            decimal IBS_IFU_01_01 = 0;
            decimal TotalDepense_01_01 = 0;
            decimal SoldeFinal_01_01 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année01 Mois02
            decimal SoldeInitial_01_02 = 0;
            decimal ApportSupplementaire_01_02 = 0;
            decimal CMT_01_02 = 0;
            decimal PNRClassique_01_02 = 0;
            decimal ApportPersonnel_01_02 = 0;
            decimal PNRLoyer_01_02 = 0;
            decimal EncaissementRecusClients_01_02 = 0;
            decimal TotalRecette_01_02 = 0;
            decimal AcquisitionEquipementAmenagement_01_02 = 0;
            decimal DecaissementFournisseurs_01_02 = 0;
            decimal DecaissementPrestataires_01_02 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_01_02 = 0;
            decimal DecaissementSalairesNets_01_02 = 0;
            decimal CotisationsSociales_01_02 = 0;
            decimal IRGSalaires_01_02 = 0;
            decimal TVAPayer_01_02 = 0;
            decimal IBS_IFU_01_02 = 0;
            decimal TotalDepense_01_02 = 0;
            decimal SoldeFinal_01_02 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année01 Mois03
            decimal SoldeInitial_01_03 = 0;
            decimal ApportSupplementaire_01_03 = 0;
            decimal CMT_01_03 = 0;
            decimal PNRClassique_01_03 = 0;
            decimal ApportPersonnel_01_03 = 0;
            decimal PNRLoyer_01_03 = 0;
            decimal EncaissementRecusClients_01_03 = 0;
            decimal TotalRecette_01_03 = 0;
            decimal AcquisitionEquipementAmenagement_01_03 = 0;
            decimal DecaissementFournisseurs_01_03 = 0;
            decimal DecaissementPrestataires_01_03 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_01_03 = 0;
            decimal DecaissementSalairesNets_01_03 = 0;
            decimal CotisationsSociales_01_03 = 0;
            decimal IRGSalaires_01_03 = 0;
            decimal TVAPayer_01_03 = 0;
            decimal IBS_IFU_01_03 = 0;
            decimal TotalDepense_01_03 = 0;
            decimal SoldeFinal_01_03 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année01 Mois04
            decimal SoldeInitial_01_04 = 0;
            decimal ApportSupplementaire_01_04 = 0;
            decimal CMT_01_04 = 0;
            decimal PNRClassique_01_04 = 0;
            decimal ApportPersonnel_01_04 = 0;
            decimal PNRLoyer_01_04 = 0;
            decimal EncaissementRecusClients_01_04 = 0;
            decimal TotalRecette_01_04 = 0;
            decimal AcquisitionEquipementAmenagement_01_04 = 0;
            decimal DecaissementFournisseurs_01_04 = 0;
            decimal DecaissementPrestataires_01_04 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_01_04 = 0;
            decimal DecaissementSalairesNets_01_04 = 0;
            decimal CotisationsSociales_01_04 = 0;
            decimal IRGSalaires_01_04 = 0;
            decimal TVAPayer_01_04 = 0;
            decimal IBS_IFU_01_04 = 0;
            decimal TotalDepense_01_04 = 0;
            decimal SoldeFinal_01_04 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année01 Mois05
            decimal SoldeInitial_01_05 = 0;
            decimal ApportSupplementaire_01_05 = 0;
            decimal CMT_01_05 = 0;
            decimal PNRClassique_01_05 = 0;
            decimal ApportPersonnel_01_05 = 0;
            decimal PNRLoyer_01_05 = 0;
            decimal EncaissementRecusClients_01_05 = 0;
            decimal TotalRecette_01_05 = 0;
            decimal AcquisitionEquipementAmenagement_01_05 = 0;
            decimal DecaissementFournisseurs_01_05 = 0;
            decimal DecaissementPrestataires_01_05 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_01_05 = 0;
            decimal DecaissementSalairesNets_01_05 = 0;
            decimal CotisationsSociales_01_05 = 0;
            decimal IRGSalaires_01_05 = 0;
            decimal TVAPayer_01_05 = 0;
            decimal IBS_IFU_01_05 = 0;
            decimal TotalDepense_01_05 = 0;
            decimal SoldeFinal_01_05 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année01 Mois06
            decimal SoldeInitial_01_06 = 0;
            decimal ApportSupplementaire_01_06 = 0;
            decimal CMT_01_06 = 0;
            decimal PNRClassique_01_06 = 0;
            decimal ApportPersonnel_01_06 = 0;
            decimal PNRLoyer_01_06 = 0;
            decimal EncaissementRecusClients_01_06 = 0;
            decimal TotalRecette_01_06 = 0;
            decimal AcquisitionEquipementAmenagement_01_06 = 0;
            decimal DecaissementFournisseurs_01_06 = 0;
            decimal DecaissementPrestataires_01_06 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_01_06 = 0;
            decimal DecaissementSalairesNets_01_06 = 0;
            decimal CotisationsSociales_01_06 = 0;
            decimal IRGSalaires_01_06 = 0;
            decimal TVAPayer_01_06 = 0;
            decimal IBS_IFU_01_06 = 0;
            decimal TotalDepense_01_06 = 0;
            decimal SoldeFinal_01_06 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année01 Mois07
            decimal SoldeInitial_01_07 = 0;
            decimal ApportSupplementaire_01_07 = 0;
            decimal CMT_01_07 = 0;
            decimal PNRClassique_01_07 = 0;
            decimal ApportPersonnel_01_07 = 0;
            decimal PNRLoyer_01_07 = 0;
            decimal EncaissementRecusClients_01_07 = 0;
            decimal TotalRecette_01_07 = 0;
            decimal AcquisitionEquipementAmenagement_01_07 = 0;
            decimal DecaissementFournisseurs_01_07 = 0;
            decimal DecaissementPrestataires_01_07 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_01_07 = 0;
            decimal DecaissementSalairesNets_01_07 = 0;
            decimal CotisationsSociales_01_07 = 0;
            decimal IRGSalaires_01_07 = 0;
            decimal TVAPayer_01_07 = 0;
            decimal IBS_IFU_01_07 = 0;
            decimal TotalDepense_01_07 = 0;
            decimal SoldeFinal_01_07 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année01 Mois08
            decimal SoldeInitial_01_08 = 0;
            decimal ApportSupplementaire_01_08 = 0;
            decimal CMT_01_08 = 0;
            decimal PNRClassique_01_08 = 0;
            decimal ApportPersonnel_01_08 = 0;
            decimal PNRLoyer_01_08 = 0;
            decimal EncaissementRecusClients_01_08 = 0;
            decimal TotalRecette_01_08 = 0;
            decimal AcquisitionEquipementAmenagement_01_08 = 0;
            decimal DecaissementFournisseurs_01_08 = 0;
            decimal DecaissementPrestataires_01_08 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_01_08 = 0;
            decimal DecaissementSalairesNets_01_08 = 0;
            decimal CotisationsSociales_01_08 = 0;
            decimal IRGSalaires_01_08 = 0;
            decimal TVAPayer_01_08 = 0;
            decimal IBS_IFU_01_08 = 0;
            decimal TotalDepense_01_08 = 0;
            decimal SoldeFinal_01_08 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année01 Mois09
            decimal SoldeInitial_01_09 = 0;
            decimal ApportSupplementaire_01_09 = 0;
            decimal CMT_01_09 = 0;
            decimal PNRClassique_01_09 = 0;
            decimal ApportPersonnel_01_09 = 0;
            decimal PNRLoyer_01_09 = 0;
            decimal EncaissementRecusClients_01_09 = 0;
            decimal TotalRecette_01_09 = 0;
            decimal AcquisitionEquipementAmenagement_01_09 = 0;
            decimal DecaissementFournisseurs_01_09 = 0;
            decimal DecaissementPrestataires_01_09 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_01_09 = 0;
            decimal DecaissementSalairesNets_01_09 = 0;
            decimal CotisationsSociales_01_09 = 0;
            decimal IRGSalaires_01_09 = 0;
            decimal TVAPayer_01_09 = 0;
            decimal IBS_IFU_01_09 = 0;
            decimal TotalDepense_01_09 = 0;
            decimal SoldeFinal_01_09 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année01 Mois10
            decimal SoldeInitial_01_10 = 0;
            decimal ApportSupplementaire_01_10 = 0;
            decimal CMT_01_10 = 0;
            decimal PNRClassique_01_10 = 0;
            decimal ApportPersonnel_01_10 = 0;
            decimal PNRLoyer_01_10 = 0;
            decimal EncaissementRecusClients_01_10 = 0;
            decimal TotalRecette_01_10 = 0;
            decimal AcquisitionEquipementAmenagement_01_10 = 0;
            decimal DecaissementFournisseurs_01_10 = 0;
            decimal DecaissementPrestataires_01_10 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_01_10 = 0;
            decimal DecaissementSalairesNets_01_10 = 0;
            decimal CotisationsSociales_01_10 = 0;
            decimal IRGSalaires_01_10 = 0;
            decimal TVAPayer_01_10 = 0;
            decimal IBS_IFU_01_10 = 0;
            decimal TotalDepense_01_10 = 0;
            decimal SoldeFinal_01_10 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année01 Mois11
            decimal SoldeInitial_01_11 = 0;
            decimal ApportSupplementaire_01_11 = 0;
            decimal CMT_01_11 = 0;
            decimal PNRClassique_01_11 = 0;
            decimal ApportPersonnel_01_11 = 0;
            decimal PNRLoyer_01_11 = 0;
            decimal EncaissementRecusClients_01_11 = 0;
            decimal TotalRecette_01_11 = 0;
            decimal AcquisitionEquipementAmenagement_01_11 = 0;
            decimal DecaissementFournisseurs_01_11 = 0;
            decimal DecaissementPrestataires_01_11 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_01_11 = 0;
            decimal DecaissementSalairesNets_01_11 = 0;
            decimal CotisationsSociales_01_11 = 0;
            decimal IRGSalaires_01_11 = 0;
            decimal TVAPayer_01_11 = 0;
            decimal IBS_IFU_01_11 = 0;
            decimal TotalDepense_01_11 = 0;
            decimal SoldeFinal_01_11 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année01 Mois12
            decimal SoldeInitial_01_12 = 0;
            decimal ApportSupplementaire_01_12 = 0;
            decimal CMT_01_12 = 0;
            decimal PNRClassique_01_12 = 0;
            decimal ApportPersonnel_01_12 = 0;
            decimal PNRLoyer_01_12 = 0;
            decimal EncaissementRecusClients_01_12 = 0;
            decimal TotalRecette_01_12 = 0;
            decimal AcquisitionEquipementAmenagement_01_12 = 0;
            decimal DecaissementFournisseurs_01_12 = 0;
            decimal DecaissementPrestataires_01_12 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_01_12 = 0;
            decimal DecaissementSalairesNets_01_12 = 0;
            decimal CotisationsSociales_01_12 = 0;
            decimal IRGSalaires_01_12 = 0;
            decimal TVAPayer_01_12 = 0;
            decimal IBS_IFU_01_12 = 0;
            decimal TotalDepense_01_12 = 0;
            decimal SoldeFinal_01_12 = 0;
            #endregion

            #endregion

            #region Données EtatPlanTresorerie Année02

            #region Données EtatPlanTresorerie Année02 Mois01
            decimal SoldeInitial_02_01 = 0;
            decimal ApportSupplementaire_02_01 = 0;
            decimal CMT_02_01 = 0;
            decimal PNRClassique_02_01 = 0;
            decimal ApportPersonnel_02_01 = 0;
            decimal PNRLoyer_02_01 = 0;
            decimal EncaissementRecusClients_02_01 = 0;
            decimal TotalRecette_02_01 = 0;
            decimal AcquisitionEquipementAmenagement_02_01 = 0;
            decimal DecaissementFournisseurs_02_01 = 0;
            decimal DecaissementPrestataires_02_01 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_02_01 = 0;
            decimal DecaissementSalairesNets_02_01 = 0;
            decimal CotisationsSociales_02_01 = 0;
            decimal IRGSalaires_02_01 = 0;
            decimal TVAPayer_02_01 = 0;
            decimal IBS_IFU_02_01 = 0;
            decimal TotalDepense_02_01 = 0;
            decimal SoldeFinal_02_01 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année02 Mois02
            decimal SoldeInitial_02_02 = 0;
            decimal ApportSupplementaire_02_02 = 0;
            decimal CMT_02_02 = 0;
            decimal PNRClassique_02_02 = 0;
            decimal ApportPersonnel_02_02 = 0;
            decimal PNRLoyer_02_02 = 0;
            decimal EncaissementRecusClients_02_02 = 0;
            decimal TotalRecette_02_02 = 0;
            decimal AcquisitionEquipementAmenagement_02_02 = 0;
            decimal DecaissementFournisseurs_02_02 = 0;
            decimal DecaissementPrestataires_02_02 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_02_02 = 0;
            decimal DecaissementSalairesNets_02_02 = 0;
            decimal CotisationsSociales_02_02 = 0;
            decimal IRGSalaires_02_02 = 0;
            decimal TVAPayer_02_02 = 0;
            decimal IBS_IFU_02_02 = 0;
            decimal TotalDepense_02_02 = 0;
            decimal SoldeFinal_02_02 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année02 Mois03
            decimal SoldeInitial_02_03 = 0;
            decimal ApportSupplementaire_02_03 = 0;
            decimal CMT_02_03 = 0;
            decimal PNRClassique_02_03 = 0;
            decimal ApportPersonnel_02_03 = 0;
            decimal PNRLoyer_02_03 = 0;
            decimal EncaissementRecusClients_02_03 = 0;
            decimal TotalRecette_02_03 = 0;
            decimal AcquisitionEquipementAmenagement_02_03 = 0;
            decimal DecaissementFournisseurs_02_03 = 0;
            decimal DecaissementPrestataires_02_03 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_02_03 = 0;
            decimal DecaissementSalairesNets_02_03 = 0;
            decimal CotisationsSociales_02_03 = 0;
            decimal IRGSalaires_02_03 = 0;
            decimal TVAPayer_02_03 = 0;
            decimal IBS_IFU_02_03 = 0;
            decimal TotalDepense_02_03 = 0;
            decimal SoldeFinal_02_03 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année02 Mois04
            decimal SoldeInitial_02_04 = 0;
            decimal ApportSupplementaire_02_04 = 0;
            decimal CMT_02_04 = 0;
            decimal PNRClassique_02_04 = 0;
            decimal ApportPersonnel_02_04 = 0;
            decimal PNRLoyer_02_04 = 0;
            decimal EncaissementRecusClients_02_04 = 0;
            decimal TotalRecette_02_04 = 0;
            decimal AcquisitionEquipementAmenagement_02_04 = 0;
            decimal DecaissementFournisseurs_02_04 = 0;
            decimal DecaissementPrestataires_02_04 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_02_04 = 0;
            decimal DecaissementSalairesNets_02_04 = 0;
            decimal CotisationsSociales_02_04 = 0;
            decimal IRGSalaires_02_04 = 0;
            decimal TVAPayer_02_04 = 0;
            decimal IBS_IFU_02_04 = 0;
            decimal TotalDepense_02_04 = 0;
            decimal SoldeFinal_02_04 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année02 Mois05
            decimal SoldeInitial_02_05 = 0;
            decimal ApportSupplementaire_02_05 = 0;
            decimal CMT_02_05 = 0;
            decimal PNRClassique_02_05 = 0;
            decimal ApportPersonnel_02_05 = 0;
            decimal PNRLoyer_02_05 = 0;
            decimal EncaissementRecusClients_02_05 = 0;
            decimal TotalRecette_02_05 = 0;
            decimal AcquisitionEquipementAmenagement_02_05 = 0;
            decimal DecaissementFournisseurs_02_05 = 0;
            decimal DecaissementPrestataires_02_05 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_02_05 = 0;
            decimal DecaissementSalairesNets_02_05 = 0;
            decimal CotisationsSociales_02_05 = 0;
            decimal IRGSalaires_02_05 = 0;
            decimal TVAPayer_02_05 = 0;
            decimal IBS_IFU_02_05 = 0;
            decimal TotalDepense_02_05 = 0;
            decimal SoldeFinal_02_05 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année02 Mois06
            decimal SoldeInitial_02_06 = 0;
            decimal ApportSupplementaire_02_06 = 0;
            decimal CMT_02_06 = 0;
            decimal PNRClassique_02_06 = 0;
            decimal ApportPersonnel_02_06 = 0;
            decimal PNRLoyer_02_06 = 0;
            decimal EncaissementRecusClients_02_06 = 0;
            decimal TotalRecette_02_06 = 0;
            decimal AcquisitionEquipementAmenagement_02_06 = 0;
            decimal DecaissementFournisseurs_02_06 = 0;
            decimal DecaissementPrestataires_02_06 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_02_06 = 0;
            decimal DecaissementSalairesNets_02_06 = 0;
            decimal CotisationsSociales_02_06 = 0;
            decimal IRGSalaires_02_06 = 0;
            decimal TVAPayer_02_06 = 0;
            decimal IBS_IFU_02_06 = 0;
            decimal TotalDepense_02_06 = 0;
            decimal SoldeFinal_02_06 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année02 Mois07
            decimal SoldeInitial_02_07 = 0;
            decimal ApportSupplementaire_02_07 = 0;
            decimal CMT_02_07 = 0;
            decimal PNRClassique_02_07 = 0;
            decimal ApportPersonnel_02_07 = 0;
            decimal PNRLoyer_02_07 = 0;
            decimal EncaissementRecusClients_02_07 = 0;
            decimal TotalRecette_02_07 = 0;
            decimal AcquisitionEquipementAmenagement_02_07 = 0;
            decimal DecaissementFournisseurs_02_07 = 0;
            decimal DecaissementPrestataires_02_07 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_02_07 = 0;
            decimal DecaissementSalairesNets_02_07 = 0;
            decimal CotisationsSociales_02_07 = 0;
            decimal IRGSalaires_02_07 = 0;
            decimal TVAPayer_02_07 = 0;
            decimal IBS_IFU_02_07 = 0;
            decimal TotalDepense_02_07 = 0;
            decimal SoldeFinal_02_07 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année02 Mois08
            decimal SoldeInitial_02_08 = 0;
            decimal ApportSupplementaire_02_08 = 0;
            decimal CMT_02_08 = 0;
            decimal PNRClassique_02_08 = 0;
            decimal ApportPersonnel_02_08 = 0;
            decimal PNRLoyer_02_08 = 0;
            decimal EncaissementRecusClients_02_08 = 0;
            decimal TotalRecette_02_08 = 0;
            decimal AcquisitionEquipementAmenagement_02_08 = 0;
            decimal DecaissementFournisseurs_02_08 = 0;
            decimal DecaissementPrestataires_02_08 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_02_08 = 0;
            decimal DecaissementSalairesNets_02_08 = 0;
            decimal CotisationsSociales_02_08 = 0;
            decimal IRGSalaires_02_08 = 0;
            decimal TVAPayer_02_08 = 0;
            decimal IBS_IFU_02_08 = 0;
            decimal TotalDepense_02_08 = 0;
            decimal SoldeFinal_02_08 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année02 Mois09
            decimal SoldeInitial_02_09 = 0;
            decimal ApportSupplementaire_02_09 = 0;
            decimal CMT_02_09 = 0;
            decimal PNRClassique_02_09 = 0;
            decimal ApportPersonnel_02_09 = 0;
            decimal PNRLoyer_02_09 = 0;
            decimal EncaissementRecusClients_02_09 = 0;
            decimal TotalRecette_02_09 = 0;
            decimal AcquisitionEquipementAmenagement_02_09 = 0;
            decimal DecaissementFournisseurs_02_09 = 0;
            decimal DecaissementPrestataires_02_09 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_02_09 = 0;
            decimal DecaissementSalairesNets_02_09 = 0;
            decimal CotisationsSociales_02_09 = 0;
            decimal IRGSalaires_02_09 = 0;
            decimal TVAPayer_02_09 = 0;
            decimal IBS_IFU_02_09 = 0;
            decimal TotalDepense_02_09 = 0;
            decimal SoldeFinal_02_09 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année02 Mois10
            decimal SoldeInitial_02_10 = 0;
            decimal ApportSupplementaire_02_10 = 0;
            decimal CMT_02_10 = 0;
            decimal PNRClassique_02_10 = 0;
            decimal ApportPersonnel_02_10 = 0;
            decimal PNRLoyer_02_10 = 0;
            decimal EncaissementRecusClients_02_10 = 0;
            decimal TotalRecette_02_10 = 0;
            decimal AcquisitionEquipementAmenagement_02_10 = 0;
            decimal DecaissementFournisseurs_02_10 = 0;
            decimal DecaissementPrestataires_02_10 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_02_10 = 0;
            decimal DecaissementSalairesNets_02_10 = 0;
            decimal CotisationsSociales_02_10 = 0;
            decimal IRGSalaires_02_10 = 0;
            decimal TVAPayer_02_10 = 0;
            decimal IBS_IFU_02_10 = 0;
            decimal TotalDepense_02_10 = 0;
            decimal SoldeFinal_02_10 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année02 Mois11
            decimal SoldeInitial_02_11 = 0;
            decimal ApportSupplementaire_02_11 = 0;
            decimal CMT_02_11 = 0;
            decimal PNRClassique_02_11 = 0;
            decimal ApportPersonnel_02_11 = 0;
            decimal PNRLoyer_02_11 = 0;
            decimal EncaissementRecusClients_02_11 = 0;
            decimal TotalRecette_02_11 = 0;
            decimal AcquisitionEquipementAmenagement_02_11 = 0;
            decimal DecaissementFournisseurs_02_11 = 0;
            decimal DecaissementPrestataires_02_11 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_02_11 = 0;
            decimal DecaissementSalairesNets_02_11 = 0;
            decimal CotisationsSociales_02_11 = 0;
            decimal IRGSalaires_02_11 = 0;
            decimal TVAPayer_02_11 = 0;
            decimal IBS_IFU_02_11 = 0;
            decimal TotalDepense_02_11 = 0;
            decimal SoldeFinal_02_11 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année02 Mois12
            decimal SoldeInitial_02_12 = 0;
            decimal ApportSupplementaire_02_12 = 0;
            decimal CMT_02_12 = 0;
            decimal PNRClassique_02_12 = 0;
            decimal ApportPersonnel_02_12 = 0;
            decimal PNRLoyer_02_12 = 0;
            decimal EncaissementRecusClients_02_12 = 0;
            decimal TotalRecette_02_12 = 0;
            decimal AcquisitionEquipementAmenagement_02_12 = 0;
            decimal DecaissementFournisseurs_02_12 = 0;
            decimal DecaissementPrestataires_02_12 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_02_12 = 0;
            decimal DecaissementSalairesNets_02_12 = 0;
            decimal CotisationsSociales_02_12 = 0;
            decimal IRGSalaires_02_12 = 0;
            decimal TVAPayer_02_12 = 0;
            decimal IBS_IFU_02_12 = 0;
            decimal TotalDepense_02_12 = 0;
            decimal SoldeFinal_02_12 = 0;
            #endregion

            #endregion

            #region Données EtatPlanTresorerie Année03

            #region Données EtatPlanTresorerie Année03 Mois01
            decimal SoldeInitial_03_01 = 0;
            decimal ApportSupplementaire_03_01 = 0;
            decimal CMT_03_01 = 0;
            decimal PNRClassique_03_01 = 0;
            decimal ApportPersonnel_03_01 = 0;
            decimal PNRLoyer_03_01 = 0;
            decimal EncaissementRecusClients_03_01 = 0;
            decimal TotalRecette_03_01 = 0;
            decimal AcquisitionEquipementAmenagement_03_01 = 0;
            decimal DecaissementFournisseurs_03_01 = 0;
            decimal DecaissementPrestataires_03_01 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_03_01 = 0;
            decimal DecaissementSalairesNets_03_01 = 0;
            decimal CotisationsSociales_03_01 = 0;
            decimal IRGSalaires_03_01 = 0;
            decimal TVAPayer_03_01 = 0;
            decimal IBS_IFU_03_01 = 0;
            decimal TotalDepense_03_01 = 0;
            decimal SoldeFinal_03_01 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année03 Mois02
            decimal SoldeInitial_03_02 = 0;
            decimal ApportSupplementaire_03_02 = 0;
            decimal CMT_03_02 = 0;
            decimal PNRClassique_03_02 = 0;
            decimal ApportPersonnel_03_02 = 0;
            decimal PNRLoyer_03_02 = 0;
            decimal EncaissementRecusClients_03_02 = 0;
            decimal TotalRecette_03_02 = 0;
            decimal AcquisitionEquipementAmenagement_03_02 = 0;
            decimal DecaissementFournisseurs_03_02 = 0;
            decimal DecaissementPrestataires_03_02 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_03_02 = 0;
            decimal DecaissementSalairesNets_03_02 = 0;
            decimal CotisationsSociales_03_02 = 0;
            decimal IRGSalaires_03_02 = 0;
            decimal TVAPayer_03_02 = 0;
            decimal IBS_IFU_03_02 = 0;
            decimal TotalDepense_03_02 = 0;
            decimal SoldeFinal_03_02 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année03 Mois03
            decimal SoldeInitial_03_03 = 0;
            decimal ApportSupplementaire_03_03 = 0;
            decimal CMT_03_03 = 0;
            decimal PNRClassique_03_03 = 0;
            decimal ApportPersonnel_03_03 = 0;
            decimal PNRLoyer_03_03 = 0;
            decimal EncaissementRecusClients_03_03 = 0;
            decimal TotalRecette_03_03 = 0;
            decimal AcquisitionEquipementAmenagement_03_03 = 0;
            decimal DecaissementFournisseurs_03_03 = 0;
            decimal DecaissementPrestataires_03_03 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_03_03 = 0;
            decimal DecaissementSalairesNets_03_03 = 0;
            decimal CotisationsSociales_03_03 = 0;
            decimal IRGSalaires_03_03 = 0;
            decimal TVAPayer_03_03 = 0;
            decimal IBS_IFU_03_03 = 0;
            decimal TotalDepense_03_03 = 0;
            decimal SoldeFinal_03_03 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année03 Mois04
            decimal SoldeInitial_03_04 = 0;
            decimal ApportSupplementaire_03_04 = 0;
            decimal CMT_03_04 = 0;
            decimal PNRClassique_03_04 = 0;
            decimal ApportPersonnel_03_04 = 0;
            decimal PNRLoyer_03_04 = 0;
            decimal EncaissementRecusClients_03_04 = 0;
            decimal TotalRecette_03_04 = 0;
            decimal AcquisitionEquipementAmenagement_03_04 = 0;
            decimal DecaissementFournisseurs_03_04 = 0;
            decimal DecaissementPrestataires_03_04 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_03_04 = 0;
            decimal DecaissementSalairesNets_03_04 = 0;
            decimal CotisationsSociales_03_04 = 0;
            decimal IRGSalaires_03_04 = 0;
            decimal TVAPayer_03_04 = 0;
            decimal IBS_IFU_03_04 = 0;
            decimal TotalDepense_03_04 = 0;
            decimal SoldeFinal_03_04 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année03 Mois05
            decimal SoldeInitial_03_05 = 0;
            decimal ApportSupplementaire_03_05 = 0;
            decimal CMT_03_05 = 0;
            decimal PNRClassique_03_05 = 0;
            decimal ApportPersonnel_03_05 = 0;
            decimal PNRLoyer_03_05 = 0;
            decimal EncaissementRecusClients_03_05 = 0;
            decimal TotalRecette_03_05 = 0;
            decimal AcquisitionEquipementAmenagement_03_05 = 0;
            decimal DecaissementFournisseurs_03_05 = 0;
            decimal DecaissementPrestataires_03_05 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_03_05 = 0;
            decimal DecaissementSalairesNets_03_05 = 0;
            decimal CotisationsSociales_03_05 = 0;
            decimal IRGSalaires_03_05 = 0;
            decimal TVAPayer_03_05 = 0;
            decimal IBS_IFU_03_05 = 0;
            decimal TotalDepense_03_05 = 0;
            decimal SoldeFinal_03_05 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année03 Mois06
            decimal SoldeInitial_03_06 = 0;
            decimal ApportSupplementaire_03_06 = 0;
            decimal CMT_03_06 = 0;
            decimal PNRClassique_03_06 = 0;
            decimal ApportPersonnel_03_06 = 0;
            decimal PNRLoyer_03_06 = 0;
            decimal EncaissementRecusClients_03_06 = 0;
            decimal TotalRecette_03_06 = 0;
            decimal AcquisitionEquipementAmenagement_03_06 = 0;
            decimal DecaissementFournisseurs_03_06 = 0;
            decimal DecaissementPrestataires_03_06 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_03_06 = 0;
            decimal DecaissementSalairesNets_03_06 = 0;
            decimal CotisationsSociales_03_06 = 0;
            decimal IRGSalaires_03_06 = 0;
            decimal TVAPayer_03_06 = 0;
            decimal IBS_IFU_03_06 = 0;
            decimal TotalDepense_03_06 = 0;
            decimal SoldeFinal_03_06 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année03 Mois07
            decimal SoldeInitial_03_07 = 0;
            decimal ApportSupplementaire_03_07 = 0;
            decimal CMT_03_07 = 0;
            decimal PNRClassique_03_07 = 0;
            decimal ApportPersonnel_03_07 = 0;
            decimal PNRLoyer_03_07 = 0;
            decimal EncaissementRecusClients_03_07 = 0;
            decimal TotalRecette_03_07 = 0;
            decimal AcquisitionEquipementAmenagement_03_07 = 0;
            decimal DecaissementFournisseurs_03_07 = 0;
            decimal DecaissementPrestataires_03_07 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_03_07 = 0;
            decimal DecaissementSalairesNets_03_07 = 0;
            decimal CotisationsSociales_03_07 = 0;
            decimal IRGSalaires_03_07 = 0;
            decimal TVAPayer_03_07 = 0;
            decimal IBS_IFU_03_07 = 0;
            decimal TotalDepense_03_07 = 0;
            decimal SoldeFinal_03_07 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année03 Mois08
            decimal SoldeInitial_03_08 = 0;
            decimal ApportSupplementaire_03_08 = 0;
            decimal CMT_03_08 = 0;
            decimal PNRClassique_03_08 = 0;
            decimal ApportPersonnel_03_08 = 0;
            decimal PNRLoyer_03_08 = 0;
            decimal EncaissementRecusClients_03_08 = 0;
            decimal TotalRecette_03_08 = 0;
            decimal AcquisitionEquipementAmenagement_03_08 = 0;
            decimal DecaissementFournisseurs_03_08 = 0;
            decimal DecaissementPrestataires_03_08 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_03_08 = 0;
            decimal DecaissementSalairesNets_03_08 = 0;
            decimal CotisationsSociales_03_08 = 0;
            decimal IRGSalaires_03_08 = 0;
            decimal TVAPayer_03_08 = 0;
            decimal IBS_IFU_03_08 = 0;
            decimal TotalDepense_03_08 = 0;
            decimal SoldeFinal_03_08 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année03 Mois09
            decimal SoldeInitial_03_09 = 0;
            decimal ApportSupplementaire_03_09 = 0;
            decimal CMT_03_09 = 0;
            decimal PNRClassique_03_09 = 0;
            decimal ApportPersonnel_03_09 = 0;
            decimal PNRLoyer_03_09 = 0;
            decimal EncaissementRecusClients_03_09 = 0;
            decimal TotalRecette_03_09 = 0;
            decimal AcquisitionEquipementAmenagement_03_09 = 0;
            decimal DecaissementFournisseurs_03_09 = 0;
            decimal DecaissementPrestataires_03_09 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_03_09 = 0;
            decimal DecaissementSalairesNets_03_09 = 0;
            decimal CotisationsSociales_03_09 = 0;
            decimal IRGSalaires_03_09 = 0;
            decimal TVAPayer_03_09 = 0;
            decimal IBS_IFU_03_09 = 0;
            decimal TotalDepense_03_09 = 0;
            decimal SoldeFinal_03_09 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année03 Mois10
            decimal SoldeInitial_03_10 = 0;
            decimal ApportSupplementaire_03_10 = 0;
            decimal CMT_03_10 = 0;
            decimal PNRClassique_03_10 = 0;
            decimal ApportPersonnel_03_10 = 0;
            decimal PNRLoyer_03_10 = 0;
            decimal EncaissementRecusClients_03_10 = 0;
            decimal TotalRecette_03_10 = 0;
            decimal AcquisitionEquipementAmenagement_03_10 = 0;
            decimal DecaissementFournisseurs_03_10 = 0;
            decimal DecaissementPrestataires_03_10 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_03_10 = 0;
            decimal DecaissementSalairesNets_03_10 = 0;
            decimal CotisationsSociales_03_10 = 0;
            decimal IRGSalaires_03_10 = 0;
            decimal TVAPayer_03_10 = 0;
            decimal IBS_IFU_03_10 = 0;
            decimal TotalDepense_03_10 = 0;
            decimal SoldeFinal_03_10 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année03 Mois11
            decimal SoldeInitial_03_11 = 0;
            decimal ApportSupplementaire_03_11 = 0;
            decimal CMT_03_11 = 0;
            decimal PNRClassique_03_11 = 0;
            decimal ApportPersonnel_03_11 = 0;
            decimal PNRLoyer_03_11 = 0;
            decimal EncaissementRecusClients_03_11 = 0;
            decimal TotalRecette_03_11 = 0;
            decimal AcquisitionEquipementAmenagement_03_11 = 0;
            decimal DecaissementFournisseurs_03_11 = 0;
            decimal DecaissementPrestataires_03_11 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_03_11 = 0;
            decimal DecaissementSalairesNets_03_11 = 0;
            decimal CotisationsSociales_03_11 = 0;
            decimal IRGSalaires_03_11 = 0;
            decimal TVAPayer_03_11 = 0;
            decimal IBS_IFU_03_11 = 0;
            decimal TotalDepense_03_11 = 0;
            decimal SoldeFinal_03_11 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année03 Mois12
            decimal SoldeInitial_03_12 = 0;
            decimal ApportSupplementaire_03_12 = 0;
            decimal CMT_03_12 = 0;
            decimal PNRClassique_03_12 = 0;
            decimal ApportPersonnel_03_12 = 0;
            decimal PNRLoyer_03_12 = 0;
            decimal EncaissementRecusClients_03_12 = 0;
            decimal TotalRecette_03_12 = 0;
            decimal AcquisitionEquipementAmenagement_03_12 = 0;
            decimal DecaissementFournisseurs_03_12 = 0;
            decimal DecaissementPrestataires_03_12 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_03_12 = 0;
            decimal DecaissementSalairesNets_03_12 = 0;
            decimal CotisationsSociales_03_12 = 0;
            decimal IRGSalaires_03_12 = 0;
            decimal TVAPayer_03_12 = 0;
            decimal IBS_IFU_03_12 = 0;
            decimal TotalDepense_03_12 = 0;
            decimal SoldeFinal_03_12 = 0;
            #endregion

            #endregion

            #region Données EtatPlanTresorerie Année04

            #region Données EtatPlanTresorerie Année04 Mois01
            decimal SoldeInitial_04_01 = 0;
            decimal ApportSupplementaire_04_01 = 0;
            decimal CMT_04_01 = 0;
            decimal PNRClassique_04_01 = 0;
            decimal ApportPersonnel_04_01 = 0;
            decimal PNRLoyer_04_01 = 0;
            decimal EncaissementRecusClients_04_01 = 0;
            decimal TotalRecette_04_01 = 0;
            decimal AcquisitionEquipementAmenagement_04_01 = 0;
            decimal DecaissementFournisseurs_04_01 = 0;
            decimal DecaissementPrestataires_04_01 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_04_01 = 0;
            decimal DecaissementSalairesNets_04_01 = 0;
            decimal CotisationsSociales_04_01 = 0;
            decimal IRGSalaires_04_01 = 0;
            decimal TVAPayer_04_01 = 0;
            decimal IBS_IFU_04_01 = 0;
            decimal TotalDepense_04_01 = 0;
            decimal SoldeFinal_04_01 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année04 Mois02
            decimal SoldeInitial_04_02 = 0;
            decimal ApportSupplementaire_04_02 = 0;
            decimal CMT_04_02 = 0;
            decimal PNRClassique_04_02 = 0;
            decimal ApportPersonnel_04_02 = 0;
            decimal PNRLoyer_04_02 = 0;
            decimal EncaissementRecusClients_04_02 = 0;
            decimal TotalRecette_04_02 = 0;
            decimal AcquisitionEquipementAmenagement_04_02 = 0;
            decimal DecaissementFournisseurs_04_02 = 0;
            decimal DecaissementPrestataires_04_02 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_04_02 = 0;
            decimal DecaissementSalairesNets_04_02 = 0;
            decimal CotisationsSociales_04_02 = 0;
            decimal IRGSalaires_04_02 = 0;
            decimal TVAPayer_04_02 = 0;
            decimal IBS_IFU_04_02 = 0;
            decimal TotalDepense_04_02 = 0;
            decimal SoldeFinal_04_02 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année04 Mois03
            decimal SoldeInitial_04_03 = 0;
            decimal ApportSupplementaire_04_03 = 0;
            decimal CMT_04_03 = 0;
            decimal PNRClassique_04_03 = 0;
            decimal ApportPersonnel_04_03 = 0;
            decimal PNRLoyer_04_03 = 0;
            decimal EncaissementRecusClients_04_03 = 0;
            decimal TotalRecette_04_03 = 0;
            decimal AcquisitionEquipementAmenagement_04_03 = 0;
            decimal DecaissementFournisseurs_04_03 = 0;
            decimal DecaissementPrestataires_04_03 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_04_03 = 0;
            decimal DecaissementSalairesNets_04_03 = 0;
            decimal CotisationsSociales_04_03 = 0;
            decimal IRGSalaires_04_03 = 0;
            decimal TVAPayer_04_03 = 0;
            decimal IBS_IFU_04_03 = 0;
            decimal TotalDepense_04_03 = 0;
            decimal SoldeFinal_04_03 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année04 Mois04
            decimal SoldeInitial_04_04 = 0;
            decimal ApportSupplementaire_04_04 = 0;
            decimal CMT_04_04 = 0;
            decimal PNRClassique_04_04 = 0;
            decimal ApportPersonnel_04_04 = 0;
            decimal PNRLoyer_04_04 = 0;
            decimal EncaissementRecusClients_04_04 = 0;
            decimal TotalRecette_04_04 = 0;
            decimal AcquisitionEquipementAmenagement_04_04 = 0;
            decimal DecaissementFournisseurs_04_04 = 0;
            decimal DecaissementPrestataires_04_04 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_04_04 = 0;
            decimal DecaissementSalairesNets_04_04 = 0;
            decimal CotisationsSociales_04_04 = 0;
            decimal IRGSalaires_04_04 = 0;
            decimal TVAPayer_04_04 = 0;
            decimal IBS_IFU_04_04 = 0;
            decimal TotalDepense_04_04 = 0;
            decimal SoldeFinal_04_04 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année04 Mois05
            decimal SoldeInitial_04_05 = 0;
            decimal ApportSupplementaire_04_05 = 0;
            decimal CMT_04_05 = 0;
            decimal PNRClassique_04_05 = 0;
            decimal ApportPersonnel_04_05 = 0;
            decimal PNRLoyer_04_05 = 0;
            decimal EncaissementRecusClients_04_05 = 0;
            decimal TotalRecette_04_05 = 0;
            decimal AcquisitionEquipementAmenagement_04_05 = 0;
            decimal DecaissementFournisseurs_04_05 = 0;
            decimal DecaissementPrestataires_04_05 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_04_05 = 0;
            decimal DecaissementSalairesNets_04_05 = 0;
            decimal CotisationsSociales_04_05 = 0;
            decimal IRGSalaires_04_05 = 0;
            decimal TVAPayer_04_05 = 0;
            decimal IBS_IFU_04_05 = 0;
            decimal TotalDepense_04_05 = 0;
            decimal SoldeFinal_04_05 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année04 Mois06
            decimal SoldeInitial_04_06 = 0;
            decimal ApportSupplementaire_04_06 = 0;
            decimal CMT_04_06 = 0;
            decimal PNRClassique_04_06 = 0;
            decimal ApportPersonnel_04_06 = 0;
            decimal PNRLoyer_04_06 = 0;
            decimal EncaissementRecusClients_04_06 = 0;
            decimal TotalRecette_04_06 = 0;
            decimal AcquisitionEquipementAmenagement_04_06 = 0;
            decimal DecaissementFournisseurs_04_06 = 0;
            decimal DecaissementPrestataires_04_06 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_04_06 = 0;
            decimal DecaissementSalairesNets_04_06 = 0;
            decimal CotisationsSociales_04_06 = 0;
            decimal IRGSalaires_04_06 = 0;
            decimal TVAPayer_04_06 = 0;
            decimal IBS_IFU_04_06 = 0;
            decimal TotalDepense_04_06 = 0;
            decimal SoldeFinal_04_06 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année04 Mois07
            decimal SoldeInitial_04_07 = 0;
            decimal ApportSupplementaire_04_07 = 0;
            decimal CMT_04_07 = 0;
            decimal PNRClassique_04_07 = 0;
            decimal ApportPersonnel_04_07 = 0;
            decimal PNRLoyer_04_07 = 0;
            decimal EncaissementRecusClients_04_07 = 0;
            decimal TotalRecette_04_07 = 0;
            decimal AcquisitionEquipementAmenagement_04_07 = 0;
            decimal DecaissementFournisseurs_04_07 = 0;
            decimal DecaissementPrestataires_04_07 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_04_07 = 0;
            decimal DecaissementSalairesNets_04_07 = 0;
            decimal CotisationsSociales_04_07 = 0;
            decimal IRGSalaires_04_07 = 0;
            decimal TVAPayer_04_07 = 0;
            decimal IBS_IFU_04_07 = 0;
            decimal TotalDepense_04_07 = 0;
            decimal SoldeFinal_04_07 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année04 Mois08
            decimal SoldeInitial_04_08 = 0;
            decimal ApportSupplementaire_04_08 = 0;
            decimal CMT_04_08 = 0;
            decimal PNRClassique_04_08 = 0;
            decimal ApportPersonnel_04_08 = 0;
            decimal PNRLoyer_04_08 = 0;
            decimal EncaissementRecusClients_04_08 = 0;
            decimal TotalRecette_04_08 = 0;
            decimal AcquisitionEquipementAmenagement_04_08 = 0;
            decimal DecaissementFournisseurs_04_08 = 0;
            decimal DecaissementPrestataires_04_08 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_04_08 = 0;
            decimal DecaissementSalairesNets_04_08 = 0;
            decimal CotisationsSociales_04_08 = 0;
            decimal IRGSalaires_04_08 = 0;
            decimal TVAPayer_04_08 = 0;
            decimal IBS_IFU_04_08 = 0;
            decimal TotalDepense_04_08 = 0;
            decimal SoldeFinal_04_08 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année04 Mois09
            decimal SoldeInitial_04_09 = 0;
            decimal ApportSupplementaire_04_09 = 0;
            decimal CMT_04_09 = 0;
            decimal PNRClassique_04_09 = 0;
            decimal ApportPersonnel_04_09 = 0;
            decimal PNRLoyer_04_09 = 0;
            decimal EncaissementRecusClients_04_09 = 0;
            decimal TotalRecette_04_09 = 0;
            decimal AcquisitionEquipementAmenagement_04_09 = 0;
            decimal DecaissementFournisseurs_04_09 = 0;
            decimal DecaissementPrestataires_04_09 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_04_09 = 0;
            decimal DecaissementSalairesNets_04_09 = 0;
            decimal CotisationsSociales_04_09 = 0;
            decimal IRGSalaires_04_09 = 0;
            decimal TVAPayer_04_09 = 0;
            decimal IBS_IFU_04_09 = 0;
            decimal TotalDepense_04_09 = 0;
            decimal SoldeFinal_04_09 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année04 Mois10
            decimal SoldeInitial_04_10 = 0;
            decimal ApportSupplementaire_04_10 = 0;
            decimal CMT_04_10 = 0;
            decimal PNRClassique_04_10 = 0;
            decimal ApportPersonnel_04_10 = 0;
            decimal PNRLoyer_04_10 = 0;
            decimal EncaissementRecusClients_04_10 = 0;
            decimal TotalRecette_04_10 = 0;
            decimal AcquisitionEquipementAmenagement_04_10 = 0;
            decimal DecaissementFournisseurs_04_10 = 0;
            decimal DecaissementPrestataires_04_10 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_04_10 = 0;
            decimal DecaissementSalairesNets_04_10 = 0;
            decimal CotisationsSociales_04_10 = 0;
            decimal IRGSalaires_04_10 = 0;
            decimal TVAPayer_04_10 = 0;
            decimal IBS_IFU_04_10 = 0;
            decimal TotalDepense_04_10 = 0;
            decimal SoldeFinal_04_10 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année04 Mois11
            decimal SoldeInitial_04_11 = 0;
            decimal ApportSupplementaire_04_11 = 0;
            decimal CMT_04_11 = 0;
            decimal PNRClassique_04_11 = 0;
            decimal ApportPersonnel_04_11 = 0;
            decimal PNRLoyer_04_11 = 0;
            decimal EncaissementRecusClients_04_11 = 0;
            decimal TotalRecette_04_11 = 0;
            decimal AcquisitionEquipementAmenagement_04_11 = 0;
            decimal DecaissementFournisseurs_04_11 = 0;
            decimal DecaissementPrestataires_04_11 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_04_11 = 0;
            decimal DecaissementSalairesNets_04_11 = 0;
            decimal CotisationsSociales_04_11 = 0;
            decimal IRGSalaires_04_11 = 0;
            decimal TVAPayer_04_11 = 0;
            decimal IBS_IFU_04_11 = 0;
            decimal TotalDepense_04_11 = 0;
            decimal SoldeFinal_04_11 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année04 Mois12
            decimal SoldeInitial_04_12 = 0;
            decimal ApportSupplementaire_04_12 = 0;
            decimal CMT_04_12 = 0;
            decimal PNRClassique_04_12 = 0;
            decimal ApportPersonnel_04_12 = 0;
            decimal PNRLoyer_04_12 = 0;
            decimal EncaissementRecusClients_04_12 = 0;
            decimal TotalRecette_04_12 = 0;
            decimal AcquisitionEquipementAmenagement_04_12 = 0;
            decimal DecaissementFournisseurs_04_12 = 0;
            decimal DecaissementPrestataires_04_12 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_04_12 = 0;
            decimal DecaissementSalairesNets_04_12 = 0;
            decimal CotisationsSociales_04_12 = 0;
            decimal IRGSalaires_04_12 = 0;
            decimal TVAPayer_04_12 = 0;
            decimal IBS_IFU_04_12 = 0;
            decimal TotalDepense_04_12 = 0;
            decimal SoldeFinal_04_12 = 0;
            #endregion

            #endregion

            #region Données EtatPlanTresorerie Année05

            #region Données EtatPlanTresorerie Année05 Mois01
            decimal SoldeInitial_05_01 = 0;
            decimal ApportSupplementaire_05_01 = 0;
            decimal CMT_05_01 = 0;
            decimal PNRClassique_05_01 = 0;
            decimal ApportPersonnel_05_01 = 0;
            decimal PNRLoyer_05_01 = 0;
            decimal EncaissementRecusClients_05_01 = 0;
            decimal TotalRecette_05_01 = 0;
            decimal AcquisitionEquipementAmenagement_05_01 = 0;
            decimal DecaissementFournisseurs_05_01 = 0;
            decimal DecaissementPrestataires_05_01 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_05_01 = 0;
            decimal DecaissementSalairesNets_05_01 = 0;
            decimal CotisationsSociales_05_01 = 0;
            decimal IRGSalaires_05_01 = 0;
            decimal TVAPayer_05_01 = 0;
            decimal IBS_IFU_05_01 = 0;
            decimal TotalDepense_05_01 = 0;
            decimal SoldeFinal_05_01 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année05 Mois02
            decimal SoldeInitial_05_02 = 0;
            decimal ApportSupplementaire_05_02 = 0;
            decimal CMT_05_02 = 0;
            decimal PNRClassique_05_02 = 0;
            decimal ApportPersonnel_05_02 = 0;
            decimal PNRLoyer_05_02 = 0;
            decimal EncaissementRecusClients_05_02 = 0;
            decimal TotalRecette_05_02 = 0;
            decimal AcquisitionEquipementAmenagement_05_02 = 0;
            decimal DecaissementFournisseurs_05_02 = 0;
            decimal DecaissementPrestataires_05_02 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_05_02 = 0;
            decimal DecaissementSalairesNets_05_02 = 0;
            decimal CotisationsSociales_05_02 = 0;
            decimal IRGSalaires_05_02 = 0;
            decimal TVAPayer_05_02 = 0;
            decimal IBS_IFU_05_02 = 0;
            decimal TotalDepense_05_02 = 0;
            decimal SoldeFinal_05_02 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année05 Mois03
            decimal SoldeInitial_05_03 = 0;
            decimal ApportSupplementaire_05_03 = 0;
            decimal CMT_05_03 = 0;
            decimal PNRClassique_05_03 = 0;
            decimal ApportPersonnel_05_03 = 0;
            decimal PNRLoyer_05_03 = 0;
            decimal EncaissementRecusClients_05_03 = 0;
            decimal TotalRecette_05_03 = 0;
            decimal AcquisitionEquipementAmenagement_05_03 = 0;
            decimal DecaissementFournisseurs_05_03 = 0;
            decimal DecaissementPrestataires_05_03 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_05_03 = 0;
            decimal DecaissementSalairesNets_05_03 = 0;
            decimal CotisationsSociales_05_03 = 0;
            decimal IRGSalaires_05_03 = 0;
            decimal TVAPayer_05_03 = 0;
            decimal IBS_IFU_05_03 = 0;
            decimal TotalDepense_05_03 = 0;
            decimal SoldeFinal_05_03 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année05 Mois04
            decimal SoldeInitial_05_04 = 0;
            decimal ApportSupplementaire_05_04 = 0;
            decimal CMT_05_04 = 0;
            decimal PNRClassique_05_04 = 0;
            decimal ApportPersonnel_05_04 = 0;
            decimal PNRLoyer_05_04 = 0;
            decimal EncaissementRecusClients_05_04 = 0;
            decimal TotalRecette_05_04 = 0;
            decimal AcquisitionEquipementAmenagement_05_04 = 0;
            decimal DecaissementFournisseurs_05_04 = 0;
            decimal DecaissementPrestataires_05_04 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_05_04 = 0;
            decimal DecaissementSalairesNets_05_04 = 0;
            decimal CotisationsSociales_05_04 = 0;
            decimal IRGSalaires_05_04 = 0;
            decimal TVAPayer_05_04 = 0;
            decimal IBS_IFU_05_04 = 0;
            decimal TotalDepense_05_04 = 0;
            decimal SoldeFinal_05_04 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année05 Mois05
            decimal SoldeInitial_05_05 = 0;
            decimal ApportSupplementaire_05_05 = 0;
            decimal CMT_05_05 = 0;
            decimal PNRClassique_05_05 = 0;
            decimal ApportPersonnel_05_05 = 0;
            decimal PNRLoyer_05_05 = 0;
            decimal EncaissementRecusClients_05_05 = 0;
            decimal TotalRecette_05_05 = 0;
            decimal AcquisitionEquipementAmenagement_05_05 = 0;
            decimal DecaissementFournisseurs_05_05 = 0;
            decimal DecaissementPrestataires_05_05 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_05_05 = 0;
            decimal DecaissementSalairesNets_05_05 = 0;
            decimal CotisationsSociales_05_05 = 0;
            decimal IRGSalaires_05_05 = 0;
            decimal TVAPayer_05_05 = 0;
            decimal IBS_IFU_05_05 = 0;
            decimal TotalDepense_05_05 = 0;
            decimal SoldeFinal_05_05 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année05 Mois06
            decimal SoldeInitial_05_06 = 0;
            decimal ApportSupplementaire_05_06 = 0;
            decimal CMT_05_06 = 0;
            decimal PNRClassique_05_06 = 0;
            decimal ApportPersonnel_05_06 = 0;
            decimal PNRLoyer_05_06 = 0;
            decimal EncaissementRecusClients_05_06 = 0;
            decimal TotalRecette_05_06 = 0;
            decimal AcquisitionEquipementAmenagement_05_06 = 0;
            decimal DecaissementFournisseurs_05_06 = 0;
            decimal DecaissementPrestataires_05_06 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_05_06 = 0;
            decimal DecaissementSalairesNets_05_06 = 0;
            decimal CotisationsSociales_05_06 = 0;
            decimal IRGSalaires_05_06 = 0;
            decimal TVAPayer_05_06 = 0;
            decimal IBS_IFU_05_06 = 0;
            decimal TotalDepense_05_06 = 0;
            decimal SoldeFinal_05_06 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année05 Mois07
            decimal SoldeInitial_05_07 = 0;
            decimal ApportSupplementaire_05_07 = 0;
            decimal CMT_05_07 = 0;
            decimal PNRClassique_05_07 = 0;
            decimal ApportPersonnel_05_07 = 0;
            decimal PNRLoyer_05_07 = 0;
            decimal EncaissementRecusClients_05_07 = 0;
            decimal TotalRecette_05_07 = 0;
            decimal AcquisitionEquipementAmenagement_05_07 = 0;
            decimal DecaissementFournisseurs_05_07 = 0;
            decimal DecaissementPrestataires_05_07 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_05_07 = 0;
            decimal DecaissementSalairesNets_05_07 = 0;
            decimal CotisationsSociales_05_07 = 0;
            decimal IRGSalaires_05_07 = 0;
            decimal TVAPayer_05_07 = 0;
            decimal IBS_IFU_05_07 = 0;
            decimal TotalDepense_05_07 = 0;
            decimal SoldeFinal_05_07 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année05 Mois08
            decimal SoldeInitial_05_08 = 0;
            decimal ApportSupplementaire_05_08 = 0;
            decimal CMT_05_08 = 0;
            decimal PNRClassique_05_08 = 0;
            decimal ApportPersonnel_05_08 = 0;
            decimal PNRLoyer_05_08 = 0;
            decimal EncaissementRecusClients_05_08 = 0;
            decimal TotalRecette_05_08 = 0;
            decimal AcquisitionEquipementAmenagement_05_08 = 0;
            decimal DecaissementFournisseurs_05_08 = 0;
            decimal DecaissementPrestataires_05_08 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_05_08 = 0;
            decimal DecaissementSalairesNets_05_08 = 0;
            decimal CotisationsSociales_05_08 = 0;
            decimal IRGSalaires_05_08 = 0;
            decimal TVAPayer_05_08 = 0;
            decimal IBS_IFU_05_08 = 0;
            decimal TotalDepense_05_08 = 0;
            decimal SoldeFinal_05_08 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année05 Mois09
            decimal SoldeInitial_05_09 = 0;
            decimal ApportSupplementaire_05_09 = 0;
            decimal CMT_05_09 = 0;
            decimal PNRClassique_05_09 = 0;
            decimal ApportPersonnel_05_09 = 0;
            decimal PNRLoyer_05_09 = 0;
            decimal EncaissementRecusClients_05_09 = 0;
            decimal TotalRecette_05_09 = 0;
            decimal AcquisitionEquipementAmenagement_05_09 = 0;
            decimal DecaissementFournisseurs_05_09 = 0;
            decimal DecaissementPrestataires_05_09 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_05_09 = 0;
            decimal DecaissementSalairesNets_05_09 = 0;
            decimal CotisationsSociales_05_09 = 0;
            decimal IRGSalaires_05_09 = 0;
            decimal TVAPayer_05_09 = 0;
            decimal IBS_IFU_05_09 = 0;
            decimal TotalDepense_05_09 = 0;
            decimal SoldeFinal_05_09 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année05 Mois10
            decimal SoldeInitial_05_10 = 0;
            decimal ApportSupplementaire_05_10 = 0;
            decimal CMT_05_10 = 0;
            decimal PNRClassique_05_10 = 0;
            decimal ApportPersonnel_05_10 = 0;
            decimal PNRLoyer_05_10 = 0;
            decimal EncaissementRecusClients_05_10 = 0;
            decimal TotalRecette_05_10 = 0;
            decimal AcquisitionEquipementAmenagement_05_10 = 0;
            decimal DecaissementFournisseurs_05_10 = 0;
            decimal DecaissementPrestataires_05_10 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_05_10 = 0;
            decimal DecaissementSalairesNets_05_10 = 0;
            decimal CotisationsSociales_05_10 = 0;
            decimal IRGSalaires_05_10 = 0;
            decimal TVAPayer_05_10 = 0;
            decimal IBS_IFU_05_10 = 0;
            decimal TotalDepense_05_10 = 0;
            decimal SoldeFinal_05_10 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année05 Mois11
            decimal SoldeInitial_05_11 = 0;
            decimal ApportSupplementaire_05_11 = 0;
            decimal CMT_05_11 = 0;
            decimal PNRClassique_05_11 = 0;
            decimal ApportPersonnel_05_11 = 0;
            decimal PNRLoyer_05_11 = 0;
            decimal EncaissementRecusClients_05_11 = 0;
            decimal TotalRecette_05_11 = 0;
            decimal AcquisitionEquipementAmenagement_05_11 = 0;
            decimal DecaissementFournisseurs_05_11 = 0;
            decimal DecaissementPrestataires_05_11 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_05_11 = 0;
            decimal DecaissementSalairesNets_05_11 = 0;
            decimal CotisationsSociales_05_11 = 0;
            decimal IRGSalaires_05_11 = 0;
            decimal TVAPayer_05_11 = 0;
            decimal IBS_IFU_05_11 = 0;
            decimal TotalDepense_05_11 = 0;
            decimal SoldeFinal_05_11 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année05 Mois12
            decimal SoldeInitial_05_12 = 0;
            decimal ApportSupplementaire_05_12 = 0;
            decimal CMT_05_12 = 0;
            decimal PNRClassique_05_12 = 0;
            decimal ApportPersonnel_05_12 = 0;
            decimal PNRLoyer_05_12 = 0;
            decimal EncaissementRecusClients_05_12 = 0;
            decimal TotalRecette_05_12 = 0;
            decimal AcquisitionEquipementAmenagement_05_12 = 0;
            decimal DecaissementFournisseurs_05_12 = 0;
            decimal DecaissementPrestataires_05_12 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_05_12 = 0;
            decimal DecaissementSalairesNets_05_12 = 0;
            decimal CotisationsSociales_05_12 = 0;
            decimal IRGSalaires_05_12 = 0;
            decimal TVAPayer_05_12 = 0;
            decimal IBS_IFU_05_12 = 0;
            decimal TotalDepense_05_12 = 0;
            decimal SoldeFinal_05_12 = 0;
            #endregion

            #endregion

            #region Données EtatPlanTresorerie Année06

            #region Données EtatPlanTresorerie Année06 Mois01
            decimal SoldeInitial_06_01 = 0;
            decimal ApportSupplementaire_06_01 = 0;
            decimal CMT_06_01 = 0;
            decimal PNRClassique_06_01 = 0;
            decimal ApportPersonnel_06_01 = 0;
            decimal PNRLoyer_06_01 = 0;
            decimal EncaissementRecusClients_06_01 = 0;
            decimal TotalRecette_06_01 = 0;
            decimal AcquisitionEquipementAmenagement_06_01 = 0;
            decimal DecaissementFournisseurs_06_01 = 0;
            decimal DecaissementPrestataires_06_01 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_06_01 = 0;
            decimal DecaissementSalairesNets_06_01 = 0;
            decimal CotisationsSociales_06_01 = 0;
            decimal IRGSalaires_06_01 = 0;
            decimal TVAPayer_06_01 = 0;
            decimal IBS_IFU_06_01 = 0;
            decimal TotalDepense_06_01 = 0;
            decimal SoldeFinal_06_01 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année06 Mois02
            decimal SoldeInitial_06_02 = 0;
            decimal ApportSupplementaire_06_02 = 0;
            decimal CMT_06_02 = 0;
            decimal PNRClassique_06_02 = 0;
            decimal ApportPersonnel_06_02 = 0;
            decimal PNRLoyer_06_02 = 0;
            decimal EncaissementRecusClients_06_02 = 0;
            decimal TotalRecette_06_02 = 0;
            decimal AcquisitionEquipementAmenagement_06_02 = 0;
            decimal DecaissementFournisseurs_06_02 = 0;
            decimal DecaissementPrestataires_06_02 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_06_02 = 0;
            decimal DecaissementSalairesNets_06_02 = 0;
            decimal CotisationsSociales_06_02 = 0;
            decimal IRGSalaires_06_02 = 0;
            decimal TVAPayer_06_02 = 0;
            decimal IBS_IFU_06_02 = 0;
            decimal TotalDepense_06_02 = 0;
            decimal SoldeFinal_06_02 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année06 Mois03
            decimal SoldeInitial_06_03 = 0;
            decimal ApportSupplementaire_06_03 = 0;
            decimal CMT_06_03 = 0;
            decimal PNRClassique_06_03 = 0;
            decimal ApportPersonnel_06_03 = 0;
            decimal PNRLoyer_06_03 = 0;
            decimal EncaissementRecusClients_06_03 = 0;
            decimal TotalRecette_06_03 = 0;
            decimal AcquisitionEquipementAmenagement_06_03 = 0;
            decimal DecaissementFournisseurs_06_03 = 0;
            decimal DecaissementPrestataires_06_03 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_06_03 = 0;
            decimal DecaissementSalairesNets_06_03 = 0;
            decimal CotisationsSociales_06_03 = 0;
            decimal IRGSalaires_06_03 = 0;
            decimal TVAPayer_06_03 = 0;
            decimal IBS_IFU_06_03 = 0;
            decimal TotalDepense_06_03 = 0;
            decimal SoldeFinal_06_03 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année06 Mois04
            decimal SoldeInitial_06_04 = 0;
            decimal ApportSupplementaire_06_04 = 0;
            decimal CMT_06_04 = 0;
            decimal PNRClassique_06_04 = 0;
            decimal ApportPersonnel_06_04 = 0;
            decimal PNRLoyer_06_04 = 0;
            decimal EncaissementRecusClients_06_04 = 0;
            decimal TotalRecette_06_04 = 0;
            decimal AcquisitionEquipementAmenagement_06_04 = 0;
            decimal DecaissementFournisseurs_06_04 = 0;
            decimal DecaissementPrestataires_06_04 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_06_04 = 0;
            decimal DecaissementSalairesNets_06_04 = 0;
            decimal CotisationsSociales_06_04 = 0;
            decimal IRGSalaires_06_04 = 0;
            decimal TVAPayer_06_04 = 0;
            decimal IBS_IFU_06_04 = 0;
            decimal TotalDepense_06_04 = 0;
            decimal SoldeFinal_06_04 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année06 Mois05
            decimal SoldeInitial_06_05 = 0;
            decimal ApportSupplementaire_06_05 = 0;
            decimal CMT_06_05 = 0;
            decimal PNRClassique_06_05 = 0;
            decimal ApportPersonnel_06_05 = 0;
            decimal PNRLoyer_06_05 = 0;
            decimal EncaissementRecusClients_06_05 = 0;
            decimal TotalRecette_06_05 = 0;
            decimal AcquisitionEquipementAmenagement_06_05 = 0;
            decimal DecaissementFournisseurs_06_05 = 0;
            decimal DecaissementPrestataires_06_05 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_06_05 = 0;
            decimal DecaissementSalairesNets_06_05 = 0;
            decimal CotisationsSociales_06_05 = 0;
            decimal IRGSalaires_06_05 = 0;
            decimal TVAPayer_06_05 = 0;
            decimal IBS_IFU_06_05 = 0;
            decimal TotalDepense_06_05 = 0;
            decimal SoldeFinal_06_05 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année06 Mois06
            decimal SoldeInitial_06_06 = 0;
            decimal ApportSupplementaire_06_06 = 0;
            decimal CMT_06_06 = 0;
            decimal PNRClassique_06_06 = 0;
            decimal ApportPersonnel_06_06 = 0;
            decimal PNRLoyer_06_06 = 0;
            decimal EncaissementRecusClients_06_06 = 0;
            decimal TotalRecette_06_06 = 0;
            decimal AcquisitionEquipementAmenagement_06_06 = 0;
            decimal DecaissementFournisseurs_06_06 = 0;
            decimal DecaissementPrestataires_06_06 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_06_06 = 0;
            decimal DecaissementSalairesNets_06_06 = 0;
            decimal CotisationsSociales_06_06 = 0;
            decimal IRGSalaires_06_06 = 0;
            decimal TVAPayer_06_06 = 0;
            decimal IBS_IFU_06_06 = 0;
            decimal TotalDepense_06_06 = 0;
            decimal SoldeFinal_06_06 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année06 Mois07
            decimal SoldeInitial_06_07 = 0;
            decimal ApportSupplementaire_06_07 = 0;
            decimal CMT_06_07 = 0;
            decimal PNRClassique_06_07 = 0;
            decimal ApportPersonnel_06_07 = 0;
            decimal PNRLoyer_06_07 = 0;
            decimal EncaissementRecusClients_06_07 = 0;
            decimal TotalRecette_06_07 = 0;
            decimal AcquisitionEquipementAmenagement_06_07 = 0;
            decimal DecaissementFournisseurs_06_07 = 0;
            decimal DecaissementPrestataires_06_07 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_06_07 = 0;
            decimal DecaissementSalairesNets_06_07 = 0;
            decimal CotisationsSociales_06_07 = 0;
            decimal IRGSalaires_06_07 = 0;
            decimal TVAPayer_06_07 = 0;
            decimal IBS_IFU_06_07 = 0;
            decimal TotalDepense_06_07 = 0;
            decimal SoldeFinal_06_07 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année06 Mois08
            decimal SoldeInitial_06_08 = 0;
            decimal ApportSupplementaire_06_08 = 0;
            decimal CMT_06_08 = 0;
            decimal PNRClassique_06_08 = 0;
            decimal ApportPersonnel_06_08 = 0;
            decimal PNRLoyer_06_08 = 0;
            decimal EncaissementRecusClients_06_08 = 0;
            decimal TotalRecette_06_08 = 0;
            decimal AcquisitionEquipementAmenagement_06_08 = 0;
            decimal DecaissementFournisseurs_06_08 = 0;
            decimal DecaissementPrestataires_06_08 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_06_08 = 0;
            decimal DecaissementSalairesNets_06_08 = 0;
            decimal CotisationsSociales_06_08 = 0;
            decimal IRGSalaires_06_08 = 0;
            decimal TVAPayer_06_08 = 0;
            decimal IBS_IFU_06_08 = 0;
            decimal TotalDepense_06_08 = 0;
            decimal SoldeFinal_06_08 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année06 Mois09
            decimal SoldeInitial_06_09 = 0;
            decimal ApportSupplementaire_06_09 = 0;
            decimal CMT_06_09 = 0;
            decimal PNRClassique_06_09 = 0;
            decimal ApportPersonnel_06_09 = 0;
            decimal PNRLoyer_06_09 = 0;
            decimal EncaissementRecusClients_06_09 = 0;
            decimal TotalRecette_06_09 = 0;
            decimal AcquisitionEquipementAmenagement_06_09 = 0;
            decimal DecaissementFournisseurs_06_09 = 0;
            decimal DecaissementPrestataires_06_09 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_06_09 = 0;
            decimal DecaissementSalairesNets_06_09 = 0;
            decimal CotisationsSociales_06_09 = 0;
            decimal IRGSalaires_06_09 = 0;
            decimal TVAPayer_06_09 = 0;
            decimal IBS_IFU_06_09 = 0;
            decimal TotalDepense_06_09 = 0;
            decimal SoldeFinal_06_09 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année06 Mois10
            decimal SoldeInitial_06_10 = 0;
            decimal ApportSupplementaire_06_10 = 0;
            decimal CMT_06_10 = 0;
            decimal PNRClassique_06_10 = 0;
            decimal ApportPersonnel_06_10 = 0;
            decimal PNRLoyer_06_10 = 0;
            decimal EncaissementRecusClients_06_10 = 0;
            decimal TotalRecette_06_10 = 0;
            decimal AcquisitionEquipementAmenagement_06_10 = 0;
            decimal DecaissementFournisseurs_06_10 = 0;
            decimal DecaissementPrestataires_06_10 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_06_10 = 0;
            decimal DecaissementSalairesNets_06_10 = 0;
            decimal CotisationsSociales_06_10 = 0;
            decimal IRGSalaires_06_10 = 0;
            decimal TVAPayer_06_10 = 0;
            decimal IBS_IFU_06_10 = 0;
            decimal TotalDepense_06_10 = 0;
            decimal SoldeFinal_06_10 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année06 Mois11
            decimal SoldeInitial_06_11 = 0;
            decimal ApportSupplementaire_06_11 = 0;
            decimal CMT_06_11 = 0;
            decimal PNRClassique_06_11 = 0;
            decimal ApportPersonnel_06_11 = 0;
            decimal PNRLoyer_06_11 = 0;
            decimal EncaissementRecusClients_06_11 = 0;
            decimal TotalRecette_06_11 = 0;
            decimal AcquisitionEquipementAmenagement_06_11 = 0;
            decimal DecaissementFournisseurs_06_11 = 0;
            decimal DecaissementPrestataires_06_11 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_06_11 = 0;
            decimal DecaissementSalairesNets_06_11 = 0;
            decimal CotisationsSociales_06_11 = 0;
            decimal IRGSalaires_06_11 = 0;
            decimal TVAPayer_06_11 = 0;
            decimal IBS_IFU_06_11 = 0;
            decimal TotalDepense_06_11 = 0;
            decimal SoldeFinal_06_11 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année06 Mois12
            decimal SoldeInitial_06_12 = 0;
            decimal ApportSupplementaire_06_12 = 0;
            decimal CMT_06_12 = 0;
            decimal PNRClassique_06_12 = 0;
            decimal ApportPersonnel_06_12 = 0;
            decimal PNRLoyer_06_12 = 0;
            decimal EncaissementRecusClients_06_12 = 0;
            decimal TotalRecette_06_12 = 0;
            decimal AcquisitionEquipementAmenagement_06_12 = 0;
            decimal DecaissementFournisseurs_06_12 = 0;
            decimal DecaissementPrestataires_06_12 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_06_12 = 0;
            decimal DecaissementSalairesNets_06_12 = 0;
            decimal CotisationsSociales_06_12 = 0;
            decimal IRGSalaires_06_12 = 0;
            decimal TVAPayer_06_12 = 0;
            decimal IBS_IFU_06_12 = 0;
            decimal TotalDepense_06_12 = 0;
            decimal SoldeFinal_06_12 = 0;
            #endregion

            #endregion

            #region Données EtatPlanTresorerie Année07

            #region Données EtatPlanTresorerie Année07 Mois01
            decimal SoldeInitial_07_01 = 0;
            decimal ApportSupplementaire_07_01 = 0;
            decimal CMT_07_01 = 0;
            decimal PNRClassique_07_01 = 0;
            decimal ApportPersonnel_07_01 = 0;
            decimal PNRLoyer_07_01 = 0;
            decimal EncaissementRecusClients_07_01 = 0;
            decimal TotalRecette_07_01 = 0;
            decimal AcquisitionEquipementAmenagement_07_01 = 0;
            decimal DecaissementFournisseurs_07_01 = 0;
            decimal DecaissementPrestataires_07_01 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_07_01 = 0;
            decimal DecaissementSalairesNets_07_01 = 0;
            decimal CotisationsSociales_07_01 = 0;
            decimal IRGSalaires_07_01 = 0;
            decimal TVAPayer_07_01 = 0;
            decimal IBS_IFU_07_01 = 0;
            decimal TotalDepense_07_01 = 0;
            decimal SoldeFinal_07_01 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année07 Mois02
            decimal SoldeInitial_07_02 = 0;
            decimal ApportSupplementaire_07_02 = 0;
            decimal CMT_07_02 = 0;
            decimal PNRClassique_07_02 = 0;
            decimal ApportPersonnel_07_02 = 0;
            decimal PNRLoyer_07_02 = 0;
            decimal EncaissementRecusClients_07_02 = 0;
            decimal TotalRecette_07_02 = 0;
            decimal AcquisitionEquipementAmenagement_07_02 = 0;
            decimal DecaissementFournisseurs_07_02 = 0;
            decimal DecaissementPrestataires_07_02 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_07_02 = 0;
            decimal DecaissementSalairesNets_07_02 = 0;
            decimal CotisationsSociales_07_02 = 0;
            decimal IRGSalaires_07_02 = 0;
            decimal TVAPayer_07_02 = 0;
            decimal IBS_IFU_07_02 = 0;
            decimal TotalDepense_07_02 = 0;
            decimal SoldeFinal_07_02 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année07 Mois03
            decimal SoldeInitial_07_03 = 0;
            decimal ApportSupplementaire_07_03 = 0;
            decimal CMT_07_03 = 0;
            decimal PNRClassique_07_03 = 0;
            decimal ApportPersonnel_07_03 = 0;
            decimal PNRLoyer_07_03 = 0;
            decimal EncaissementRecusClients_07_03 = 0;
            decimal TotalRecette_07_03 = 0;
            decimal AcquisitionEquipementAmenagement_07_03 = 0;
            decimal DecaissementFournisseurs_07_03 = 0;
            decimal DecaissementPrestataires_07_03 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_07_03 = 0;
            decimal DecaissementSalairesNets_07_03 = 0;
            decimal CotisationsSociales_07_03 = 0;
            decimal IRGSalaires_07_03 = 0;
            decimal TVAPayer_07_03 = 0;
            decimal IBS_IFU_07_03 = 0;
            decimal TotalDepense_07_03 = 0;
            decimal SoldeFinal_07_03 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année07 Mois04
            decimal SoldeInitial_07_04 = 0;
            decimal ApportSupplementaire_07_04 = 0;
            decimal CMT_07_04 = 0;
            decimal PNRClassique_07_04 = 0;
            decimal ApportPersonnel_07_04 = 0;
            decimal PNRLoyer_07_04 = 0;
            decimal EncaissementRecusClients_07_04 = 0;
            decimal TotalRecette_07_04 = 0;
            decimal AcquisitionEquipementAmenagement_07_04 = 0;
            decimal DecaissementFournisseurs_07_04 = 0;
            decimal DecaissementPrestataires_07_04 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_07_04 = 0;
            decimal DecaissementSalairesNets_07_04 = 0;
            decimal CotisationsSociales_07_04 = 0;
            decimal IRGSalaires_07_04 = 0;
            decimal TVAPayer_07_04 = 0;
            decimal IBS_IFU_07_04 = 0;
            decimal TotalDepense_07_04 = 0;
            decimal SoldeFinal_07_04 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année07 Mois05
            decimal SoldeInitial_07_05 = 0;
            decimal ApportSupplementaire_07_05 = 0;
            decimal CMT_07_05 = 0;
            decimal PNRClassique_07_05 = 0;
            decimal ApportPersonnel_07_05 = 0;
            decimal PNRLoyer_07_05 = 0;
            decimal EncaissementRecusClients_07_05 = 0;
            decimal TotalRecette_07_05 = 0;
            decimal AcquisitionEquipementAmenagement_07_05 = 0;
            decimal DecaissementFournisseurs_07_05 = 0;
            decimal DecaissementPrestataires_07_05 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_07_05 = 0;
            decimal DecaissementSalairesNets_07_05 = 0;
            decimal CotisationsSociales_07_05 = 0;
            decimal IRGSalaires_07_05 = 0;
            decimal TVAPayer_07_05 = 0;
            decimal IBS_IFU_07_05 = 0;
            decimal TotalDepense_07_05 = 0;
            decimal SoldeFinal_07_05 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année07 Mois06
            decimal SoldeInitial_07_06 = 0;
            decimal ApportSupplementaire_07_06 = 0;
            decimal CMT_07_06 = 0;
            decimal PNRClassique_07_06 = 0;
            decimal ApportPersonnel_07_06 = 0;
            decimal PNRLoyer_07_06 = 0;
            decimal EncaissementRecusClients_07_06 = 0;
            decimal TotalRecette_07_06 = 0;
            decimal AcquisitionEquipementAmenagement_07_06 = 0;
            decimal DecaissementFournisseurs_07_06 = 0;
            decimal DecaissementPrestataires_07_06 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_07_06 = 0;
            decimal DecaissementSalairesNets_07_06 = 0;
            decimal CotisationsSociales_07_06 = 0;
            decimal IRGSalaires_07_06 = 0;
            decimal TVAPayer_07_06 = 0;
            decimal IBS_IFU_07_06 = 0;
            decimal TotalDepense_07_06 = 0;
            decimal SoldeFinal_07_06 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année07 Mois07
            decimal SoldeInitial_07_07 = 0;
            decimal ApportSupplementaire_07_07 = 0;
            decimal CMT_07_07 = 0;
            decimal PNRClassique_07_07 = 0;
            decimal ApportPersonnel_07_07 = 0;
            decimal PNRLoyer_07_07 = 0;
            decimal EncaissementRecusClients_07_07 = 0;
            decimal TotalRecette_07_07 = 0;
            decimal AcquisitionEquipementAmenagement_07_07 = 0;
            decimal DecaissementFournisseurs_07_07 = 0;
            decimal DecaissementPrestataires_07_07 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_07_07 = 0;
            decimal DecaissementSalairesNets_07_07 = 0;
            decimal CotisationsSociales_07_07 = 0;
            decimal IRGSalaires_07_07 = 0;
            decimal TVAPayer_07_07 = 0;
            decimal IBS_IFU_07_07 = 0;
            decimal TotalDepense_07_07 = 0;
            decimal SoldeFinal_07_07 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année07 Mois08
            decimal SoldeInitial_07_08 = 0;
            decimal ApportSupplementaire_07_08 = 0;
            decimal CMT_07_08 = 0;
            decimal PNRClassique_07_08 = 0;
            decimal ApportPersonnel_07_08 = 0;
            decimal PNRLoyer_07_08 = 0;
            decimal EncaissementRecusClients_07_08 = 0;
            decimal TotalRecette_07_08 = 0;
            decimal AcquisitionEquipementAmenagement_07_08 = 0;
            decimal DecaissementFournisseurs_07_08 = 0;
            decimal DecaissementPrestataires_07_08 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_07_08 = 0;
            decimal DecaissementSalairesNets_07_08 = 0;
            decimal CotisationsSociales_07_08 = 0;
            decimal IRGSalaires_07_08 = 0;
            decimal TVAPayer_07_08 = 0;
            decimal IBS_IFU_07_08 = 0;
            decimal TotalDepense_07_08 = 0;
            decimal SoldeFinal_07_08 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année07 Mois09
            decimal SoldeInitial_07_09 = 0;
            decimal ApportSupplementaire_07_09 = 0;
            decimal CMT_07_09 = 0;
            decimal PNRClassique_07_09 = 0;
            decimal ApportPersonnel_07_09 = 0;
            decimal PNRLoyer_07_09 = 0;
            decimal EncaissementRecusClients_07_09 = 0;
            decimal TotalRecette_07_09 = 0;
            decimal AcquisitionEquipementAmenagement_07_09 = 0;
            decimal DecaissementFournisseurs_07_09 = 0;
            decimal DecaissementPrestataires_07_09 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_07_09 = 0;
            decimal DecaissementSalairesNets_07_09 = 0;
            decimal CotisationsSociales_07_09 = 0;
            decimal IRGSalaires_07_09 = 0;
            decimal TVAPayer_07_09 = 0;
            decimal IBS_IFU_07_09 = 0;
            decimal TotalDepense_07_09 = 0;
            decimal SoldeFinal_07_09 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année07 Mois10
            decimal SoldeInitial_07_10 = 0;
            decimal ApportSupplementaire_07_10 = 0;
            decimal CMT_07_10 = 0;
            decimal PNRClassique_07_10 = 0;
            decimal ApportPersonnel_07_10 = 0;
            decimal PNRLoyer_07_10 = 0;
            decimal EncaissementRecusClients_07_10 = 0;
            decimal TotalRecette_07_10 = 0;
            decimal AcquisitionEquipementAmenagement_07_10 = 0;
            decimal DecaissementFournisseurs_07_10 = 0;
            decimal DecaissementPrestataires_07_10 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_07_10 = 0;
            decimal DecaissementSalairesNets_07_10 = 0;
            decimal CotisationsSociales_07_10 = 0;
            decimal IRGSalaires_07_10 = 0;
            decimal TVAPayer_07_10 = 0;
            decimal IBS_IFU_07_10 = 0;
            decimal TotalDepense_07_10 = 0;
            decimal SoldeFinal_07_10 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année07 Mois11
            decimal SoldeInitial_07_11 = 0;
            decimal ApportSupplementaire_07_11 = 0;
            decimal CMT_07_11 = 0;
            decimal PNRClassique_07_11 = 0;
            decimal ApportPersonnel_07_11 = 0;
            decimal PNRLoyer_07_11 = 0;
            decimal EncaissementRecusClients_07_11 = 0;
            decimal TotalRecette_07_11 = 0;
            decimal AcquisitionEquipementAmenagement_07_11 = 0;
            decimal DecaissementFournisseurs_07_11 = 0;
            decimal DecaissementPrestataires_07_11 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_07_11 = 0;
            decimal DecaissementSalairesNets_07_11 = 0;
            decimal CotisationsSociales_07_11 = 0;
            decimal IRGSalaires_07_11 = 0;
            decimal TVAPayer_07_11 = 0;
            decimal IBS_IFU_07_11 = 0;
            decimal TotalDepense_07_11 = 0;
            decimal SoldeFinal_07_11 = 0;
            #endregion

            #region Données EtatPlanTresorerie Année07 Mois12
            decimal SoldeInitial_07_12 = 0;
            decimal ApportSupplementaire_07_12 = 0;
            decimal CMT_07_12 = 0;
            decimal PNRClassique_07_12 = 0;
            decimal ApportPersonnel_07_12 = 0;
            decimal PNRLoyer_07_12 = 0;
            decimal EncaissementRecusClients_07_12 = 0;
            decimal TotalRecette_07_12 = 0;
            decimal AcquisitionEquipementAmenagement_07_12 = 0;
            decimal DecaissementFournisseurs_07_12 = 0;
            decimal DecaissementPrestataires_07_12 = 0;
            decimal PaiementFGAssurancesFraisLieesCreation_07_12 = 0;
            decimal DecaissementSalairesNets_07_12 = 0;
            decimal CotisationsSociales_07_12 = 0;
            decimal IRGSalaires_07_12 = 0;
            decimal TVAPayer_07_12 = 0;
            decimal IBS_IFU_07_12 = 0;
            decimal TotalDepense_07_12 = 0;
            decimal SoldeFinal_07_12 = 0;
            #endregion

            #endregion

            #endregion

            EtatPlanTresorerieModel etatPlanTresorerieModel = new();

            #region Données etatPlanTresorerieModel

            #region Données etatPlanTresorerieModel Année01

            #region Données EtatPlanTresorerie Année01 Mois01

            etatPlanTresorerieModel.SoldeInitial_01_01 = string.Format(frCult, "{0:n}", SoldeInitial_01_01);
            etatPlanTresorerieModel.ApportSupplementaire_01_01 = string.Format(frCult, "{0:n}", ApportSupplementaire_01_01);
            etatPlanTresorerieModel.CMT_01_01 = string.Format(frCult, "{0:n}", CMT_01_01);
            etatPlanTresorerieModel.PNRClassique_01_01 = string.Format(frCult, "{0:n}", PNRClassique_01_01);
            etatPlanTresorerieModel.ApportPersonnel_01_01 = string.Format(frCult, "{0:n}", ApportPersonnel_01_01);
            etatPlanTresorerieModel.PNRLoyer_01_01 = string.Format(frCult, "{0:n}", PNRLoyer_01_01);
            etatPlanTresorerieModel.EncaissementRecusClients_01_01 = string.Format(frCult, "{0:n}", EncaissementRecusClients_01_01);
            etatPlanTresorerieModel.TotalRecette_01_01 = string.Format(frCult, "{0:n}", TotalRecette_01_01);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_01_01 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_01_01);
            etatPlanTresorerieModel.DecaissementFournisseurs_01_01 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_01_01);
            etatPlanTresorerieModel.DecaissementPrestataires_01_01 = string.Format(frCult, "{0:n}", DecaissementPrestataires_01_01);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_01_01 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_01_01);
            etatPlanTresorerieModel.DecaissementSalairesNets_01_01 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_01_01);
            etatPlanTresorerieModel.CotisationsSociales_01_01 = string.Format(frCult, "{0:n}", CotisationsSociales_01_01);
            etatPlanTresorerieModel.IRGSalaires_01_01 = string.Format(frCult, "{0:n}", IRGSalaires_01_01);
            etatPlanTresorerieModel.TVAPayer_01_01 = string.Format(frCult, "{0:n}", TVAPayer_01_01);
            etatPlanTresorerieModel.IBS_IFU_01_01 = string.Format(frCult, "{0:n}", IBS_IFU_01_01);
            etatPlanTresorerieModel.TotalDepense_01_01 = string.Format(frCult, "{0:n}", TotalDepense_01_01);
            etatPlanTresorerieModel.SoldeFinal_01_01 = string.Format(frCult, "{0:n}", SoldeFinal_01_01);

            #endregion

            #region Données EtatPlanTresorerie Année01 Mois02

            etatPlanTresorerieModel.SoldeInitial_01_02 = string.Format(frCult, "{0:n}", SoldeInitial_01_02);
            etatPlanTresorerieModel.ApportSupplementaire_01_02 = string.Format(frCult, "{0:n}", ApportSupplementaire_01_02);
            etatPlanTresorerieModel.CMT_01_02 = string.Format(frCult, "{0:n}", CMT_01_02);
            etatPlanTresorerieModel.PNRClassique_01_02 = string.Format(frCult, "{0:n}", PNRClassique_01_02);
            etatPlanTresorerieModel.ApportPersonnel_01_02 = string.Format(frCult, "{0:n}", ApportPersonnel_01_02);
            etatPlanTresorerieModel.PNRLoyer_01_02 = string.Format(frCult, "{0:n}", PNRLoyer_01_02);
            etatPlanTresorerieModel.EncaissementRecusClients_01_02 = string.Format(frCult, "{0:n}", EncaissementRecusClients_01_02);
            etatPlanTresorerieModel.TotalRecette_01_02 = string.Format(frCult, "{0:n}", TotalRecette_01_02);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_01_02 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_01_02);
            etatPlanTresorerieModel.DecaissementFournisseurs_01_02 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_01_02);
            etatPlanTresorerieModel.DecaissementPrestataires_01_02 = string.Format(frCult, "{0:n}", DecaissementPrestataires_01_02);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_01_02 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_01_02);
            etatPlanTresorerieModel.DecaissementSalairesNets_01_02 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_01_02);
            etatPlanTresorerieModel.CotisationsSociales_01_02 = string.Format(frCult, "{0:n}", CotisationsSociales_01_02);
            etatPlanTresorerieModel.IRGSalaires_01_02 = string.Format(frCult, "{0:n}", IRGSalaires_01_02);
            etatPlanTresorerieModel.TVAPayer_01_02 = string.Format(frCult, "{0:n}", TVAPayer_01_02);
            etatPlanTresorerieModel.IBS_IFU_01_02 = string.Format(frCult, "{0:n}", IBS_IFU_01_02);
            etatPlanTresorerieModel.TotalDepense_01_02 = string.Format(frCult, "{0:n}", TotalDepense_01_02);
            etatPlanTresorerieModel.SoldeFinal_01_02 = string.Format(frCult, "{0:n}", SoldeFinal_01_02);

            #endregion

            #region Données EtatPlanTresorerie Année01 Mois03

            etatPlanTresorerieModel.SoldeInitial_01_03 = string.Format(frCult, "{0:n}", SoldeInitial_01_03);
            etatPlanTresorerieModel.ApportSupplementaire_01_03 = string.Format(frCult, "{0:n}", ApportSupplementaire_01_03);
            etatPlanTresorerieModel.CMT_01_03 = string.Format(frCult, "{0:n}", CMT_01_03);
            etatPlanTresorerieModel.PNRClassique_01_03 = string.Format(frCult, "{0:n}", PNRClassique_01_03);
            etatPlanTresorerieModel.ApportPersonnel_01_03 = string.Format(frCult, "{0:n}", ApportPersonnel_01_03);
            etatPlanTresorerieModel.PNRLoyer_01_03 = string.Format(frCult, "{0:n}", PNRLoyer_01_03);
            etatPlanTresorerieModel.EncaissementRecusClients_01_03 = string.Format(frCult, "{0:n}", EncaissementRecusClients_01_03);
            etatPlanTresorerieModel.TotalRecette_01_03 = string.Format(frCult, "{0:n}", TotalRecette_01_03);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_01_03 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_01_03);
            etatPlanTresorerieModel.DecaissementFournisseurs_01_03 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_01_03);
            etatPlanTresorerieModel.DecaissementPrestataires_01_03 = string.Format(frCult, "{0:n}", DecaissementPrestataires_01_03);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_01_03 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_01_03);
            etatPlanTresorerieModel.DecaissementSalairesNets_01_03 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_01_03);
            etatPlanTresorerieModel.CotisationsSociales_01_03 = string.Format(frCult, "{0:n}", CotisationsSociales_01_03);
            etatPlanTresorerieModel.IRGSalaires_01_03 = string.Format(frCult, "{0:n}", IRGSalaires_01_03);
            etatPlanTresorerieModel.TVAPayer_01_03 = string.Format(frCult, "{0:n}", TVAPayer_01_03);
            etatPlanTresorerieModel.IBS_IFU_01_03 = string.Format(frCult, "{0:n}", IBS_IFU_01_03);
            etatPlanTresorerieModel.TotalDepense_01_03 = string.Format(frCult, "{0:n}", TotalDepense_01_03);
            etatPlanTresorerieModel.SoldeFinal_01_03 = string.Format(frCult, "{0:n}", SoldeFinal_01_03);

            #endregion

            #region Données EtatPlanTresorerie Année01 Mois04

            etatPlanTresorerieModel.SoldeInitial_01_04 = string.Format(frCult, "{0:n}", SoldeInitial_01_04);
            etatPlanTresorerieModel.ApportSupplementaire_01_04 = string.Format(frCult, "{0:n}", ApportSupplementaire_01_04);
            etatPlanTresorerieModel.CMT_01_04 = string.Format(frCult, "{0:n}", CMT_01_04);
            etatPlanTresorerieModel.PNRClassique_01_04 = string.Format(frCult, "{0:n}", PNRClassique_01_04);
            etatPlanTresorerieModel.ApportPersonnel_01_04 = string.Format(frCult, "{0:n}", ApportPersonnel_01_04);
            etatPlanTresorerieModel.PNRLoyer_01_04 = string.Format(frCult, "{0:n}", PNRLoyer_01_04);
            etatPlanTresorerieModel.EncaissementRecusClients_01_04 = string.Format(frCult, "{0:n}", EncaissementRecusClients_01_04);
            etatPlanTresorerieModel.TotalRecette_01_04 = string.Format(frCult, "{0:n}", TotalRecette_01_04);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_01_04 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_01_04);
            etatPlanTresorerieModel.DecaissementFournisseurs_01_04 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_01_04);
            etatPlanTresorerieModel.DecaissementPrestataires_01_04 = string.Format(frCult, "{0:n}", DecaissementPrestataires_01_04);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_01_04 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_01_04);
            etatPlanTresorerieModel.DecaissementSalairesNets_01_04 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_01_04);
            etatPlanTresorerieModel.CotisationsSociales_01_04 = string.Format(frCult, "{0:n}", CotisationsSociales_01_04);
            etatPlanTresorerieModel.IRGSalaires_01_04 = string.Format(frCult, "{0:n}", IRGSalaires_01_04);
            etatPlanTresorerieModel.TVAPayer_01_04 = string.Format(frCult, "{0:n}", TVAPayer_01_04);
            etatPlanTresorerieModel.IBS_IFU_01_04 = string.Format(frCult, "{0:n}", IBS_IFU_01_04);
            etatPlanTresorerieModel.TotalDepense_01_04 = string.Format(frCult, "{0:n}", TotalDepense_01_04);
            etatPlanTresorerieModel.SoldeFinal_01_04 = string.Format(frCult, "{0:n}", SoldeFinal_01_04);

            #endregion

            #region Données EtatPlanTresorerie Année01 Mois05

            etatPlanTresorerieModel.SoldeInitial_01_05 = string.Format(frCult, "{0:n}", SoldeInitial_01_05);
            etatPlanTresorerieModel.ApportSupplementaire_01_05 = string.Format(frCult, "{0:n}", ApportSupplementaire_01_05);
            etatPlanTresorerieModel.CMT_01_05 = string.Format(frCult, "{0:n}", CMT_01_05);
            etatPlanTresorerieModel.PNRClassique_01_05 = string.Format(frCult, "{0:n}", PNRClassique_01_05);
            etatPlanTresorerieModel.ApportPersonnel_01_05 = string.Format(frCult, "{0:n}", ApportPersonnel_01_05);
            etatPlanTresorerieModel.PNRLoyer_01_05 = string.Format(frCult, "{0:n}", PNRLoyer_01_05);
            etatPlanTresorerieModel.EncaissementRecusClients_01_05 = string.Format(frCult, "{0:n}", EncaissementRecusClients_01_05);
            etatPlanTresorerieModel.TotalRecette_01_05 = string.Format(frCult, "{0:n}", TotalRecette_01_05);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_01_05 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_01_05);
            etatPlanTresorerieModel.DecaissementFournisseurs_01_05 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_01_05);
            etatPlanTresorerieModel.DecaissementPrestataires_01_05 = string.Format(frCult, "{0:n}", DecaissementPrestataires_01_05);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_01_05 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_01_05);
            etatPlanTresorerieModel.DecaissementSalairesNets_01_05 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_01_05);
            etatPlanTresorerieModel.CotisationsSociales_01_05 = string.Format(frCult, "{0:n}", CotisationsSociales_01_05);
            etatPlanTresorerieModel.IRGSalaires_01_05 = string.Format(frCult, "{0:n}", IRGSalaires_01_05);
            etatPlanTresorerieModel.TVAPayer_01_05 = string.Format(frCult, "{0:n}", TVAPayer_01_05);
            etatPlanTresorerieModel.IBS_IFU_01_05 = string.Format(frCult, "{0:n}", IBS_IFU_01_05);
            etatPlanTresorerieModel.TotalDepense_01_05 = string.Format(frCult, "{0:n}", TotalDepense_01_05);
            etatPlanTresorerieModel.SoldeFinal_01_05 = string.Format(frCult, "{0:n}", SoldeFinal_01_05);

            #endregion

            #region Données EtatPlanTresorerie Année01 Mois06

            etatPlanTresorerieModel.SoldeInitial_01_06 = string.Format(frCult, "{0:n}", SoldeInitial_01_06);
            etatPlanTresorerieModel.ApportSupplementaire_01_06 = string.Format(frCult, "{0:n}", ApportSupplementaire_01_06);
            etatPlanTresorerieModel.CMT_01_06 = string.Format(frCult, "{0:n}", CMT_01_06);
            etatPlanTresorerieModel.PNRClassique_01_06 = string.Format(frCult, "{0:n}", PNRClassique_01_06);
            etatPlanTresorerieModel.ApportPersonnel_01_06 = string.Format(frCult, "{0:n}", ApportPersonnel_01_06);
            etatPlanTresorerieModel.PNRLoyer_01_06 = string.Format(frCult, "{0:n}", PNRLoyer_01_06);
            etatPlanTresorerieModel.EncaissementRecusClients_01_06 = string.Format(frCult, "{0:n}", EncaissementRecusClients_01_06);
            etatPlanTresorerieModel.TotalRecette_01_06 = string.Format(frCult, "{0:n}", TotalRecette_01_06);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_01_06 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_01_06);
            etatPlanTresorerieModel.DecaissementFournisseurs_01_06 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_01_06);
            etatPlanTresorerieModel.DecaissementPrestataires_01_06 = string.Format(frCult, "{0:n}", DecaissementPrestataires_01_06);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_01_06 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_01_06);
            etatPlanTresorerieModel.DecaissementSalairesNets_01_06 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_01_06);
            etatPlanTresorerieModel.CotisationsSociales_01_06 = string.Format(frCult, "{0:n}", CotisationsSociales_01_06);
            etatPlanTresorerieModel.IRGSalaires_01_06 = string.Format(frCult, "{0:n}", IRGSalaires_01_06);
            etatPlanTresorerieModel.TVAPayer_01_06 = string.Format(frCult, "{0:n}", TVAPayer_01_06);
            etatPlanTresorerieModel.IBS_IFU_01_06 = string.Format(frCult, "{0:n}", IBS_IFU_01_06);
            etatPlanTresorerieModel.TotalDepense_01_06 = string.Format(frCult, "{0:n}", TotalDepense_01_06);
            etatPlanTresorerieModel.SoldeFinal_01_06 = string.Format(frCult, "{0:n}", SoldeFinal_01_06);

            #endregion

            #region Données EtatPlanTresorerie Année01 Mois07

            etatPlanTresorerieModel.SoldeInitial_01_07 = string.Format(frCult, "{0:n}", SoldeInitial_01_07);
            etatPlanTresorerieModel.ApportSupplementaire_01_07 = string.Format(frCult, "{0:n}", ApportSupplementaire_01_07);
            etatPlanTresorerieModel.CMT_01_07 = string.Format(frCult, "{0:n}", CMT_01_07);
            etatPlanTresorerieModel.PNRClassique_01_07 = string.Format(frCult, "{0:n}", PNRClassique_01_07);
            etatPlanTresorerieModel.ApportPersonnel_01_07 = string.Format(frCult, "{0:n}", ApportPersonnel_01_07);
            etatPlanTresorerieModel.PNRLoyer_01_07 = string.Format(frCult, "{0:n}", PNRLoyer_01_07);
            etatPlanTresorerieModel.EncaissementRecusClients_01_07 = string.Format(frCult, "{0:n}", EncaissementRecusClients_01_07);
            etatPlanTresorerieModel.TotalRecette_01_07 = string.Format(frCult, "{0:n}", TotalRecette_01_07);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_01_07 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_01_07);
            etatPlanTresorerieModel.DecaissementFournisseurs_01_07 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_01_07);
            etatPlanTresorerieModel.DecaissementPrestataires_01_07 = string.Format(frCult, "{0:n}", DecaissementPrestataires_01_07);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_01_07 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_01_07);
            etatPlanTresorerieModel.DecaissementSalairesNets_01_07 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_01_07);
            etatPlanTresorerieModel.CotisationsSociales_01_07 = string.Format(frCult, "{0:n}", CotisationsSociales_01_07);
            etatPlanTresorerieModel.IRGSalaires_01_07 = string.Format(frCult, "{0:n}", IRGSalaires_01_07);
            etatPlanTresorerieModel.TVAPayer_01_07 = string.Format(frCult, "{0:n}", TVAPayer_01_07);
            etatPlanTresorerieModel.IBS_IFU_01_07 = string.Format(frCult, "{0:n}", IBS_IFU_01_07);
            etatPlanTresorerieModel.TotalDepense_01_07 = string.Format(frCult, "{0:n}", TotalDepense_01_07);
            etatPlanTresorerieModel.SoldeFinal_01_07 = string.Format(frCult, "{0:n}", SoldeFinal_01_07);

            #endregion

            #region Données EtatPlanTresorerie Année01 Mois08

            etatPlanTresorerieModel.SoldeInitial_01_08 = string.Format(frCult, "{0:n}", SoldeInitial_01_08);
            etatPlanTresorerieModel.ApportSupplementaire_01_08 = string.Format(frCult, "{0:n}", ApportSupplementaire_01_08);
            etatPlanTresorerieModel.CMT_01_08 = string.Format(frCult, "{0:n}", CMT_01_08);
            etatPlanTresorerieModel.PNRClassique_01_08 = string.Format(frCult, "{0:n}", PNRClassique_01_08);
            etatPlanTresorerieModel.ApportPersonnel_01_08 = string.Format(frCult, "{0:n}", ApportPersonnel_01_08);
            etatPlanTresorerieModel.PNRLoyer_01_08 = string.Format(frCult, "{0:n}", PNRLoyer_01_08);
            etatPlanTresorerieModel.EncaissementRecusClients_01_08 = string.Format(frCult, "{0:n}", EncaissementRecusClients_01_08);
            etatPlanTresorerieModel.TotalRecette_01_08 = string.Format(frCult, "{0:n}", TotalRecette_01_08);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_01_08 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_01_08);
            etatPlanTresorerieModel.DecaissementFournisseurs_01_08 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_01_08);
            etatPlanTresorerieModel.DecaissementPrestataires_01_08 = string.Format(frCult, "{0:n}", DecaissementPrestataires_01_08);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_01_08 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_01_08);
            etatPlanTresorerieModel.DecaissementSalairesNets_01_08 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_01_08);
            etatPlanTresorerieModel.CotisationsSociales_01_08 = string.Format(frCult, "{0:n}", CotisationsSociales_01_08);
            etatPlanTresorerieModel.IRGSalaires_01_08 = string.Format(frCult, "{0:n}", IRGSalaires_01_08);
            etatPlanTresorerieModel.TVAPayer_01_08 = string.Format(frCult, "{0:n}", TVAPayer_01_08);
            etatPlanTresorerieModel.IBS_IFU_01_08 = string.Format(frCult, "{0:n}", IBS_IFU_01_08);
            etatPlanTresorerieModel.TotalDepense_01_08 = string.Format(frCult, "{0:n}", TotalDepense_01_08);
            etatPlanTresorerieModel.SoldeFinal_01_08 = string.Format(frCult, "{0:n}", SoldeFinal_01_08);

            #endregion

            #region Données EtatPlanTresorerie Année01 Mois09

            etatPlanTresorerieModel.SoldeInitial_01_09 = string.Format(frCult, "{0:n}", SoldeInitial_01_09);
            etatPlanTresorerieModel.ApportSupplementaire_01_09 = string.Format(frCult, "{0:n}", ApportSupplementaire_01_09);
            etatPlanTresorerieModel.CMT_01_09 = string.Format(frCult, "{0:n}", CMT_01_09);
            etatPlanTresorerieModel.PNRClassique_01_09 = string.Format(frCult, "{0:n}", PNRClassique_01_09);
            etatPlanTresorerieModel.ApportPersonnel_01_09 = string.Format(frCult, "{0:n}", ApportPersonnel_01_09);
            etatPlanTresorerieModel.PNRLoyer_01_09 = string.Format(frCult, "{0:n}", PNRLoyer_01_09);
            etatPlanTresorerieModel.EncaissementRecusClients_01_09 = string.Format(frCult, "{0:n}", EncaissementRecusClients_01_09);
            etatPlanTresorerieModel.TotalRecette_01_09 = string.Format(frCult, "{0:n}", TotalRecette_01_09);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_01_09 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_01_09);
            etatPlanTresorerieModel.DecaissementFournisseurs_01_09 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_01_09);
            etatPlanTresorerieModel.DecaissementPrestataires_01_09 = string.Format(frCult, "{0:n}", DecaissementPrestataires_01_09);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_01_09 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_01_09);
            etatPlanTresorerieModel.DecaissementSalairesNets_01_09 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_01_09);
            etatPlanTresorerieModel.CotisationsSociales_01_09 = string.Format(frCult, "{0:n}", CotisationsSociales_01_09);
            etatPlanTresorerieModel.IRGSalaires_01_09 = string.Format(frCult, "{0:n}", IRGSalaires_01_09);
            etatPlanTresorerieModel.TVAPayer_01_09 = string.Format(frCult, "{0:n}", TVAPayer_01_09);
            etatPlanTresorerieModel.IBS_IFU_01_09 = string.Format(frCult, "{0:n}", IBS_IFU_01_09);
            etatPlanTresorerieModel.TotalDepense_01_09 = string.Format(frCult, "{0:n}", TotalDepense_01_09);
            etatPlanTresorerieModel.SoldeFinal_01_09 = string.Format(frCult, "{0:n}", SoldeFinal_01_09);

            #endregion

            #region Données EtatPlanTresorerie Année01 Mois10

            etatPlanTresorerieModel.SoldeInitial_01_10 = string.Format(frCult, "{0:n}", SoldeInitial_01_10);
            etatPlanTresorerieModel.ApportSupplementaire_01_10 = string.Format(frCult, "{0:n}", ApportSupplementaire_01_10);
            etatPlanTresorerieModel.CMT_01_10 = string.Format(frCult, "{0:n}", CMT_01_10);
            etatPlanTresorerieModel.PNRClassique_01_10 = string.Format(frCult, "{0:n}", PNRClassique_01_10);
            etatPlanTresorerieModel.ApportPersonnel_01_10 = string.Format(frCult, "{0:n}", ApportPersonnel_01_10);
            etatPlanTresorerieModel.PNRLoyer_01_10 = string.Format(frCult, "{0:n}", PNRLoyer_01_10);
            etatPlanTresorerieModel.EncaissementRecusClients_01_10 = string.Format(frCult, "{0:n}", EncaissementRecusClients_01_10);
            etatPlanTresorerieModel.TotalRecette_01_10 = string.Format(frCult, "{0:n}", TotalRecette_01_10);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_01_10 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_01_10);
            etatPlanTresorerieModel.DecaissementFournisseurs_01_10 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_01_10);
            etatPlanTresorerieModel.DecaissementPrestataires_01_10 = string.Format(frCult, "{0:n}", DecaissementPrestataires_01_10);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_01_10 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_01_10);
            etatPlanTresorerieModel.DecaissementSalairesNets_01_10 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_01_10);
            etatPlanTresorerieModel.CotisationsSociales_01_10 = string.Format(frCult, "{0:n}", CotisationsSociales_01_10);
            etatPlanTresorerieModel.IRGSalaires_01_10 = string.Format(frCult, "{0:n}", IRGSalaires_01_10);
            etatPlanTresorerieModel.TVAPayer_01_10 = string.Format(frCult, "{0:n}", TVAPayer_01_10);
            etatPlanTresorerieModel.IBS_IFU_01_10 = string.Format(frCult, "{0:n}", IBS_IFU_01_10);
            etatPlanTresorerieModel.TotalDepense_01_10 = string.Format(frCult, "{0:n}", TotalDepense_01_10);
            etatPlanTresorerieModel.SoldeFinal_01_10 = string.Format(frCult, "{0:n}", SoldeFinal_01_10);

            #endregion

            #region Données EtatPlanTresorerie Année01 Mois11

            etatPlanTresorerieModel.SoldeInitial_01_11 = string.Format(frCult, "{0:n}", SoldeInitial_01_11);
            etatPlanTresorerieModel.ApportSupplementaire_01_11 = string.Format(frCult, "{0:n}", ApportSupplementaire_01_11);
            etatPlanTresorerieModel.CMT_01_11 = string.Format(frCult, "{0:n}", CMT_01_11);
            etatPlanTresorerieModel.PNRClassique_01_11 = string.Format(frCult, "{0:n}", PNRClassique_01_11);
            etatPlanTresorerieModel.ApportPersonnel_01_11 = string.Format(frCult, "{0:n}", ApportPersonnel_01_11);
            etatPlanTresorerieModel.PNRLoyer_01_11 = string.Format(frCult, "{0:n}", PNRLoyer_01_11);
            etatPlanTresorerieModel.EncaissementRecusClients_01_11 = string.Format(frCult, "{0:n}", EncaissementRecusClients_01_11);
            etatPlanTresorerieModel.TotalRecette_01_11 = string.Format(frCult, "{0:n}", TotalRecette_01_11);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_01_11 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_01_11);
            etatPlanTresorerieModel.DecaissementFournisseurs_01_11 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_01_11);
            etatPlanTresorerieModel.DecaissementPrestataires_01_11 = string.Format(frCult, "{0:n}", DecaissementPrestataires_01_11);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_01_11 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_01_11);
            etatPlanTresorerieModel.DecaissementSalairesNets_01_11 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_01_11);
            etatPlanTresorerieModel.CotisationsSociales_01_11 = string.Format(frCult, "{0:n}", CotisationsSociales_01_11);
            etatPlanTresorerieModel.IRGSalaires_01_11 = string.Format(frCult, "{0:n}", IRGSalaires_01_11);
            etatPlanTresorerieModel.TVAPayer_01_11 = string.Format(frCult, "{0:n}", TVAPayer_01_11);
            etatPlanTresorerieModel.IBS_IFU_01_11 = string.Format(frCult, "{0:n}", IBS_IFU_01_11);
            etatPlanTresorerieModel.TotalDepense_01_11 = string.Format(frCult, "{0:n}", TotalDepense_01_11);
            etatPlanTresorerieModel.SoldeFinal_01_11 = string.Format(frCult, "{0:n}", SoldeFinal_01_11);

            #endregion

            #region Données EtatPlanTresorerie Année01 Mois12

            etatPlanTresorerieModel.SoldeInitial_01_12 = string.Format(frCult, "{0:n}", SoldeInitial_01_12);
            etatPlanTresorerieModel.ApportSupplementaire_01_12 = string.Format(frCult, "{0:n}", ApportSupplementaire_01_12);
            etatPlanTresorerieModel.CMT_01_12 = string.Format(frCult, "{0:n}", CMT_01_12);
            etatPlanTresorerieModel.PNRClassique_01_12 = string.Format(frCult, "{0:n}", PNRClassique_01_12);
            etatPlanTresorerieModel.ApportPersonnel_01_12 = string.Format(frCult, "{0:n}", ApportPersonnel_01_12);
            etatPlanTresorerieModel.PNRLoyer_01_12 = string.Format(frCult, "{0:n}", PNRLoyer_01_12);
            etatPlanTresorerieModel.EncaissementRecusClients_01_12 = string.Format(frCult, "{0:n}", EncaissementRecusClients_01_12);
            etatPlanTresorerieModel.TotalRecette_01_12 = string.Format(frCult, "{0:n}", TotalRecette_01_12);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_01_12 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_01_12);
            etatPlanTresorerieModel.DecaissementFournisseurs_01_12 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_01_12);
            etatPlanTresorerieModel.DecaissementPrestataires_01_12 = string.Format(frCult, "{0:n}", DecaissementPrestataires_01_12);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_01_12 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_01_12);
            etatPlanTresorerieModel.DecaissementSalairesNets_01_12 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_01_12);
            etatPlanTresorerieModel.CotisationsSociales_01_12 = string.Format(frCult, "{0:n}", CotisationsSociales_01_12);
            etatPlanTresorerieModel.IRGSalaires_01_12 = string.Format(frCult, "{0:n}", IRGSalaires_01_12);
            etatPlanTresorerieModel.TVAPayer_01_12 = string.Format(frCult, "{0:n}", TVAPayer_01_12);
            etatPlanTresorerieModel.IBS_IFU_01_12 = string.Format(frCult, "{0:n}", IBS_IFU_01_12);
            etatPlanTresorerieModel.TotalDepense_01_12 = string.Format(frCult, "{0:n}", TotalDepense_01_12);
            etatPlanTresorerieModel.SoldeFinal_01_12 = string.Format(frCult, "{0:n}", SoldeFinal_01_12);

            #endregion

            #endregion

            #region Données etatPlanTresorerieModel Année02

            #region Données EtatPlanTresorerie Année02 Mois01

            etatPlanTresorerieModel.SoldeInitial_02_01 = string.Format(frCult, "{0:n}", SoldeInitial_02_01);
            etatPlanTresorerieModel.ApportSupplementaire_02_01 = string.Format(frCult, "{0:n}", ApportSupplementaire_02_01);
            etatPlanTresorerieModel.CMT_02_01 = string.Format(frCult, "{0:n}", CMT_02_01);
            etatPlanTresorerieModel.PNRClassique_02_01 = string.Format(frCult, "{0:n}", PNRClassique_02_01);
            etatPlanTresorerieModel.ApportPersonnel_02_01 = string.Format(frCult, "{0:n}", ApportPersonnel_02_01);
            etatPlanTresorerieModel.PNRLoyer_02_01 = string.Format(frCult, "{0:n}", PNRLoyer_02_01);
            etatPlanTresorerieModel.EncaissementRecusClients_02_01 = string.Format(frCult, "{0:n}", EncaissementRecusClients_02_01);
            etatPlanTresorerieModel.TotalRecette_02_01 = string.Format(frCult, "{0:n}", TotalRecette_02_01);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_02_01 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_02_01);
            etatPlanTresorerieModel.DecaissementFournisseurs_02_01 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_02_01);
            etatPlanTresorerieModel.DecaissementPrestataires_02_01 = string.Format(frCult, "{0:n}", DecaissementPrestataires_02_01);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_02_01 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_02_01);
            etatPlanTresorerieModel.DecaissementSalairesNets_02_01 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_02_01);
            etatPlanTresorerieModel.CotisationsSociales_02_01 = string.Format(frCult, "{0:n}", CotisationsSociales_02_01);
            etatPlanTresorerieModel.IRGSalaires_02_01 = string.Format(frCult, "{0:n}", IRGSalaires_02_01);
            etatPlanTresorerieModel.TVAPayer_02_01 = string.Format(frCult, "{0:n}", TVAPayer_02_01);
            etatPlanTresorerieModel.IBS_IFU_02_01 = string.Format(frCult, "{0:n}", IBS_IFU_02_01);
            etatPlanTresorerieModel.TotalDepense_02_01 = string.Format(frCult, "{0:n}", TotalDepense_02_01);
            etatPlanTresorerieModel.SoldeFinal_02_01 = string.Format(frCult, "{0:n}", SoldeFinal_02_01);

            #endregion

            #region Données EtatPlanTresorerie Année02 Mois02

            etatPlanTresorerieModel.SoldeInitial_02_02 = string.Format(frCult, "{0:n}", SoldeInitial_02_02);
            etatPlanTresorerieModel.ApportSupplementaire_02_02 = string.Format(frCult, "{0:n}", ApportSupplementaire_02_02);
            etatPlanTresorerieModel.CMT_02_02 = string.Format(frCult, "{0:n}", CMT_02_02);
            etatPlanTresorerieModel.PNRClassique_02_02 = string.Format(frCult, "{0:n}", PNRClassique_02_02);
            etatPlanTresorerieModel.ApportPersonnel_02_02 = string.Format(frCult, "{0:n}", ApportPersonnel_02_02);
            etatPlanTresorerieModel.PNRLoyer_02_02 = string.Format(frCult, "{0:n}", PNRLoyer_02_02);
            etatPlanTresorerieModel.EncaissementRecusClients_02_02 = string.Format(frCult, "{0:n}", EncaissementRecusClients_02_02);
            etatPlanTresorerieModel.TotalRecette_02_02 = string.Format(frCult, "{0:n}", TotalRecette_02_02);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_02_02 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_02_02);
            etatPlanTresorerieModel.DecaissementFournisseurs_02_02 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_02_02);
            etatPlanTresorerieModel.DecaissementPrestataires_02_02 = string.Format(frCult, "{0:n}", DecaissementPrestataires_02_02);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_02_02 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_02_02);
            etatPlanTresorerieModel.DecaissementSalairesNets_02_02 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_02_02);
            etatPlanTresorerieModel.CotisationsSociales_02_02 = string.Format(frCult, "{0:n}", CotisationsSociales_02_02);
            etatPlanTresorerieModel.IRGSalaires_02_02 = string.Format(frCult, "{0:n}", IRGSalaires_02_02);
            etatPlanTresorerieModel.TVAPayer_02_02 = string.Format(frCult, "{0:n}", TVAPayer_02_02);
            etatPlanTresorerieModel.IBS_IFU_02_02 = string.Format(frCult, "{0:n}", IBS_IFU_02_02);
            etatPlanTresorerieModel.TotalDepense_02_02 = string.Format(frCult, "{0:n}", TotalDepense_02_02);
            etatPlanTresorerieModel.SoldeFinal_02_02 = string.Format(frCult, "{0:n}", SoldeFinal_02_02);

            #endregion

            #region Données EtatPlanTresorerie Année02 Mois03

            etatPlanTresorerieModel.SoldeInitial_02_03 = string.Format(frCult, "{0:n}", SoldeInitial_02_03);
            etatPlanTresorerieModel.ApportSupplementaire_02_03 = string.Format(frCult, "{0:n}", ApportSupplementaire_02_03);
            etatPlanTresorerieModel.CMT_02_03 = string.Format(frCult, "{0:n}", CMT_02_03);
            etatPlanTresorerieModel.PNRClassique_02_03 = string.Format(frCult, "{0:n}", PNRClassique_02_03);
            etatPlanTresorerieModel.ApportPersonnel_02_03 = string.Format(frCult, "{0:n}", ApportPersonnel_02_03);
            etatPlanTresorerieModel.PNRLoyer_02_03 = string.Format(frCult, "{0:n}", PNRLoyer_02_03);
            etatPlanTresorerieModel.EncaissementRecusClients_02_03 = string.Format(frCult, "{0:n}", EncaissementRecusClients_02_03);
            etatPlanTresorerieModel.TotalRecette_02_03 = string.Format(frCult, "{0:n}", TotalRecette_02_03);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_02_03 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_02_03);
            etatPlanTresorerieModel.DecaissementFournisseurs_02_03 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_02_03);
            etatPlanTresorerieModel.DecaissementPrestataires_02_03 = string.Format(frCult, "{0:n}", DecaissementPrestataires_02_03);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_02_03 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_02_03);
            etatPlanTresorerieModel.DecaissementSalairesNets_02_03 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_02_03);
            etatPlanTresorerieModel.CotisationsSociales_02_03 = string.Format(frCult, "{0:n}", CotisationsSociales_02_03);
            etatPlanTresorerieModel.IRGSalaires_02_03 = string.Format(frCult, "{0:n}", IRGSalaires_02_03);
            etatPlanTresorerieModel.TVAPayer_02_03 = string.Format(frCult, "{0:n}", TVAPayer_02_03);
            etatPlanTresorerieModel.IBS_IFU_02_03 = string.Format(frCult, "{0:n}", IBS_IFU_02_03);
            etatPlanTresorerieModel.TotalDepense_02_03 = string.Format(frCult, "{0:n}", TotalDepense_02_03);
            etatPlanTresorerieModel.SoldeFinal_02_03 = string.Format(frCult, "{0:n}", SoldeFinal_02_03);

            #endregion

            #region Données EtatPlanTresorerie Année02 Mois04

            etatPlanTresorerieModel.SoldeInitial_02_04 = string.Format(frCult, "{0:n}", SoldeInitial_02_04);
            etatPlanTresorerieModel.ApportSupplementaire_02_04 = string.Format(frCult, "{0:n}", ApportSupplementaire_02_04);
            etatPlanTresorerieModel.CMT_02_04 = string.Format(frCult, "{0:n}", CMT_02_04);
            etatPlanTresorerieModel.PNRClassique_02_04 = string.Format(frCult, "{0:n}", PNRClassique_02_04);
            etatPlanTresorerieModel.ApportPersonnel_02_04 = string.Format(frCult, "{0:n}", ApportPersonnel_02_04);
            etatPlanTresorerieModel.PNRLoyer_02_04 = string.Format(frCult, "{0:n}", PNRLoyer_02_04);
            etatPlanTresorerieModel.EncaissementRecusClients_02_04 = string.Format(frCult, "{0:n}", EncaissementRecusClients_02_04);
            etatPlanTresorerieModel.TotalRecette_02_04 = string.Format(frCult, "{0:n}", TotalRecette_02_04);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_02_04 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_02_04);
            etatPlanTresorerieModel.DecaissementFournisseurs_02_04 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_02_04);
            etatPlanTresorerieModel.DecaissementPrestataires_02_04 = string.Format(frCult, "{0:n}", DecaissementPrestataires_02_04);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_02_04 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_02_04);
            etatPlanTresorerieModel.DecaissementSalairesNets_02_04 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_02_04);
            etatPlanTresorerieModel.CotisationsSociales_02_04 = string.Format(frCult, "{0:n}", CotisationsSociales_02_04);
            etatPlanTresorerieModel.IRGSalaires_02_04 = string.Format(frCult, "{0:n}", IRGSalaires_02_04);
            etatPlanTresorerieModel.TVAPayer_02_04 = string.Format(frCult, "{0:n}", TVAPayer_02_04);
            etatPlanTresorerieModel.IBS_IFU_02_04 = string.Format(frCult, "{0:n}", IBS_IFU_02_04);
            etatPlanTresorerieModel.TotalDepense_02_04 = string.Format(frCult, "{0:n}", TotalDepense_02_04);
            etatPlanTresorerieModel.SoldeFinal_02_04 = string.Format(frCult, "{0:n}", SoldeFinal_02_04);

            #endregion

            #region Données EtatPlanTresorerie Année02 Mois05

            etatPlanTresorerieModel.SoldeInitial_02_05 = string.Format(frCult, "{0:n}", SoldeInitial_02_05);
            etatPlanTresorerieModel.ApportSupplementaire_02_05 = string.Format(frCult, "{0:n}", ApportSupplementaire_02_05);
            etatPlanTresorerieModel.CMT_02_05 = string.Format(frCult, "{0:n}", CMT_02_05);
            etatPlanTresorerieModel.PNRClassique_02_05 = string.Format(frCult, "{0:n}", PNRClassique_02_05);
            etatPlanTresorerieModel.ApportPersonnel_02_05 = string.Format(frCult, "{0:n}", ApportPersonnel_02_05);
            etatPlanTresorerieModel.PNRLoyer_02_05 = string.Format(frCult, "{0:n}", PNRLoyer_02_05);
            etatPlanTresorerieModel.EncaissementRecusClients_02_05 = string.Format(frCult, "{0:n}", EncaissementRecusClients_02_05);
            etatPlanTresorerieModel.TotalRecette_02_05 = string.Format(frCult, "{0:n}", TotalRecette_02_05);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_02_05 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_02_05);
            etatPlanTresorerieModel.DecaissementFournisseurs_02_05 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_02_05);
            etatPlanTresorerieModel.DecaissementPrestataires_02_05 = string.Format(frCult, "{0:n}", DecaissementPrestataires_02_05);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_02_05 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_02_05);
            etatPlanTresorerieModel.DecaissementSalairesNets_02_05 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_02_05);
            etatPlanTresorerieModel.CotisationsSociales_02_05 = string.Format(frCult, "{0:n}", CotisationsSociales_02_05);
            etatPlanTresorerieModel.IRGSalaires_02_05 = string.Format(frCult, "{0:n}", IRGSalaires_02_05);
            etatPlanTresorerieModel.TVAPayer_02_05 = string.Format(frCult, "{0:n}", TVAPayer_02_05);
            etatPlanTresorerieModel.IBS_IFU_02_05 = string.Format(frCult, "{0:n}", IBS_IFU_02_05);
            etatPlanTresorerieModel.TotalDepense_02_05 = string.Format(frCult, "{0:n}", TotalDepense_02_05);
            etatPlanTresorerieModel.SoldeFinal_02_05 = string.Format(frCult, "{0:n}", SoldeFinal_02_05);

            #endregion

            #region Données EtatPlanTresorerie Année02 Mois06

            etatPlanTresorerieModel.SoldeInitial_02_06 = string.Format(frCult, "{0:n}", SoldeInitial_02_06);
            etatPlanTresorerieModel.ApportSupplementaire_02_06 = string.Format(frCult, "{0:n}", ApportSupplementaire_02_06);
            etatPlanTresorerieModel.CMT_02_06 = string.Format(frCult, "{0:n}", CMT_02_06);
            etatPlanTresorerieModel.PNRClassique_02_06 = string.Format(frCult, "{0:n}", PNRClassique_02_06);
            etatPlanTresorerieModel.ApportPersonnel_02_06 = string.Format(frCult, "{0:n}", ApportPersonnel_02_06);
            etatPlanTresorerieModel.PNRLoyer_02_06 = string.Format(frCult, "{0:n}", PNRLoyer_02_06);
            etatPlanTresorerieModel.EncaissementRecusClients_02_06 = string.Format(frCult, "{0:n}", EncaissementRecusClients_02_06);
            etatPlanTresorerieModel.TotalRecette_02_06 = string.Format(frCult, "{0:n}", TotalRecette_02_06);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_02_06 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_02_06);
            etatPlanTresorerieModel.DecaissementFournisseurs_02_06 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_02_06);
            etatPlanTresorerieModel.DecaissementPrestataires_02_06 = string.Format(frCult, "{0:n}", DecaissementPrestataires_02_06);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_02_06 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_02_06);
            etatPlanTresorerieModel.DecaissementSalairesNets_02_06 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_02_06);
            etatPlanTresorerieModel.CotisationsSociales_02_06 = string.Format(frCult, "{0:n}", CotisationsSociales_02_06);
            etatPlanTresorerieModel.IRGSalaires_02_06 = string.Format(frCult, "{0:n}", IRGSalaires_02_06);
            etatPlanTresorerieModel.TVAPayer_02_06 = string.Format(frCult, "{0:n}", TVAPayer_02_06);
            etatPlanTresorerieModel.IBS_IFU_02_06 = string.Format(frCult, "{0:n}", IBS_IFU_02_06);
            etatPlanTresorerieModel.TotalDepense_02_06 = string.Format(frCult, "{0:n}", TotalDepense_02_06);
            etatPlanTresorerieModel.SoldeFinal_02_06 = string.Format(frCult, "{0:n}", SoldeFinal_02_06);

            #endregion

            #region Données EtatPlanTresorerie Année02 Mois07

            etatPlanTresorerieModel.SoldeInitial_02_07 = string.Format(frCult, "{0:n}", SoldeInitial_02_07);
            etatPlanTresorerieModel.ApportSupplementaire_02_07 = string.Format(frCult, "{0:n}", ApportSupplementaire_02_07);
            etatPlanTresorerieModel.CMT_02_07 = string.Format(frCult, "{0:n}", CMT_02_07);
            etatPlanTresorerieModel.PNRClassique_02_07 = string.Format(frCult, "{0:n}", PNRClassique_02_07);
            etatPlanTresorerieModel.ApportPersonnel_02_07 = string.Format(frCult, "{0:n}", ApportPersonnel_02_07);
            etatPlanTresorerieModel.PNRLoyer_02_07 = string.Format(frCult, "{0:n}", PNRLoyer_02_07);
            etatPlanTresorerieModel.EncaissementRecusClients_02_07 = string.Format(frCult, "{0:n}", EncaissementRecusClients_02_07);
            etatPlanTresorerieModel.TotalRecette_02_07 = string.Format(frCult, "{0:n}", TotalRecette_02_07);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_02_07 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_02_07);
            etatPlanTresorerieModel.DecaissementFournisseurs_02_07 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_02_07);
            etatPlanTresorerieModel.DecaissementPrestataires_02_07 = string.Format(frCult, "{0:n}", DecaissementPrestataires_02_07);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_02_07 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_02_07);
            etatPlanTresorerieModel.DecaissementSalairesNets_02_07 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_02_07);
            etatPlanTresorerieModel.CotisationsSociales_02_07 = string.Format(frCult, "{0:n}", CotisationsSociales_02_07);
            etatPlanTresorerieModel.IRGSalaires_02_07 = string.Format(frCult, "{0:n}", IRGSalaires_02_07);
            etatPlanTresorerieModel.TVAPayer_02_07 = string.Format(frCult, "{0:n}", TVAPayer_02_07);
            etatPlanTresorerieModel.IBS_IFU_02_07 = string.Format(frCult, "{0:n}", IBS_IFU_02_07);
            etatPlanTresorerieModel.TotalDepense_02_07 = string.Format(frCult, "{0:n}", TotalDepense_02_07);
            etatPlanTresorerieModel.SoldeFinal_02_07 = string.Format(frCult, "{0:n}", SoldeFinal_02_07);

            #endregion

            #region Données EtatPlanTresorerie Année02 Mois08

            etatPlanTresorerieModel.SoldeInitial_02_08 = string.Format(frCult, "{0:n}", SoldeInitial_02_08);
            etatPlanTresorerieModel.ApportSupplementaire_02_08 = string.Format(frCult, "{0:n}", ApportSupplementaire_02_08);
            etatPlanTresorerieModel.CMT_02_08 = string.Format(frCult, "{0:n}", CMT_02_08);
            etatPlanTresorerieModel.PNRClassique_02_08 = string.Format(frCult, "{0:n}", PNRClassique_02_08);
            etatPlanTresorerieModel.ApportPersonnel_02_08 = string.Format(frCult, "{0:n}", ApportPersonnel_02_08);
            etatPlanTresorerieModel.PNRLoyer_02_08 = string.Format(frCult, "{0:n}", PNRLoyer_02_08);
            etatPlanTresorerieModel.EncaissementRecusClients_02_08 = string.Format(frCult, "{0:n}", EncaissementRecusClients_02_08);
            etatPlanTresorerieModel.TotalRecette_02_08 = string.Format(frCult, "{0:n}", TotalRecette_02_08);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_02_08 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_02_08);
            etatPlanTresorerieModel.DecaissementFournisseurs_02_08 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_02_08);
            etatPlanTresorerieModel.DecaissementPrestataires_02_08 = string.Format(frCult, "{0:n}", DecaissementPrestataires_02_08);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_02_08 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_02_08);
            etatPlanTresorerieModel.DecaissementSalairesNets_02_08 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_02_08);
            etatPlanTresorerieModel.CotisationsSociales_02_08 = string.Format(frCult, "{0:n}", CotisationsSociales_02_08);
            etatPlanTresorerieModel.IRGSalaires_02_08 = string.Format(frCult, "{0:n}", IRGSalaires_02_08);
            etatPlanTresorerieModel.TVAPayer_02_08 = string.Format(frCult, "{0:n}", TVAPayer_02_08);
            etatPlanTresorerieModel.IBS_IFU_02_08 = string.Format(frCult, "{0:n}", IBS_IFU_02_08);
            etatPlanTresorerieModel.TotalDepense_02_08 = string.Format(frCult, "{0:n}", TotalDepense_02_08);
            etatPlanTresorerieModel.SoldeFinal_02_08 = string.Format(frCult, "{0:n}", SoldeFinal_02_08);

            #endregion

            #region Données EtatPlanTresorerie Année02 Mois09

            etatPlanTresorerieModel.SoldeInitial_02_09 = string.Format(frCult, "{0:n}", SoldeInitial_02_09);
            etatPlanTresorerieModel.ApportSupplementaire_02_09 = string.Format(frCult, "{0:n}", ApportSupplementaire_02_09);
            etatPlanTresorerieModel.CMT_02_09 = string.Format(frCult, "{0:n}", CMT_02_09);
            etatPlanTresorerieModel.PNRClassique_02_09 = string.Format(frCult, "{0:n}", PNRClassique_02_09);
            etatPlanTresorerieModel.ApportPersonnel_02_09 = string.Format(frCult, "{0:n}", ApportPersonnel_02_09);
            etatPlanTresorerieModel.PNRLoyer_02_09 = string.Format(frCult, "{0:n}", PNRLoyer_02_09);
            etatPlanTresorerieModel.EncaissementRecusClients_02_09 = string.Format(frCult, "{0:n}", EncaissementRecusClients_02_09);
            etatPlanTresorerieModel.TotalRecette_02_09 = string.Format(frCult, "{0:n}", TotalRecette_02_09);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_02_09 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_02_09);
            etatPlanTresorerieModel.DecaissementFournisseurs_02_09 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_02_09);
            etatPlanTresorerieModel.DecaissementPrestataires_02_09 = string.Format(frCult, "{0:n}", DecaissementPrestataires_02_09);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_02_09 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_02_09);
            etatPlanTresorerieModel.DecaissementSalairesNets_02_09 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_02_09);
            etatPlanTresorerieModel.CotisationsSociales_02_09 = string.Format(frCult, "{0:n}", CotisationsSociales_02_09);
            etatPlanTresorerieModel.IRGSalaires_02_09 = string.Format(frCult, "{0:n}", IRGSalaires_02_09);
            etatPlanTresorerieModel.TVAPayer_02_09 = string.Format(frCult, "{0:n}", TVAPayer_02_09);
            etatPlanTresorerieModel.IBS_IFU_02_09 = string.Format(frCult, "{0:n}", IBS_IFU_02_09);
            etatPlanTresorerieModel.TotalDepense_02_09 = string.Format(frCult, "{0:n}", TotalDepense_02_09);
            etatPlanTresorerieModel.SoldeFinal_02_09 = string.Format(frCult, "{0:n}", SoldeFinal_02_09);

            #endregion

            #region Données EtatPlanTresorerie Année02 Mois10

            etatPlanTresorerieModel.SoldeInitial_02_10 = string.Format(frCult, "{0:n}", SoldeInitial_02_10);
            etatPlanTresorerieModel.ApportSupplementaire_02_10 = string.Format(frCult, "{0:n}", ApportSupplementaire_02_10);
            etatPlanTresorerieModel.CMT_02_10 = string.Format(frCult, "{0:n}", CMT_02_10);
            etatPlanTresorerieModel.PNRClassique_02_10 = string.Format(frCult, "{0:n}", PNRClassique_02_10);
            etatPlanTresorerieModel.ApportPersonnel_02_10 = string.Format(frCult, "{0:n}", ApportPersonnel_02_10);
            etatPlanTresorerieModel.PNRLoyer_02_10 = string.Format(frCult, "{0:n}", PNRLoyer_02_10);
            etatPlanTresorerieModel.EncaissementRecusClients_02_10 = string.Format(frCult, "{0:n}", EncaissementRecusClients_02_10);
            etatPlanTresorerieModel.TotalRecette_02_10 = string.Format(frCult, "{0:n}", TotalRecette_02_10);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_02_10 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_02_10);
            etatPlanTresorerieModel.DecaissementFournisseurs_02_10 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_02_10);
            etatPlanTresorerieModel.DecaissementPrestataires_02_10 = string.Format(frCult, "{0:n}", DecaissementPrestataires_02_10);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_02_10 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_02_10);
            etatPlanTresorerieModel.DecaissementSalairesNets_02_10 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_02_10);
            etatPlanTresorerieModel.CotisationsSociales_02_10 = string.Format(frCult, "{0:n}", CotisationsSociales_02_10);
            etatPlanTresorerieModel.IRGSalaires_02_10 = string.Format(frCult, "{0:n}", IRGSalaires_02_10);
            etatPlanTresorerieModel.TVAPayer_02_10 = string.Format(frCult, "{0:n}", TVAPayer_02_10);
            etatPlanTresorerieModel.IBS_IFU_02_10 = string.Format(frCult, "{0:n}", IBS_IFU_02_10);
            etatPlanTresorerieModel.TotalDepense_02_10 = string.Format(frCult, "{0:n}", TotalDepense_02_10);
            etatPlanTresorerieModel.SoldeFinal_02_10 = string.Format(frCult, "{0:n}", SoldeFinal_02_10);

            #endregion

            #region Données EtatPlanTresorerie Année02 Mois11

            etatPlanTresorerieModel.SoldeInitial_02_11 = string.Format(frCult, "{0:n}", SoldeInitial_02_11);
            etatPlanTresorerieModel.ApportSupplementaire_02_11 = string.Format(frCult, "{0:n}", ApportSupplementaire_02_11);
            etatPlanTresorerieModel.CMT_02_11 = string.Format(frCult, "{0:n}", CMT_02_11);
            etatPlanTresorerieModel.PNRClassique_02_11 = string.Format(frCult, "{0:n}", PNRClassique_02_11);
            etatPlanTresorerieModel.ApportPersonnel_02_11 = string.Format(frCult, "{0:n}", ApportPersonnel_02_11);
            etatPlanTresorerieModel.PNRLoyer_02_11 = string.Format(frCult, "{0:n}", PNRLoyer_02_11);
            etatPlanTresorerieModel.EncaissementRecusClients_02_11 = string.Format(frCult, "{0:n}", EncaissementRecusClients_02_11);
            etatPlanTresorerieModel.TotalRecette_02_11 = string.Format(frCult, "{0:n}", TotalRecette_02_11);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_02_11 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_02_11);
            etatPlanTresorerieModel.DecaissementFournisseurs_02_11 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_02_11);
            etatPlanTresorerieModel.DecaissementPrestataires_02_11 = string.Format(frCult, "{0:n}", DecaissementPrestataires_02_11);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_02_11 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_02_11);
            etatPlanTresorerieModel.DecaissementSalairesNets_02_11 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_02_11);
            etatPlanTresorerieModel.CotisationsSociales_02_11 = string.Format(frCult, "{0:n}", CotisationsSociales_02_11);
            etatPlanTresorerieModel.IRGSalaires_02_11 = string.Format(frCult, "{0:n}", IRGSalaires_02_11);
            etatPlanTresorerieModel.TVAPayer_02_11 = string.Format(frCult, "{0:n}", TVAPayer_02_11);
            etatPlanTresorerieModel.IBS_IFU_02_11 = string.Format(frCult, "{0:n}", IBS_IFU_02_11);
            etatPlanTresorerieModel.TotalDepense_02_11 = string.Format(frCult, "{0:n}", TotalDepense_02_11);
            etatPlanTresorerieModel.SoldeFinal_02_11 = string.Format(frCult, "{0:n}", SoldeFinal_02_11);

            #endregion

            #region Données EtatPlanTresorerie Année02 Mois12

            etatPlanTresorerieModel.SoldeInitial_02_12 = string.Format(frCult, "{0:n}", SoldeInitial_02_12);
            etatPlanTresorerieModel.ApportSupplementaire_02_12 = string.Format(frCult, "{0:n}", ApportSupplementaire_02_12);
            etatPlanTresorerieModel.CMT_02_12 = string.Format(frCult, "{0:n}", CMT_02_12);
            etatPlanTresorerieModel.PNRClassique_02_12 = string.Format(frCult, "{0:n}", PNRClassique_02_12);
            etatPlanTresorerieModel.ApportPersonnel_02_12 = string.Format(frCult, "{0:n}", ApportPersonnel_02_12);
            etatPlanTresorerieModel.PNRLoyer_02_12 = string.Format(frCult, "{0:n}", PNRLoyer_02_12);
            etatPlanTresorerieModel.EncaissementRecusClients_02_12 = string.Format(frCult, "{0:n}", EncaissementRecusClients_02_12);
            etatPlanTresorerieModel.TotalRecette_02_12 = string.Format(frCult, "{0:n}", TotalRecette_02_12);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_02_12 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_02_12);
            etatPlanTresorerieModel.DecaissementFournisseurs_02_12 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_02_12);
            etatPlanTresorerieModel.DecaissementPrestataires_02_12 = string.Format(frCult, "{0:n}", DecaissementPrestataires_02_12);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_02_12 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_02_12);
            etatPlanTresorerieModel.DecaissementSalairesNets_02_12 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_02_12);
            etatPlanTresorerieModel.CotisationsSociales_02_12 = string.Format(frCult, "{0:n}", CotisationsSociales_02_12);
            etatPlanTresorerieModel.IRGSalaires_02_12 = string.Format(frCult, "{0:n}", IRGSalaires_02_12);
            etatPlanTresorerieModel.TVAPayer_02_12 = string.Format(frCult, "{0:n}", TVAPayer_02_12);
            etatPlanTresorerieModel.IBS_IFU_02_12 = string.Format(frCult, "{0:n}", IBS_IFU_02_12);
            etatPlanTresorerieModel.TotalDepense_02_12 = string.Format(frCult, "{0:n}", TotalDepense_02_12);
            etatPlanTresorerieModel.SoldeFinal_02_12 = string.Format(frCult, "{0:n}", SoldeFinal_02_12);

            #endregion

            #endregion

            #region Données etatPlanTresorerieModel Année03

            #region Données EtatPlanTresorerie Année03 Mois01

            etatPlanTresorerieModel.SoldeInitial_03_01 = string.Format(frCult, "{0:n}", SoldeInitial_03_01);
            etatPlanTresorerieModel.ApportSupplementaire_03_01 = string.Format(frCult, "{0:n}", ApportSupplementaire_03_01);
            etatPlanTresorerieModel.CMT_03_01 = string.Format(frCult, "{0:n}", CMT_03_01);
            etatPlanTresorerieModel.PNRClassique_03_01 = string.Format(frCult, "{0:n}", PNRClassique_03_01);
            etatPlanTresorerieModel.ApportPersonnel_03_01 = string.Format(frCult, "{0:n}", ApportPersonnel_03_01);
            etatPlanTresorerieModel.PNRLoyer_03_01 = string.Format(frCult, "{0:n}", PNRLoyer_03_01);
            etatPlanTresorerieModel.EncaissementRecusClients_03_01 = string.Format(frCult, "{0:n}", EncaissementRecusClients_03_01);
            etatPlanTresorerieModel.TotalRecette_03_01 = string.Format(frCult, "{0:n}", TotalRecette_03_01);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_03_01 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_03_01);
            etatPlanTresorerieModel.DecaissementFournisseurs_03_01 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_03_01);
            etatPlanTresorerieModel.DecaissementPrestataires_03_01 = string.Format(frCult, "{0:n}", DecaissementPrestataires_03_01);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_03_01 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_03_01);
            etatPlanTresorerieModel.DecaissementSalairesNets_03_01 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_03_01);
            etatPlanTresorerieModel.CotisationsSociales_03_01 = string.Format(frCult, "{0:n}", CotisationsSociales_03_01);
            etatPlanTresorerieModel.IRGSalaires_03_01 = string.Format(frCult, "{0:n}", IRGSalaires_03_01);
            etatPlanTresorerieModel.TVAPayer_03_01 = string.Format(frCult, "{0:n}", TVAPayer_03_01);
            etatPlanTresorerieModel.IBS_IFU_03_01 = string.Format(frCult, "{0:n}", IBS_IFU_03_01);
            etatPlanTresorerieModel.TotalDepense_03_01 = string.Format(frCult, "{0:n}", TotalDepense_03_01);
            etatPlanTresorerieModel.SoldeFinal_03_01 = string.Format(frCult, "{0:n}", SoldeFinal_03_01);

            #endregion

            #region Données EtatPlanTresorerie Année03 Mois02

            etatPlanTresorerieModel.SoldeInitial_03_02 = string.Format(frCult, "{0:n}", SoldeInitial_03_02);
            etatPlanTresorerieModel.ApportSupplementaire_03_02 = string.Format(frCult, "{0:n}", ApportSupplementaire_03_02);
            etatPlanTresorerieModel.CMT_03_02 = string.Format(frCult, "{0:n}", CMT_03_02);
            etatPlanTresorerieModel.PNRClassique_03_02 = string.Format(frCult, "{0:n}", PNRClassique_03_02);
            etatPlanTresorerieModel.ApportPersonnel_03_02 = string.Format(frCult, "{0:n}", ApportPersonnel_03_02);
            etatPlanTresorerieModel.PNRLoyer_03_02 = string.Format(frCult, "{0:n}", PNRLoyer_03_02);
            etatPlanTresorerieModel.EncaissementRecusClients_03_02 = string.Format(frCult, "{0:n}", EncaissementRecusClients_03_02);
            etatPlanTresorerieModel.TotalRecette_03_02 = string.Format(frCult, "{0:n}", TotalRecette_03_02);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_03_02 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_03_02);
            etatPlanTresorerieModel.DecaissementFournisseurs_03_02 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_03_02);
            etatPlanTresorerieModel.DecaissementPrestataires_03_02 = string.Format(frCult, "{0:n}", DecaissementPrestataires_03_02);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_03_02 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_03_02);
            etatPlanTresorerieModel.DecaissementSalairesNets_03_02 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_03_02);
            etatPlanTresorerieModel.CotisationsSociales_03_02 = string.Format(frCult, "{0:n}", CotisationsSociales_03_02);
            etatPlanTresorerieModel.IRGSalaires_03_02 = string.Format(frCult, "{0:n}", IRGSalaires_03_02);
            etatPlanTresorerieModel.TVAPayer_03_02 = string.Format(frCult, "{0:n}", TVAPayer_03_02);
            etatPlanTresorerieModel.IBS_IFU_03_02 = string.Format(frCult, "{0:n}", IBS_IFU_03_02);
            etatPlanTresorerieModel.TotalDepense_03_02 = string.Format(frCult, "{0:n}", TotalDepense_03_02);
            etatPlanTresorerieModel.SoldeFinal_03_02 = string.Format(frCult, "{0:n}", SoldeFinal_03_02);

            #endregion

            #region Données EtatPlanTresorerie Année03 Mois03

            etatPlanTresorerieModel.SoldeInitial_03_03 = string.Format(frCult, "{0:n}", SoldeInitial_03_03);
            etatPlanTresorerieModel.ApportSupplementaire_03_03 = string.Format(frCult, "{0:n}", ApportSupplementaire_03_03);
            etatPlanTresorerieModel.CMT_03_03 = string.Format(frCult, "{0:n}", CMT_03_03);
            etatPlanTresorerieModel.PNRClassique_03_03 = string.Format(frCult, "{0:n}", PNRClassique_03_03);
            etatPlanTresorerieModel.ApportPersonnel_03_03 = string.Format(frCult, "{0:n}", ApportPersonnel_03_03);
            etatPlanTresorerieModel.PNRLoyer_03_03 = string.Format(frCult, "{0:n}", PNRLoyer_03_03);
            etatPlanTresorerieModel.EncaissementRecusClients_03_03 = string.Format(frCult, "{0:n}", EncaissementRecusClients_03_03);
            etatPlanTresorerieModel.TotalRecette_03_03 = string.Format(frCult, "{0:n}", TotalRecette_03_03);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_03_03 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_03_03);
            etatPlanTresorerieModel.DecaissementFournisseurs_03_03 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_03_03);
            etatPlanTresorerieModel.DecaissementPrestataires_03_03 = string.Format(frCult, "{0:n}", DecaissementPrestataires_03_03);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_03_03 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_03_03);
            etatPlanTresorerieModel.DecaissementSalairesNets_03_03 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_03_03);
            etatPlanTresorerieModel.CotisationsSociales_03_03 = string.Format(frCult, "{0:n}", CotisationsSociales_03_03);
            etatPlanTresorerieModel.IRGSalaires_03_03 = string.Format(frCult, "{0:n}", IRGSalaires_03_03);
            etatPlanTresorerieModel.TVAPayer_03_03 = string.Format(frCult, "{0:n}", TVAPayer_03_03);
            etatPlanTresorerieModel.IBS_IFU_03_03 = string.Format(frCult, "{0:n}", IBS_IFU_03_03);
            etatPlanTresorerieModel.TotalDepense_03_03 = string.Format(frCult, "{0:n}", TotalDepense_03_03);
            etatPlanTresorerieModel.SoldeFinal_03_03 = string.Format(frCult, "{0:n}", SoldeFinal_03_03);

            #endregion

            #region Données EtatPlanTresorerie Année03 Mois04

            etatPlanTresorerieModel.SoldeInitial_03_04 = string.Format(frCult, "{0:n}", SoldeInitial_03_04);
            etatPlanTresorerieModel.ApportSupplementaire_03_04 = string.Format(frCult, "{0:n}", ApportSupplementaire_03_04);
            etatPlanTresorerieModel.CMT_03_04 = string.Format(frCult, "{0:n}", CMT_03_04);
            etatPlanTresorerieModel.PNRClassique_03_04 = string.Format(frCult, "{0:n}", PNRClassique_03_04);
            etatPlanTresorerieModel.ApportPersonnel_03_04 = string.Format(frCult, "{0:n}", ApportPersonnel_03_04);
            etatPlanTresorerieModel.PNRLoyer_03_04 = string.Format(frCult, "{0:n}", PNRLoyer_03_04);
            etatPlanTresorerieModel.EncaissementRecusClients_03_04 = string.Format(frCult, "{0:n}", EncaissementRecusClients_03_04);
            etatPlanTresorerieModel.TotalRecette_03_04 = string.Format(frCult, "{0:n}", TotalRecette_03_04);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_03_04 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_03_04);
            etatPlanTresorerieModel.DecaissementFournisseurs_03_04 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_03_04);
            etatPlanTresorerieModel.DecaissementPrestataires_03_04 = string.Format(frCult, "{0:n}", DecaissementPrestataires_03_04);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_03_04 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_03_04);
            etatPlanTresorerieModel.DecaissementSalairesNets_03_04 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_03_04);
            etatPlanTresorerieModel.CotisationsSociales_03_04 = string.Format(frCult, "{0:n}", CotisationsSociales_03_04);
            etatPlanTresorerieModel.IRGSalaires_03_04 = string.Format(frCult, "{0:n}", IRGSalaires_03_04);
            etatPlanTresorerieModel.TVAPayer_03_04 = string.Format(frCult, "{0:n}", TVAPayer_03_04);
            etatPlanTresorerieModel.IBS_IFU_03_04 = string.Format(frCult, "{0:n}", IBS_IFU_03_04);
            etatPlanTresorerieModel.TotalDepense_03_04 = string.Format(frCult, "{0:n}", TotalDepense_03_04);
            etatPlanTresorerieModel.SoldeFinal_03_04 = string.Format(frCult, "{0:n}", SoldeFinal_03_04);

            #endregion

            #region Données EtatPlanTresorerie Année03 Mois05

            etatPlanTresorerieModel.SoldeInitial_03_05 = string.Format(frCult, "{0:n}", SoldeInitial_03_05);
            etatPlanTresorerieModel.ApportSupplementaire_03_05 = string.Format(frCult, "{0:n}", ApportSupplementaire_03_05);
            etatPlanTresorerieModel.CMT_03_05 = string.Format(frCult, "{0:n}", CMT_03_05);
            etatPlanTresorerieModel.PNRClassique_03_05 = string.Format(frCult, "{0:n}", PNRClassique_03_05);
            etatPlanTresorerieModel.ApportPersonnel_03_05 = string.Format(frCult, "{0:n}", ApportPersonnel_03_05);
            etatPlanTresorerieModel.PNRLoyer_03_05 = string.Format(frCult, "{0:n}", PNRLoyer_03_05);
            etatPlanTresorerieModel.EncaissementRecusClients_03_05 = string.Format(frCult, "{0:n}", EncaissementRecusClients_03_05);
            etatPlanTresorerieModel.TotalRecette_03_05 = string.Format(frCult, "{0:n}", TotalRecette_03_05);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_03_05 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_03_05);
            etatPlanTresorerieModel.DecaissementFournisseurs_03_05 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_03_05);
            etatPlanTresorerieModel.DecaissementPrestataires_03_05 = string.Format(frCult, "{0:n}", DecaissementPrestataires_03_05);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_03_05 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_03_05);
            etatPlanTresorerieModel.DecaissementSalairesNets_03_05 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_03_05);
            etatPlanTresorerieModel.CotisationsSociales_03_05 = string.Format(frCult, "{0:n}", CotisationsSociales_03_05);
            etatPlanTresorerieModel.IRGSalaires_03_05 = string.Format(frCult, "{0:n}", IRGSalaires_03_05);
            etatPlanTresorerieModel.TVAPayer_03_05 = string.Format(frCult, "{0:n}", TVAPayer_03_05);
            etatPlanTresorerieModel.IBS_IFU_03_05 = string.Format(frCult, "{0:n}", IBS_IFU_03_05);
            etatPlanTresorerieModel.TotalDepense_03_05 = string.Format(frCult, "{0:n}", TotalDepense_03_05);
            etatPlanTresorerieModel.SoldeFinal_03_05 = string.Format(frCult, "{0:n}", SoldeFinal_03_05);

            #endregion

            #region Données EtatPlanTresorerie Année03 Mois06

            etatPlanTresorerieModel.SoldeInitial_03_06 = string.Format(frCult, "{0:n}", SoldeInitial_03_06);
            etatPlanTresorerieModel.ApportSupplementaire_03_06 = string.Format(frCult, "{0:n}", ApportSupplementaire_03_06);
            etatPlanTresorerieModel.CMT_03_06 = string.Format(frCult, "{0:n}", CMT_03_06);
            etatPlanTresorerieModel.PNRClassique_03_06 = string.Format(frCult, "{0:n}", PNRClassique_03_06);
            etatPlanTresorerieModel.ApportPersonnel_03_06 = string.Format(frCult, "{0:n}", ApportPersonnel_03_06);
            etatPlanTresorerieModel.PNRLoyer_03_06 = string.Format(frCult, "{0:n}", PNRLoyer_03_06);
            etatPlanTresorerieModel.EncaissementRecusClients_03_06 = string.Format(frCult, "{0:n}", EncaissementRecusClients_03_06);
            etatPlanTresorerieModel.TotalRecette_03_06 = string.Format(frCult, "{0:n}", TotalRecette_03_06);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_03_06 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_03_06);
            etatPlanTresorerieModel.DecaissementFournisseurs_03_06 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_03_06);
            etatPlanTresorerieModel.DecaissementPrestataires_03_06 = string.Format(frCult, "{0:n}", DecaissementPrestataires_03_06);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_03_06 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_03_06);
            etatPlanTresorerieModel.DecaissementSalairesNets_03_06 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_03_06);
            etatPlanTresorerieModel.CotisationsSociales_03_06 = string.Format(frCult, "{0:n}", CotisationsSociales_03_06);
            etatPlanTresorerieModel.IRGSalaires_03_06 = string.Format(frCult, "{0:n}", IRGSalaires_03_06);
            etatPlanTresorerieModel.TVAPayer_03_06 = string.Format(frCult, "{0:n}", TVAPayer_03_06);
            etatPlanTresorerieModel.IBS_IFU_03_06 = string.Format(frCult, "{0:n}", IBS_IFU_03_06);
            etatPlanTresorerieModel.TotalDepense_03_06 = string.Format(frCult, "{0:n}", TotalDepense_03_06);
            etatPlanTresorerieModel.SoldeFinal_03_06 = string.Format(frCult, "{0:n}", SoldeFinal_03_06);

            #endregion

            #region Données EtatPlanTresorerie Année03 Mois07

            etatPlanTresorerieModel.SoldeInitial_03_07 = string.Format(frCult, "{0:n}", SoldeInitial_03_07);
            etatPlanTresorerieModel.ApportSupplementaire_03_07 = string.Format(frCult, "{0:n}", ApportSupplementaire_03_07);
            etatPlanTresorerieModel.CMT_03_07 = string.Format(frCult, "{0:n}", CMT_03_07);
            etatPlanTresorerieModel.PNRClassique_03_07 = string.Format(frCult, "{0:n}", PNRClassique_03_07);
            etatPlanTresorerieModel.ApportPersonnel_03_07 = string.Format(frCult, "{0:n}", ApportPersonnel_03_07);
            etatPlanTresorerieModel.PNRLoyer_03_07 = string.Format(frCult, "{0:n}", PNRLoyer_03_07);
            etatPlanTresorerieModel.EncaissementRecusClients_03_07 = string.Format(frCult, "{0:n}", EncaissementRecusClients_03_07);
            etatPlanTresorerieModel.TotalRecette_03_07 = string.Format(frCult, "{0:n}", TotalRecette_03_07);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_03_07 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_03_07);
            etatPlanTresorerieModel.DecaissementFournisseurs_03_07 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_03_07);
            etatPlanTresorerieModel.DecaissementPrestataires_03_07 = string.Format(frCult, "{0:n}", DecaissementPrestataires_03_07);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_03_07 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_03_07);
            etatPlanTresorerieModel.DecaissementSalairesNets_03_07 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_03_07);
            etatPlanTresorerieModel.CotisationsSociales_03_07 = string.Format(frCult, "{0:n}", CotisationsSociales_03_07);
            etatPlanTresorerieModel.IRGSalaires_03_07 = string.Format(frCult, "{0:n}", IRGSalaires_03_07);
            etatPlanTresorerieModel.TVAPayer_03_07 = string.Format(frCult, "{0:n}", TVAPayer_03_07);
            etatPlanTresorerieModel.IBS_IFU_03_07 = string.Format(frCult, "{0:n}", IBS_IFU_03_07);
            etatPlanTresorerieModel.TotalDepense_03_07 = string.Format(frCult, "{0:n}", TotalDepense_03_07);
            etatPlanTresorerieModel.SoldeFinal_03_07 = string.Format(frCult, "{0:n}", SoldeFinal_03_07);

            #endregion

            #region Données EtatPlanTresorerie Année03 Mois08

            etatPlanTresorerieModel.SoldeInitial_03_08 = string.Format(frCult, "{0:n}", SoldeInitial_03_08);
            etatPlanTresorerieModel.ApportSupplementaire_03_08 = string.Format(frCult, "{0:n}", ApportSupplementaire_03_08);
            etatPlanTresorerieModel.CMT_03_08 = string.Format(frCult, "{0:n}", CMT_03_08);
            etatPlanTresorerieModel.PNRClassique_03_08 = string.Format(frCult, "{0:n}", PNRClassique_03_08);
            etatPlanTresorerieModel.ApportPersonnel_03_08 = string.Format(frCult, "{0:n}", ApportPersonnel_03_08);
            etatPlanTresorerieModel.PNRLoyer_03_08 = string.Format(frCult, "{0:n}", PNRLoyer_03_08);
            etatPlanTresorerieModel.EncaissementRecusClients_03_08 = string.Format(frCult, "{0:n}", EncaissementRecusClients_03_08);
            etatPlanTresorerieModel.TotalRecette_03_08 = string.Format(frCult, "{0:n}", TotalRecette_03_08);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_03_08 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_03_08);
            etatPlanTresorerieModel.DecaissementFournisseurs_03_08 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_03_08);
            etatPlanTresorerieModel.DecaissementPrestataires_03_08 = string.Format(frCult, "{0:n}", DecaissementPrestataires_03_08);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_03_08 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_03_08);
            etatPlanTresorerieModel.DecaissementSalairesNets_03_08 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_03_08);
            etatPlanTresorerieModel.CotisationsSociales_03_08 = string.Format(frCult, "{0:n}", CotisationsSociales_03_08);
            etatPlanTresorerieModel.IRGSalaires_03_08 = string.Format(frCult, "{0:n}", IRGSalaires_03_08);
            etatPlanTresorerieModel.TVAPayer_03_08 = string.Format(frCult, "{0:n}", TVAPayer_03_08);
            etatPlanTresorerieModel.IBS_IFU_03_08 = string.Format(frCult, "{0:n}", IBS_IFU_03_08);
            etatPlanTresorerieModel.TotalDepense_03_08 = string.Format(frCult, "{0:n}", TotalDepense_03_08);
            etatPlanTresorerieModel.SoldeFinal_03_08 = string.Format(frCult, "{0:n}", SoldeFinal_03_08);

            #endregion

            #region Données EtatPlanTresorerie Année03 Mois09

            etatPlanTresorerieModel.SoldeInitial_03_09 = string.Format(frCult, "{0:n}", SoldeInitial_03_09);
            etatPlanTresorerieModel.ApportSupplementaire_03_09 = string.Format(frCult, "{0:n}", ApportSupplementaire_03_09);
            etatPlanTresorerieModel.CMT_03_09 = string.Format(frCult, "{0:n}", CMT_03_09);
            etatPlanTresorerieModel.PNRClassique_03_09 = string.Format(frCult, "{0:n}", PNRClassique_03_09);
            etatPlanTresorerieModel.ApportPersonnel_03_09 = string.Format(frCult, "{0:n}", ApportPersonnel_03_09);
            etatPlanTresorerieModel.PNRLoyer_03_09 = string.Format(frCult, "{0:n}", PNRLoyer_03_09);
            etatPlanTresorerieModel.EncaissementRecusClients_03_09 = string.Format(frCult, "{0:n}", EncaissementRecusClients_03_09);
            etatPlanTresorerieModel.TotalRecette_03_09 = string.Format(frCult, "{0:n}", TotalRecette_03_09);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_03_09 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_03_09);
            etatPlanTresorerieModel.DecaissementFournisseurs_03_09 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_03_09);
            etatPlanTresorerieModel.DecaissementPrestataires_03_09 = string.Format(frCult, "{0:n}", DecaissementPrestataires_03_09);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_03_09 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_03_09);
            etatPlanTresorerieModel.DecaissementSalairesNets_03_09 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_03_09);
            etatPlanTresorerieModel.CotisationsSociales_03_09 = string.Format(frCult, "{0:n}", CotisationsSociales_03_09);
            etatPlanTresorerieModel.IRGSalaires_03_09 = string.Format(frCult, "{0:n}", IRGSalaires_03_09);
            etatPlanTresorerieModel.TVAPayer_03_09 = string.Format(frCult, "{0:n}", TVAPayer_03_09);
            etatPlanTresorerieModel.IBS_IFU_03_09 = string.Format(frCult, "{0:n}", IBS_IFU_03_09);
            etatPlanTresorerieModel.TotalDepense_03_09 = string.Format(frCult, "{0:n}", TotalDepense_03_09);
            etatPlanTresorerieModel.SoldeFinal_03_09 = string.Format(frCult, "{0:n}", SoldeFinal_03_09);

            #endregion

            #region Données EtatPlanTresorerie Année03 Mois10

            etatPlanTresorerieModel.SoldeInitial_03_10 = string.Format(frCult, "{0:n}", SoldeInitial_03_10);
            etatPlanTresorerieModel.ApportSupplementaire_03_10 = string.Format(frCult, "{0:n}", ApportSupplementaire_03_10);
            etatPlanTresorerieModel.CMT_03_10 = string.Format(frCult, "{0:n}", CMT_03_10);
            etatPlanTresorerieModel.PNRClassique_03_10 = string.Format(frCult, "{0:n}", PNRClassique_03_10);
            etatPlanTresorerieModel.ApportPersonnel_03_10 = string.Format(frCult, "{0:n}", ApportPersonnel_03_10);
            etatPlanTresorerieModel.PNRLoyer_03_10 = string.Format(frCult, "{0:n}", PNRLoyer_03_10);
            etatPlanTresorerieModel.EncaissementRecusClients_03_10 = string.Format(frCult, "{0:n}", EncaissementRecusClients_03_10);
            etatPlanTresorerieModel.TotalRecette_03_10 = string.Format(frCult, "{0:n}", TotalRecette_03_10);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_03_10 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_03_10);
            etatPlanTresorerieModel.DecaissementFournisseurs_03_10 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_03_10);
            etatPlanTresorerieModel.DecaissementPrestataires_03_10 = string.Format(frCult, "{0:n}", DecaissementPrestataires_03_10);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_03_10 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_03_10);
            etatPlanTresorerieModel.DecaissementSalairesNets_03_10 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_03_10);
            etatPlanTresorerieModel.CotisationsSociales_03_10 = string.Format(frCult, "{0:n}", CotisationsSociales_03_10);
            etatPlanTresorerieModel.IRGSalaires_03_10 = string.Format(frCult, "{0:n}", IRGSalaires_03_10);
            etatPlanTresorerieModel.TVAPayer_03_10 = string.Format(frCult, "{0:n}", TVAPayer_03_10);
            etatPlanTresorerieModel.IBS_IFU_03_10 = string.Format(frCult, "{0:n}", IBS_IFU_03_10);
            etatPlanTresorerieModel.TotalDepense_03_10 = string.Format(frCult, "{0:n}", TotalDepense_03_10);
            etatPlanTresorerieModel.SoldeFinal_03_10 = string.Format(frCult, "{0:n}", SoldeFinal_03_10);

            #endregion

            #region Données EtatPlanTresorerie Année03 Mois11

            etatPlanTresorerieModel.SoldeInitial_03_11 = string.Format(frCult, "{0:n}", SoldeInitial_03_11);
            etatPlanTresorerieModel.ApportSupplementaire_03_11 = string.Format(frCult, "{0:n}", ApportSupplementaire_03_11);
            etatPlanTresorerieModel.CMT_03_11 = string.Format(frCult, "{0:n}", CMT_03_11);
            etatPlanTresorerieModel.PNRClassique_03_11 = string.Format(frCult, "{0:n}", PNRClassique_03_11);
            etatPlanTresorerieModel.ApportPersonnel_03_11 = string.Format(frCult, "{0:n}", ApportPersonnel_03_11);
            etatPlanTresorerieModel.PNRLoyer_03_11 = string.Format(frCult, "{0:n}", PNRLoyer_03_11);
            etatPlanTresorerieModel.EncaissementRecusClients_03_11 = string.Format(frCult, "{0:n}", EncaissementRecusClients_03_11);
            etatPlanTresorerieModel.TotalRecette_03_11 = string.Format(frCult, "{0:n}", TotalRecette_03_11);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_03_11 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_03_11);
            etatPlanTresorerieModel.DecaissementFournisseurs_03_11 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_03_11);
            etatPlanTresorerieModel.DecaissementPrestataires_03_11 = string.Format(frCult, "{0:n}", DecaissementPrestataires_03_11);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_03_11 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_03_11);
            etatPlanTresorerieModel.DecaissementSalairesNets_03_11 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_03_11);
            etatPlanTresorerieModel.CotisationsSociales_03_11 = string.Format(frCult, "{0:n}", CotisationsSociales_03_11);
            etatPlanTresorerieModel.IRGSalaires_03_11 = string.Format(frCult, "{0:n}", IRGSalaires_03_11);
            etatPlanTresorerieModel.TVAPayer_03_11 = string.Format(frCult, "{0:n}", TVAPayer_03_11);
            etatPlanTresorerieModel.IBS_IFU_03_11 = string.Format(frCult, "{0:n}", IBS_IFU_03_11);
            etatPlanTresorerieModel.TotalDepense_03_11 = string.Format(frCult, "{0:n}", TotalDepense_03_11);
            etatPlanTresorerieModel.SoldeFinal_03_11 = string.Format(frCult, "{0:n}", SoldeFinal_03_11);

            #endregion

            #region Données EtatPlanTresorerie Année03 Mois12

            etatPlanTresorerieModel.SoldeInitial_03_12 = string.Format(frCult, "{0:n}", SoldeInitial_03_12);
            etatPlanTresorerieModel.ApportSupplementaire_03_12 = string.Format(frCult, "{0:n}", ApportSupplementaire_03_12);
            etatPlanTresorerieModel.CMT_03_12 = string.Format(frCult, "{0:n}", CMT_03_12);
            etatPlanTresorerieModel.PNRClassique_03_12 = string.Format(frCult, "{0:n}", PNRClassique_03_12);
            etatPlanTresorerieModel.ApportPersonnel_03_12 = string.Format(frCult, "{0:n}", ApportPersonnel_03_12);
            etatPlanTresorerieModel.PNRLoyer_03_12 = string.Format(frCult, "{0:n}", PNRLoyer_03_12);
            etatPlanTresorerieModel.EncaissementRecusClients_03_12 = string.Format(frCult, "{0:n}", EncaissementRecusClients_03_12);
            etatPlanTresorerieModel.TotalRecette_03_12 = string.Format(frCult, "{0:n}", TotalRecette_03_12);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_03_12 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_03_12);
            etatPlanTresorerieModel.DecaissementFournisseurs_03_12 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_03_12);
            etatPlanTresorerieModel.DecaissementPrestataires_03_12 = string.Format(frCult, "{0:n}", DecaissementPrestataires_03_12);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_03_12 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_03_12);
            etatPlanTresorerieModel.DecaissementSalairesNets_03_12 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_03_12);
            etatPlanTresorerieModel.CotisationsSociales_03_12 = string.Format(frCult, "{0:n}", CotisationsSociales_03_12);
            etatPlanTresorerieModel.IRGSalaires_03_12 = string.Format(frCult, "{0:n}", IRGSalaires_03_12);
            etatPlanTresorerieModel.TVAPayer_03_12 = string.Format(frCult, "{0:n}", TVAPayer_03_12);
            etatPlanTresorerieModel.IBS_IFU_03_12 = string.Format(frCult, "{0:n}", IBS_IFU_03_12);
            etatPlanTresorerieModel.TotalDepense_03_12 = string.Format(frCult, "{0:n}", TotalDepense_03_12);
            etatPlanTresorerieModel.SoldeFinal_03_12 = string.Format(frCult, "{0:n}", SoldeFinal_03_12);

            #endregion

            #endregion

            #region Données etatPlanTresorerieModel Année04

            #region Données EtatPlanTresorerie Année04 Mois01

            etatPlanTresorerieModel.SoldeInitial_04_01 = string.Format(frCult, "{0:n}", SoldeInitial_04_01);
            etatPlanTresorerieModel.ApportSupplementaire_04_01 = string.Format(frCult, "{0:n}", ApportSupplementaire_04_01);
            etatPlanTresorerieModel.CMT_04_01 = string.Format(frCult, "{0:n}", CMT_04_01);
            etatPlanTresorerieModel.PNRClassique_04_01 = string.Format(frCult, "{0:n}", PNRClassique_04_01);
            etatPlanTresorerieModel.ApportPersonnel_04_01 = string.Format(frCult, "{0:n}", ApportPersonnel_04_01);
            etatPlanTresorerieModel.PNRLoyer_04_01 = string.Format(frCult, "{0:n}", PNRLoyer_04_01);
            etatPlanTresorerieModel.EncaissementRecusClients_04_01 = string.Format(frCult, "{0:n}", EncaissementRecusClients_04_01);
            etatPlanTresorerieModel.TotalRecette_04_01 = string.Format(frCult, "{0:n}", TotalRecette_04_01);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_04_01 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_04_01);
            etatPlanTresorerieModel.DecaissementFournisseurs_04_01 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_04_01);
            etatPlanTresorerieModel.DecaissementPrestataires_04_01 = string.Format(frCult, "{0:n}", DecaissementPrestataires_04_01);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_04_01 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_04_01);
            etatPlanTresorerieModel.DecaissementSalairesNets_04_01 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_04_01);
            etatPlanTresorerieModel.CotisationsSociales_04_01 = string.Format(frCult, "{0:n}", CotisationsSociales_04_01);
            etatPlanTresorerieModel.IRGSalaires_04_01 = string.Format(frCult, "{0:n}", IRGSalaires_04_01);
            etatPlanTresorerieModel.TVAPayer_04_01 = string.Format(frCult, "{0:n}", TVAPayer_04_01);
            etatPlanTresorerieModel.IBS_IFU_04_01 = string.Format(frCult, "{0:n}", IBS_IFU_04_01);
            etatPlanTresorerieModel.TotalDepense_04_01 = string.Format(frCult, "{0:n}", TotalDepense_04_01);
            etatPlanTresorerieModel.SoldeFinal_04_01 = string.Format(frCult, "{0:n}", SoldeFinal_04_01);

            #endregion

            #region Données EtatPlanTresorerie Année04 Mois02

            etatPlanTresorerieModel.SoldeInitial_04_02 = string.Format(frCult, "{0:n}", SoldeInitial_04_02);
            etatPlanTresorerieModel.ApportSupplementaire_04_02 = string.Format(frCult, "{0:n}", ApportSupplementaire_04_02);
            etatPlanTresorerieModel.CMT_04_02 = string.Format(frCult, "{0:n}", CMT_04_02);
            etatPlanTresorerieModel.PNRClassique_04_02 = string.Format(frCult, "{0:n}", PNRClassique_04_02);
            etatPlanTresorerieModel.ApportPersonnel_04_02 = string.Format(frCult, "{0:n}", ApportPersonnel_04_02);
            etatPlanTresorerieModel.PNRLoyer_04_02 = string.Format(frCult, "{0:n}", PNRLoyer_04_02);
            etatPlanTresorerieModel.EncaissementRecusClients_04_02 = string.Format(frCult, "{0:n}", EncaissementRecusClients_04_02);
            etatPlanTresorerieModel.TotalRecette_04_02 = string.Format(frCult, "{0:n}", TotalRecette_04_02);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_04_02 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_04_02);
            etatPlanTresorerieModel.DecaissementFournisseurs_04_02 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_04_02);
            etatPlanTresorerieModel.DecaissementPrestataires_04_02 = string.Format(frCult, "{0:n}", DecaissementPrestataires_04_02);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_04_02 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_04_02);
            etatPlanTresorerieModel.DecaissementSalairesNets_04_02 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_04_02);
            etatPlanTresorerieModel.CotisationsSociales_04_02 = string.Format(frCult, "{0:n}", CotisationsSociales_04_02);
            etatPlanTresorerieModel.IRGSalaires_04_02 = string.Format(frCult, "{0:n}", IRGSalaires_04_02);
            etatPlanTresorerieModel.TVAPayer_04_02 = string.Format(frCult, "{0:n}", TVAPayer_04_02);
            etatPlanTresorerieModel.IBS_IFU_04_02 = string.Format(frCult, "{0:n}", IBS_IFU_04_02);
            etatPlanTresorerieModel.TotalDepense_04_02 = string.Format(frCult, "{0:n}", TotalDepense_04_02);
            etatPlanTresorerieModel.SoldeFinal_04_02 = string.Format(frCult, "{0:n}", SoldeFinal_04_02);

            #endregion

            #region Données EtatPlanTresorerie Année04 Mois03

            etatPlanTresorerieModel.SoldeInitial_04_03 = string.Format(frCult, "{0:n}", SoldeInitial_04_03);
            etatPlanTresorerieModel.ApportSupplementaire_04_03 = string.Format(frCult, "{0:n}", ApportSupplementaire_04_03);
            etatPlanTresorerieModel.CMT_04_03 = string.Format(frCult, "{0:n}", CMT_04_03);
            etatPlanTresorerieModel.PNRClassique_04_03 = string.Format(frCult, "{0:n}", PNRClassique_04_03);
            etatPlanTresorerieModel.ApportPersonnel_04_03 = string.Format(frCult, "{0:n}", ApportPersonnel_04_03);
            etatPlanTresorerieModel.PNRLoyer_04_03 = string.Format(frCult, "{0:n}", PNRLoyer_04_03);
            etatPlanTresorerieModel.EncaissementRecusClients_04_03 = string.Format(frCult, "{0:n}", EncaissementRecusClients_04_03);
            etatPlanTresorerieModel.TotalRecette_04_03 = string.Format(frCult, "{0:n}", TotalRecette_04_03);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_04_03 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_04_03);
            etatPlanTresorerieModel.DecaissementFournisseurs_04_03 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_04_03);
            etatPlanTresorerieModel.DecaissementPrestataires_04_03 = string.Format(frCult, "{0:n}", DecaissementPrestataires_04_03);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_04_03 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_04_03);
            etatPlanTresorerieModel.DecaissementSalairesNets_04_03 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_04_03);
            etatPlanTresorerieModel.CotisationsSociales_04_03 = string.Format(frCult, "{0:n}", CotisationsSociales_04_03);
            etatPlanTresorerieModel.IRGSalaires_04_03 = string.Format(frCult, "{0:n}", IRGSalaires_04_03);
            etatPlanTresorerieModel.TVAPayer_04_03 = string.Format(frCult, "{0:n}", TVAPayer_04_03);
            etatPlanTresorerieModel.IBS_IFU_04_03 = string.Format(frCult, "{0:n}", IBS_IFU_04_03);
            etatPlanTresorerieModel.TotalDepense_04_03 = string.Format(frCult, "{0:n}", TotalDepense_04_03);
            etatPlanTresorerieModel.SoldeFinal_04_03 = string.Format(frCult, "{0:n}", SoldeFinal_04_03);

            #endregion

            #region Données EtatPlanTresorerie Année04 Mois04

            etatPlanTresorerieModel.SoldeInitial_04_04 = string.Format(frCult, "{0:n}", SoldeInitial_04_04);
            etatPlanTresorerieModel.ApportSupplementaire_04_04 = string.Format(frCult, "{0:n}", ApportSupplementaire_04_04);
            etatPlanTresorerieModel.CMT_04_04 = string.Format(frCult, "{0:n}", CMT_04_04);
            etatPlanTresorerieModel.PNRClassique_04_04 = string.Format(frCult, "{0:n}", PNRClassique_04_04);
            etatPlanTresorerieModel.ApportPersonnel_04_04 = string.Format(frCult, "{0:n}", ApportPersonnel_04_04);
            etatPlanTresorerieModel.PNRLoyer_04_04 = string.Format(frCult, "{0:n}", PNRLoyer_04_04);
            etatPlanTresorerieModel.EncaissementRecusClients_04_04 = string.Format(frCult, "{0:n}", EncaissementRecusClients_04_04);
            etatPlanTresorerieModel.TotalRecette_04_04 = string.Format(frCult, "{0:n}", TotalRecette_04_04);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_04_04 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_04_04);
            etatPlanTresorerieModel.DecaissementFournisseurs_04_04 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_04_04);
            etatPlanTresorerieModel.DecaissementPrestataires_04_04 = string.Format(frCult, "{0:n}", DecaissementPrestataires_04_04);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_04_04 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_04_04);
            etatPlanTresorerieModel.DecaissementSalairesNets_04_04 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_04_04);
            etatPlanTresorerieModel.CotisationsSociales_04_04 = string.Format(frCult, "{0:n}", CotisationsSociales_04_04);
            etatPlanTresorerieModel.IRGSalaires_04_04 = string.Format(frCult, "{0:n}", IRGSalaires_04_04);
            etatPlanTresorerieModel.TVAPayer_04_04 = string.Format(frCult, "{0:n}", TVAPayer_04_04);
            etatPlanTresorerieModel.IBS_IFU_04_04 = string.Format(frCult, "{0:n}", IBS_IFU_04_04);
            etatPlanTresorerieModel.TotalDepense_04_04 = string.Format(frCult, "{0:n}", TotalDepense_04_04);
            etatPlanTresorerieModel.SoldeFinal_04_04 = string.Format(frCult, "{0:n}", SoldeFinal_04_04);

            #endregion

            #region Données EtatPlanTresorerie Année04 Mois05

            etatPlanTresorerieModel.SoldeInitial_04_05 = string.Format(frCult, "{0:n}", SoldeInitial_04_05);
            etatPlanTresorerieModel.ApportSupplementaire_04_05 = string.Format(frCult, "{0:n}", ApportSupplementaire_04_05);
            etatPlanTresorerieModel.CMT_04_05 = string.Format(frCult, "{0:n}", CMT_04_05);
            etatPlanTresorerieModel.PNRClassique_04_05 = string.Format(frCult, "{0:n}", PNRClassique_04_05);
            etatPlanTresorerieModel.ApportPersonnel_04_05 = string.Format(frCult, "{0:n}", ApportPersonnel_04_05);
            etatPlanTresorerieModel.PNRLoyer_04_05 = string.Format(frCult, "{0:n}", PNRLoyer_04_05);
            etatPlanTresorerieModel.EncaissementRecusClients_04_05 = string.Format(frCult, "{0:n}", EncaissementRecusClients_04_05);
            etatPlanTresorerieModel.TotalRecette_04_05 = string.Format(frCult, "{0:n}", TotalRecette_04_05);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_04_05 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_04_05);
            etatPlanTresorerieModel.DecaissementFournisseurs_04_05 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_04_05);
            etatPlanTresorerieModel.DecaissementPrestataires_04_05 = string.Format(frCult, "{0:n}", DecaissementPrestataires_04_05);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_04_05 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_04_05);
            etatPlanTresorerieModel.DecaissementSalairesNets_04_05 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_04_05);
            etatPlanTresorerieModel.CotisationsSociales_04_05 = string.Format(frCult, "{0:n}", CotisationsSociales_04_05);
            etatPlanTresorerieModel.IRGSalaires_04_05 = string.Format(frCult, "{0:n}", IRGSalaires_04_05);
            etatPlanTresorerieModel.TVAPayer_04_05 = string.Format(frCult, "{0:n}", TVAPayer_04_05);
            etatPlanTresorerieModel.IBS_IFU_04_05 = string.Format(frCult, "{0:n}", IBS_IFU_04_05);
            etatPlanTresorerieModel.TotalDepense_04_05 = string.Format(frCult, "{0:n}", TotalDepense_04_05);
            etatPlanTresorerieModel.SoldeFinal_04_05 = string.Format(frCult, "{0:n}", SoldeFinal_04_05);

            #endregion

            #region Données EtatPlanTresorerie Année04 Mois06

            etatPlanTresorerieModel.SoldeInitial_04_06 = string.Format(frCult, "{0:n}", SoldeInitial_04_06);
            etatPlanTresorerieModel.ApportSupplementaire_04_06 = string.Format(frCult, "{0:n}", ApportSupplementaire_04_06);
            etatPlanTresorerieModel.CMT_04_06 = string.Format(frCult, "{0:n}", CMT_04_06);
            etatPlanTresorerieModel.PNRClassique_04_06 = string.Format(frCult, "{0:n}", PNRClassique_04_06);
            etatPlanTresorerieModel.ApportPersonnel_04_06 = string.Format(frCult, "{0:n}", ApportPersonnel_04_06);
            etatPlanTresorerieModel.PNRLoyer_04_06 = string.Format(frCult, "{0:n}", PNRLoyer_04_06);
            etatPlanTresorerieModel.EncaissementRecusClients_04_06 = string.Format(frCult, "{0:n}", EncaissementRecusClients_04_06);
            etatPlanTresorerieModel.TotalRecette_04_06 = string.Format(frCult, "{0:n}", TotalRecette_04_06);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_04_06 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_04_06);
            etatPlanTresorerieModel.DecaissementFournisseurs_04_06 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_04_06);
            etatPlanTresorerieModel.DecaissementPrestataires_04_06 = string.Format(frCult, "{0:n}", DecaissementPrestataires_04_06);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_04_06 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_04_06);
            etatPlanTresorerieModel.DecaissementSalairesNets_04_06 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_04_06);
            etatPlanTresorerieModel.CotisationsSociales_04_06 = string.Format(frCult, "{0:n}", CotisationsSociales_04_06);
            etatPlanTresorerieModel.IRGSalaires_04_06 = string.Format(frCult, "{0:n}", IRGSalaires_04_06);
            etatPlanTresorerieModel.TVAPayer_04_06 = string.Format(frCult, "{0:n}", TVAPayer_04_06);
            etatPlanTresorerieModel.IBS_IFU_04_06 = string.Format(frCult, "{0:n}", IBS_IFU_04_06);
            etatPlanTresorerieModel.TotalDepense_04_06 = string.Format(frCult, "{0:n}", TotalDepense_04_06);
            etatPlanTresorerieModel.SoldeFinal_04_06 = string.Format(frCult, "{0:n}", SoldeFinal_04_06);

            #endregion

            #region Données EtatPlanTresorerie Année04 Mois07

            etatPlanTresorerieModel.SoldeInitial_04_07 = string.Format(frCult, "{0:n}", SoldeInitial_04_07);
            etatPlanTresorerieModel.ApportSupplementaire_04_07 = string.Format(frCult, "{0:n}", ApportSupplementaire_04_07);
            etatPlanTresorerieModel.CMT_04_07 = string.Format(frCult, "{0:n}", CMT_04_07);
            etatPlanTresorerieModel.PNRClassique_04_07 = string.Format(frCult, "{0:n}", PNRClassique_04_07);
            etatPlanTresorerieModel.ApportPersonnel_04_07 = string.Format(frCult, "{0:n}", ApportPersonnel_04_07);
            etatPlanTresorerieModel.PNRLoyer_04_07 = string.Format(frCult, "{0:n}", PNRLoyer_04_07);
            etatPlanTresorerieModel.EncaissementRecusClients_04_07 = string.Format(frCult, "{0:n}", EncaissementRecusClients_04_07);
            etatPlanTresorerieModel.TotalRecette_04_07 = string.Format(frCult, "{0:n}", TotalRecette_04_07);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_04_07 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_04_07);
            etatPlanTresorerieModel.DecaissementFournisseurs_04_07 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_04_07);
            etatPlanTresorerieModel.DecaissementPrestataires_04_07 = string.Format(frCult, "{0:n}", DecaissementPrestataires_04_07);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_04_07 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_04_07);
            etatPlanTresorerieModel.DecaissementSalairesNets_04_07 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_04_07);
            etatPlanTresorerieModel.CotisationsSociales_04_07 = string.Format(frCult, "{0:n}", CotisationsSociales_04_07);
            etatPlanTresorerieModel.IRGSalaires_04_07 = string.Format(frCult, "{0:n}", IRGSalaires_04_07);
            etatPlanTresorerieModel.TVAPayer_04_07 = string.Format(frCult, "{0:n}", TVAPayer_04_07);
            etatPlanTresorerieModel.IBS_IFU_04_07 = string.Format(frCult, "{0:n}", IBS_IFU_04_07);
            etatPlanTresorerieModel.TotalDepense_04_07 = string.Format(frCult, "{0:n}", TotalDepense_04_07);
            etatPlanTresorerieModel.SoldeFinal_04_07 = string.Format(frCult, "{0:n}", SoldeFinal_04_07);

            #endregion

            #region Données EtatPlanTresorerie Année04 Mois08

            etatPlanTresorerieModel.SoldeInitial_04_08 = string.Format(frCult, "{0:n}", SoldeInitial_04_08);
            etatPlanTresorerieModel.ApportSupplementaire_04_08 = string.Format(frCult, "{0:n}", ApportSupplementaire_04_08);
            etatPlanTresorerieModel.CMT_04_08 = string.Format(frCult, "{0:n}", CMT_04_08);
            etatPlanTresorerieModel.PNRClassique_04_08 = string.Format(frCult, "{0:n}", PNRClassique_04_08);
            etatPlanTresorerieModel.ApportPersonnel_04_08 = string.Format(frCult, "{0:n}", ApportPersonnel_04_08);
            etatPlanTresorerieModel.PNRLoyer_04_08 = string.Format(frCult, "{0:n}", PNRLoyer_04_08);
            etatPlanTresorerieModel.EncaissementRecusClients_04_08 = string.Format(frCult, "{0:n}", EncaissementRecusClients_04_08);
            etatPlanTresorerieModel.TotalRecette_04_08 = string.Format(frCult, "{0:n}", TotalRecette_04_08);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_04_08 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_04_08);
            etatPlanTresorerieModel.DecaissementFournisseurs_04_08 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_04_08);
            etatPlanTresorerieModel.DecaissementPrestataires_04_08 = string.Format(frCult, "{0:n}", DecaissementPrestataires_04_08);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_04_08 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_04_08);
            etatPlanTresorerieModel.DecaissementSalairesNets_04_08 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_04_08);
            etatPlanTresorerieModel.CotisationsSociales_04_08 = string.Format(frCult, "{0:n}", CotisationsSociales_04_08);
            etatPlanTresorerieModel.IRGSalaires_04_08 = string.Format(frCult, "{0:n}", IRGSalaires_04_08);
            etatPlanTresorerieModel.TVAPayer_04_08 = string.Format(frCult, "{0:n}", TVAPayer_04_08);
            etatPlanTresorerieModel.IBS_IFU_04_08 = string.Format(frCult, "{0:n}", IBS_IFU_04_08);
            etatPlanTresorerieModel.TotalDepense_04_08 = string.Format(frCult, "{0:n}", TotalDepense_04_08);
            etatPlanTresorerieModel.SoldeFinal_04_08 = string.Format(frCult, "{0:n}", SoldeFinal_04_08);

            #endregion

            #region Données EtatPlanTresorerie Année04 Mois09

            etatPlanTresorerieModel.SoldeInitial_04_09 = string.Format(frCult, "{0:n}", SoldeInitial_04_09);
            etatPlanTresorerieModel.ApportSupplementaire_04_09 = string.Format(frCult, "{0:n}", ApportSupplementaire_04_09);
            etatPlanTresorerieModel.CMT_04_09 = string.Format(frCult, "{0:n}", CMT_04_09);
            etatPlanTresorerieModel.PNRClassique_04_09 = string.Format(frCult, "{0:n}", PNRClassique_04_09);
            etatPlanTresorerieModel.ApportPersonnel_04_09 = string.Format(frCult, "{0:n}", ApportPersonnel_04_09);
            etatPlanTresorerieModel.PNRLoyer_04_09 = string.Format(frCult, "{0:n}", PNRLoyer_04_09);
            etatPlanTresorerieModel.EncaissementRecusClients_04_09 = string.Format(frCult, "{0:n}", EncaissementRecusClients_04_09);
            etatPlanTresorerieModel.TotalRecette_04_09 = string.Format(frCult, "{0:n}", TotalRecette_04_09);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_04_09 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_04_09);
            etatPlanTresorerieModel.DecaissementFournisseurs_04_09 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_04_09);
            etatPlanTresorerieModel.DecaissementPrestataires_04_09 = string.Format(frCult, "{0:n}", DecaissementPrestataires_04_09);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_04_09 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_04_09);
            etatPlanTresorerieModel.DecaissementSalairesNets_04_09 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_04_09);
            etatPlanTresorerieModel.CotisationsSociales_04_09 = string.Format(frCult, "{0:n}", CotisationsSociales_04_09);
            etatPlanTresorerieModel.IRGSalaires_04_09 = string.Format(frCult, "{0:n}", IRGSalaires_04_09);
            etatPlanTresorerieModel.TVAPayer_04_09 = string.Format(frCult, "{0:n}", TVAPayer_04_09);
            etatPlanTresorerieModel.IBS_IFU_04_09 = string.Format(frCult, "{0:n}", IBS_IFU_04_09);
            etatPlanTresorerieModel.TotalDepense_04_09 = string.Format(frCult, "{0:n}", TotalDepense_04_09);
            etatPlanTresorerieModel.SoldeFinal_04_09 = string.Format(frCult, "{0:n}", SoldeFinal_04_09);

            #endregion

            #region Données EtatPlanTresorerie Année04 Mois10

            etatPlanTresorerieModel.SoldeInitial_04_10 = string.Format(frCult, "{0:n}", SoldeInitial_04_10);
            etatPlanTresorerieModel.ApportSupplementaire_04_10 = string.Format(frCult, "{0:n}", ApportSupplementaire_04_10);
            etatPlanTresorerieModel.CMT_04_10 = string.Format(frCult, "{0:n}", CMT_04_10);
            etatPlanTresorerieModel.PNRClassique_04_10 = string.Format(frCult, "{0:n}", PNRClassique_04_10);
            etatPlanTresorerieModel.ApportPersonnel_04_10 = string.Format(frCult, "{0:n}", ApportPersonnel_04_10);
            etatPlanTresorerieModel.PNRLoyer_04_10 = string.Format(frCult, "{0:n}", PNRLoyer_04_10);
            etatPlanTresorerieModel.EncaissementRecusClients_04_10 = string.Format(frCult, "{0:n}", EncaissementRecusClients_04_10);
            etatPlanTresorerieModel.TotalRecette_04_10 = string.Format(frCult, "{0:n}", TotalRecette_04_10);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_04_10 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_04_10);
            etatPlanTresorerieModel.DecaissementFournisseurs_04_10 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_04_10);
            etatPlanTresorerieModel.DecaissementPrestataires_04_10 = string.Format(frCult, "{0:n}", DecaissementPrestataires_04_10);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_04_10 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_04_10);
            etatPlanTresorerieModel.DecaissementSalairesNets_04_10 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_04_10);
            etatPlanTresorerieModel.CotisationsSociales_04_10 = string.Format(frCult, "{0:n}", CotisationsSociales_04_10);
            etatPlanTresorerieModel.IRGSalaires_04_10 = string.Format(frCult, "{0:n}", IRGSalaires_04_10);
            etatPlanTresorerieModel.TVAPayer_04_10 = string.Format(frCult, "{0:n}", TVAPayer_04_10);
            etatPlanTresorerieModel.IBS_IFU_04_10 = string.Format(frCult, "{0:n}", IBS_IFU_04_10);
            etatPlanTresorerieModel.TotalDepense_04_10 = string.Format(frCult, "{0:n}", TotalDepense_04_10);
            etatPlanTresorerieModel.SoldeFinal_04_10 = string.Format(frCult, "{0:n}", SoldeFinal_04_10);

            #endregion

            #region Données EtatPlanTresorerie Année04 Mois11

            etatPlanTresorerieModel.SoldeInitial_04_11 = string.Format(frCult, "{0:n}", SoldeInitial_04_11);
            etatPlanTresorerieModel.ApportSupplementaire_04_11 = string.Format(frCult, "{0:n}", ApportSupplementaire_04_11);
            etatPlanTresorerieModel.CMT_04_11 = string.Format(frCult, "{0:n}", CMT_04_11);
            etatPlanTresorerieModel.PNRClassique_04_11 = string.Format(frCult, "{0:n}", PNRClassique_04_11);
            etatPlanTresorerieModel.ApportPersonnel_04_11 = string.Format(frCult, "{0:n}", ApportPersonnel_04_11);
            etatPlanTresorerieModel.PNRLoyer_04_11 = string.Format(frCult, "{0:n}", PNRLoyer_04_11);
            etatPlanTresorerieModel.EncaissementRecusClients_04_11 = string.Format(frCult, "{0:n}", EncaissementRecusClients_04_11);
            etatPlanTresorerieModel.TotalRecette_04_11 = string.Format(frCult, "{0:n}", TotalRecette_04_11);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_04_11 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_04_11);
            etatPlanTresorerieModel.DecaissementFournisseurs_04_11 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_04_11);
            etatPlanTresorerieModel.DecaissementPrestataires_04_11 = string.Format(frCult, "{0:n}", DecaissementPrestataires_04_11);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_04_11 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_04_11);
            etatPlanTresorerieModel.DecaissementSalairesNets_04_11 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_04_11);
            etatPlanTresorerieModel.CotisationsSociales_04_11 = string.Format(frCult, "{0:n}", CotisationsSociales_04_11);
            etatPlanTresorerieModel.IRGSalaires_04_11 = string.Format(frCult, "{0:n}", IRGSalaires_04_11);
            etatPlanTresorerieModel.TVAPayer_04_11 = string.Format(frCult, "{0:n}", TVAPayer_04_11);
            etatPlanTresorerieModel.IBS_IFU_04_11 = string.Format(frCult, "{0:n}", IBS_IFU_04_11);
            etatPlanTresorerieModel.TotalDepense_04_11 = string.Format(frCult, "{0:n}", TotalDepense_04_11);
            etatPlanTresorerieModel.SoldeFinal_04_11 = string.Format(frCult, "{0:n}", SoldeFinal_04_11);

            #endregion

            #region Données EtatPlanTresorerie Année04 Mois12

            etatPlanTresorerieModel.SoldeInitial_04_12 = string.Format(frCult, "{0:n}", SoldeInitial_04_12);
            etatPlanTresorerieModel.ApportSupplementaire_04_12 = string.Format(frCult, "{0:n}", ApportSupplementaire_04_12);
            etatPlanTresorerieModel.CMT_04_12 = string.Format(frCult, "{0:n}", CMT_04_12);
            etatPlanTresorerieModel.PNRClassique_04_12 = string.Format(frCult, "{0:n}", PNRClassique_04_12);
            etatPlanTresorerieModel.ApportPersonnel_04_12 = string.Format(frCult, "{0:n}", ApportPersonnel_04_12);
            etatPlanTresorerieModel.PNRLoyer_04_12 = string.Format(frCult, "{0:n}", PNRLoyer_04_12);
            etatPlanTresorerieModel.EncaissementRecusClients_04_12 = string.Format(frCult, "{0:n}", EncaissementRecusClients_04_12);
            etatPlanTresorerieModel.TotalRecette_04_12 = string.Format(frCult, "{0:n}", TotalRecette_04_12);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_04_12 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_04_12);
            etatPlanTresorerieModel.DecaissementFournisseurs_04_12 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_04_12);
            etatPlanTresorerieModel.DecaissementPrestataires_04_12 = string.Format(frCult, "{0:n}", DecaissementPrestataires_04_12);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_04_12 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_04_12);
            etatPlanTresorerieModel.DecaissementSalairesNets_04_12 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_04_12);
            etatPlanTresorerieModel.CotisationsSociales_04_12 = string.Format(frCult, "{0:n}", CotisationsSociales_04_12);
            etatPlanTresorerieModel.IRGSalaires_04_12 = string.Format(frCult, "{0:n}", IRGSalaires_04_12);
            etatPlanTresorerieModel.TVAPayer_04_12 = string.Format(frCult, "{0:n}", TVAPayer_04_12);
            etatPlanTresorerieModel.IBS_IFU_04_12 = string.Format(frCult, "{0:n}", IBS_IFU_04_12);
            etatPlanTresorerieModel.TotalDepense_04_12 = string.Format(frCult, "{0:n}", TotalDepense_04_12);
            etatPlanTresorerieModel.SoldeFinal_04_12 = string.Format(frCult, "{0:n}", SoldeFinal_04_12);

            #endregion

            #endregion

            #region Données etatPlanTresorerieModel Année05

            #region Données EtatPlanTresorerie Année05 Mois01

            etatPlanTresorerieModel.SoldeInitial_05_01 = string.Format(frCult, "{0:n}", SoldeInitial_05_01);
            etatPlanTresorerieModel.ApportSupplementaire_05_01 = string.Format(frCult, "{0:n}", ApportSupplementaire_05_01);
            etatPlanTresorerieModel.CMT_05_01 = string.Format(frCult, "{0:n}", CMT_05_01);
            etatPlanTresorerieModel.PNRClassique_05_01 = string.Format(frCult, "{0:n}", PNRClassique_05_01);
            etatPlanTresorerieModel.ApportPersonnel_05_01 = string.Format(frCult, "{0:n}", ApportPersonnel_05_01);
            etatPlanTresorerieModel.PNRLoyer_05_01 = string.Format(frCult, "{0:n}", PNRLoyer_05_01);
            etatPlanTresorerieModel.EncaissementRecusClients_05_01 = string.Format(frCult, "{0:n}", EncaissementRecusClients_05_01);
            etatPlanTresorerieModel.TotalRecette_05_01 = string.Format(frCult, "{0:n}", TotalRecette_05_01);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_05_01 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_05_01);
            etatPlanTresorerieModel.DecaissementFournisseurs_05_01 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_05_01);
            etatPlanTresorerieModel.DecaissementPrestataires_05_01 = string.Format(frCult, "{0:n}", DecaissementPrestataires_05_01);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_05_01 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_05_01);
            etatPlanTresorerieModel.DecaissementSalairesNets_05_01 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_05_01);
            etatPlanTresorerieModel.CotisationsSociales_05_01 = string.Format(frCult, "{0:n}", CotisationsSociales_05_01);
            etatPlanTresorerieModel.IRGSalaires_05_01 = string.Format(frCult, "{0:n}", IRGSalaires_05_01);
            etatPlanTresorerieModel.TVAPayer_05_01 = string.Format(frCult, "{0:n}", TVAPayer_05_01);
            etatPlanTresorerieModel.IBS_IFU_05_01 = string.Format(frCult, "{0:n}", IBS_IFU_05_01);
            etatPlanTresorerieModel.TotalDepense_05_01 = string.Format(frCult, "{0:n}", TotalDepense_05_01);
            etatPlanTresorerieModel.SoldeFinal_05_01 = string.Format(frCult, "{0:n}", SoldeFinal_05_01);

            #endregion

            #region Données EtatPlanTresorerie Année05 Mois02

            etatPlanTresorerieModel.SoldeInitial_05_02 = string.Format(frCult, "{0:n}", SoldeInitial_05_02);
            etatPlanTresorerieModel.ApportSupplementaire_05_02 = string.Format(frCult, "{0:n}", ApportSupplementaire_05_02);
            etatPlanTresorerieModel.CMT_05_02 = string.Format(frCult, "{0:n}", CMT_05_02);
            etatPlanTresorerieModel.PNRClassique_05_02 = string.Format(frCult, "{0:n}", PNRClassique_05_02);
            etatPlanTresorerieModel.ApportPersonnel_05_02 = string.Format(frCult, "{0:n}", ApportPersonnel_05_02);
            etatPlanTresorerieModel.PNRLoyer_05_02 = string.Format(frCult, "{0:n}", PNRLoyer_05_02);
            etatPlanTresorerieModel.EncaissementRecusClients_05_02 = string.Format(frCult, "{0:n}", EncaissementRecusClients_05_02);
            etatPlanTresorerieModel.TotalRecette_05_02 = string.Format(frCult, "{0:n}", TotalRecette_05_02);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_05_02 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_05_02);
            etatPlanTresorerieModel.DecaissementFournisseurs_05_02 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_05_02);
            etatPlanTresorerieModel.DecaissementPrestataires_05_02 = string.Format(frCult, "{0:n}", DecaissementPrestataires_05_02);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_05_02 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_05_02);
            etatPlanTresorerieModel.DecaissementSalairesNets_05_02 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_05_02);
            etatPlanTresorerieModel.CotisationsSociales_05_02 = string.Format(frCult, "{0:n}", CotisationsSociales_05_02);
            etatPlanTresorerieModel.IRGSalaires_05_02 = string.Format(frCult, "{0:n}", IRGSalaires_05_02);
            etatPlanTresorerieModel.TVAPayer_05_02 = string.Format(frCult, "{0:n}", TVAPayer_05_02);
            etatPlanTresorerieModel.IBS_IFU_05_02 = string.Format(frCult, "{0:n}", IBS_IFU_05_02);
            etatPlanTresorerieModel.TotalDepense_05_02 = string.Format(frCult, "{0:n}", TotalDepense_05_02);
            etatPlanTresorerieModel.SoldeFinal_05_02 = string.Format(frCult, "{0:n}", SoldeFinal_05_02);

            #endregion

            #region Données EtatPlanTresorerie Année05 Mois03

            etatPlanTresorerieModel.SoldeInitial_05_03 = string.Format(frCult, "{0:n}", SoldeInitial_05_03);
            etatPlanTresorerieModel.ApportSupplementaire_05_03 = string.Format(frCult, "{0:n}", ApportSupplementaire_05_03);
            etatPlanTresorerieModel.CMT_05_03 = string.Format(frCult, "{0:n}", CMT_05_03);
            etatPlanTresorerieModel.PNRClassique_05_03 = string.Format(frCult, "{0:n}", PNRClassique_05_03);
            etatPlanTresorerieModel.ApportPersonnel_05_03 = string.Format(frCult, "{0:n}", ApportPersonnel_05_03);
            etatPlanTresorerieModel.PNRLoyer_05_03 = string.Format(frCult, "{0:n}", PNRLoyer_05_03);
            etatPlanTresorerieModel.EncaissementRecusClients_05_03 = string.Format(frCult, "{0:n}", EncaissementRecusClients_05_03);
            etatPlanTresorerieModel.TotalRecette_05_03 = string.Format(frCult, "{0:n}", TotalRecette_05_03);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_05_03 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_05_03);
            etatPlanTresorerieModel.DecaissementFournisseurs_05_03 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_05_03);
            etatPlanTresorerieModel.DecaissementPrestataires_05_03 = string.Format(frCult, "{0:n}", DecaissementPrestataires_05_03);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_05_03 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_05_03);
            etatPlanTresorerieModel.DecaissementSalairesNets_05_03 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_05_03);
            etatPlanTresorerieModel.CotisationsSociales_05_03 = string.Format(frCult, "{0:n}", CotisationsSociales_05_03);
            etatPlanTresorerieModel.IRGSalaires_05_03 = string.Format(frCult, "{0:n}", IRGSalaires_05_03);
            etatPlanTresorerieModel.TVAPayer_05_03 = string.Format(frCult, "{0:n}", TVAPayer_05_03);
            etatPlanTresorerieModel.IBS_IFU_05_03 = string.Format(frCult, "{0:n}", IBS_IFU_05_03);
            etatPlanTresorerieModel.TotalDepense_05_03 = string.Format(frCult, "{0:n}", TotalDepense_05_03);
            etatPlanTresorerieModel.SoldeFinal_05_03 = string.Format(frCult, "{0:n}", SoldeFinal_05_03);

            #endregion

            #region Données EtatPlanTresorerie Année05 Mois04

            etatPlanTresorerieModel.SoldeInitial_05_04 = string.Format(frCult, "{0:n}", SoldeInitial_05_04);
            etatPlanTresorerieModel.ApportSupplementaire_05_04 = string.Format(frCult, "{0:n}", ApportSupplementaire_05_04);
            etatPlanTresorerieModel.CMT_05_04 = string.Format(frCult, "{0:n}", CMT_05_04);
            etatPlanTresorerieModel.PNRClassique_05_04 = string.Format(frCult, "{0:n}", PNRClassique_05_04);
            etatPlanTresorerieModel.ApportPersonnel_05_04 = string.Format(frCult, "{0:n}", ApportPersonnel_05_04);
            etatPlanTresorerieModel.PNRLoyer_05_04 = string.Format(frCult, "{0:n}", PNRLoyer_05_04);
            etatPlanTresorerieModel.EncaissementRecusClients_05_04 = string.Format(frCult, "{0:n}", EncaissementRecusClients_05_04);
            etatPlanTresorerieModel.TotalRecette_05_04 = string.Format(frCult, "{0:n}", TotalRecette_05_04);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_05_04 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_05_04);
            etatPlanTresorerieModel.DecaissementFournisseurs_05_04 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_05_04);
            etatPlanTresorerieModel.DecaissementPrestataires_05_04 = string.Format(frCult, "{0:n}", DecaissementPrestataires_05_04);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_05_04 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_05_04);
            etatPlanTresorerieModel.DecaissementSalairesNets_05_04 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_05_04);
            etatPlanTresorerieModel.CotisationsSociales_05_04 = string.Format(frCult, "{0:n}", CotisationsSociales_05_04);
            etatPlanTresorerieModel.IRGSalaires_05_04 = string.Format(frCult, "{0:n}", IRGSalaires_05_04);
            etatPlanTresorerieModel.TVAPayer_05_04 = string.Format(frCult, "{0:n}", TVAPayer_05_04);
            etatPlanTresorerieModel.IBS_IFU_05_04 = string.Format(frCult, "{0:n}", IBS_IFU_05_04);
            etatPlanTresorerieModel.TotalDepense_05_04 = string.Format(frCult, "{0:n}", TotalDepense_05_04);
            etatPlanTresorerieModel.SoldeFinal_05_04 = string.Format(frCult, "{0:n}", SoldeFinal_05_04);

            #endregion

            #region Données EtatPlanTresorerie Année05 Mois05

            etatPlanTresorerieModel.SoldeInitial_05_05 = string.Format(frCult, "{0:n}", SoldeInitial_05_05);
            etatPlanTresorerieModel.ApportSupplementaire_05_05 = string.Format(frCult, "{0:n}", ApportSupplementaire_05_05);
            etatPlanTresorerieModel.CMT_05_05 = string.Format(frCult, "{0:n}", CMT_05_05);
            etatPlanTresorerieModel.PNRClassique_05_05 = string.Format(frCult, "{0:n}", PNRClassique_05_05);
            etatPlanTresorerieModel.ApportPersonnel_05_05 = string.Format(frCult, "{0:n}", ApportPersonnel_05_05);
            etatPlanTresorerieModel.PNRLoyer_05_05 = string.Format(frCult, "{0:n}", PNRLoyer_05_05);
            etatPlanTresorerieModel.EncaissementRecusClients_05_05 = string.Format(frCult, "{0:n}", EncaissementRecusClients_05_05);
            etatPlanTresorerieModel.TotalRecette_05_05 = string.Format(frCult, "{0:n}", TotalRecette_05_05);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_05_05 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_05_05);
            etatPlanTresorerieModel.DecaissementFournisseurs_05_05 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_05_05);
            etatPlanTresorerieModel.DecaissementPrestataires_05_05 = string.Format(frCult, "{0:n}", DecaissementPrestataires_05_05);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_05_05 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_05_05);
            etatPlanTresorerieModel.DecaissementSalairesNets_05_05 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_05_05);
            etatPlanTresorerieModel.CotisationsSociales_05_05 = string.Format(frCult, "{0:n}", CotisationsSociales_05_05);
            etatPlanTresorerieModel.IRGSalaires_05_05 = string.Format(frCult, "{0:n}", IRGSalaires_05_05);
            etatPlanTresorerieModel.TVAPayer_05_05 = string.Format(frCult, "{0:n}", TVAPayer_05_05);
            etatPlanTresorerieModel.IBS_IFU_05_05 = string.Format(frCult, "{0:n}", IBS_IFU_05_05);
            etatPlanTresorerieModel.TotalDepense_05_05 = string.Format(frCult, "{0:n}", TotalDepense_05_05);
            etatPlanTresorerieModel.SoldeFinal_05_05 = string.Format(frCult, "{0:n}", SoldeFinal_05_05);

            #endregion

            #region Données EtatPlanTresorerie Année05 Mois06

            etatPlanTresorerieModel.SoldeInitial_05_06 = string.Format(frCult, "{0:n}", SoldeInitial_05_06);
            etatPlanTresorerieModel.ApportSupplementaire_05_06 = string.Format(frCult, "{0:n}", ApportSupplementaire_05_06);
            etatPlanTresorerieModel.CMT_05_06 = string.Format(frCult, "{0:n}", CMT_05_06);
            etatPlanTresorerieModel.PNRClassique_05_06 = string.Format(frCult, "{0:n}", PNRClassique_05_06);
            etatPlanTresorerieModel.ApportPersonnel_05_06 = string.Format(frCult, "{0:n}", ApportPersonnel_05_06);
            etatPlanTresorerieModel.PNRLoyer_05_06 = string.Format(frCult, "{0:n}", PNRLoyer_05_06);
            etatPlanTresorerieModel.EncaissementRecusClients_05_06 = string.Format(frCult, "{0:n}", EncaissementRecusClients_05_06);
            etatPlanTresorerieModel.TotalRecette_05_06 = string.Format(frCult, "{0:n}", TotalRecette_05_06);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_05_06 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_05_06);
            etatPlanTresorerieModel.DecaissementFournisseurs_05_06 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_05_06);
            etatPlanTresorerieModel.DecaissementPrestataires_05_06 = string.Format(frCult, "{0:n}", DecaissementPrestataires_05_06);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_05_06 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_05_06);
            etatPlanTresorerieModel.DecaissementSalairesNets_05_06 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_05_06);
            etatPlanTresorerieModel.CotisationsSociales_05_06 = string.Format(frCult, "{0:n}", CotisationsSociales_05_06);
            etatPlanTresorerieModel.IRGSalaires_05_06 = string.Format(frCult, "{0:n}", IRGSalaires_05_06);
            etatPlanTresorerieModel.TVAPayer_05_06 = string.Format(frCult, "{0:n}", TVAPayer_05_06);
            etatPlanTresorerieModel.IBS_IFU_05_06 = string.Format(frCult, "{0:n}", IBS_IFU_05_06);
            etatPlanTresorerieModel.TotalDepense_05_06 = string.Format(frCult, "{0:n}", TotalDepense_05_06);
            etatPlanTresorerieModel.SoldeFinal_05_06 = string.Format(frCult, "{0:n}", SoldeFinal_05_06);

            #endregion

            #region Données EtatPlanTresorerie Année05 Mois07

            etatPlanTresorerieModel.SoldeInitial_05_07 = string.Format(frCult, "{0:n}", SoldeInitial_05_07);
            etatPlanTresorerieModel.ApportSupplementaire_05_07 = string.Format(frCult, "{0:n}", ApportSupplementaire_05_07);
            etatPlanTresorerieModel.CMT_05_07 = string.Format(frCult, "{0:n}", CMT_05_07);
            etatPlanTresorerieModel.PNRClassique_05_07 = string.Format(frCult, "{0:n}", PNRClassique_05_07);
            etatPlanTresorerieModel.ApportPersonnel_05_07 = string.Format(frCult, "{0:n}", ApportPersonnel_05_07);
            etatPlanTresorerieModel.PNRLoyer_05_07 = string.Format(frCult, "{0:n}", PNRLoyer_05_07);
            etatPlanTresorerieModel.EncaissementRecusClients_05_07 = string.Format(frCult, "{0:n}", EncaissementRecusClients_05_07);
            etatPlanTresorerieModel.TotalRecette_05_07 = string.Format(frCult, "{0:n}", TotalRecette_05_07);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_05_07 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_05_07);
            etatPlanTresorerieModel.DecaissementFournisseurs_05_07 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_05_07);
            etatPlanTresorerieModel.DecaissementPrestataires_05_07 = string.Format(frCult, "{0:n}", DecaissementPrestataires_05_07);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_05_07 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_05_07);
            etatPlanTresorerieModel.DecaissementSalairesNets_05_07 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_05_07);
            etatPlanTresorerieModel.CotisationsSociales_05_07 = string.Format(frCult, "{0:n}", CotisationsSociales_05_07);
            etatPlanTresorerieModel.IRGSalaires_05_07 = string.Format(frCult, "{0:n}", IRGSalaires_05_07);
            etatPlanTresorerieModel.TVAPayer_05_07 = string.Format(frCult, "{0:n}", TVAPayer_05_07);
            etatPlanTresorerieModel.IBS_IFU_05_07 = string.Format(frCult, "{0:n}", IBS_IFU_05_07);
            etatPlanTresorerieModel.TotalDepense_05_07 = string.Format(frCult, "{0:n}", TotalDepense_05_07);
            etatPlanTresorerieModel.SoldeFinal_05_07 = string.Format(frCult, "{0:n}", SoldeFinal_05_07);

            #endregion

            #region Données EtatPlanTresorerie Année05 Mois08

            etatPlanTresorerieModel.SoldeInitial_05_08 = string.Format(frCult, "{0:n}", SoldeInitial_05_08);
            etatPlanTresorerieModel.ApportSupplementaire_05_08 = string.Format(frCult, "{0:n}", ApportSupplementaire_05_08);
            etatPlanTresorerieModel.CMT_05_08 = string.Format(frCult, "{0:n}", CMT_05_08);
            etatPlanTresorerieModel.PNRClassique_05_08 = string.Format(frCult, "{0:n}", PNRClassique_05_08);
            etatPlanTresorerieModel.ApportPersonnel_05_08 = string.Format(frCult, "{0:n}", ApportPersonnel_05_08);
            etatPlanTresorerieModel.PNRLoyer_05_08 = string.Format(frCult, "{0:n}", PNRLoyer_05_08);
            etatPlanTresorerieModel.EncaissementRecusClients_05_08 = string.Format(frCult, "{0:n}", EncaissementRecusClients_05_08);
            etatPlanTresorerieModel.TotalRecette_05_08 = string.Format(frCult, "{0:n}", TotalRecette_05_08);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_05_08 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_05_08);
            etatPlanTresorerieModel.DecaissementFournisseurs_05_08 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_05_08);
            etatPlanTresorerieModel.DecaissementPrestataires_05_08 = string.Format(frCult, "{0:n}", DecaissementPrestataires_05_08);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_05_08 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_05_08);
            etatPlanTresorerieModel.DecaissementSalairesNets_05_08 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_05_08);
            etatPlanTresorerieModel.CotisationsSociales_05_08 = string.Format(frCult, "{0:n}", CotisationsSociales_05_08);
            etatPlanTresorerieModel.IRGSalaires_05_08 = string.Format(frCult, "{0:n}", IRGSalaires_05_08);
            etatPlanTresorerieModel.TVAPayer_05_08 = string.Format(frCult, "{0:n}", TVAPayer_05_08);
            etatPlanTresorerieModel.IBS_IFU_05_08 = string.Format(frCult, "{0:n}", IBS_IFU_05_08);
            etatPlanTresorerieModel.TotalDepense_05_08 = string.Format(frCult, "{0:n}", TotalDepense_05_08);
            etatPlanTresorerieModel.SoldeFinal_05_08 = string.Format(frCult, "{0:n}", SoldeFinal_05_08);

            #endregion

            #region Données EtatPlanTresorerie Année05 Mois09

            etatPlanTresorerieModel.SoldeInitial_05_09 = string.Format(frCult, "{0:n}", SoldeInitial_05_09);
            etatPlanTresorerieModel.ApportSupplementaire_05_09 = string.Format(frCult, "{0:n}", ApportSupplementaire_05_09);
            etatPlanTresorerieModel.CMT_05_09 = string.Format(frCult, "{0:n}", CMT_05_09);
            etatPlanTresorerieModel.PNRClassique_05_09 = string.Format(frCult, "{0:n}", PNRClassique_05_09);
            etatPlanTresorerieModel.ApportPersonnel_05_09 = string.Format(frCult, "{0:n}", ApportPersonnel_05_09);
            etatPlanTresorerieModel.PNRLoyer_05_09 = string.Format(frCult, "{0:n}", PNRLoyer_05_09);
            etatPlanTresorerieModel.EncaissementRecusClients_05_09 = string.Format(frCult, "{0:n}", EncaissementRecusClients_05_09);
            etatPlanTresorerieModel.TotalRecette_05_09 = string.Format(frCult, "{0:n}", TotalRecette_05_09);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_05_09 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_05_09);
            etatPlanTresorerieModel.DecaissementFournisseurs_05_09 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_05_09);
            etatPlanTresorerieModel.DecaissementPrestataires_05_09 = string.Format(frCult, "{0:n}", DecaissementPrestataires_05_09);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_05_09 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_05_09);
            etatPlanTresorerieModel.DecaissementSalairesNets_05_09 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_05_09);
            etatPlanTresorerieModel.CotisationsSociales_05_09 = string.Format(frCult, "{0:n}", CotisationsSociales_05_09);
            etatPlanTresorerieModel.IRGSalaires_05_09 = string.Format(frCult, "{0:n}", IRGSalaires_05_09);
            etatPlanTresorerieModel.TVAPayer_05_09 = string.Format(frCult, "{0:n}", TVAPayer_05_09);
            etatPlanTresorerieModel.IBS_IFU_05_09 = string.Format(frCult, "{0:n}", IBS_IFU_05_09);
            etatPlanTresorerieModel.TotalDepense_05_09 = string.Format(frCult, "{0:n}", TotalDepense_05_09);
            etatPlanTresorerieModel.SoldeFinal_05_09 = string.Format(frCult, "{0:n}", SoldeFinal_05_09);

            #endregion

            #region Données EtatPlanTresorerie Année05 Mois10

            etatPlanTresorerieModel.SoldeInitial_05_10 = string.Format(frCult, "{0:n}", SoldeInitial_05_10);
            etatPlanTresorerieModel.ApportSupplementaire_05_10 = string.Format(frCult, "{0:n}", ApportSupplementaire_05_10);
            etatPlanTresorerieModel.CMT_05_10 = string.Format(frCult, "{0:n}", CMT_05_10);
            etatPlanTresorerieModel.PNRClassique_05_10 = string.Format(frCult, "{0:n}", PNRClassique_05_10);
            etatPlanTresorerieModel.ApportPersonnel_05_10 = string.Format(frCult, "{0:n}", ApportPersonnel_05_10);
            etatPlanTresorerieModel.PNRLoyer_05_10 = string.Format(frCult, "{0:n}", PNRLoyer_05_10);
            etatPlanTresorerieModel.EncaissementRecusClients_05_10 = string.Format(frCult, "{0:n}", EncaissementRecusClients_05_10);
            etatPlanTresorerieModel.TotalRecette_05_10 = string.Format(frCult, "{0:n}", TotalRecette_05_10);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_05_10 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_05_10);
            etatPlanTresorerieModel.DecaissementFournisseurs_05_10 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_05_10);
            etatPlanTresorerieModel.DecaissementPrestataires_05_10 = string.Format(frCult, "{0:n}", DecaissementPrestataires_05_10);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_05_10 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_05_10);
            etatPlanTresorerieModel.DecaissementSalairesNets_05_10 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_05_10);
            etatPlanTresorerieModel.CotisationsSociales_05_10 = string.Format(frCult, "{0:n}", CotisationsSociales_05_10);
            etatPlanTresorerieModel.IRGSalaires_05_10 = string.Format(frCult, "{0:n}", IRGSalaires_05_10);
            etatPlanTresorerieModel.TVAPayer_05_10 = string.Format(frCult, "{0:n}", TVAPayer_05_10);
            etatPlanTresorerieModel.IBS_IFU_05_10 = string.Format(frCult, "{0:n}", IBS_IFU_05_10);
            etatPlanTresorerieModel.TotalDepense_05_10 = string.Format(frCult, "{0:n}", TotalDepense_05_10);
            etatPlanTresorerieModel.SoldeFinal_05_10 = string.Format(frCult, "{0:n}", SoldeFinal_05_10);

            #endregion

            #region Données EtatPlanTresorerie Année05 Mois11

            etatPlanTresorerieModel.SoldeInitial_05_11 = string.Format(frCult, "{0:n}", SoldeInitial_05_11);
            etatPlanTresorerieModel.ApportSupplementaire_05_11 = string.Format(frCult, "{0:n}", ApportSupplementaire_05_11);
            etatPlanTresorerieModel.CMT_05_11 = string.Format(frCult, "{0:n}", CMT_05_11);
            etatPlanTresorerieModel.PNRClassique_05_11 = string.Format(frCult, "{0:n}", PNRClassique_05_11);
            etatPlanTresorerieModel.ApportPersonnel_05_11 = string.Format(frCult, "{0:n}", ApportPersonnel_05_11);
            etatPlanTresorerieModel.PNRLoyer_05_11 = string.Format(frCult, "{0:n}", PNRLoyer_05_11);
            etatPlanTresorerieModel.EncaissementRecusClients_05_11 = string.Format(frCult, "{0:n}", EncaissementRecusClients_05_11);
            etatPlanTresorerieModel.TotalRecette_05_11 = string.Format(frCult, "{0:n}", TotalRecette_05_11);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_05_11 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_05_11);
            etatPlanTresorerieModel.DecaissementFournisseurs_05_11 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_05_11);
            etatPlanTresorerieModel.DecaissementPrestataires_05_11 = string.Format(frCult, "{0:n}", DecaissementPrestataires_05_11);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_05_11 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_05_11);
            etatPlanTresorerieModel.DecaissementSalairesNets_05_11 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_05_11);
            etatPlanTresorerieModel.CotisationsSociales_05_11 = string.Format(frCult, "{0:n}", CotisationsSociales_05_11);
            etatPlanTresorerieModel.IRGSalaires_05_11 = string.Format(frCult, "{0:n}", IRGSalaires_05_11);
            etatPlanTresorerieModel.TVAPayer_05_11 = string.Format(frCult, "{0:n}", TVAPayer_05_11);
            etatPlanTresorerieModel.IBS_IFU_05_11 = string.Format(frCult, "{0:n}", IBS_IFU_05_11);
            etatPlanTresorerieModel.TotalDepense_05_11 = string.Format(frCult, "{0:n}", TotalDepense_05_11);
            etatPlanTresorerieModel.SoldeFinal_05_11 = string.Format(frCult, "{0:n}", SoldeFinal_05_11);

            #endregion

            #region Données EtatPlanTresorerie Année05 Mois12

            etatPlanTresorerieModel.SoldeInitial_05_12 = string.Format(frCult, "{0:n}", SoldeInitial_05_12);
            etatPlanTresorerieModel.ApportSupplementaire_05_12 = string.Format(frCult, "{0:n}", ApportSupplementaire_05_12);
            etatPlanTresorerieModel.CMT_05_12 = string.Format(frCult, "{0:n}", CMT_05_12);
            etatPlanTresorerieModel.PNRClassique_05_12 = string.Format(frCult, "{0:n}", PNRClassique_05_12);
            etatPlanTresorerieModel.ApportPersonnel_05_12 = string.Format(frCult, "{0:n}", ApportPersonnel_05_12);
            etatPlanTresorerieModel.PNRLoyer_05_12 = string.Format(frCult, "{0:n}", PNRLoyer_05_12);
            etatPlanTresorerieModel.EncaissementRecusClients_05_12 = string.Format(frCult, "{0:n}", EncaissementRecusClients_05_12);
            etatPlanTresorerieModel.TotalRecette_05_12 = string.Format(frCult, "{0:n}", TotalRecette_05_12);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_05_12 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_05_12);
            etatPlanTresorerieModel.DecaissementFournisseurs_05_12 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_05_12);
            etatPlanTresorerieModel.DecaissementPrestataires_05_12 = string.Format(frCult, "{0:n}", DecaissementPrestataires_05_12);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_05_12 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_05_12);
            etatPlanTresorerieModel.DecaissementSalairesNets_05_12 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_05_12);
            etatPlanTresorerieModel.CotisationsSociales_05_12 = string.Format(frCult, "{0:n}", CotisationsSociales_05_12);
            etatPlanTresorerieModel.IRGSalaires_05_12 = string.Format(frCult, "{0:n}", IRGSalaires_05_12);
            etatPlanTresorerieModel.TVAPayer_05_12 = string.Format(frCult, "{0:n}", TVAPayer_05_12);
            etatPlanTresorerieModel.IBS_IFU_05_12 = string.Format(frCult, "{0:n}", IBS_IFU_05_12);
            etatPlanTresorerieModel.TotalDepense_05_12 = string.Format(frCult, "{0:n}", TotalDepense_05_12);
            etatPlanTresorerieModel.SoldeFinal_05_12 = string.Format(frCult, "{0:n}", SoldeFinal_05_12);

            #endregion

            #endregion

            #region Données etatPlanTresorerieModel Année06

            #region Données EtatPlanTresorerie Année06 Mois01

            etatPlanTresorerieModel.SoldeInitial_06_01 = string.Format(frCult, "{0:n}", SoldeInitial_06_01);
            etatPlanTresorerieModel.ApportSupplementaire_06_01 = string.Format(frCult, "{0:n}", ApportSupplementaire_06_01);
            etatPlanTresorerieModel.CMT_06_01 = string.Format(frCult, "{0:n}", CMT_06_01);
            etatPlanTresorerieModel.PNRClassique_06_01 = string.Format(frCult, "{0:n}", PNRClassique_06_01);
            etatPlanTresorerieModel.ApportPersonnel_06_01 = string.Format(frCult, "{0:n}", ApportPersonnel_06_01);
            etatPlanTresorerieModel.PNRLoyer_06_01 = string.Format(frCult, "{0:n}", PNRLoyer_06_01);
            etatPlanTresorerieModel.EncaissementRecusClients_06_01 = string.Format(frCult, "{0:n}", EncaissementRecusClients_06_01);
            etatPlanTresorerieModel.TotalRecette_06_01 = string.Format(frCult, "{0:n}", TotalRecette_06_01);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_06_01 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_06_01);
            etatPlanTresorerieModel.DecaissementFournisseurs_06_01 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_06_01);
            etatPlanTresorerieModel.DecaissementPrestataires_06_01 = string.Format(frCult, "{0:n}", DecaissementPrestataires_06_01);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_06_01 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_06_01);
            etatPlanTresorerieModel.DecaissementSalairesNets_06_01 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_06_01);
            etatPlanTresorerieModel.CotisationsSociales_06_01 = string.Format(frCult, "{0:n}", CotisationsSociales_06_01);
            etatPlanTresorerieModel.IRGSalaires_06_01 = string.Format(frCult, "{0:n}", IRGSalaires_06_01);
            etatPlanTresorerieModel.TVAPayer_06_01 = string.Format(frCult, "{0:n}", TVAPayer_06_01);
            etatPlanTresorerieModel.IBS_IFU_06_01 = string.Format(frCult, "{0:n}", IBS_IFU_06_01);
            etatPlanTresorerieModel.TotalDepense_06_01 = string.Format(frCult, "{0:n}", TotalDepense_06_01);
            etatPlanTresorerieModel.SoldeFinal_06_01 = string.Format(frCult, "{0:n}", SoldeFinal_06_01);

            #endregion

            #region Données EtatPlanTresorerie Année06 Mois02

            etatPlanTresorerieModel.SoldeInitial_06_02 = string.Format(frCult, "{0:n}", SoldeInitial_06_02);
            etatPlanTresorerieModel.ApportSupplementaire_06_02 = string.Format(frCult, "{0:n}", ApportSupplementaire_06_02);
            etatPlanTresorerieModel.CMT_06_02 = string.Format(frCult, "{0:n}", CMT_06_02);
            etatPlanTresorerieModel.PNRClassique_06_02 = string.Format(frCult, "{0:n}", PNRClassique_06_02);
            etatPlanTresorerieModel.ApportPersonnel_06_02 = string.Format(frCult, "{0:n}", ApportPersonnel_06_02);
            etatPlanTresorerieModel.PNRLoyer_06_02 = string.Format(frCult, "{0:n}", PNRLoyer_06_02);
            etatPlanTresorerieModel.EncaissementRecusClients_06_02 = string.Format(frCult, "{0:n}", EncaissementRecusClients_06_02);
            etatPlanTresorerieModel.TotalRecette_06_02 = string.Format(frCult, "{0:n}", TotalRecette_06_02);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_06_02 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_06_02);
            etatPlanTresorerieModel.DecaissementFournisseurs_06_02 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_06_02);
            etatPlanTresorerieModel.DecaissementPrestataires_06_02 = string.Format(frCult, "{0:n}", DecaissementPrestataires_06_02);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_06_02 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_06_02);
            etatPlanTresorerieModel.DecaissementSalairesNets_06_02 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_06_02);
            etatPlanTresorerieModel.CotisationsSociales_06_02 = string.Format(frCult, "{0:n}", CotisationsSociales_06_02);
            etatPlanTresorerieModel.IRGSalaires_06_02 = string.Format(frCult, "{0:n}", IRGSalaires_06_02);
            etatPlanTresorerieModel.TVAPayer_06_02 = string.Format(frCult, "{0:n}", TVAPayer_06_02);
            etatPlanTresorerieModel.IBS_IFU_06_02 = string.Format(frCult, "{0:n}", IBS_IFU_06_02);
            etatPlanTresorerieModel.TotalDepense_06_02 = string.Format(frCult, "{0:n}", TotalDepense_06_02);
            etatPlanTresorerieModel.SoldeFinal_06_02 = string.Format(frCult, "{0:n}", SoldeFinal_06_02);

            #endregion

            #region Données EtatPlanTresorerie Année06 Mois03

            etatPlanTresorerieModel.SoldeInitial_06_03 = string.Format(frCult, "{0:n}", SoldeInitial_06_03);
            etatPlanTresorerieModel.ApportSupplementaire_06_03 = string.Format(frCult, "{0:n}", ApportSupplementaire_06_03);
            etatPlanTresorerieModel.CMT_06_03 = string.Format(frCult, "{0:n}", CMT_06_03);
            etatPlanTresorerieModel.PNRClassique_06_03 = string.Format(frCult, "{0:n}", PNRClassique_06_03);
            etatPlanTresorerieModel.ApportPersonnel_06_03 = string.Format(frCult, "{0:n}", ApportPersonnel_06_03);
            etatPlanTresorerieModel.PNRLoyer_06_03 = string.Format(frCult, "{0:n}", PNRLoyer_06_03);
            etatPlanTresorerieModel.EncaissementRecusClients_06_03 = string.Format(frCult, "{0:n}", EncaissementRecusClients_06_03);
            etatPlanTresorerieModel.TotalRecette_06_03 = string.Format(frCult, "{0:n}", TotalRecette_06_03);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_06_03 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_06_03);
            etatPlanTresorerieModel.DecaissementFournisseurs_06_03 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_06_03);
            etatPlanTresorerieModel.DecaissementPrestataires_06_03 = string.Format(frCult, "{0:n}", DecaissementPrestataires_06_03);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_06_03 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_06_03);
            etatPlanTresorerieModel.DecaissementSalairesNets_06_03 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_06_03);
            etatPlanTresorerieModel.CotisationsSociales_06_03 = string.Format(frCult, "{0:n}", CotisationsSociales_06_03);
            etatPlanTresorerieModel.IRGSalaires_06_03 = string.Format(frCult, "{0:n}", IRGSalaires_06_03);
            etatPlanTresorerieModel.TVAPayer_06_03 = string.Format(frCult, "{0:n}", TVAPayer_06_03);
            etatPlanTresorerieModel.IBS_IFU_06_03 = string.Format(frCult, "{0:n}", IBS_IFU_06_03);
            etatPlanTresorerieModel.TotalDepense_06_03 = string.Format(frCult, "{0:n}", TotalDepense_06_03);
            etatPlanTresorerieModel.SoldeFinal_06_03 = string.Format(frCult, "{0:n}", SoldeFinal_06_03);

            #endregion

            #region Données EtatPlanTresorerie Année06 Mois04

            etatPlanTresorerieModel.SoldeInitial_06_04 = string.Format(frCult, "{0:n}", SoldeInitial_06_04);
            etatPlanTresorerieModel.ApportSupplementaire_06_04 = string.Format(frCult, "{0:n}", ApportSupplementaire_06_04);
            etatPlanTresorerieModel.CMT_06_04 = string.Format(frCult, "{0:n}", CMT_06_04);
            etatPlanTresorerieModel.PNRClassique_06_04 = string.Format(frCult, "{0:n}", PNRClassique_06_04);
            etatPlanTresorerieModel.ApportPersonnel_06_04 = string.Format(frCult, "{0:n}", ApportPersonnel_06_04);
            etatPlanTresorerieModel.PNRLoyer_06_04 = string.Format(frCult, "{0:n}", PNRLoyer_06_04);
            etatPlanTresorerieModel.EncaissementRecusClients_06_04 = string.Format(frCult, "{0:n}", EncaissementRecusClients_06_04);
            etatPlanTresorerieModel.TotalRecette_06_04 = string.Format(frCult, "{0:n}", TotalRecette_06_04);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_06_04 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_06_04);
            etatPlanTresorerieModel.DecaissementFournisseurs_06_04 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_06_04);
            etatPlanTresorerieModel.DecaissementPrestataires_06_04 = string.Format(frCult, "{0:n}", DecaissementPrestataires_06_04);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_06_04 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_06_04);
            etatPlanTresorerieModel.DecaissementSalairesNets_06_04 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_06_04);
            etatPlanTresorerieModel.CotisationsSociales_06_04 = string.Format(frCult, "{0:n}", CotisationsSociales_06_04);
            etatPlanTresorerieModel.IRGSalaires_06_04 = string.Format(frCult, "{0:n}", IRGSalaires_06_04);
            etatPlanTresorerieModel.TVAPayer_06_04 = string.Format(frCult, "{0:n}", TVAPayer_06_04);
            etatPlanTresorerieModel.IBS_IFU_06_04 = string.Format(frCult, "{0:n}", IBS_IFU_06_04);
            etatPlanTresorerieModel.TotalDepense_06_04 = string.Format(frCult, "{0:n}", TotalDepense_06_04);
            etatPlanTresorerieModel.SoldeFinal_06_04 = string.Format(frCult, "{0:n}", SoldeFinal_06_04);

            #endregion

            #region Données EtatPlanTresorerie Année06 Mois05

            etatPlanTresorerieModel.SoldeInitial_06_05 = string.Format(frCult, "{0:n}", SoldeInitial_06_05);
            etatPlanTresorerieModel.ApportSupplementaire_06_05 = string.Format(frCult, "{0:n}", ApportSupplementaire_06_05);
            etatPlanTresorerieModel.CMT_06_05 = string.Format(frCult, "{0:n}", CMT_06_05);
            etatPlanTresorerieModel.PNRClassique_06_05 = string.Format(frCult, "{0:n}", PNRClassique_06_05);
            etatPlanTresorerieModel.ApportPersonnel_06_05 = string.Format(frCult, "{0:n}", ApportPersonnel_06_05);
            etatPlanTresorerieModel.PNRLoyer_06_05 = string.Format(frCult, "{0:n}", PNRLoyer_06_05);
            etatPlanTresorerieModel.EncaissementRecusClients_06_05 = string.Format(frCult, "{0:n}", EncaissementRecusClients_06_05);
            etatPlanTresorerieModel.TotalRecette_06_05 = string.Format(frCult, "{0:n}", TotalRecette_06_05);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_06_05 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_06_05);
            etatPlanTresorerieModel.DecaissementFournisseurs_06_05 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_06_05);
            etatPlanTresorerieModel.DecaissementPrestataires_06_05 = string.Format(frCult, "{0:n}", DecaissementPrestataires_06_05);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_06_05 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_06_05);
            etatPlanTresorerieModel.DecaissementSalairesNets_06_05 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_06_05);
            etatPlanTresorerieModel.CotisationsSociales_06_05 = string.Format(frCult, "{0:n}", CotisationsSociales_06_05);
            etatPlanTresorerieModel.IRGSalaires_06_05 = string.Format(frCult, "{0:n}", IRGSalaires_06_05);
            etatPlanTresorerieModel.TVAPayer_06_05 = string.Format(frCult, "{0:n}", TVAPayer_06_05);
            etatPlanTresorerieModel.IBS_IFU_06_05 = string.Format(frCult, "{0:n}", IBS_IFU_06_05);
            etatPlanTresorerieModel.TotalDepense_06_05 = string.Format(frCult, "{0:n}", TotalDepense_06_05);
            etatPlanTresorerieModel.SoldeFinal_06_05 = string.Format(frCult, "{0:n}", SoldeFinal_06_05);

            #endregion

            #region Données EtatPlanTresorerie Année06 Mois06

            etatPlanTresorerieModel.SoldeInitial_06_06 = string.Format(frCult, "{0:n}", SoldeInitial_06_06);
            etatPlanTresorerieModel.ApportSupplementaire_06_06 = string.Format(frCult, "{0:n}", ApportSupplementaire_06_06);
            etatPlanTresorerieModel.CMT_06_06 = string.Format(frCult, "{0:n}", CMT_06_06);
            etatPlanTresorerieModel.PNRClassique_06_06 = string.Format(frCult, "{0:n}", PNRClassique_06_06);
            etatPlanTresorerieModel.ApportPersonnel_06_06 = string.Format(frCult, "{0:n}", ApportPersonnel_06_06);
            etatPlanTresorerieModel.PNRLoyer_06_06 = string.Format(frCult, "{0:n}", PNRLoyer_06_06);
            etatPlanTresorerieModel.EncaissementRecusClients_06_06 = string.Format(frCult, "{0:n}", EncaissementRecusClients_06_06);
            etatPlanTresorerieModel.TotalRecette_06_06 = string.Format(frCult, "{0:n}", TotalRecette_06_06);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_06_06 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_06_06);
            etatPlanTresorerieModel.DecaissementFournisseurs_06_06 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_06_06);
            etatPlanTresorerieModel.DecaissementPrestataires_06_06 = string.Format(frCult, "{0:n}", DecaissementPrestataires_06_06);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_06_06 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_06_06);
            etatPlanTresorerieModel.DecaissementSalairesNets_06_06 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_06_06);
            etatPlanTresorerieModel.CotisationsSociales_06_06 = string.Format(frCult, "{0:n}", CotisationsSociales_06_06);
            etatPlanTresorerieModel.IRGSalaires_06_06 = string.Format(frCult, "{0:n}", IRGSalaires_06_06);
            etatPlanTresorerieModel.TVAPayer_06_06 = string.Format(frCult, "{0:n}", TVAPayer_06_06);
            etatPlanTresorerieModel.IBS_IFU_06_06 = string.Format(frCult, "{0:n}", IBS_IFU_06_06);
            etatPlanTresorerieModel.TotalDepense_06_06 = string.Format(frCult, "{0:n}", TotalDepense_06_06);
            etatPlanTresorerieModel.SoldeFinal_06_06 = string.Format(frCult, "{0:n}", SoldeFinal_06_06);

            #endregion

            #region Données EtatPlanTresorerie Année06 Mois07

            etatPlanTresorerieModel.SoldeInitial_06_07 = string.Format(frCult, "{0:n}", SoldeInitial_06_07);
            etatPlanTresorerieModel.ApportSupplementaire_06_07 = string.Format(frCult, "{0:n}", ApportSupplementaire_06_07);
            etatPlanTresorerieModel.CMT_06_07 = string.Format(frCult, "{0:n}", CMT_06_07);
            etatPlanTresorerieModel.PNRClassique_06_07 = string.Format(frCult, "{0:n}", PNRClassique_06_07);
            etatPlanTresorerieModel.ApportPersonnel_06_07 = string.Format(frCult, "{0:n}", ApportPersonnel_06_07);
            etatPlanTresorerieModel.PNRLoyer_06_07 = string.Format(frCult, "{0:n}", PNRLoyer_06_07);
            etatPlanTresorerieModel.EncaissementRecusClients_06_07 = string.Format(frCult, "{0:n}", EncaissementRecusClients_06_07);
            etatPlanTresorerieModel.TotalRecette_06_07 = string.Format(frCult, "{0:n}", TotalRecette_06_07);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_06_07 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_06_07);
            etatPlanTresorerieModel.DecaissementFournisseurs_06_07 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_06_07);
            etatPlanTresorerieModel.DecaissementPrestataires_06_07 = string.Format(frCult, "{0:n}", DecaissementPrestataires_06_07);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_06_07 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_06_07);
            etatPlanTresorerieModel.DecaissementSalairesNets_06_07 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_06_07);
            etatPlanTresorerieModel.CotisationsSociales_06_07 = string.Format(frCult, "{0:n}", CotisationsSociales_06_07);
            etatPlanTresorerieModel.IRGSalaires_06_07 = string.Format(frCult, "{0:n}", IRGSalaires_06_07);
            etatPlanTresorerieModel.TVAPayer_06_07 = string.Format(frCult, "{0:n}", TVAPayer_06_07);
            etatPlanTresorerieModel.IBS_IFU_06_07 = string.Format(frCult, "{0:n}", IBS_IFU_06_07);
            etatPlanTresorerieModel.TotalDepense_06_07 = string.Format(frCult, "{0:n}", TotalDepense_06_07);
            etatPlanTresorerieModel.SoldeFinal_06_07 = string.Format(frCult, "{0:n}", SoldeFinal_06_07);

            #endregion

            #region Données EtatPlanTresorerie Année06 Mois08

            etatPlanTresorerieModel.SoldeInitial_06_08 = string.Format(frCult, "{0:n}", SoldeInitial_06_08);
            etatPlanTresorerieModel.ApportSupplementaire_06_08 = string.Format(frCult, "{0:n}", ApportSupplementaire_06_08);
            etatPlanTresorerieModel.CMT_06_08 = string.Format(frCult, "{0:n}", CMT_06_08);
            etatPlanTresorerieModel.PNRClassique_06_08 = string.Format(frCult, "{0:n}", PNRClassique_06_08);
            etatPlanTresorerieModel.ApportPersonnel_06_08 = string.Format(frCult, "{0:n}", ApportPersonnel_06_08);
            etatPlanTresorerieModel.PNRLoyer_06_08 = string.Format(frCult, "{0:n}", PNRLoyer_06_08);
            etatPlanTresorerieModel.EncaissementRecusClients_06_08 = string.Format(frCult, "{0:n}", EncaissementRecusClients_06_08);
            etatPlanTresorerieModel.TotalRecette_06_08 = string.Format(frCult, "{0:n}", TotalRecette_06_08);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_06_08 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_06_08);
            etatPlanTresorerieModel.DecaissementFournisseurs_06_08 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_06_08);
            etatPlanTresorerieModel.DecaissementPrestataires_06_08 = string.Format(frCult, "{0:n}", DecaissementPrestataires_06_08);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_06_08 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_06_08);
            etatPlanTresorerieModel.DecaissementSalairesNets_06_08 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_06_08);
            etatPlanTresorerieModel.CotisationsSociales_06_08 = string.Format(frCult, "{0:n}", CotisationsSociales_06_08);
            etatPlanTresorerieModel.IRGSalaires_06_08 = string.Format(frCult, "{0:n}", IRGSalaires_06_08);
            etatPlanTresorerieModel.TVAPayer_06_08 = string.Format(frCult, "{0:n}", TVAPayer_06_08);
            etatPlanTresorerieModel.IBS_IFU_06_08 = string.Format(frCult, "{0:n}", IBS_IFU_06_08);
            etatPlanTresorerieModel.TotalDepense_06_08 = string.Format(frCult, "{0:n}", TotalDepense_06_08);
            etatPlanTresorerieModel.SoldeFinal_06_08 = string.Format(frCult, "{0:n}", SoldeFinal_06_08);

            #endregion

            #region Données EtatPlanTresorerie Année06 Mois09

            etatPlanTresorerieModel.SoldeInitial_06_09 = string.Format(frCult, "{0:n}", SoldeInitial_06_09);
            etatPlanTresorerieModel.ApportSupplementaire_06_09 = string.Format(frCult, "{0:n}", ApportSupplementaire_06_09);
            etatPlanTresorerieModel.CMT_06_09 = string.Format(frCult, "{0:n}", CMT_06_09);
            etatPlanTresorerieModel.PNRClassique_06_09 = string.Format(frCult, "{0:n}", PNRClassique_06_09);
            etatPlanTresorerieModel.ApportPersonnel_06_09 = string.Format(frCult, "{0:n}", ApportPersonnel_06_09);
            etatPlanTresorerieModel.PNRLoyer_06_09 = string.Format(frCult, "{0:n}", PNRLoyer_06_09);
            etatPlanTresorerieModel.EncaissementRecusClients_06_09 = string.Format(frCult, "{0:n}", EncaissementRecusClients_06_09);
            etatPlanTresorerieModel.TotalRecette_06_09 = string.Format(frCult, "{0:n}", TotalRecette_06_09);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_06_09 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_06_09);
            etatPlanTresorerieModel.DecaissementFournisseurs_06_09 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_06_09);
            etatPlanTresorerieModel.DecaissementPrestataires_06_09 = string.Format(frCult, "{0:n}", DecaissementPrestataires_06_09);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_06_09 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_06_09);
            etatPlanTresorerieModel.DecaissementSalairesNets_06_09 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_06_09);
            etatPlanTresorerieModel.CotisationsSociales_06_09 = string.Format(frCult, "{0:n}", CotisationsSociales_06_09);
            etatPlanTresorerieModel.IRGSalaires_06_09 = string.Format(frCult, "{0:n}", IRGSalaires_06_09);
            etatPlanTresorerieModel.TVAPayer_06_09 = string.Format(frCult, "{0:n}", TVAPayer_06_09);
            etatPlanTresorerieModel.IBS_IFU_06_09 = string.Format(frCult, "{0:n}", IBS_IFU_06_09);
            etatPlanTresorerieModel.TotalDepense_06_09 = string.Format(frCult, "{0:n}", TotalDepense_06_09);
            etatPlanTresorerieModel.SoldeFinal_06_09 = string.Format(frCult, "{0:n}", SoldeFinal_06_09);

            #endregion

            #region Données EtatPlanTresorerie Année06 Mois10

            etatPlanTresorerieModel.SoldeInitial_06_10 = string.Format(frCult, "{0:n}", SoldeInitial_06_10);
            etatPlanTresorerieModel.ApportSupplementaire_06_10 = string.Format(frCult, "{0:n}", ApportSupplementaire_06_10);
            etatPlanTresorerieModel.CMT_06_10 = string.Format(frCult, "{0:n}", CMT_06_10);
            etatPlanTresorerieModel.PNRClassique_06_10 = string.Format(frCult, "{0:n}", PNRClassique_06_10);
            etatPlanTresorerieModel.ApportPersonnel_06_10 = string.Format(frCult, "{0:n}", ApportPersonnel_06_10);
            etatPlanTresorerieModel.PNRLoyer_06_10 = string.Format(frCult, "{0:n}", PNRLoyer_06_10);
            etatPlanTresorerieModel.EncaissementRecusClients_06_10 = string.Format(frCult, "{0:n}", EncaissementRecusClients_06_10);
            etatPlanTresorerieModel.TotalRecette_06_10 = string.Format(frCult, "{0:n}", TotalRecette_06_10);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_06_10 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_06_10);
            etatPlanTresorerieModel.DecaissementFournisseurs_06_10 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_06_10);
            etatPlanTresorerieModel.DecaissementPrestataires_06_10 = string.Format(frCult, "{0:n}", DecaissementPrestataires_06_10);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_06_10 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_06_10);
            etatPlanTresorerieModel.DecaissementSalairesNets_06_10 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_06_10);
            etatPlanTresorerieModel.CotisationsSociales_06_10 = string.Format(frCult, "{0:n}", CotisationsSociales_06_10);
            etatPlanTresorerieModel.IRGSalaires_06_10 = string.Format(frCult, "{0:n}", IRGSalaires_06_10);
            etatPlanTresorerieModel.TVAPayer_06_10 = string.Format(frCult, "{0:n}", TVAPayer_06_10);
            etatPlanTresorerieModel.IBS_IFU_06_10 = string.Format(frCult, "{0:n}", IBS_IFU_06_10);
            etatPlanTresorerieModel.TotalDepense_06_10 = string.Format(frCult, "{0:n}", TotalDepense_06_10);
            etatPlanTresorerieModel.SoldeFinal_06_10 = string.Format(frCult, "{0:n}", SoldeFinal_06_10);

            #endregion

            #region Données EtatPlanTresorerie Année06 Mois11

            etatPlanTresorerieModel.SoldeInitial_06_11 = string.Format(frCult, "{0:n}", SoldeInitial_06_11);
            etatPlanTresorerieModel.ApportSupplementaire_06_11 = string.Format(frCult, "{0:n}", ApportSupplementaire_06_11);
            etatPlanTresorerieModel.CMT_06_11 = string.Format(frCult, "{0:n}", CMT_06_11);
            etatPlanTresorerieModel.PNRClassique_06_11 = string.Format(frCult, "{0:n}", PNRClassique_06_11);
            etatPlanTresorerieModel.ApportPersonnel_06_11 = string.Format(frCult, "{0:n}", ApportPersonnel_06_11);
            etatPlanTresorerieModel.PNRLoyer_06_11 = string.Format(frCult, "{0:n}", PNRLoyer_06_11);
            etatPlanTresorerieModel.EncaissementRecusClients_06_11 = string.Format(frCult, "{0:n}", EncaissementRecusClients_06_11);
            etatPlanTresorerieModel.TotalRecette_06_11 = string.Format(frCult, "{0:n}", TotalRecette_06_11);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_06_11 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_06_11);
            etatPlanTresorerieModel.DecaissementFournisseurs_06_11 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_06_11);
            etatPlanTresorerieModel.DecaissementPrestataires_06_11 = string.Format(frCult, "{0:n}", DecaissementPrestataires_06_11);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_06_11 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_06_11);
            etatPlanTresorerieModel.DecaissementSalairesNets_06_11 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_06_11);
            etatPlanTresorerieModel.CotisationsSociales_06_11 = string.Format(frCult, "{0:n}", CotisationsSociales_06_11);
            etatPlanTresorerieModel.IRGSalaires_06_11 = string.Format(frCult, "{0:n}", IRGSalaires_06_11);
            etatPlanTresorerieModel.TVAPayer_06_11 = string.Format(frCult, "{0:n}", TVAPayer_06_11);
            etatPlanTresorerieModel.IBS_IFU_06_11 = string.Format(frCult, "{0:n}", IBS_IFU_06_11);
            etatPlanTresorerieModel.TotalDepense_06_11 = string.Format(frCult, "{0:n}", TotalDepense_06_11);
            etatPlanTresorerieModel.SoldeFinal_06_11 = string.Format(frCult, "{0:n}", SoldeFinal_06_11);

            #endregion

            #region Données EtatPlanTresorerie Année06 Mois12

            etatPlanTresorerieModel.SoldeInitial_06_12 = string.Format(frCult, "{0:n}", SoldeInitial_06_12);
            etatPlanTresorerieModel.ApportSupplementaire_06_12 = string.Format(frCult, "{0:n}", ApportSupplementaire_06_12);
            etatPlanTresorerieModel.CMT_06_12 = string.Format(frCult, "{0:n}", CMT_06_12);
            etatPlanTresorerieModel.PNRClassique_06_12 = string.Format(frCult, "{0:n}", PNRClassique_06_12);
            etatPlanTresorerieModel.ApportPersonnel_06_12 = string.Format(frCult, "{0:n}", ApportPersonnel_06_12);
            etatPlanTresorerieModel.PNRLoyer_06_12 = string.Format(frCult, "{0:n}", PNRLoyer_06_12);
            etatPlanTresorerieModel.EncaissementRecusClients_06_12 = string.Format(frCult, "{0:n}", EncaissementRecusClients_06_12);
            etatPlanTresorerieModel.TotalRecette_06_12 = string.Format(frCult, "{0:n}", TotalRecette_06_12);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_06_12 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_06_12);
            etatPlanTresorerieModel.DecaissementFournisseurs_06_12 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_06_12);
            etatPlanTresorerieModel.DecaissementPrestataires_06_12 = string.Format(frCult, "{0:n}", DecaissementPrestataires_06_12);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_06_12 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_06_12);
            etatPlanTresorerieModel.DecaissementSalairesNets_06_12 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_06_12);
            etatPlanTresorerieModel.CotisationsSociales_06_12 = string.Format(frCult, "{0:n}", CotisationsSociales_06_12);
            etatPlanTresorerieModel.IRGSalaires_06_12 = string.Format(frCult, "{0:n}", IRGSalaires_06_12);
            etatPlanTresorerieModel.TVAPayer_06_12 = string.Format(frCult, "{0:n}", TVAPayer_06_12);
            etatPlanTresorerieModel.IBS_IFU_06_12 = string.Format(frCult, "{0:n}", IBS_IFU_06_12);
            etatPlanTresorerieModel.TotalDepense_06_12 = string.Format(frCult, "{0:n}", TotalDepense_06_12);
            etatPlanTresorerieModel.SoldeFinal_06_12 = string.Format(frCult, "{0:n}", SoldeFinal_06_12);

            #endregion

            #endregion

            #region Données etatPlanTresorerieModel Année07

            #region Données EtatPlanTresorerie Année07 Mois01

            etatPlanTresorerieModel.SoldeInitial_07_01 = string.Format(frCult, "{0:n}", SoldeInitial_07_01);
            etatPlanTresorerieModel.ApportSupplementaire_07_01 = string.Format(frCult, "{0:n}", ApportSupplementaire_07_01);
            etatPlanTresorerieModel.CMT_07_01 = string.Format(frCult, "{0:n}", CMT_07_01);
            etatPlanTresorerieModel.PNRClassique_07_01 = string.Format(frCult, "{0:n}", PNRClassique_07_01);
            etatPlanTresorerieModel.ApportPersonnel_07_01 = string.Format(frCult, "{0:n}", ApportPersonnel_07_01);
            etatPlanTresorerieModel.PNRLoyer_07_01 = string.Format(frCult, "{0:n}", PNRLoyer_07_01);
            etatPlanTresorerieModel.EncaissementRecusClients_07_01 = string.Format(frCult, "{0:n}", EncaissementRecusClients_07_01);
            etatPlanTresorerieModel.TotalRecette_07_01 = string.Format(frCult, "{0:n}", TotalRecette_07_01);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_07_01 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_07_01);
            etatPlanTresorerieModel.DecaissementFournisseurs_07_01 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_07_01);
            etatPlanTresorerieModel.DecaissementPrestataires_07_01 = string.Format(frCult, "{0:n}", DecaissementPrestataires_07_01);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_07_01 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_07_01);
            etatPlanTresorerieModel.DecaissementSalairesNets_07_01 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_07_01);
            etatPlanTresorerieModel.CotisationsSociales_07_01 = string.Format(frCult, "{0:n}", CotisationsSociales_07_01);
            etatPlanTresorerieModel.IRGSalaires_07_01 = string.Format(frCult, "{0:n}", IRGSalaires_07_01);
            etatPlanTresorerieModel.TVAPayer_07_01 = string.Format(frCult, "{0:n}", TVAPayer_07_01);
            etatPlanTresorerieModel.IBS_IFU_07_01 = string.Format(frCult, "{0:n}", IBS_IFU_07_01);
            etatPlanTresorerieModel.TotalDepense_07_01 = string.Format(frCult, "{0:n}", TotalDepense_07_01);
            etatPlanTresorerieModel.SoldeFinal_07_01 = string.Format(frCult, "{0:n}", SoldeFinal_07_01);

            #endregion

            #region Données EtatPlanTresorerie Année07 Mois02

            etatPlanTresorerieModel.SoldeInitial_07_02 = string.Format(frCult, "{0:n}", SoldeInitial_07_02);
            etatPlanTresorerieModel.ApportSupplementaire_07_02 = string.Format(frCult, "{0:n}", ApportSupplementaire_07_02);
            etatPlanTresorerieModel.CMT_07_02 = string.Format(frCult, "{0:n}", CMT_07_02);
            etatPlanTresorerieModel.PNRClassique_07_02 = string.Format(frCult, "{0:n}", PNRClassique_07_02);
            etatPlanTresorerieModel.ApportPersonnel_07_02 = string.Format(frCult, "{0:n}", ApportPersonnel_07_02);
            etatPlanTresorerieModel.PNRLoyer_07_02 = string.Format(frCult, "{0:n}", PNRLoyer_07_02);
            etatPlanTresorerieModel.EncaissementRecusClients_07_02 = string.Format(frCult, "{0:n}", EncaissementRecusClients_07_02);
            etatPlanTresorerieModel.TotalRecette_07_02 = string.Format(frCult, "{0:n}", TotalRecette_07_02);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_07_02 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_07_02);
            etatPlanTresorerieModel.DecaissementFournisseurs_07_02 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_07_02);
            etatPlanTresorerieModel.DecaissementPrestataires_07_02 = string.Format(frCult, "{0:n}", DecaissementPrestataires_07_02);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_07_02 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_07_02);
            etatPlanTresorerieModel.DecaissementSalairesNets_07_02 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_07_02);
            etatPlanTresorerieModel.CotisationsSociales_07_02 = string.Format(frCult, "{0:n}", CotisationsSociales_07_02);
            etatPlanTresorerieModel.IRGSalaires_07_02 = string.Format(frCult, "{0:n}", IRGSalaires_07_02);
            etatPlanTresorerieModel.TVAPayer_07_02 = string.Format(frCult, "{0:n}", TVAPayer_07_02);
            etatPlanTresorerieModel.IBS_IFU_07_02 = string.Format(frCult, "{0:n}", IBS_IFU_07_02);
            etatPlanTresorerieModel.TotalDepense_07_02 = string.Format(frCult, "{0:n}", TotalDepense_07_02);
            etatPlanTresorerieModel.SoldeFinal_07_02 = string.Format(frCult, "{0:n}", SoldeFinal_07_02);

            #endregion

            #region Données EtatPlanTresorerie Année07 Mois03

            etatPlanTresorerieModel.SoldeInitial_07_03 = string.Format(frCult, "{0:n}", SoldeInitial_07_03);
            etatPlanTresorerieModel.ApportSupplementaire_07_03 = string.Format(frCult, "{0:n}", ApportSupplementaire_07_03);
            etatPlanTresorerieModel.CMT_07_03 = string.Format(frCult, "{0:n}", CMT_07_03);
            etatPlanTresorerieModel.PNRClassique_07_03 = string.Format(frCult, "{0:n}", PNRClassique_07_03);
            etatPlanTresorerieModel.ApportPersonnel_07_03 = string.Format(frCult, "{0:n}", ApportPersonnel_07_03);
            etatPlanTresorerieModel.PNRLoyer_07_03 = string.Format(frCult, "{0:n}", PNRLoyer_07_03);
            etatPlanTresorerieModel.EncaissementRecusClients_07_03 = string.Format(frCult, "{0:n}", EncaissementRecusClients_07_03);
            etatPlanTresorerieModel.TotalRecette_07_03 = string.Format(frCult, "{0:n}", TotalRecette_07_03);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_07_03 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_07_03);
            etatPlanTresorerieModel.DecaissementFournisseurs_07_03 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_07_03);
            etatPlanTresorerieModel.DecaissementPrestataires_07_03 = string.Format(frCult, "{0:n}", DecaissementPrestataires_07_03);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_07_03 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_07_03);
            etatPlanTresorerieModel.DecaissementSalairesNets_07_03 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_07_03);
            etatPlanTresorerieModel.CotisationsSociales_07_03 = string.Format(frCult, "{0:n}", CotisationsSociales_07_03);
            etatPlanTresorerieModel.IRGSalaires_07_03 = string.Format(frCult, "{0:n}", IRGSalaires_07_03);
            etatPlanTresorerieModel.TVAPayer_07_03 = string.Format(frCult, "{0:n}", TVAPayer_07_03);
            etatPlanTresorerieModel.IBS_IFU_07_03 = string.Format(frCult, "{0:n}", IBS_IFU_07_03);
            etatPlanTresorerieModel.TotalDepense_07_03 = string.Format(frCult, "{0:n}", TotalDepense_07_03);
            etatPlanTresorerieModel.SoldeFinal_07_03 = string.Format(frCult, "{0:n}", SoldeFinal_07_03);

            #endregion

            #region Données EtatPlanTresorerie Année07 Mois04

            etatPlanTresorerieModel.SoldeInitial_07_04 = string.Format(frCult, "{0:n}", SoldeInitial_07_04);
            etatPlanTresorerieModel.ApportSupplementaire_07_04 = string.Format(frCult, "{0:n}", ApportSupplementaire_07_04);
            etatPlanTresorerieModel.CMT_07_04 = string.Format(frCult, "{0:n}", CMT_07_04);
            etatPlanTresorerieModel.PNRClassique_07_04 = string.Format(frCult, "{0:n}", PNRClassique_07_04);
            etatPlanTresorerieModel.ApportPersonnel_07_04 = string.Format(frCult, "{0:n}", ApportPersonnel_07_04);
            etatPlanTresorerieModel.PNRLoyer_07_04 = string.Format(frCult, "{0:n}", PNRLoyer_07_04);
            etatPlanTresorerieModel.EncaissementRecusClients_07_04 = string.Format(frCult, "{0:n}", EncaissementRecusClients_07_04);
            etatPlanTresorerieModel.TotalRecette_07_04 = string.Format(frCult, "{0:n}", TotalRecette_07_04);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_07_04 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_07_04);
            etatPlanTresorerieModel.DecaissementFournisseurs_07_04 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_07_04);
            etatPlanTresorerieModel.DecaissementPrestataires_07_04 = string.Format(frCult, "{0:n}", DecaissementPrestataires_07_04);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_07_04 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_07_04);
            etatPlanTresorerieModel.DecaissementSalairesNets_07_04 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_07_04);
            etatPlanTresorerieModel.CotisationsSociales_07_04 = string.Format(frCult, "{0:n}", CotisationsSociales_07_04);
            etatPlanTresorerieModel.IRGSalaires_07_04 = string.Format(frCult, "{0:n}", IRGSalaires_07_04);
            etatPlanTresorerieModel.TVAPayer_07_04 = string.Format(frCult, "{0:n}", TVAPayer_07_04);
            etatPlanTresorerieModel.IBS_IFU_07_04 = string.Format(frCult, "{0:n}", IBS_IFU_07_04);
            etatPlanTresorerieModel.TotalDepense_07_04 = string.Format(frCult, "{0:n}", TotalDepense_07_04);
            etatPlanTresorerieModel.SoldeFinal_07_04 = string.Format(frCult, "{0:n}", SoldeFinal_07_04);

            #endregion

            #region Données EtatPlanTresorerie Année07 Mois05

            etatPlanTresorerieModel.SoldeInitial_07_05 = string.Format(frCult, "{0:n}", SoldeInitial_07_05);
            etatPlanTresorerieModel.ApportSupplementaire_07_05 = string.Format(frCult, "{0:n}", ApportSupplementaire_07_05);
            etatPlanTresorerieModel.CMT_07_05 = string.Format(frCult, "{0:n}", CMT_07_05);
            etatPlanTresorerieModel.PNRClassique_07_05 = string.Format(frCult, "{0:n}", PNRClassique_07_05);
            etatPlanTresorerieModel.ApportPersonnel_07_05 = string.Format(frCult, "{0:n}", ApportPersonnel_07_05);
            etatPlanTresorerieModel.PNRLoyer_07_05 = string.Format(frCult, "{0:n}", PNRLoyer_07_05);
            etatPlanTresorerieModel.EncaissementRecusClients_07_05 = string.Format(frCult, "{0:n}", EncaissementRecusClients_07_05);
            etatPlanTresorerieModel.TotalRecette_07_05 = string.Format(frCult, "{0:n}", TotalRecette_07_05);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_07_05 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_07_05);
            etatPlanTresorerieModel.DecaissementFournisseurs_07_05 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_07_05);
            etatPlanTresorerieModel.DecaissementPrestataires_07_05 = string.Format(frCult, "{0:n}", DecaissementPrestataires_07_05);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_07_05 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_07_05);
            etatPlanTresorerieModel.DecaissementSalairesNets_07_05 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_07_05);
            etatPlanTresorerieModel.CotisationsSociales_07_05 = string.Format(frCult, "{0:n}", CotisationsSociales_07_05);
            etatPlanTresorerieModel.IRGSalaires_07_05 = string.Format(frCult, "{0:n}", IRGSalaires_07_05);
            etatPlanTresorerieModel.TVAPayer_07_05 = string.Format(frCult, "{0:n}", TVAPayer_07_05);
            etatPlanTresorerieModel.IBS_IFU_07_05 = string.Format(frCult, "{0:n}", IBS_IFU_07_05);
            etatPlanTresorerieModel.TotalDepense_07_05 = string.Format(frCult, "{0:n}", TotalDepense_07_05);
            etatPlanTresorerieModel.SoldeFinal_07_05 = string.Format(frCult, "{0:n}", SoldeFinal_07_05);

            #endregion

            #region Données EtatPlanTresorerie Année07 Mois06

            etatPlanTresorerieModel.SoldeInitial_07_06 = string.Format(frCult, "{0:n}", SoldeInitial_07_06);
            etatPlanTresorerieModel.ApportSupplementaire_07_06 = string.Format(frCult, "{0:n}", ApportSupplementaire_07_06);
            etatPlanTresorerieModel.CMT_07_06 = string.Format(frCult, "{0:n}", CMT_07_06);
            etatPlanTresorerieModel.PNRClassique_07_06 = string.Format(frCult, "{0:n}", PNRClassique_07_06);
            etatPlanTresorerieModel.ApportPersonnel_07_06 = string.Format(frCult, "{0:n}", ApportPersonnel_07_06);
            etatPlanTresorerieModel.PNRLoyer_07_06 = string.Format(frCult, "{0:n}", PNRLoyer_07_06);
            etatPlanTresorerieModel.EncaissementRecusClients_07_06 = string.Format(frCult, "{0:n}", EncaissementRecusClients_07_06);
            etatPlanTresorerieModel.TotalRecette_07_06 = string.Format(frCult, "{0:n}", TotalRecette_07_06);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_07_06 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_07_06);
            etatPlanTresorerieModel.DecaissementFournisseurs_07_06 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_07_06);
            etatPlanTresorerieModel.DecaissementPrestataires_07_06 = string.Format(frCult, "{0:n}", DecaissementPrestataires_07_06);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_07_06 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_07_06);
            etatPlanTresorerieModel.DecaissementSalairesNets_07_06 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_07_06);
            etatPlanTresorerieModel.CotisationsSociales_07_06 = string.Format(frCult, "{0:n}", CotisationsSociales_07_06);
            etatPlanTresorerieModel.IRGSalaires_07_06 = string.Format(frCult, "{0:n}", IRGSalaires_07_06);
            etatPlanTresorerieModel.TVAPayer_07_06 = string.Format(frCult, "{0:n}", TVAPayer_07_06);
            etatPlanTresorerieModel.IBS_IFU_07_06 = string.Format(frCult, "{0:n}", IBS_IFU_07_06);
            etatPlanTresorerieModel.TotalDepense_07_06 = string.Format(frCult, "{0:n}", TotalDepense_07_06);
            etatPlanTresorerieModel.SoldeFinal_07_06 = string.Format(frCult, "{0:n}", SoldeFinal_07_06);

            #endregion

            #region Données EtatPlanTresorerie Année07 Mois07

            etatPlanTresorerieModel.SoldeInitial_07_07 = string.Format(frCult, "{0:n}", SoldeInitial_07_07);
            etatPlanTresorerieModel.ApportSupplementaire_07_07 = string.Format(frCult, "{0:n}", ApportSupplementaire_07_07);
            etatPlanTresorerieModel.CMT_07_07 = string.Format(frCult, "{0:n}", CMT_07_07);
            etatPlanTresorerieModel.PNRClassique_07_07 = string.Format(frCult, "{0:n}", PNRClassique_07_07);
            etatPlanTresorerieModel.ApportPersonnel_07_07 = string.Format(frCult, "{0:n}", ApportPersonnel_07_07);
            etatPlanTresorerieModel.PNRLoyer_07_07 = string.Format(frCult, "{0:n}", PNRLoyer_07_07);
            etatPlanTresorerieModel.EncaissementRecusClients_07_07 = string.Format(frCult, "{0:n}", EncaissementRecusClients_07_07);
            etatPlanTresorerieModel.TotalRecette_07_07 = string.Format(frCult, "{0:n}", TotalRecette_07_07);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_07_07 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_07_07);
            etatPlanTresorerieModel.DecaissementFournisseurs_07_07 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_07_07);
            etatPlanTresorerieModel.DecaissementPrestataires_07_07 = string.Format(frCult, "{0:n}", DecaissementPrestataires_07_07);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_07_07 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_07_07);
            etatPlanTresorerieModel.DecaissementSalairesNets_07_07 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_07_07);
            etatPlanTresorerieModel.CotisationsSociales_07_07 = string.Format(frCult, "{0:n}", CotisationsSociales_07_07);
            etatPlanTresorerieModel.IRGSalaires_07_07 = string.Format(frCult, "{0:n}", IRGSalaires_07_07);
            etatPlanTresorerieModel.TVAPayer_07_07 = string.Format(frCult, "{0:n}", TVAPayer_07_07);
            etatPlanTresorerieModel.IBS_IFU_07_07 = string.Format(frCult, "{0:n}", IBS_IFU_07_07);
            etatPlanTresorerieModel.TotalDepense_07_07 = string.Format(frCult, "{0:n}", TotalDepense_07_07);
            etatPlanTresorerieModel.SoldeFinal_07_07 = string.Format(frCult, "{0:n}", SoldeFinal_07_07);

            #endregion

            #region Données EtatPlanTresorerie Année07 Mois08

            etatPlanTresorerieModel.SoldeInitial_07_08 = string.Format(frCult, "{0:n}", SoldeInitial_07_08);
            etatPlanTresorerieModel.ApportSupplementaire_07_08 = string.Format(frCult, "{0:n}", ApportSupplementaire_07_08);
            etatPlanTresorerieModel.CMT_07_08 = string.Format(frCult, "{0:n}", CMT_07_08);
            etatPlanTresorerieModel.PNRClassique_07_08 = string.Format(frCult, "{0:n}", PNRClassique_07_08);
            etatPlanTresorerieModel.ApportPersonnel_07_08 = string.Format(frCult, "{0:n}", ApportPersonnel_07_08);
            etatPlanTresorerieModel.PNRLoyer_07_08 = string.Format(frCult, "{0:n}", PNRLoyer_07_08);
            etatPlanTresorerieModel.EncaissementRecusClients_07_08 = string.Format(frCult, "{0:n}", EncaissementRecusClients_07_08);
            etatPlanTresorerieModel.TotalRecette_07_08 = string.Format(frCult, "{0:n}", TotalRecette_07_08);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_07_08 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_07_08);
            etatPlanTresorerieModel.DecaissementFournisseurs_07_08 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_07_08);
            etatPlanTresorerieModel.DecaissementPrestataires_07_08 = string.Format(frCult, "{0:n}", DecaissementPrestataires_07_08);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_07_08 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_07_08);
            etatPlanTresorerieModel.DecaissementSalairesNets_07_08 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_07_08);
            etatPlanTresorerieModel.CotisationsSociales_07_08 = string.Format(frCult, "{0:n}", CotisationsSociales_07_08);
            etatPlanTresorerieModel.IRGSalaires_07_08 = string.Format(frCult, "{0:n}", IRGSalaires_07_08);
            etatPlanTresorerieModel.TVAPayer_07_08 = string.Format(frCult, "{0:n}", TVAPayer_07_08);
            etatPlanTresorerieModel.IBS_IFU_07_08 = string.Format(frCult, "{0:n}", IBS_IFU_07_08);
            etatPlanTresorerieModel.TotalDepense_07_08 = string.Format(frCult, "{0:n}", TotalDepense_07_08);
            etatPlanTresorerieModel.SoldeFinal_07_08 = string.Format(frCult, "{0:n}", SoldeFinal_07_08);

            #endregion

            #region Données EtatPlanTresorerie Année07 Mois09

            etatPlanTresorerieModel.SoldeInitial_07_09 = string.Format(frCult, "{0:n}", SoldeInitial_07_09);
            etatPlanTresorerieModel.ApportSupplementaire_07_09 = string.Format(frCult, "{0:n}", ApportSupplementaire_07_09);
            etatPlanTresorerieModel.CMT_07_09 = string.Format(frCult, "{0:n}", CMT_07_09);
            etatPlanTresorerieModel.PNRClassique_07_09 = string.Format(frCult, "{0:n}", PNRClassique_07_09);
            etatPlanTresorerieModel.ApportPersonnel_07_09 = string.Format(frCult, "{0:n}", ApportPersonnel_07_09);
            etatPlanTresorerieModel.PNRLoyer_07_09 = string.Format(frCult, "{0:n}", PNRLoyer_07_09);
            etatPlanTresorerieModel.EncaissementRecusClients_07_09 = string.Format(frCult, "{0:n}", EncaissementRecusClients_07_09);
            etatPlanTresorerieModel.TotalRecette_07_09 = string.Format(frCult, "{0:n}", TotalRecette_07_09);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_07_09 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_07_09);
            etatPlanTresorerieModel.DecaissementFournisseurs_07_09 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_07_09);
            etatPlanTresorerieModel.DecaissementPrestataires_07_09 = string.Format(frCult, "{0:n}", DecaissementPrestataires_07_09);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_07_09 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_07_09);
            etatPlanTresorerieModel.DecaissementSalairesNets_07_09 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_07_09);
            etatPlanTresorerieModel.CotisationsSociales_07_09 = string.Format(frCult, "{0:n}", CotisationsSociales_07_09);
            etatPlanTresorerieModel.IRGSalaires_07_09 = string.Format(frCult, "{0:n}", IRGSalaires_07_09);
            etatPlanTresorerieModel.TVAPayer_07_09 = string.Format(frCult, "{0:n}", TVAPayer_07_09);
            etatPlanTresorerieModel.IBS_IFU_07_09 = string.Format(frCult, "{0:n}", IBS_IFU_07_09);
            etatPlanTresorerieModel.TotalDepense_07_09 = string.Format(frCult, "{0:n}", TotalDepense_07_09);
            etatPlanTresorerieModel.SoldeFinal_07_09 = string.Format(frCult, "{0:n}", SoldeFinal_07_09);

            #endregion

            #region Données EtatPlanTresorerie Année07 Mois10

            etatPlanTresorerieModel.SoldeInitial_07_10 = string.Format(frCult, "{0:n}", SoldeInitial_07_10);
            etatPlanTresorerieModel.ApportSupplementaire_07_10 = string.Format(frCult, "{0:n}", ApportSupplementaire_07_10);
            etatPlanTresorerieModel.CMT_07_10 = string.Format(frCult, "{0:n}", CMT_07_10);
            etatPlanTresorerieModel.PNRClassique_07_10 = string.Format(frCult, "{0:n}", PNRClassique_07_10);
            etatPlanTresorerieModel.ApportPersonnel_07_10 = string.Format(frCult, "{0:n}", ApportPersonnel_07_10);
            etatPlanTresorerieModel.PNRLoyer_07_10 = string.Format(frCult, "{0:n}", PNRLoyer_07_10);
            etatPlanTresorerieModel.EncaissementRecusClients_07_10 = string.Format(frCult, "{0:n}", EncaissementRecusClients_07_10);
            etatPlanTresorerieModel.TotalRecette_07_10 = string.Format(frCult, "{0:n}", TotalRecette_07_10);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_07_10 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_07_10);
            etatPlanTresorerieModel.DecaissementFournisseurs_07_10 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_07_10);
            etatPlanTresorerieModel.DecaissementPrestataires_07_10 = string.Format(frCult, "{0:n}", DecaissementPrestataires_07_10);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_07_10 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_07_10);
            etatPlanTresorerieModel.DecaissementSalairesNets_07_10 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_07_10);
            etatPlanTresorerieModel.CotisationsSociales_07_10 = string.Format(frCult, "{0:n}", CotisationsSociales_07_10);
            etatPlanTresorerieModel.IRGSalaires_07_10 = string.Format(frCult, "{0:n}", IRGSalaires_07_10);
            etatPlanTresorerieModel.TVAPayer_07_10 = string.Format(frCult, "{0:n}", TVAPayer_07_10);
            etatPlanTresorerieModel.IBS_IFU_07_10 = string.Format(frCult, "{0:n}", IBS_IFU_07_10);
            etatPlanTresorerieModel.TotalDepense_07_10 = string.Format(frCult, "{0:n}", TotalDepense_07_10);
            etatPlanTresorerieModel.SoldeFinal_07_10 = string.Format(frCult, "{0:n}", SoldeFinal_07_10);

            #endregion

            #region Données EtatPlanTresorerie Année07 Mois11

            etatPlanTresorerieModel.SoldeInitial_07_11 = string.Format(frCult, "{0:n}", SoldeInitial_07_11);
            etatPlanTresorerieModel.ApportSupplementaire_07_11 = string.Format(frCult, "{0:n}", ApportSupplementaire_07_11);
            etatPlanTresorerieModel.CMT_07_11 = string.Format(frCult, "{0:n}", CMT_07_11);
            etatPlanTresorerieModel.PNRClassique_07_11 = string.Format(frCult, "{0:n}", PNRClassique_07_11);
            etatPlanTresorerieModel.ApportPersonnel_07_11 = string.Format(frCult, "{0:n}", ApportPersonnel_07_11);
            etatPlanTresorerieModel.PNRLoyer_07_11 = string.Format(frCult, "{0:n}", PNRLoyer_07_11);
            etatPlanTresorerieModel.EncaissementRecusClients_07_11 = string.Format(frCult, "{0:n}", EncaissementRecusClients_07_11);
            etatPlanTresorerieModel.TotalRecette_07_11 = string.Format(frCult, "{0:n}", TotalRecette_07_11);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_07_11 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_07_11);
            etatPlanTresorerieModel.DecaissementFournisseurs_07_11 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_07_11);
            etatPlanTresorerieModel.DecaissementPrestataires_07_11 = string.Format(frCult, "{0:n}", DecaissementPrestataires_07_11);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_07_11 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_07_11);
            etatPlanTresorerieModel.DecaissementSalairesNets_07_11 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_07_11);
            etatPlanTresorerieModel.CotisationsSociales_07_11 = string.Format(frCult, "{0:n}", CotisationsSociales_07_11);
            etatPlanTresorerieModel.IRGSalaires_07_11 = string.Format(frCult, "{0:n}", IRGSalaires_07_11);
            etatPlanTresorerieModel.TVAPayer_07_11 = string.Format(frCult, "{0:n}", TVAPayer_07_11);
            etatPlanTresorerieModel.IBS_IFU_07_11 = string.Format(frCult, "{0:n}", IBS_IFU_07_11);
            etatPlanTresorerieModel.TotalDepense_07_11 = string.Format(frCult, "{0:n}", TotalDepense_07_11);
            etatPlanTresorerieModel.SoldeFinal_07_11 = string.Format(frCult, "{0:n}", SoldeFinal_07_11);

            #endregion

            #region Données EtatPlanTresorerie Année07 Mois12

            etatPlanTresorerieModel.SoldeInitial_07_12 = string.Format(frCult, "{0:n}", SoldeInitial_07_12);
            etatPlanTresorerieModel.ApportSupplementaire_07_12 = string.Format(frCult, "{0:n}", ApportSupplementaire_07_12);
            etatPlanTresorerieModel.CMT_07_12 = string.Format(frCult, "{0:n}", CMT_07_12);
            etatPlanTresorerieModel.PNRClassique_07_12 = string.Format(frCult, "{0:n}", PNRClassique_07_12);
            etatPlanTresorerieModel.ApportPersonnel_07_12 = string.Format(frCult, "{0:n}", ApportPersonnel_07_12);
            etatPlanTresorerieModel.PNRLoyer_07_12 = string.Format(frCult, "{0:n}", PNRLoyer_07_12);
            etatPlanTresorerieModel.EncaissementRecusClients_07_12 = string.Format(frCult, "{0:n}", EncaissementRecusClients_07_12);
            etatPlanTresorerieModel.TotalRecette_07_12 = string.Format(frCult, "{0:n}", TotalRecette_07_12);
            etatPlanTresorerieModel.AcquisitionEquipementAmenagement_07_12 = string.Format(frCult, "{0:n}", AcquisitionEquipementAmenagement_07_12);
            etatPlanTresorerieModel.DecaissementFournisseurs_07_12 = string.Format(frCult, "{0:n}", DecaissementFournisseurs_07_12);
            etatPlanTresorerieModel.DecaissementPrestataires_07_12 = string.Format(frCult, "{0:n}", DecaissementPrestataires_07_12);
            etatPlanTresorerieModel.PaiementFGAssurancesFraisLieesCreation_07_12 = string.Format(frCult, "{0:n}", PaiementFGAssurancesFraisLieesCreation_07_12);
            etatPlanTresorerieModel.DecaissementSalairesNets_07_12 = string.Format(frCult, "{0:n}", DecaissementSalairesNets_07_12);
            etatPlanTresorerieModel.CotisationsSociales_07_12 = string.Format(frCult, "{0:n}", CotisationsSociales_07_12);
            etatPlanTresorerieModel.IRGSalaires_07_12 = string.Format(frCult, "{0:n}", IRGSalaires_07_12);
            etatPlanTresorerieModel.TVAPayer_07_12 = string.Format(frCult, "{0:n}", TVAPayer_07_12);
            etatPlanTresorerieModel.IBS_IFU_07_12 = string.Format(frCult, "{0:n}", IBS_IFU_07_12);
            etatPlanTresorerieModel.TotalDepense_07_12 = string.Format(frCult, "{0:n}", TotalDepense_07_12);
            etatPlanTresorerieModel.SoldeFinal_07_12 = string.Format(frCult, "{0:n}", SoldeFinal_07_12);

            #endregion

            #endregion

            #endregion

            return PartialView($"_{nameof(EtatPlanTresorerie)}", etatPlanTresorerieModel);
        }

        [Authorize(Roles = "Analyste")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> EtatEvaluationProjet(int id)
        {
            //var modelBusinessPlan = _businessPlanBusinessService.GetById(id);
            var modelBusinessPlan = _businessPlanBusinessService.GetById(id, _businessPlanBusinessService.GetDefaultLoadProperties());

            ViewData["BusinessPlanID"] = id;
            ViewData["NumeroSIEJE"] = modelBusinessPlan.NumeroSIEJE;

            var listeRubriqueChargesExternes = new SelectList(_rubriqueChargesExternesBusinessService.GetAll(), "Id", "CodeDesignationFr");

            ViewData["RubriqueChargesExternesID"] = listeRubriqueChargesExternes;

            if (modelBusinessPlan.Complet)
            {
                ViewData["CompletOuiNon"] = "Oui";
            }
            else
            {
                ViewData["CompletOuiNon"] = "Non";
            }

            System.Globalization.CultureInfo frCult = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");

            #region Données EtatEvaluationProjet

            decimal MontantTresorerieNetAnnee01 = 0;
            decimal MontantCashFlowActualisesAnnee01 = 0;
            decimal MontantCumulCFActualisesAnnee01 = 0;

            decimal MontantTresorerieNetAnnee02 = 0;
            decimal MontantCashFlowActualisesAnnee02 = 0;
            decimal MontantCumulCFActualisesAnnee02 = 0;

            decimal MontantTresorerieNetAnnee03 = 0;
            decimal MontantCashFlowActualisesAnnee03 = 0;
            decimal MontantCumulCFActualisesAnnee03 = 0;

            decimal MontantTresorerieNetAnnee04 = 0;
            decimal MontantCashFlowActualisesAnnee04 = 0;
            decimal MontantCumulCFActualisesAnnee04 = 0;

            decimal MontantTresorerieNetAnnee05 = 0;
            decimal MontantCashFlowActualisesAnnee05 = 0;
            decimal MontantCumulCFActualisesAnnee05 = 0;

            decimal MontantTresorerieNetAnnee06 = 0;
            decimal MontantCashFlowActualisesAnnee06 = 0;
            decimal MontantCumulCFActualisesAnnee06 = 0;

            decimal MontantTresorerieNetAnnee07 = 0;
            decimal MontantCashFlowActualisesAnnee07 = 0;
            decimal MontantCumulCFActualisesAnnee07 = 0;

            decimal MontantValeurActuelleNette = 0;
            decimal TauxValeurActuelleNette = 0;
            string DelaiRecuperation = "01 an";
            decimal InvestissementInitial = 0;

            #endregion

            EtatEvaluationProjetModel etatEvaluationProjetModel = new();

            #region Données EtatEvaluationProjetModel

            etatEvaluationProjetModel.MontantTresorerieNetAnnee01 = string.Format(frCult, "{0:n}", MontantTresorerieNetAnnee01);
            etatEvaluationProjetModel.MontantCashFlowActualisesAnnee01 = string.Format(frCult, "{0:n}", MontantCashFlowActualisesAnnee01);
            etatEvaluationProjetModel.MontantCumulCFActualisesAnnee01 = string.Format(frCult, "{0:n}", MontantCumulCFActualisesAnnee01);

            etatEvaluationProjetModel.MontantTresorerieNetAnnee02 = string.Format(frCult, "{0:n}", MontantTresorerieNetAnnee02);
            etatEvaluationProjetModel.MontantCashFlowActualisesAnnee02 = string.Format(frCult, "{0:n}", MontantCashFlowActualisesAnnee02);
            etatEvaluationProjetModel.MontantCumulCFActualisesAnnee02 = string.Format(frCult, "{0:n}", MontantCumulCFActualisesAnnee02);

            etatEvaluationProjetModel.MontantTresorerieNetAnnee03 = string.Format(frCult, "{0:n}", MontantTresorerieNetAnnee03);
            etatEvaluationProjetModel.MontantCashFlowActualisesAnnee03 = string.Format(frCult, "{0:n}", MontantCashFlowActualisesAnnee03);
            etatEvaluationProjetModel.MontantCumulCFActualisesAnnee03 = string.Format(frCult, "{0:n}", MontantCumulCFActualisesAnnee03);

            etatEvaluationProjetModel.MontantTresorerieNetAnnee04 = string.Format(frCult, "{0:n}", MontantTresorerieNetAnnee04);
            etatEvaluationProjetModel.MontantCashFlowActualisesAnnee04 = string.Format(frCult, "{0:n}", MontantCashFlowActualisesAnnee04);
            etatEvaluationProjetModel.MontantCumulCFActualisesAnnee04 = string.Format(frCult, "{0:n}", MontantCumulCFActualisesAnnee04);

            etatEvaluationProjetModel.MontantTresorerieNetAnnee05 = string.Format(frCult, "{0:n}", MontantTresorerieNetAnnee05);
            etatEvaluationProjetModel.MontantCashFlowActualisesAnnee05 = string.Format(frCult, "{0:n}", MontantCashFlowActualisesAnnee05);
            etatEvaluationProjetModel.MontantCumulCFActualisesAnnee05 = string.Format(frCult, "{0:n}", MontantCumulCFActualisesAnnee05);

            etatEvaluationProjetModel.MontantTresorerieNetAnnee06 = string.Format(frCult, "{0:n}", MontantTresorerieNetAnnee06);
            etatEvaluationProjetModel.MontantCashFlowActualisesAnnee06 = string.Format(frCult, "{0:n}", MontantCashFlowActualisesAnnee06);
            etatEvaluationProjetModel.MontantCumulCFActualisesAnnee06 = string.Format(frCult, "{0:n}", MontantCumulCFActualisesAnnee06);

            etatEvaluationProjetModel.MontantTresorerieNetAnnee07 = string.Format(frCult, "{0:n}", MontantTresorerieNetAnnee07);
            etatEvaluationProjetModel.MontantCashFlowActualisesAnnee07 = string.Format(frCult, "{0:n}", MontantCashFlowActualisesAnnee07);
            etatEvaluationProjetModel.MontantCumulCFActualisesAnnee07 = string.Format(frCult, "{0:n}", MontantCumulCFActualisesAnnee07);

            etatEvaluationProjetModel.MontantValeurActuelleNette = string.Format(frCult, "{0:n}", MontantValeurActuelleNette);
            etatEvaluationProjetModel.TauxValeurActuelleNette = string.Format(frCult, "{0:n}", TauxValeurActuelleNette);
            etatEvaluationProjetModel.DelaiRecuperation = DelaiRecuperation;
            etatEvaluationProjetModel.InvestissementInitial = string.Format(frCult, "{0:n}", InvestissementInitial);

            #endregion

            return PartialView($"_{nameof(EtatEvaluationProjet)}", etatEvaluationProjetModel);
        }

    }
}
