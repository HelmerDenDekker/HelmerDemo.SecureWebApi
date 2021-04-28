namespace HelmerDemo.SecureWebApi.Attributes
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    /// The claim requirement filter.
    /// </summary>
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        /// <summary>
        /// The claim private field.
        /// </summary>
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
           // ToDo
        }
    }
}
