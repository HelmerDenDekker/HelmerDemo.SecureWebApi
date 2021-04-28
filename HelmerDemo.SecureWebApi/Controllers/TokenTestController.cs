namespace HelmerDemo.SecureWebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The token test controller.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenTestController : ControllerBase
    {
        /// <summary>
        /// The get controller.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpGet]
        public IActionResult Get()
        {
            var message = "Successful";
            return this.Ok(message);
        }

    }
}
