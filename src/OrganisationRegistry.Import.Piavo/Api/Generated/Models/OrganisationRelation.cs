// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace OrganisationRegistry.Import.Piavo.Models
{
    using System.Linq;

    public partial class OrganisationRelation
    {
        /// <summary>
        /// Initializes a new instance of the OrganisationRelation class.
        /// </summary>
        public OrganisationRelation() { }

        /// <summary>
        /// Initializes a new instance of the OrganisationRelation class.
        /// </summary>
        public OrganisationRelation(System.Guid? organisationRelationId = default(System.Guid?), System.Guid? relationId = default(System.Guid?), string relationName = default(string), System.Guid? relatedOrganisationId = default(System.Guid?), string relatedOrganisationName = default(string), Period validity = default(Period))
        {
            OrganisationRelationId = organisationRelationId;
            RelationId = relationId;
            RelationName = relationName;
            RelatedOrganisationId = relatedOrganisationId;
            RelatedOrganisationName = relatedOrganisationName;
            Validity = validity;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "organisationRelationId")]
        public System.Guid? OrganisationRelationId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "relationId")]
        public System.Guid? RelationId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "relationName")]
        public string RelationName { get; private set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "relatedOrganisationId")]
        public System.Guid? RelatedOrganisationId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "relatedOrganisationName")]
        public string RelatedOrganisationName { get; private set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "validity")]
        public Period Validity { get; set; }

    }
}
