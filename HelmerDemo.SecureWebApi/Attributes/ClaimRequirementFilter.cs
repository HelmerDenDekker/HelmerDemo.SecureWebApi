namespace HelmerDemo.SecureWebApi.Attributes
{
    using System;
    using System.Linq;
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    /// The claim requirement filter.
    /// </summary>
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        private Claim _claim;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimRequirementFilter"/> class.
        /// </summary>
        /// <param name="claim">
        /// The claim.
        /// </param>
        public ClaimRequirementFilter(Claim claim)
        {
            _claim = claim;
        }

        /// <summary>
        /// The on authorization.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (this._claim.Value == "HasKey")
            {
                ClientHasKey(context);
            }
        }

        /// <summary>
        /// The client has key.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        private static void ClientHasKey(AuthorizationFilterContext context)
        {
            var keyName = "X-API-KEY";
            if (!context.HttpContext.Request.Headers.Keys.Contains(keyName))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var keyHeader =
                context.HttpContext.Request.Headers.FirstOrDefault(
                    x => x.Key.Equals(keyName, StringComparison.CurrentCultureIgnoreCase));
            var apiKey = "TestSecret";
            if (keyHeader.Value.First() == apiKey)
            {
                return;
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
