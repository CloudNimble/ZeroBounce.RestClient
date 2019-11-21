namespace ZeroBounce.Models 
{

    /// <summary>
    /// Api return results for GetCredits call
    /// </summary>
    public class CreditsResponse 
    {

        /// <summary>
        /// The amount of credits you have left in your account for email validations. If a -1 is returned, that means your API Key is invalid.
        /// </summary>
        public long Credits { get; set; }

        /// <summary>
        /// This will hold any kind of error from the request or response
        /// </summary>
        public string ErrorMessage { get; set; }

    }

}