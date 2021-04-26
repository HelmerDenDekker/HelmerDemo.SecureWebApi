﻿namespace HelmerDemo.SecureWebApi.Controllers
{
    using HelmerDemo.SecureWebApi.Attributes;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The key secured controller.
    /// </summary>
    [ClaimRequirement("Permission", "HasKey")]
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
