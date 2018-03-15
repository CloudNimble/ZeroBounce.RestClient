using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using ZeroBounce.Models;

namespace ZeroBounce {
    public class ZeroBounceAPI {
        private const string BASE_URL = "https://api.zerobounce.net/v1/";

        private string _apiKey = null;
        public string ApiKey {
            get { return _apiKey; }
            set { _apiKey = value; }
        }

        private string _ipAddress = null;
        public string IPAddress {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }

        private string _emailToValidate = null;
        public string EmailToValidate {
            get { return _emailToValidate; }
            set { _emailToValidate = value; }
        }

        private int _requestTimeOut = 0;
        public int RequestTimeOut {
            get { return _requestTimeOut; }
            set { _requestTimeOut = value; }
        }

        private int _readTimeOut = 0;
        public int ReadTimeOut {
            get { return _readTimeOut; }
            set { _readTimeOut = value; }
        }

        public ZeroBounceResultsModel ValidateEmail(string email, string ipAddress = null) {
           var apiUrl = string.Empty;

            if (string.IsNullOrEmpty(ipAddress)) {
                apiUrl = BASE_URL + "validate" +
                    "?apikey=" + ApiKey +
                    "&email=" + WebUtility.UrlEncode(EmailToValidate);
            }
            else {
                apiUrl = BASE_URL + "validatewithip" +
                    "?apikey=" + ApiKey +
                    "&email=" + WebUtility.UrlEncode(EmailToValidate) +
                    "&ipaddress=" + WebUtility.UrlEncode(ipAddress);
            }

            var responseString = string.Empty;
            var oResults = new ZeroBounceResultsModel();
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Timeout = RequestTimeOut;
            request.Method = "GET";
            Console.WriteLine("Input APIKey: " + ApiKey);

            try {
                using (var response = request.GetResponse()) {
                    response.GetResponseStream().ReadTimeout = ReadTimeOut;
                    using (var ostream = new StreamReader(response.GetResponseStream())) {
                        responseString = ostream.ReadToEnd();
                        oResults = JsonConvert.DeserializeObject<ZeroBounceResultsModel>(responseString);
                    }
                }
            }
            catch (Exception ex) {
                if (ex.Message.Contains("The operation has timed out")) oResults.subStatus = "timeout_exceeded";
                else oResults.subStatus = "exception_occurred";
                oResults.status = "Unknown";
                oResults.domain = EmailToValidate.Substring(EmailToValidate.IndexOf("@") + 1).ToLower();
                oResults.account = EmailToValidate.Substring(0, EmailToValidate.IndexOf("@")).ToLower();
                oResults.address = EmailToValidate.ToLower();

                Console.WriteLine(ex.ToString());
                oResults.errMsg = ex.ToString();
            }
            return oResults;
        }

        public ZeroBounceCreditsModel GetCredits() {
            var apiUrl = BASE_URL + "getcredits?apikey=" + ApiKey;
            var responseString = string.Empty;
            var oResults = new ZeroBounceCreditsModel();

            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Timeout = RequestTimeOut;
            request.Method = "GET";
            Console.WriteLine("APIKey: " + ApiKey);

            try {
                using (var response = request.GetResponse()) {
                    response.GetResponseStream().ReadTimeout = ReadTimeOut;
                    using (StreamReader ostream = new StreamReader(response.GetResponseStream())) {
                        responseString = ostream.ReadToEnd();
                        oResults = JsonConvert.DeserializeObject<ZeroBounceCreditsModel>(responseString);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                oResults.errMsg = ex.ToString();
            }

            return oResults;
        }
    }
}
