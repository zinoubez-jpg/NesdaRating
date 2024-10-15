using Anade.Business.Core;
using Anade.Khadamat.Business;
using Anade.Khadamat.Domain;
using Anade.Khadamat.Identity;
using Anade.Khadamat.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anade.Khadamat.Web.Controllers
{
   
    [Route("[controller]/[action]")]
    public class NesdaProjectController : Controller
    {
        private readonly UserService _userService;
        //private readonly ReferentielBusinessService<Annexe, int> _annexeBusinessService;
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
        public NesdaProjectController(UserService userService,
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
                                      PaysApiService paysApiService)
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

        // GET: Generic/Details/5
        [Authorize(Roles = "Analyste,DG,Admin,AdminAgence,Utilisateur-Rating")]
        public virtual async Task<IActionResult> Details(string id)
        {
            ViewData["AnnexeID"] = new SelectList(_annexeBusinessService.GetAll(), "Id", "DesignationFr");
            ViewData["AntenneID"] = new SelectList(_antenneBusinessService.GetAll(), "Id", "DesignationFr");

            var promoteur = await _promoteurApiService.GetByNumDossAsync(id);

            var fiches = _ficheNotationBusinessService.GetAllFiltered(x => x.PromoteurId == promoteur.NUM_DOSS, _ficheNotationBusinessService.GetDefaultLoadProperties());

            promoteur.FicheNotations = fiches;
            if (promoteur == null)
                return NotFound();
            return View(promoteur);
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
        public IActionResult AddFiche(string promoteurId)
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

            var fiche = new FicheNotation { PromoteurId = promoteurId };
            return PartialView($"_{nameof(AddFiche)}");
        }
        [Authorize(Roles = "Analyste")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{promoteurId}")]
        public async Task<IActionResult> AddFiche(string promoteurId, FicheNotation model)
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

            var annexe = _annexeBusinessService.GetSingle(x => x.Code == structure.CodeStructure,_annexeBusinessService.GetDefaultLoadProperties());
            model.AnnexeId = annexe.Id;
            model.Annexe=annexe;
            model.NomAnnexe = annexe.DesignationFr;
            model.NomAntenne = annexe.Antenne.DesignationFr;
            var promoteur = await _promoteurApiService.GetByNumDossAsync(model.PromoteurId);
            model.Activite = promoteur.ACTIVITE;
            model.NOM_P = promoteur.NOM_P;
            model.PRENOM_P = promoteur.PRENOM_P;
            model.DDN_P = promoteur.DDN_P;
            model.RAISON_SOCIALE = promoteur.RAISON_SOCIALE;
            model.DATE_DEPOT = promoteur.DATE_DEPOT;
            model.Date = System.DateTime.Now;
            model.Analyste = user.FullName;
            


            var lastFiche = _ficheNotationBusinessService.GetAllFiltered(x => x.Annexe.Code == structure.CodeStructure, _ficheNotationBusinessService.GetDefaultLoadProperties()).Max(x => x.Numero);

            if (lastFiche == null)
            {
                int numSeq = 0;
                var newNumero = _ficheNotationBusinessService.GenererNumero(structure.CodeStructure, numSeq);
                model.Numero = newNumero;
                
            }
            else
            {
                var lastNumeroFiche = lastFiche.Substring(4);
                var numSeq = int.Parse(lastNumeroFiche);
                var newNumero = _ficheNotationBusinessService.GenererNumero(structure.CodeStructure, numSeq);
                model.Numero = newNumero;
            }

            
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

            if (model.ScoreTotal>=42.5)
            {
                model.Deliberation = "Admis (e)";
            }
            else
            {
                model.Deliberation = "Non Admis (e)";
            }

            if (ModelState.IsValid)
            {
                businessResult = _nesdaProjectBusinessService.AddFiche(model);

                if (businessResult.Succeeded)
                {
                    TempData["Message"] = businessResult.ToBootstrapAlerts();
                    return RedirectToAction(nameof(Fiche), new { promoteurId });
                }
                else
                {

                    return Json(new { messages = businessResult.ToBootstrapAlerts() });
                }
            }
            else
            {
                return PartialView($"_{nameof(AddFiche)}", model);
            }
        }
        [Authorize(Roles = "Analyste")]
        [Route("{id}")]
       
        public async Task<IActionResult> EditFiche(int id)
        {
            var model = _ficheNotationBusinessService.GetById(id , _ficheNotationBusinessService.GetDefaultLoadProperties());
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

            return PartialView($"_{nameof(EditFiche)}", model);
        }
        [Authorize(Roles = "Analyste")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id}")]
        public async Task<IActionResult> EditFiche(int id, FicheNotation model)
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

            model.ScoreTotal = model.ScoreSousTotal  +  model.NoteProduitTemoin;

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
                    return RedirectToAction(nameof(Fiche), new { id = model.PromoteurId });
                }
                else
                {
                    return Json(new { messages = businessResult.ToBootstrapAlerts() });
                }
            }
            else
            {
                return PartialView($"_{nameof(EditFiche)}", model);
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

       

    }
}
