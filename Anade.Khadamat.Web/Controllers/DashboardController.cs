using Anade.Domain.Core;
using Anade.Khadamat.Business;
using Anade.Khadamat.Domain;
using Anade.Khadamat.Identity;
using Anade.Khadamat.Identity.Services;
using Anade.Khadamat.Web.Models;
using Anade.Khadamat.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Anade.Khadamat.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserService _userService;
        private readonly ProjetBusinessService _projetBusinessService;
        private readonly FicheNotationBusinessService _ficheNotationBusinessService;
        private readonly PromoteurApiService _promoteurApiService;
        public readonly StructureService _structureService;
        public readonly ReferentielBusinessService<Antenne, int> _agenceBusinessService;
        public DashboardController(UserService userService, FicheNotationBusinessService ficheNotationBusinessService,
                                   ProjetBusinessService projetBusinessService,
                                   PromoteurApiService promoteurApiService,
                                   StructureService structureService,
                                   ReferentielBusinessService<Antenne, int> agenceBusinessService
                                   )
        {
            _userService = userService;
            _projetBusinessService = projetBusinessService;
            _promoteurApiService = promoteurApiService;
            _ficheNotationBusinessService = ficheNotationBusinessService;
            _structureService = structureService;
            _agenceBusinessService = agenceBusinessService;
        }
        [Authorize(Roles = "Analyste,DG,Admin,AdminAgence,Utilisateur-Rating")]
        public async Task<IActionResult> Index(int structureId)
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

            ViewBag.StructureId = new SelectList(_structureService.GetAllFiltered(x => x.Niveau.Code == "2", _structureService.GetDefaultLoadProperties()), nameof(Structure.Id), nameof(Structure.Designation));
            if (structure.Designation == "DG")
            {
                var selectedStructure = _structureService.GetById(structureId);
                if (selectedStructure == null)
                {
                    List<PROMOTEUR> projets = new List<PROMOTEUR>();
                    var fiches = _ficheNotationBusinessService.GetAllPaged();
                    foreach (var item in fiches.Items)
                    {
                        var projet = await _promoteurApiService.GetByNumDossAsync(item.PromoteurId);
                        projets.Add(projet);
                    }
                    projets = RemoveDuplicatesProjet(projets);
                    DashboardViewModel dashboardViewModel = new DashboardViewModel
                    {
                        NbProjetEvaluer = projets.Count(),
                        NbFicheNotation = _ficheNotationBusinessService.GetAll().Count(),
                        Admis = _ficheNotationBusinessService.GetAllFiltered(x => x.ScoreTotal >= 42.5).Count(),
                        NonAdmis = _ficheNotationBusinessService.GetAllFiltered(x => x.ScoreTotal <= 42.5).Count(),
                    };
                    return View(dashboardViewModel);
                }
                else
                {
                    List<PROMOTEUR> projets = new List<PROMOTEUR>();
                    var fiches = _ficheNotationBusinessService.GetAllFiltered(x => x.Annexe.Code.StartsWith(selectedStructure.CodeStructure));
                    foreach (var item in fiches)
                    {
                        var projet = await _promoteurApiService.GetByNumDossAsync(item.PromoteurId);
                        projets.Add(projet);
                    }
                    projets = RemoveDuplicatesProjet(projets);
                    DashboardViewModel dashboardViewModel = new DashboardViewModel
                    {
                        NbProjetEvaluer = projets.Count(),
                        NbFicheNotation = _ficheNotationBusinessService.GetAllFiltered(x => x.Annexe.Code.StartsWith(selectedStructure.CodeStructure)).Count(),
                        Admis = _ficheNotationBusinessService.GetAllFiltered(x => x.Annexe.Code.StartsWith(selectedStructure.CodeStructure) && x.Deliberation == "Admis (e)").Count(),
                        NonAdmis = _ficheNotationBusinessService.GetAllFiltered(x => x.Annexe.Code.StartsWith(selectedStructure.CodeStructure) && x.Deliberation == "Non Admis (e)").Count(),
                    };
                    return View(dashboardViewModel);
                }
            }
            else
            {
                List<PROMOTEUR> projets = new List<PROMOTEUR>();
                var fiches = _ficheNotationBusinessService.GetAllFiltered(x => x.Annexe.Antenne.Code.StartsWith(structure.CodeStructure) || x.Annexe.Code.StartsWith(structure.CodeStructure));
                foreach (var item in fiches)
                {
                    var projet = await _promoteurApiService.GetByNumDossAsync(item.PromoteurId);
                    projets.Add(projet);
                }
                projets = RemoveDuplicatesProjet(projets);
                DashboardViewModel dashboardViewModel = new DashboardViewModel
                {
                    NbProjetEvaluer = projets.Count(),
                    NbFicheNotation = _ficheNotationBusinessService.GetAllFiltered(x => x.Annexe.Code.StartsWith(structure.CodeStructure) || x.Annexe.Antenne.Code.StartsWith(structure.CodeStructure)).Count(),
                    Admis = _ficheNotationBusinessService.GetAllFiltered(x => x.Deliberation == "Admis (e)" && (x.Annexe.Code.StartsWith(structure.CodeStructure) || x.Annexe.Antenne.Code.StartsWith(structure.CodeStructure))).Count(),
                    NonAdmis = _ficheNotationBusinessService.GetAllFiltered(x => x.Deliberation == "Non Admis (e)" && (x.Annexe.Code.StartsWith(structure.CodeStructure) || x.Annexe.Antenne.Code.StartsWith(structure.CodeStructure))).Count(),
                };
                return View(dashboardViewModel);
            }
        }
        [Authorize(Roles = "Anade,DG,Admin,AdminAgence")]
        [Authorize(Roles = "Admin,DG")]
        public IActionResult DashboardBI()
        {
            return View();
        }

        public static List<PROMOTEUR> RemoveDuplicatesProjet(List<PROMOTEUR> items)
        {
            List<PROMOTEUR> result = new List<PROMOTEUR>();
            for (int i = 0; i < items.Count; i++)
            {
                // Assume not duplicate.
                bool duplicate = false;
                for (int z = 0; z < i; z++)
                {
                    if (items[z].Id == items[i].Id)
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
