namespace HelmerDemo.SecureWebApi.Authorization
{
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// The has api key requirement.
    /// </summary>
    public class HasApiKeyRequirement : IAuthorizationRequirement
    {
    }
}
