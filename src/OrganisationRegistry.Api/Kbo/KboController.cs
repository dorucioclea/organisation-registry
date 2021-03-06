namespace OrganisationRegistry.Api.Kbo
{
    using System;
    using System.Linq;
    using Configuration;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using SqlServer.Infrastructure;
    using System.Net;
    using System.Threading.Tasks;
    using Autofac.Features.OwnedInstances;
    using Infrastructure.Security;
    using Magda;
    using Microsoft.Extensions.Logging;
    using OrganisationRegistry.Infrastructure.Commands;
    using OrganisationRegistry.Organisation;

    [ApiVersion("1.0")]
    [AdvertiseApiVersions("1.0")]
    [OrganisationRegistryRoute("kbo")]
    public class KboController : OrganisationRegistryController
    {
        private readonly ILogger<KboController> _logger;
        private readonly MagdaConfiguration _magdaConfiguration;
        private readonly ApiConfiguration _apiConfiguration;

        public KboController(
            ILogger<KboController> logger,
            ICommandSender commandSender,
            IOptions<ApiConfiguration> apiOptions,
            MagdaConfiguration magdaConfiguration) : base(commandSender)
        {
            _logger = logger;
            _magdaConfiguration = magdaConfiguration;
            _apiConfiguration = apiOptions.Value;
        }

        /// <summary>Find organisation in KBO.</summary>
        /// <response code="200">If the organisation is found.</response>
        /// <response code="404">If the kbo number does not exist</response>
        [HttpGet("{kboNumberInput}")]
        [OrganisationRegistryAuthorize]
        [ProducesResponseType(typeof(NotFoundResult), (int) HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(
            [FromServices] Func<Owned<OrganisationRegistryContext>> contextFactory,
            [FromServices] IKboOrganisationRetriever kboOrganisationRetriever,
            [FromRoute] string kboNumberInput)
        {
            var kboNumber = new KboNumber(kboNumberInput);
            var dotFormat = kboNumber.ToDotFormat();
            var digitsOnly = kboNumber.ToDigitsOnly();

            using (var organisationRegistryContext = contextFactory().Value)
            {
                if (await organisationRegistryContext
                    .OrganisationDetail
                    .AsQueryable()
                    .AnyAsync(x => x.KboNumber.Equals(dotFormat) || x.KboNumber.Equals(digitsOnly)))
                {
                    ModelState.AddModelError(
                        key: "Duplicate",
                        errorMessage: $"Organisatie met KBO nummer {kboNumber} is reeds gedefinieerd in wegwijs.");

                    return BadRequest(ModelState);
                }
            }

            var kboOrganisationResult = await kboOrganisationRetriever.RetrieveOrganisation(User, kboNumber);

            if (kboOrganisationResult.HasErrors)
            {
                kboOrganisationResult.ErrorMessages
                    .ToList()
                    .ForEach(x => _logger.LogWarning(x));

                return NotFound();
            }

            return Ok(kboOrganisationResult.Value);
        }
    }
}
