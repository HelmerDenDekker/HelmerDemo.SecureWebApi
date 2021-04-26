namespace HelmerDemo.SecureWebApi.Attributes
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    using IAuthorizationFilter = System.Web.Http.Filters.IAuthorizationFilter;

    /// <summary>
    /// The key requirement attribute.
    /// </summary>
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimRequirementAttribute"/> class.
        /// </summary>
        /// <param name="claimType">
        /// The claim type.
        /// </param>
        /// <param name="claimValue">
        /// The claim value.
        /// </param>
        public ClaimRequirementAttribute(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }
}
