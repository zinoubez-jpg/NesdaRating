using Anade.Business.Core;
using Anade.Domain.Core;
using Anade.Khadamat.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Anade.Khadamat.Web.Services
{
    public class FournisseurApiService : GenericApiService<Fournisseur>
    {
       
        private readonly AppSettings _appSettings;
        
        private readonly string _baseUrl;
        public FournisseurApiService(HttpClient httpClient, AppSettings appSettings, ApiServicesUrls apiServicesUrls):base(httpClient, apiServicesUrls)
        {
            
            _appSettings = appSettings;
           
            _baseUrl = apiServicesUrls.GetBaseUrl<Fournisseur>();
        }
        

    }

}
