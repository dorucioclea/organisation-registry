// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace OrganisationRegistry.Import.Piavo.Models
{
    using System.Linq;

    public partial class UpdateLifecyclePhaseTypeRequest
    {
        /// <summary>
        /// Initializes a new instance of the UpdateLifecyclePhaseTypeRequest
        /// class.
        /// </summary>
        public UpdateLifecyclePhaseTypeRequest() { }

        /// <summary>
        /// Initializes a new instance of the UpdateLifecyclePhaseTypeRequest
        /// class.
        /// </summary>
        public UpdateLifecyclePhaseTypeRequest(string name = default(string), bool? representsActivePhase = default(bool?), bool? isDefaultPhase = default(bool?))
        {
            Name = name;
            RepresentsActivePhase = representsActivePhase;
            IsDefaultPhase = isDefaultPhase;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "representsActivePhase")]
        public bool? RepresentsActivePhase { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isDefaultPhase")]
        public bool? IsDefaultPhase { get; set; }

    }
}