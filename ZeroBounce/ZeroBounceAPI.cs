using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using ZeroBounce.Models;

namespace ZeroBounce {
    /// <summary>
    /// ZeroBounce Api dotnet core wrapper
    /// </summary>
    public class ZeroBounceAPI {
        private const string BASE_URL = "https://api.zerobounce.net/v1/";
        private string _apiKey = null;
        private int _requestTimeOut = 200000;

        /// <summary>
        /// Api Key to be used with the API Call. Available at https://www.zerobounce.net/members/apikey/
        /// </summary>
        public string ApiKey {
            get { return _apiKey; }
            set { _apiKey = value; }
        }

        /// <summary>
        /// Depending on how you use the API, you might want it to time out faster, for example on a registration screen. Normally the API will return results very fast, but a small percentage of mail servers take upwards of 20+ seconds to respond. If the API times out, it will return a status of "Unknown" and a sub_status of "timeout_exceeded"
        /// </summary>
        public int RequestTimeOut {
            get { return _requestTimeOut; }
            set { _requestTimeOut = value; }
        }

        /// <summary>
        /// Method calls the ZeroBounce api to validate the email
        /// </summary>
        /// <param name="email">Email address to validate</param>
        /// <param name="ipAddress">Ip Address to validate with (Optional)</param>
        /// <returns>ZeroBounceResultsModel</returns>
        public ZeroBounceResultsModel ValidateEmail(string email, string ipAddress = null) {
           var apiUrl = string.Empty;

            if (string.IsNullOrEmpty(ipAddress)) {
                apiUrl = BASE_URL + "validate" +
                    "?apikey=" + ApiKey +
                    "&email=" + WebUtility.UrlEncode(email);
            }
            else {
                apiUrl = BASE_URL + "validatewithip" +
                    "?apikey=" + ApiKey +
                    "&email=" + WebUtility.UrlEncode(email) +
                    "&ipaddress=" + WebUtility.UrlEncode(ipAddress);
            }

            try {
                return DoRequest<ZeroBounceResultsModel>(apiUrl);
            }
            catch (Exception ex) {
                return new ZeroBounceResultsModel {
                    Status = "Unknown",
                    SubStatus = ex.Message.Contains("The operation has timed out") ? "timeout_exceeded" : "exception_occurred",
                    Domain = email.Substring(email.IndexOf("@") + 1).ToLower(),
                    Account = email.Substring(0, email.IndexOf("@")).ToLower(),
                    Address = email.ToLower(),
                    ErrorMessage = ex.ToString()
                };
            }
        }

        /// <summary>
        /// Method calls the ZeroBounce api to find the number of credits left for an account
        /// </summary>
        /// <returns>ZeroBounceCreditsModel</returns>
        public ZeroBounceCreditsModel GetCredits() {
            var apiUrl = BASE_URL + "getcredits?apikey=" + ApiKey;
            var responseString = string.Empty;

            try {
                return DoRequest<ZeroBounceCreditsModel>(apiUrl);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return new ZeroBounceCreditsModel {
                    ErrorMessage = ex.ToString()
                };
            }
        }

        private T DoRequest<T>(string url) {
            var request = (HttpWebRequest)WebRequest.Create(url);
            if (RequestTimeOut > 0) request.Timeout = RequestTimeOut;
            request.Method = "GET";
            Console.WriteLine("APIKey: " + ApiKey);
            Console.WriteLine("Request URL: " + url);

            using (var response = request.GetResponse()) {
                using (var ostream = new StreamReader(response.GetResponseStream())) {
                    var responseString = ostream.ReadToEnd();
                    Console.WriteLine("Response: " + responseString);
                    return JsonConvert.DeserializeObject<T>(responseString);
                }
            }
        }
    }
}
