// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace OrganisationRegistry.Import.Piavo.Models
{
    using System.Linq;

    public partial class CreateOrganisationRequest
    {
        /// <summary>
        /// Initializes a new instance of the CreateOrganisationRequest class.
        /// </summary>
        public CreateOrganisationRequest() { }

        /// <summary>
        /// Initializes a new instance of the CreateOrganisationRequest class.
        /// </summary>
        public CreateOrganisationRequest(System.Guid? id = default(System.Guid?), string name = default(string), string ovoNumber = default(string), string shortName = default(string), System.Guid? parentOrganisationId = default(System.Guid?), System.Collections.Generic.IList<System.Guid?> purposeIds = default(System.Collections.Generic.IList<System.Guid?>), bool? showOnVlaamseOverheidSites = default(bool?), string description = default(string), System.DateTime? validFrom = default(System.DateTime?), System.DateTime? validTo = default(System.DateTime?))
        {
            Id = id;
            Name = name;
            OvoNumber = ovoNumber;
            ShortName = shortName;
            ParentOrganisationId = parentOrganisationId;
            PurposeIds = purposeIds;
            ShowOnVlaamseOverheidSites = showOnVlaamseOverheidSites;
            Description = description;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public System.Guid? Id { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "kbo")]
        public string Kbo { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ovoNumber")]
        public string OvoNumber { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "parentOrganisationId")]
        public System.Guid? ParentOrganisationId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "purposeIds")]
        public System.Collections.Generic.IList<System.Guid?> PurposeIds { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "showOnVlaamseOverheidSites")]
        public bool? ShowOnVlaamseOverheidSites { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

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
