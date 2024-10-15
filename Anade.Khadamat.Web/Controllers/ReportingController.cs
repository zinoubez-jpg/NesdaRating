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





        public ReportingController(ILoadProperties<FicheNotation, int> loadFicheNotationProperties,
                                   IReportService reportService,
                                   FicheNotationBusinessService ficheNotationBusinessService,
                                   PromoteurApiService promoteurApiService,
                                   ReferentielBusinessService<Annexe, int> annexeBusinessService
                                   )

        {
            _loadFicheNotationProperties = loadFicheNotationProperties;
            _ficheNotationBusinessService = ficheNotationBusinessService;
            _reportService = reportService;
            _promoteurApiService = promoteurApiService;
            _annexeBusinessService = annexeBusinessService;

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

    }
}
