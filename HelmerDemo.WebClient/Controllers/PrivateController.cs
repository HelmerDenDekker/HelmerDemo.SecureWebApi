namespace HelmerDemo.WebClient.Controllers
{
    using System.Threading.Tasks;

    using HelmerDemo.WebClient.Models;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using WE.POC.CommonCode.Helpers;

    /// <summary>
    /// The private controller.
    /// </summary>
    [Authorize]
    public class PrivateController : Controller
    {
        /// <summary>
        /// The demo rest client.
        /// </summary>
        private IDemoRestClient _demoRestClient;

        /// <summary>
        /// The rest request factory.
        /// </summary>
        private IRestRequestFactory _restRequestFactory;

        /// <summary>
        /// The _base url.
        /// </summary>
        private string _baseUrl = "https://localhost:44300/";

        /// <summary>
        /// Initializes a new instance of the <see cref="PrivateController"/> class.
        /// </summary>
        /// <param name="demoRestClient">
        /// The demo rest client.
        /// </param>
        /// <param name="restRequestFactory">
        /// The rest request factory.
        /// </param>
        public PrivateController(IDemoRestClient demoRestClient, IRestRequestFactory restRequestFactory)
        {
            this._demoRestClient = demoRestClient;
            this._restRequestFactory = restRequestFactory;
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public async Task<ActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = this._demoRestClient.Create(this._baseUrl);
            var request = this._restRequestFactory.Get("api/tokentest");
            request.AddHeader("authorization", "bearer "+ accessToken);
            var response = client.Execute(request);
            var viewModel = new PrivateViewModel { Message = response.Content };
            return View(viewModel);
        }
    }
}
