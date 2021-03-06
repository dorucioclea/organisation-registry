﻿namespace OrganisationRegistry.Api.Organisation
{
    using Microsoft.AspNetCore.Mvc;
    using Requests;
    using System.Threading.Tasks;
    using Infrastructure;
    using OrganisationRegistry.Infrastructure.Commands;
    using System;
    using SqlServer.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Infrastructure.Search.Sorting;
    using Infrastructure.Search.Pagination;
    using SqlServer.Organisation;
    using Infrastructure.Search.Filtering;
    using Queries;
    using System.Net;
    using Infrastructure.Security;
    using Security;

    [ApiVersion("1.0")]
    [AdvertiseApiVersions("1.0")]
    [OrganisationRegistryRoute("organisations/{organisationId}/locations")]
    public class OrganisationLocationController : OrganisationRegistryController
    {
        public OrganisationLocationController(ICommandSender commandSender)
            : base(commandSender)
        {
        }

        /// <summary>Get a list of available locations for an organisation.</summary>
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] OrganisationRegistryContext context, [FromRoute] Guid organisationId)
        {
            var filtering = Request.ExtractFilteringRequest<OrganisationLocationListItemFilter>();
            var sorting = Request.ExtractSortingRequest();
            var pagination = Request.ExtractPaginationRequest();

            var pagedOrganisations = new OrganisationLocationListQuery(context, organisationId).Fetch(filtering, sorting, pagination);

            Response.AddPaginationResponse(pagedOrganisations.PaginationInfo);
            Response.AddSortingResponse(sorting.SortBy, sorting.SortOrder);

            return Ok(await pagedOrganisations.Items.ToListAsync());
        }

        /// <summary>Get a location for an organisation.</summary>
        /// <response code="200">If the location is found.</response>
        /// <response code="404">If the location cannot be found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrganisationLocationListItem), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotFoundResult), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromServices] OrganisationRegistryContext context, [FromRoute] Guid organisationId, [FromRoute] Guid id)
        {
            var organisation = await context.OrganisationLocationList.FirstOrDefaultAsync(x => x.OrganisationLocationId == id);

            if (organisation == null)
                return NotFound();

            return Ok(organisation);
        }

        /// <summary>Add a location to an organisation.</summary>
        /// <response code="201">If the location is added, together with the location.</response>
        /// <response code="400">If the location information does not pass validation.</response>
        [HttpPost]
        [OrganisationRegistryAuthorize]
        [ProducesResponseType(typeof(CreatedResult), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromServices] ISecurityService securityService, [FromRoute] Guid organisationId, [FromBody] AddOrganisationLocationRequest message)
        {
            var internalMessage = new AddOrganisationLocationInternalRequest(organisationId, message);

            if (!securityService.CanEditOrganisation(User, internalMessage.OrganisationId))
                ModelState.AddModelError("NotAllowed", "U hebt niet voldoende rechten voor deze organisatie.");

            if (!TryValidateModel(internalMessage))
                return BadRequest(ModelState);

            await CommandSender.Send(AddOrganisationLocationRequestMapping.Map(internalMessage));

            return Created(Url.Action(nameof(Get), new { id = message.OrganisationLocationId }), null);
        }

        /// <summary>Update a location for an organisation.</summary>
        /// <response code="201">If the location is updated, together with the location.</response>
        /// <response code="400">If the location information does not pass validation.</response>
        [HttpPut("{id}")]
        [OrganisationRegistryAuthorize]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([FromServices] ISecurityService securityService, [FromRoute] Guid organisationId, [FromBody] UpdateOrganisationLocationRequest message)
        {
            var internalMessage = new UpdateOrganisationLocationInternalRequest(organisationId, message);

            if (!securityService.CanEditOrganisation(User, internalMessage.OrganisationId))
                ModelState.AddModelError("NotAllowed", "U hebt niet voldoende rechten voor deze organisatie.");

            if (!TryValidateModel(internalMessage))
                return BadRequest(ModelState);

            await CommandSender.Send(UpdateOrganisationLocationRequestMapping.Map(internalMessage));

            return Ok();
        }
    }
}
