using Anade.Business.Core;
using Anade.Khadamat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anade.Khadamat.Web.Services
{
    public class WilayaApiService:GenericApiService<Wilaya>
    {

        private readonly AppSettings _appSettings;

        private readonly string _baseUrl;
        public WilayaApiService(HttpClient httpClient, AppSettings appSettings, ApiServicesUrls apiServicesUrls) : base(httpClient, apiServicesUrls)
        {

            _appSettings = appSettings;

            _baseUrl = apiServicesUrls.GetBaseUrl<Wilaya>();
        }


    }
}
