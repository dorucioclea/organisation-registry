// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace OrganisationRegistry.Import.Piavo.Models
{
    using System.Linq;

    public partial class UpdateKeyTypeRequest
    {
        /// <summary>
        /// Initializes a new instance of the UpdateKeyTypeRequest class.
        /// </summary>
        public UpdateKeyTypeRequest() { }

        /// <summary>
        /// Initializes a new instance of the UpdateKeyTypeRequest class.
        /// </summary>
        public UpdateKeyTypeRequest(string name = default(string))
        {
            Name = name;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

    }
}
