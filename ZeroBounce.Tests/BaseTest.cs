namespace ZeroBounce.Tests {
    public class BaseTest {
        private const string API_KEY = "API_KEY";

        protected ZeroBounceAPI GetZeroBounceApi(string apiKey = null) {
            return new ZeroBounceAPI {
                ApiKey = apiKey != null ? apiKey : API_KEY
            };
        }
    }
}
