using Aircash.Web.Business.HttpClientService.ServiceHelpers;
using Aircash.Web.DataContract;
using Aircash.Web.DataContract.DTOs;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace Aircash.Web.Business.HttpClientService
{
    public class ApiService : IApiService
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _client;
        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseModel<IEnumerable<IataDTO>>> GetIataCodeAsync()
        {
            try
            {
                _logger.Info($"{MethodBase.GetCurrentMethod()} execute");

                _client = _httpClientFactory.CreateClient("Api");

                var response = await _client.GetAsync(ServiceUrlHelper.GetIataCode());
                if (response.IsSuccessStatusCode)
                {
                    var iataCode = JsonConvert.DeserializeObject<IEnumerable<IataDTO>>(await response.Content.ReadAsStringAsync());
                    return new ResponseModel<IEnumerable<IataDTO>>
                    {
                        Value = iataCode
                    };
                }

                return new ResponseModel<IEnumerable<IataDTO>>
                {
                    ErrorMsg = "Some error!!"
                };
            }
            catch (Exception ex)
            {
                _logger.Error("Error:", ex);
                return new ResponseModel<IEnumerable<IataDTO>>
                {
                    ErrorMsg = $"Error: {ex.Message} InnerException {ex?.InnerException}"
                };
            }

        }
    }
}
