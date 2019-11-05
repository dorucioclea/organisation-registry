// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace OrganisationRegistry.Import.Piavo.Models
{
    using System.Linq;

    public partial class CreateConfigurationValueRequest
    {
        /// <summary>
        /// Initializes a new instance of the CreateConfigurationValueRequest
        /// class.
        /// </summary>
        public CreateConfigurationValueRequest() { }

        /// <summary>
        /// Initializes a new instance of the CreateConfigurationValueRequest
        /// class.
        /// </summary>
        public CreateConfigurationValueRequest(string key = default(string), string description = default(string), string value = default(string))
        {
            Key = key;
            Description = description;
            Value = value;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

    }
}
