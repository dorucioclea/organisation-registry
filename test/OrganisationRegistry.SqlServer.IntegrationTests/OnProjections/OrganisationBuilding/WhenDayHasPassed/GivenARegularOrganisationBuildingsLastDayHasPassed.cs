namespace OrganisationRegistry.SqlServer.IntegrationTests.OnProjections.OrganisationBuilding.WhenDayHasPassed
{
    using System;
    using System.Collections.Generic;
    using Day.Events;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Organisation.ScheduledActions.Building;
    using TestBases;
    using Tests.Shared;
    using OrganisationRegistry.Building.Events;
    using OrganisationRegistry.Infrastructure.Events;
    using OrganisationRegistry.Organisation.Events;
    using Xunit;

    [Collection(SqlServerTestsCollection.Name)]
    public class GivenARegularOrganisationBuildingsLastDayHasPassed : ReactionCommandsTestBase<ActiveOrganisationBuildingListView, DayHasPassed>
    {
        private readonly SequentialOvoNumberGenerator _sequentialOvoNumberGenerator = new SequentialOvoNumberGenerator();
        public GivenARegularOrganisationBuildingsLastDayHasPassed(SqlServerFixture fixture) : base()
        {
        }

        protected override ActiveOrganisationBuildingListView BuildReactionHandler(IContextFactory contextFactory)
        {
            return new ActiveOrganisationBuildingListView(
                new Mock<ILogger<ActiveOrganisationBuildingListView>>().Object,
                null,
                new DateTimeProvider(),
                contextFactory);
        }

        protected override IEnumerable<IEvent> Given()
        {
            var organisationId = Guid.NewGuid();
            var buildingAId = Guid.NewGuid();
            return new List<IEvent>
            {
                new OrganisationCreated(organisationId, "Kind en Gezin", _sequentialOvoNumberGenerator.GenerateNumber(), "K&G", "Kindjes en gezinnetjes", new List<Purpose>(), false, null, null),
                new BuildingCreated(buildingAId, "Gebouw A456", 12345),
                new OrganisationBuildingAdded(organisationId, Guid.NewGuid(), buildingAId, "Gebouw A456", false, DateTime.Today, DateTime.Today)
            };
        }

        protected override DayHasPassed When()
        {
            return new DayHasPassed(Guid.NewGuid(), DateTime.Today);
        }

        protected override int ExpectedNumberOfCommands => 0;
    }
}
