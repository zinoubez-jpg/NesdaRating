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
    public class BusinessPlanController : Controller
    {
        private readonly UserService _userService;
        private readonly FicheNotationBusinessService _ficheNotationBusinessService;
        private readonly BusinessPlanBusinessService _businessPlanBusinessService;
        private readonly PromoteurApiService _promoteurApiService;
        private readonly AnnexeBusinessService _annexeBusinessService;
        private readonly ReferentielBusinessService<Antenne, int> _antenneBusinessService;

        public BusinessPlanController(UserService userService,
                                      FicheNotationBusinessService ficheNotationBusinessService,
                                      BusinessPlanBusinessService businessPlanBusinessService,
                                      PromoteurApiService promoteurApiService,
                                      AnnexeBusinessService annexeBusinessService,
                                      ReferentielBusinessService<Antenne, int> antenneBusinessService)
        {
            _userService = userService;
            _ficheNotationBusinessService = ficheNotationBusinessService;
            _businessPlanBusinessService = businessPlanBusinessService;
            _promoteurApiService = promoteurApiService;
            _annexeBusinessService = annexeBusinessService;
            _antenneBusinessService = antenneBusinessService;
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
                var businessPlan = _businessPlanBusinessService.GetAllPaged();
                var businessPlanByNumDoss = RemoveDuplicatesbusinessPlan(businessPlan.Items);
                foreach (var item in businessPlanByNumDoss) promoteurs.Add(await _promoteurApiService.GetByNumDossAsync(item.NumeroSIEJE));
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

        [Authorize(Roles = "Analyste,DG")]
        public virtual IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Analyste,DG")]
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

        public static List<BusinessPlan> RemoveDuplicatesbusinessPlan(List<BusinessPlan> items)
        {
            List<BusinessPlan> result = new List<BusinessPlan>();
            for (int i = 0; i < items.Count; i++)
            {
                // Assume not duplicate.
                bool duplicate = false;
                for (int z = 0; z < i; z++)
                {
                    if (items[z].NumeroSIEJE == items[i].NumeroSIEJE)
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
