using Newtonsoft.Json;

namespace ZeroBounce.Models {
    /// <summary>
    /// Api return results for ValidateEmail call
    /// </summary>
    public class ValidationResponse {

        /// <summary>
        /// Email address being validated
        /// </summary>
        [JsonProperty("address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// [Valid |Invalid |Catch-All |Unknown |Spamtrap |Abuse |DoNotMail]
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// [antispam_system |greylisted |mail_server_temporary_error |forcible_disconnect |mail_server_did_not_respond |timeout_exceeded |failed_smtp_connection |mailbox_quota_exceeded |exception_occurred |possible_traps |role_based |global_suppression |mailbox_not_found |no_dns_entries |failed_syntax_check |possible_typo |unroutable_ip_address |leading_period_removed |does_not_accept_mail ]
        /// </summary>
        [JsonProperty("sub_status")]
        public string StatusDetails { get; set; }

        /// <summary>
        ///  Portion before the @ symbol"
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Portion after the @ symbol
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Email owner's last name if available
        /// </summary>
        public string DidYouMean { get; set; }

        /// <summary>
        /// Age of the email domain in days or [null].
        /// </summary>
        [JsonProperty("domain_age_days")]
        public int? DomainAgeInDays { get; set; }

        /// <summary>
        /// [true/false] If the email comes from a free provider.
        /// </summary>
        [JsonProperty("free_email")]
        public bool IsFreeEmailProvider { get; set; }

        /// <summary>
        /// [true/false] Does the domain have an MX record.
        /// </summary>
        [JsonProperty("mx_found")]
        public bool WasMxRecordFound { get; set; }

        /// <summary>
        /// The preferred MX record of the domain.
        /// </summary>
        public string SmtpProvider { get; set; }

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
        public string Gender { get; set; }

        /// <summary>
        /// The country of the IP passed in
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The region of the IP passed in
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// The city of the IP passed in
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The zipcode of the IP passed in
        /// </summary>
        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        /// <summary>
        /// UTC time email was validated
        /// </summary>
        [JsonProperty("processedat")]
        public string ProcessedAt { get; set; }

    }

}