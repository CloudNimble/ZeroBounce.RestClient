using Newtonsoft.Json;

namespace ZeroBounce.Models {
    /// <summary>
    /// Api return results for ValidateEmail call
    /// </summary>
    public class ZeroBounceResultsModel {
        /// <summary>
        /// Email address being validated
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// [Valid |Invalid |Catch-All |Unknown |Spamtrap |Abuse |DoNotMail]
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// [antispam_system |greylisted |mail_server_temporary_error |forcible_disconnect |mail_server_did_not_respond |timeout_exceeded |failed_smtp_connection |mailbox_quota_exceeded |exception_occurred |possible_traps |role_based |global_suppression |mailbox_not_found |no_dns_entries |failed_syntax_check |possible_typo |unroutable_ip_address |leading_period_removed |does_not_accept_mail ]
        /// </summary>
        [JsonProperty("sub_status")]
        public string SubStatus { get; set; }

        /// <summary>
        ///  Portion before the @ symbol"
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; }

        /// <summary>
        /// Portion after the @ symbol
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// These are temporary emails created for the sole purpose to sign up to websites without giving their real email address. These emails are short lived from 15 minutes to around 6 months. There is only 2 values (True and False). If you have valid emails with this flag set to TRUE, you shouldn't email them.
        /// </summary>
        [JsonProperty("disposable")]
        public bool Disposable { get; set; }

        /// <summary>
        /// These domains are known for abuse, spam, and bot created emails. If you have valid emails with this flag set to TRUE, you shouldn't email them.
        /// </summary>
        [JsonProperty("toxic")]
        public bool Toxic { get; set; }

        /// <summary>
        /// Email owner's first name if available
        /// </summary>
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        /// <summary>
        /// Email owner's last name if available
        /// </summary>
        [JsonProperty("lastname")]
        public string LastName { get; set; }

        /// <summary>
        /// Email owner's gender if available
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Email owner's location if available
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// The country of the IP passed in
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// The region of the IP passed in
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// The city of the IP passed in
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// The zipcode of the IP passed in
        /// </summary>
        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        /// <summary>
        /// Creation date of email if available
        /// </summary>
        [JsonProperty("creationdate")]
        public string CreationDate { get; set; }

        /// <summary>
        /// UTC time email was validated
        /// </summary>
        [JsonProperty("processedat")]
        public string ProcessedAt { get; set; }

        /// <summary>
        /// This will hold any kind of error from the request or response
        /// </summary>
        [JsonProperty("errMsg")]
        public string ErrorMessage { get; set; }
    }
}