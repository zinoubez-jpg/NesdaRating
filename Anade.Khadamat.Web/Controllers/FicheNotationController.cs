using Anade.Khadamat.Business;
using Anade.Khadamat.Domain;
using Anade.Khadamat.Identity;
using Anade.Khadamat.Web.Models;
using Anade.Khadamat.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anade.Khadamat.Web.Controllers
{
    public class FicheNotationController : Controller
    {
        private readonly FicheNotationBusinessService _ficheNotationBusinessService;
        private readonly PromoteurApiService _promoteurApiService;
        private readonly UserService _userService;
        public FicheNotationController(UserService userService, 
                                       FicheNotationBusinessService ficheNotationBusinessService,
                                       PromoteurApiService promoteurApiService)
        {
            _ficheNotationBusinessService = ficheNotationBusinessService;
            _promoteurApiService = promoteurApiService;
            _userService = userService;
        }

        [Authorize(Roles = "Analyste,DG,Admin,AdminAgence,Utilisateur-Rating")]
        public async Task<IActionResult> FicheNotationList()
        {
            List<FicheNotation> model = new List<FicheNotation>();
            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> DataTableFicheNotation(DataTableAjaxModel model)
        {
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

            GetDataTableParameters(model, out string search, out string orderBy, out int startRowIndex, out int maxRows);
            if (!string.IsNullOrEmpty(search))
            {
                if (structure.Designation == "DG")
                {
                    var result = _ficheNotationBusinessService.GetAllFilteredPaged(x => x.Numero.StartsWith(search) || x.Activite.Contains(search) || x.RAISON_SOCIALE.Contains(search),
                                                                                   orderBy, startRowIndex, maxRows, _ficheNotationBusinessService.GetDefaultLoadProperties());
                    return Json(new JQueryDataTableRetunedData<FicheNotation> { draw = model.draw, recordsFiltered = result.TotalCount, recordsTotal = result.TotalCount, data = result.Items });
                }
                else
                {
                    var result = _ficheNotationBusinessService.GetAllFilteredPaged(x => x.Annexe.Code.StartsWith(structure.CodeStructure) && (x.Numero.StartsWith(search) || x.Activite.Contains(search) || x.RAISON_SOCIALE.Contains(search)),
                                                                                   orderBy, startRowIndex, maxRows, _ficheNotationBusinessService.GetDefaultLoadProperties());
                    return Json(new JQueryDataTableRetunedData<FicheNotation> { draw = model.draw, recordsFiltered = result.TotalCount, recordsTotal = result.TotalCount, data = result.Items });
                }
            }
            else
            {
                if (structure.Designation == "DG")
                {
                    var result = _ficheNotationBusinessService.GetAllPaged(orderBy, startRowIndex, maxRows, _ficheNotationBusinessService.GetDefaultLoadProperties());
                    return Json(new JQueryDataTableRetunedData<FicheNotation> { draw = model.draw, recordsFiltered = result.TotalCount, recordsTotal = result.TotalCount, data = result.Items });
                }
                else
                {
                    var result = _ficheNotationBusinessService.GetAllFilteredPaged(x => x.Annexe.Code.StartsWith(structure.CodeStructure),orderBy, startRowIndex, maxRows, _ficheNotationBusinessService.GetDefaultLoadProperties());
                    return Json(new JQueryDataTableRetunedData<FicheNotation> { draw = model.draw, recordsFiltered = result.TotalCount, recordsTotal = result.TotalCount, data = result.Items });
                }
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        protected static void GetDataTableParameters(DataTableAjaxModel model, out string search, out string orderBy, out int startRowIndex, out int maxRows)
        {
            maxRows = model.length;
            startRowIndex = model.start;
            string sortBy = "", sortDir = "";
            if (model.order != null)
            {
                // in this example we just default sort on the 1st column
                sortBy = model.columns[model.order[0].column].data;
                sortDir = model.order[0].dir.ToLower();
                orderBy = sortBy + " " + sortDir;
            }
            else
            {
                orderBy = "";
            }

            if (model.search.value != null)
            {
                search = model.search.value;
            }
            else
            {
                search = "";
            }

        }

    }
}
