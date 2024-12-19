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

        private readonly PosteBusinessService _PosteBusinessService;

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
                                             ReferentielBusinessService<RubriqueChargesExternes, int> rubriqueChargesExternesBusinessService

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
                model.StructureFinancement.ApportPersonnel = Math.Round(Convert.ToDecimal(model.StructureFinancement.ApportPersonnelString.Replace(".", ",")), 2);
                model.StructureFinancement.CMT = Math.Round(Convert.ToDecimal(model.StructureFinancement.CMTString.Replace(".", ",")), 2);
                model.StructureFinancement.PNRClassique = Math.Round(Convert.ToDecimal(model.StructureFinancement.PNRClassiqueString.Replace(".", ",")), 2);
                model.StructureFinancement.PNRSupplementaire = Math.Round(Convert.ToDecimal(model.StructureFinancement.PNRSupplementaireString.Replace(".", ",")), 2);
                model.StructureFinancement.ApportSupplementaire = Math.Round(Convert.ToDecimal(model.StructureFinancement.ApportSupplementaireString.Replace(".", ",")), 2);

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

            for (int i = 1; i < model.Length; i += 29)
            {
                int anneeIndex = 1;

                MatierePremiereApprovisionnement matierePremiereApprovisionnement = new();

                matierePremiereApprovisionnement.Code = matierePremiereApprovisionnement.GetCode(businessPlan.Code, indexCodeMatiereApprov);

                matierePremiereApprovisionnement.Designation = model[i];

                for (int j = 0; j < 27; j += 4)
                {
                    DetailAchatsDirects detailAchatsDirects = new();
                    detailAchatsDirects.BusinessPlanId = businessPlanId;
                    detailAchatsDirects.AnneeId = anneeIndex;
                    detailAchatsDirects.Quantite = (float)Math.Round(Convert.ToDouble(model[i + 2 + j].Replace(".", ",")), 2);
                    detailAchatsDirects.PrixUnitaire = Math.Round(Convert.ToDecimal(model[i + 3 + j].Replace(".", ",")), 2);
                    detailAchatsDirects.Montant = Math.Round(Convert.ToDecimal(model[i + 4 + j].Replace(".", ",")), 2);
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

                for (int j = 0; j < 6; j++)
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

            return PartialView($"_{nameof(EtatStructureInvestissement)}", modelBusinessPlan);
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

            return PartialView($"_{nameof(EtatCompteResultat)}", modelBusinessPlan);
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

            return PartialView($"_{nameof(EtatTFT)}", modelBusinessPlan);
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

            return PartialView($"_{nameof(EtatPlanTresorerie)}", modelBusinessPlan);
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

            return PartialView($"_{nameof(EtatEvaluationProjet)}", modelBusinessPlan);
        }

    }
}
