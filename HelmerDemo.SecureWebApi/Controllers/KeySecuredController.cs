namespace HelmerDemo.SecureWebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The key secured controller.
    /// </summary>
    [Authorize(Policy = "HasApiKey")]
    [Route("api/[controller]")]
    [ApiController]
    public class KeySecuredController : ControllerBase
    {
        /// <summary>
        /// The test get.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpGet]
        public IActionResult Get()
        {
            var message = "Secure private data";
            return this.Ok(message);
        }
    }
}
