using Aircash.Business.HttpClientService.ServiceHelpers;
using Aircash.DataContract.HotelResponse;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aircash.Business.HttpClientService
{
    public class AmadeusHotelHttpClientService : IAmadeusHotelHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private HttpClient _client;
        private IOathTokenService _tokenService;
        public AmadeusHotelHttpClientService(IHttpClientFactory httpClientFactory, IOathTokenService tokenService)
        {
            _httpClientFactory = httpClientFactory;
            _tokenService = tokenService;
        }


        public async Task<AmadeusHotelResponse> GetHotelDataAsync(string cityCode, DateTime checkInDate, DateTime checkOutDate, int adults)
        {
            var token = await _tokenService.GetTokenAsync();

            _client = _httpClientFactory.CreateClient("AmadeusApi");
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.OathToken}");

            var response 
                = await _client
                .GetAsync(
                    string.Format(ServiceUrlHelper.GetData(),cityCode,checkInDate.ToString("yyyy-MM-dd"), checkOutDate.ToString("yyyy-MM-dd"), adults)
                    );

            return JsonConvert.DeserializeObject<AmadeusHotelResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}
