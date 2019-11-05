// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace OrganisationRegistry.Import.Piavo.Models
{
    using System.Linq;

    public partial class OrganisationLocationListItem
    {
        /// <summary>
        /// Initializes a new instance of the OrganisationLocationListItem
        /// class.
        /// </summary>
        public OrganisationLocationListItem() { }

        /// <summary>
        /// Initializes a new instance of the OrganisationLocationListItem
        /// class.
        /// </summary>
        public OrganisationLocationListItem(System.Guid? organisationLocationId = default(System.Guid?), System.Guid? organisationId = default(System.Guid?), System.Guid? locationId = default(System.Guid?), string locationName = default(string), System.Guid? locationTypeId = default(System.Guid?), string locationTypeName = default(string), bool? isMainLocation = default(bool?), System.DateTime? validFrom = default(System.DateTime?), System.DateTime? validTo = default(System.DateTime?))
        {
            OrganisationLocationId = organisationLocationId;
            OrganisationId = organisationId;
            LocationId = locationId;
            LocationName = locationName;
            LocationTypeId = locationTypeId;
            LocationTypeName = locationTypeName;
            IsMainLocation = isMainLocation;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "organisationLocationId")]
        public System.Guid? OrganisationLocationId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "organisationId")]
        public System.Guid? OrganisationId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "locationId")]
        public System.Guid? LocationId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "locationName")]
        public string LocationName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "locationTypeId")]
        public System.Guid? LocationTypeId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "locationTypeName")]
        public string LocationTypeName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isMainLocation")]
        public bool? IsMainLocation { get; set; }

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
