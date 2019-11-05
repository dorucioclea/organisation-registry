// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace OrganisationRegistry.Import.Piavo.Models
{
    using System.Linq;

    public partial class AddBodyLifecyclePhaseRequest
    {
        /// <summary>
        /// Initializes a new instance of the AddBodyLifecyclePhaseRequest
        /// class.
        /// </summary>
        public AddBodyLifecyclePhaseRequest() { }

        /// <summary>
        /// Initializes a new instance of the AddBodyLifecyclePhaseRequest
        /// class.
        /// </summary>
        public AddBodyLifecyclePhaseRequest(System.Guid? bodyLifecyclePhaseId = default(System.Guid?), System.Guid? lifecyclePhaseTypeId = default(System.Guid?), System.DateTime? validFrom = default(System.DateTime?), System.DateTime? validTo = default(System.DateTime?))
        {
            BodyLifecyclePhaseId = bodyLifecyclePhaseId;
            LifecyclePhaseTypeId = lifecyclePhaseTypeId;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "bodyLifecyclePhaseId")]
        public System.Guid? BodyLifecyclePhaseId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "lifecyclePhaseTypeId")]
        public System.Guid? LifecyclePhaseTypeId { get; set; }

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
