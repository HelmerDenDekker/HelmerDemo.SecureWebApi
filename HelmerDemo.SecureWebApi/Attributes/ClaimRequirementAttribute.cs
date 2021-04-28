namespace HelmerDemo.SecureWebApi.Attributes
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;

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
