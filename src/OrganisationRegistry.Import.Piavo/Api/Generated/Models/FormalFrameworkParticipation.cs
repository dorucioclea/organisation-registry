// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace OrganisationRegistry.Import.Piavo.Models
{
    using System.Linq;

    public partial class FormalFrameworkParticipation
    {
        /// <summary>
        /// Initializes a new instance of the FormalFrameworkParticipation
        /// class.
        /// </summary>
        public FormalFrameworkParticipation() { }

        /// <summary>
        /// Initializes a new instance of the FormalFrameworkParticipation
        /// class.
        /// </summary>
        public FormalFrameworkParticipation(System.Guid? organisationId = default(System.Guid?), string organisationName = default(string), System.Guid? bodyId = default(System.Guid?), string bodyName = default(string), System.Guid? bodySeatTypeId = default(System.Guid?), string bodySeatTypeName = default(string), double? malePercentage = default(double?), double? femalePercentage = default(double?), double? unknownPercentage = default(double?), int? maleCount = default(int?), int? femaleCount = default(int?), int? unknownCount = default(int?), int? totalCount = default(int?), int? assignedCount = default(int?), int? unassignedCount = default(int?))
        {
            OrganisationId = organisationId;
            OrganisationName = organisationName;
            BodyId = bodyId;
            BodyName = bodyName;
            BodySeatTypeId = bodySeatTypeId;
            BodySeatTypeName = bodySeatTypeName;
            MalePercentage = malePercentage;
            FemalePercentage = femalePercentage;
            UnknownPercentage = unknownPercentage;
            MaleCount = maleCount;
            FemaleCount = femaleCount;
            UnknownCount = unknownCount;
            TotalCount = totalCount;
            AssignedCount = assignedCount;
            UnassignedCount = unassignedCount;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "organisationId")]
        public System.Guid? OrganisationId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "organisationName")]
        public string OrganisationName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "bodyId")]
        public System.Guid? BodyId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "bodyName")]
        public string BodyName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "bodySeatTypeId")]
        public System.Guid? BodySeatTypeId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "bodySeatTypeName")]
        public string BodySeatTypeName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "malePercentage")]
        public double? MalePercentage { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "femalePercentage")]
        public double? FemalePercentage { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "unknownPercentage")]
        public double? UnknownPercentage { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "maleCount")]
        public int? MaleCount { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "femaleCount")]
        public int? FemaleCount { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "unknownCount")]
        public int? UnknownCount { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "totalCount")]
        public int? TotalCount { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "assignedCount")]
        public int? AssignedCount { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "unassignedCount")]
        public int? UnassignedCount { get; set; }

    }
}
