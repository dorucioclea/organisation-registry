namespace OrganisationRegistry.SqlServer.Person
{
    using System;
    using System.Data.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Infrastructure;
    using OrganisationRegistry.Infrastructure.Events;
    using OrganisationRegistry.Organisation.Events;

    using System.Linq;
    using FunctionType;
    using Microsoft.Extensions.Logging;
    using Organisation;
    using Function.Events;
    using OrganisationRegistry.Infrastructure.AppSpecific;

    public class PersonFunctionListItem
    {
        public Guid OrganisationFunctionId { get; set; }

        public Guid OrganisationId { get; set; }
        public string OrganisationName { get; set; }

        public Guid FunctionId { get; set; }
        public string FunctionName { get; set; }

        public Guid PersonId { get; set; }

        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }

    public class PersonFunctionListConfiguration : EntityMappingConfiguration<PersonFunctionListItem>
    {
        public override void Map(EntityTypeBuilder<PersonFunctionListItem> b)
        {
            b.ToTable(nameof(PersonFunctionListView.ProjectionTables.PersonFunctionList), "OrganisationRegistry")
                .HasKey(p => p.OrganisationFunctionId)
                .ForSqlServerIsClustered(false);

            b.Property(p => p.OrganisationId).IsRequired();
            b.Property(p => p.OrganisationName).HasMaxLength(OrganisationListConfiguration.NameLength).IsRequired();

            b.Property(p => p.FunctionId).IsRequired();
            b.Property(p => p.FunctionName).HasMaxLength(FunctionTypeListConfiguration.NameLength).IsRequired();

            b.Property(p => p.PersonId).IsRequired();

            b.Property(p => p.ValidFrom);
            b.Property(p => p.ValidTo);

            b.HasIndex(x => x.OrganisationName).ForSqlServerIsClustered();
            b.HasIndex(x => x.FunctionName);
            b.HasIndex(x => x.ValidFrom);
            b.HasIndex(x => x.ValidTo);
        }
    }

    public class PersonFunctionListView :
        Projection<PersonFunctionListView>,
        IEventHandler<OrganisationFunctionAdded>,
        IEventHandler<OrganisationFunctionUpdated>,
        IEventHandler<FunctionUpdated>,
        IEventHandler<OrganisationInfoUpdated>,
        IEventHandler<OrganisationInfoUpdatedFromKbo>
    {
        public override string[] ProjectionTableNames => Enum.GetNames(typeof(ProjectionTables));

        public enum ProjectionTables
        {
            PersonFunctionList
        }

        private readonly IEventStore _eventStore;
        private readonly IMemoryCaches _memoryCaches;

        public PersonFunctionListView(
            ILogger<PersonFunctionListView> logger,
            IEventStore eventStore,
            IMemoryCaches memoryCaches) : base(logger)
        {
            _eventStore = eventStore;
            _memoryCaches = memoryCaches;
        }

        public void Handle(DbConnection dbConnection, DbTransaction dbTransaction, IEnvelope<OrganisationInfoUpdated> message)
        {
            UpdateOrganisationName(dbConnection, dbTransaction, message.Body.OrganisationId, message.Body.Name);
        }

        public void Handle(DbConnection dbConnection, DbTransaction dbTransaction, IEnvelope<OrganisationInfoUpdatedFromKbo> message)
        {
            UpdateOrganisationName(dbConnection, dbTransaction, message.Body.OrganisationId, message.Body.Name);
        }

        private static void UpdateOrganisationName(DbConnection dbConnection, DbTransaction dbTransaction, Guid organisationId, string organisationName)
        {
            using (var context = new OrganisationRegistryTransactionalContext(dbConnection, dbTransaction))
            {
                var personFunctions = context.PersonFunctionList.Where(x => x.OrganisationId == organisationId);
                if (!personFunctions.Any())
                    return;

                foreach (var personFunction in personFunctions)
                    personFunction.OrganisationName = organisationName;

                context.SaveChanges();
            }
        }

        public void Handle(DbConnection dbConnection, DbTransaction dbTransaction, IEnvelope<FunctionUpdated> message)
        {
            using (var context = new OrganisationRegistryTransactionalContext(dbConnection, dbTransaction))
            {
                var personFunctions = context.PersonFunctionList.Where(x => x.FunctionId == message.Body.FunctionId);
                if (!personFunctions.Any())
                    return;

                foreach (var personFunction in personFunctions)
                    personFunction.FunctionName = message.Body.Name;

                context.SaveChanges();
            }
        }

        public void Handle(DbConnection dbConnection, DbTransaction dbTransaction, IEnvelope<OrganisationFunctionAdded> message)
        {
            var personFunctionListItem = new PersonFunctionListItem
            {
                OrganisationFunctionId = message.Body.OrganisationFunctionId,
                OrganisationId = message.Body.OrganisationId,
                OrganisationName = _memoryCaches.OrganisationNames[message.Body.OrganisationId],
                FunctionId = message.Body.FunctionId,
                PersonId = message.Body.PersonId,
                FunctionName = message.Body.FunctionName,
                ValidFrom = message.Body.ValidFrom,
                ValidTo = message.Body.ValidTo
            };

            using (var context = new OrganisationRegistryTransactionalContext(dbConnection, dbTransaction))
            {
                context.PersonFunctionList.Add(personFunctionListItem);
                context.SaveChanges();
            }
        }

        public void Handle(DbConnection dbConnection, DbTransaction dbTransaction, IEnvelope<OrganisationFunctionUpdated> message)
        {
            using (var context = new OrganisationRegistryTransactionalContext(dbConnection, dbTransaction))
            {
                var key = context.PersonFunctionList.SingleOrDefault(item => item.OrganisationFunctionId == message.Body.OrganisationFunctionId);

                key.OrganisationFunctionId = message.Body.OrganisationFunctionId;
                key.OrganisationId = message.Body.OrganisationId;
                key.OrganisationName = _memoryCaches.OrganisationNames[message.Body.OrganisationId];
                key.FunctionId = message.Body.FunctionId;
                key.PersonId = message.Body.PersonId;
                key.FunctionName = message.Body.FunctionName;
                key.ValidFrom = message.Body.ValidFrom;
                key.ValidTo = message.Body.ValidTo;

                context.SaveChanges();
            }
        }

        public override void Handle(DbConnection dbConnection, DbTransaction dbTransaction, IEnvelope<RebuildProjection> message)
        {
            RebuildProjection(_eventStore, dbConnection, dbTransaction, message);
        }
    }
}