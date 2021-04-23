namespace HelmerDemo.SecureWebApi.Attributes
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    /// <summary>
    /// The key authorization filter.
    /// </summary>
    public class KeyAuthorize : AuthorizationFilterAttribute
    {
        /// <summary>
        /// The on authorization async.
        /// </summary>
        /// <param name="actionContext">
        /// The action context.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public override Task OnAuthorizationAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {
            var keyName = "X-API-KEY";
            if (!actionContext.Request.Headers.Contains(keyName))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Not allowed");
                return Task.FromResult<object>(null);
            }

            var keyHeader = actionContext.Request.Headers.FirstOrDefault(x => x.Key.Equals(keyName, StringComparison.CurrentCultureIgnoreCase));
            var apiKey = "TestSecret";
            if (keyHeader.Value.First() == apiKey)
            {
                return Task.FromResult<object>(null);
            }

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Not allowed");
            return Task.FromResult<object>(null);
        }
    }
}
