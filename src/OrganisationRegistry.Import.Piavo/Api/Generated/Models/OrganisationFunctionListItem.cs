// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace OrganisationRegistry.Import.Piavo.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class OrganisationFunctionListItem
    {
        /// <summary>
        /// Initializes a new instance of the OrganisationFunctionListItem
        /// class.
        /// </summary>
        public OrganisationFunctionListItem() { }

        /// <summary>
        /// Initializes a new instance of the OrganisationFunctionListItem
        /// class.
        /// </summary>
        public OrganisationFunctionListItem(Guid? organisationFunctionId = default(Guid?), Guid? organisationId = default(Guid?), Guid? functionId = default(Guid?), string functionName = default(string), Guid? personId = default(Guid?), string personName = default(string), string contactsJson = default(string), DateTime? validFrom = default(DateTime?), DateTime? validTo = default(DateTime?))
        {
            OrganisationFunctionId = organisationFunctionId;
            OrganisationId = organisationId;
            FunctionId = functionId;
            FunctionName = functionName;
            PersonId = personId;
            PersonName = personName;
            ContactsJson = contactsJson;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "organisationFunctionId")]
        public Guid? OrganisationFunctionId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "organisationId")]
        public Guid? OrganisationId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "functionId")]
        public Guid? FunctionId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "functionName")]
        public string FunctionName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "personId")]
        public Guid? PersonId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "personName")]
        public string PersonName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "contactsJson")]
        public string ContactsJson { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validFrom")]
        public DateTime? ValidFrom { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validTo")]
        public DateTime? ValidTo { get; set; }

    }
}
