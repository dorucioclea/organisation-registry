// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace OrganisationRegistry.Import.Piavo.Models
{
    using System.Linq;

    public partial class AddOrganisationBankAccountRequest
    {
        /// <summary>
        /// Initializes a new instance of the
        /// AddOrganisationBankAccountRequest class.
        /// </summary>
        public AddOrganisationBankAccountRequest() { }

        /// <summary>
        /// Initializes a new instance of the
        /// AddOrganisationBankAccountRequest class.
        /// </summary>
        public AddOrganisationBankAccountRequest(System.Guid? organisationBankAccountId = default(System.Guid?), string bankAccountNumber = default(string), bool? isIban = default(bool?), string bic = default(string), bool? isBic = default(bool?), System.DateTime? validFrom = default(System.DateTime?), System.DateTime? validTo = default(System.DateTime?))
        {
            OrganisationBankAccountId = organisationBankAccountId;
            BankAccountNumber = bankAccountNumber;
            IsIban = isIban;
            Bic = bic;
            IsBic = isBic;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "organisationBankAccountId")]
        public System.Guid? OrganisationBankAccountId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "bankAccountNumber")]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isIban")]
        public bool? IsIban { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "bic")]
        public string Bic { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isBic")]
        public bool? IsBic { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "validFrom")]
        public System.DateTime? ValidFrom { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "validTo")]
        public System.DateTime? ValidTo { get; set; }

    }
}
