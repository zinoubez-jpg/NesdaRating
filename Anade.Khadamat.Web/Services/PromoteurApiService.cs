using Anade.Business.Core;
using Anade.Domain.Core;
using Anade.Khadamat.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anade.Khadamat.Web.Services
{
    public class PromoteurApiService : GenericApiService<PROMOTEUR>
    {
        private readonly AppSettings _appSettings;

        private readonly string _baseUrl;
        public PromoteurApiService(HttpClient httpClient, AppSettings appSettings, ApiServicesUrls apiServicesUrls) : base(httpClient, apiServicesUrls)
        {

            _appSettings = appSettings;

            _baseUrl = apiServicesUrls.GetBaseUrl<PROMOTEUR>();
        }

        public async Task<PROMOTEUR> GetByNumDossAsync(string numeroDossier)
        {
            //TDOD: Generate url for GetById api service
            string requestUrl = _apiServicesUrls.GetBaseUrl<PROMOTEUR>("dossier") + $"?numeroDossier={numeroDossier}"; ;

            var responseString = await _httpClient.GetStringAsync(requestUrl);

            var entity = JsonConvert.DeserializeObject<ApiBusinessResult>(responseString);
            var promoteur = JsonConvert.DeserializeObject<PROMOTEUR>(entity.Result.ToString());

            return promoteur;
        }

        public  async Task<PagedResult<PROMOTEUR>> GetAllSuiviPagedAsync(string term, string orderBy, int page = 1, int pageSize = 10)
        {
            //TDOD: Generate url for GetAllPaged api service
            string requestUrl = _apiServicesUrls.GetBaseUrl<PROMOTEUR>("SuiviPaged")  ;


            var responseString = await _httpClient.GetStringAsync(requestUrl);

            var list = JsonConvert.DeserializeObject<PagedResult<PROMOTEUR>>(responseString);

            return list;
        }

        public new async Task<PagedResult<PROMOTEUR>> GetAllPagedAsync(string codeAnnexe,string term, string orderBy, int page = 1, int pageSize = 10)
        {
            //TDOD: Generate url for GetAllPaged api service
            string requestUrl = _apiServicesUrls.GetAllPaged<PROMOTEUR>() + $"?codeAnnexe={codeAnnexe}&term={term}&orderBy={orderBy}&page={page}&pageSize={pageSize}";

            var responseString = await _httpClient.GetStringAsync(requestUrl);

            var list = JsonConvert.DeserializeObject<PagedResult<PROMOTEUR>>(responseString);

            return list;
        }

        //INSCRIPTION API !!!!!!!!!!!!!!!
        //[HttpGet]
        //[Route("suivipagedfiltered")]
        //public PagedResult<Domain.Suivi.PROMOTEUR> GetAllPagedFiltered(string codeAnnexe, string term, string orderBy = "NUM_DOSS", int page = 1, int pageSize = 10)
        //{

        //    if (page < 1)
        //        page = 1;

        //    if (pageSize > MAX_PAGE_SIZE)
        //        pageSize = MAX_PAGE_SIZE;


        //    PagedResult<Domain.Suivi.PROMOTEUR> result;

        //    if (!string.IsNullOrWhiteSpace(term))
        //    {
        //        result = _promoteurSuiviBusinessService.GetAllFilteredPaged(
        //           x => x.CodeAnnexe == codeAnnexe && x.NUM_DOSS.StartsWith(term), orderBy, (page - 1) * pageSize, pageSize, _promoteurSuiviBusinessService.GetDefaultLoadProperties()
        //            );
        //    }
        //    else
        //    {
        //        result = _promoteurSuiviBusinessService.GetAllFilteredPaged(x => x.CodeAnnexe == codeAnnexe, orderBy,
        //            (page - 1) * pageSize, pageSize, _promoteurSuiviBusinessService.GetDefaultLoadProperties());
        //    }

        //    return result;
        //}

    }
}
