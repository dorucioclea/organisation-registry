﻿namespace OrganisationRegistry.Organisation
{
    using System;

    public class OrganisationBuilding
    {
        public Guid OrganisationBuildingId { get; }

        public Guid OrganisationId { get; }

        public Guid BuildingId { get; }
        public string BuildingName { get; }

        public bool IsMainBuilding { get; }

        public Period Validity { get; }

        public OrganisationBuilding(
            Guid organisationBuildingId,
            Guid organisationId,
            Guid buildingId,
            string buildingName,
            bool isMainBuilding,
            Period validity)
        {
            OrganisationBuildingId = organisationBuildingId;
            OrganisationId = organisationId;
            BuildingId = buildingId;
            BuildingName = buildingName;
            IsMainBuilding = isMainBuilding;
            Validity = validity;
        }

        public bool IsValid(DateTime date)
        {
            return Validity.OverlapsWith(new Period(new ValidFrom(date), new ValidTo(date)));
        }

        protected bool Equals(OrganisationBuilding other)
        {
            return OrganisationBuildingId.Equals(other.OrganisationBuildingId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((OrganisationBuilding) obj);
        }

        public override int GetHashCode()
        {
            return OrganisationBuildingId.GetHashCode();
        }
    }
}