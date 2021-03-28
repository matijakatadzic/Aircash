using Aircash.DataContract.Settings;
using Aircash.DataContract.Token;
using log4net;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aircash.Business.HttpClientService.ServiceHelpers
{
    public class OathTokenService : IOathTokenService
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Token _token;
        private AppSettings _appSettings;
        private IConfiguration _configuration;
        public OathTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _appSettings = _configuration.Get<AppSettings>();
        }

        private async Task GetNewOathTokenAsync()
        {
            var param = new Dictionary<string, string>();
            var url = _appSettings.AmadeusApi.ApiOathUrl;
            param.Add("grant_type", "client_credentials");
            param.Add("client_id", _appSettings.AmadeusApi.APIKey);
            param.Add("client_secret", _appSettings.AmadeusApi.APISecret);

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            HttpResponseMessage response = await client.PostAsync(url, new FormUrlEncodedContent(param));
            _token = new Token( await response.Content.ReadAsStringAsync());
        }

        public async Task<Token> GetTokenAsync()
        {
            _logger.Info($"{MethodBase.GetCurrentMethod()} execute");
            if (_token == null || _token.ExpireTime <= DateTime.Now)
            {
                _logger.Info($"Token expire");
                await GetNewOathTokenAsync();
            }

            return _token;
        }
    }
}
