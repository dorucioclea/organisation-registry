namespace OrganisationRegistry.SqlServer.ElasticSearchProjections
{
    using System;
    using Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class IsActivePerOrganisationCapacity
    {
        public Guid OrganisationCapacityId { get; set; }
        public bool IsActive { get; set; }
    }

    public class IsActivePerOrganisationCapacityListConfiguration : EntityMappingConfiguration<IsActivePerOrganisationCapacity>
    {
        public const string TableName = "IsActivePerOrganisationCapacityList";

        public override void Map(EntityTypeBuilder<IsActivePerOrganisationCapacity> b)
        {
            b.ToTable(TableName, "OrganisationRegistry")
                .HasKey(p => p.OrganisationCapacityId)
                .IsClustered(false);

            b.Property(p => p.IsActive).IsRequired();
        }
    }
}
