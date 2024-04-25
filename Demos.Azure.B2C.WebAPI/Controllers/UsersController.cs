using Azure.Identity;
using Demos.Azure.B2C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web.Resource;
using System.Security.Claims;

namespace Demos.Azure.B2C.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly Lazy<GraphServiceClient> _graphServiceClientLazy;
        private ILogger<UsersController> _logger;

        public GraphServiceClient GraphServiceClient => _graphServiceClientLazy.Value;

        public UsersController(IConfiguration configuration, ILogger<UsersController> logger)
        {
            _graphServiceClientLazy = new Lazy<GraphServiceClient>(() =>
            {
                var tenantId = configuration["MsGraph:TenantId"];
                var clientId = configuration["MsGraph:ClientId"];
                var clientSecret = configuration["MsGraph:ClientSecret"];

                var clientSecretCredential = new ClientSecretCredential(
                    tenantId, clientId, clientSecret);

                return new GraphServiceClient(clientSecretCredential);
            });

            _logger = logger;
        }

        [HttpGet]
        [Route("me")]
        [RequiredScope("CurrentUser.Read")]
        public async Task<IActionResult> GetCurrentUserDetails()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userId?.Value))
                {
                    return Unauthorized();
                }
                var user = await GraphServiceClient.Users[userId?.Value].GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Select = ["displayName", "givenName", "surname", "identities", "createdDateTime", "accountEnabled", "userPrincipalName"];
                });

                if (user == null)
                {
                    return NotFound();
                }

                var userDetails = MapToUser(user);

                return Ok(userDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving user details.");
                return StatusCode(500, "An error occurred while retrieving user details.");
            }
        }

        private User MapToUser(Microsoft.Graph.Models.User msGraphUser)
        {
            return new User
            {
                Id = msGraphUser.Id,
                Upn = msGraphUser.UserPrincipalName,
                Enabled = msGraphUser.AccountEnabled ?? false,
                Identities = msGraphUser.Identities?.Select(MapToUserIdentity).ToList() ?? [],
                GivenName = msGraphUser.GivenName,
                Surname = msGraphUser.Surname,
                CreatedAt = msGraphUser.CreatedDateTime
            };
        }

        private UserIdentity MapToUserIdentity(Microsoft.Graph.Models.ObjectIdentity msGraphIdentity)
        {
            return new UserIdentity
            {
                SignInType = msGraphIdentity.SignInType switch
                {
                    "emailAddress" => SignInType.Email,
                    "userPrincipalName" => SignInType.Upn,
                    "userName" => SignInType.UserName,
                    "federated" => SignInType.Unkwnown,
                    _ => SignInType.Unkwnown
                },

                Value = msGraphIdentity.IssuerAssignedId
            };
        }
    }
}
