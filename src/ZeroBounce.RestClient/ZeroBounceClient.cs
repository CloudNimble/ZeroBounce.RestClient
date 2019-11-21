using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PortableRest;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ZeroBounce.Models;

namespace ZeroBounce
{

    /// <summary>
    /// 
    /// </summary>
    public class ZeroBounceClient : RestClient
    {

        private const string regularApi = "https://api.zerobounce.net/v2/";

        #region Properties

        private string ApiKey { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        public ZeroBounceClient(string apiKey)
        {
            ApiKey = apiKey;
            JsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public async Task<RestResponse<ValidationResponse>> ValidateEmailAsync(string email, string ipAddress = null)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            var request = new RestRequest(regularApi + "validate", HttpMethod.Get);
            request.AddQueryString("api_key", ApiKey);
            request.AddQueryString("email", email);
            request.AddQueryString("ip_address", ipAddress ?? string.Empty);

            return await SendAsync<ValidationResponse>(request).ConfigureAwait(false);
        }

        #endregion

    }

}
