namespace HelmerDemo.SecureWebApi.Authorization
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// The has api key handler.
    /// </summary>
    public class HasApiKeyHandler : AuthorizationHandler<HasApiKeyRequirement>
    {
        /// <summary>
        /// The http context accessor.
        /// </summary>
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="HasApiKeyHandler"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">
        /// The http context accessor.
        /// </param>
        public HasApiKeyHandler(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// The handle requirement async.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="requirement">
        /// The requirement.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasApiKeyRequirement requirement)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            
            // If casting fails => requirements are not met
            if (httpContext == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var apiKey = "X-API-KEY";
            if (!httpContext.Request.Headers.Keys.Contains(apiKey))
            {
                return Task.CompletedTask;
            }

            var apiValue = "TestSecret";
            var keyHeader = httpContext.Request.Headers.FirstOrDefault(x => x.Key.Equals(apiKey, StringComparison.CurrentCultureIgnoreCase));

            if (keyHeader.Value.First() == apiValue)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
