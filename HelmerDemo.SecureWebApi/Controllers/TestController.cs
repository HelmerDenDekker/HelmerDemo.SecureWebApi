namespace HelmerDemo.SecureWebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using SecureDemoApi.CommonCode.Models;

    /// <summary>
    /// The test controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OpenTestController : ControllerBase
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
            var message = "Test succeeded";
            return this.Ok(message);
        }

        /// <summary>
        /// The test post.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPost]
        public IActionResult Post(EmailDto email)
        {
            var message = "Test succeeded";
            return this.Ok(message);
        }
    }
}
