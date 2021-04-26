namespace HelmerDemo.WebClient.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using HelmerDemo.WebClient.Models;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using WE.POC.CommonCode.Helpers;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// The Rest request factory.
        /// </summary>
        private readonly IRestRequestFactory _restRequestFactory;

        /// <summary>
        /// The demo Rest client.
        /// </summary>
        private readonly IDemoRestClient _demoRestclient;

        /// <summary>
        /// The api base url.
        /// </summary>
        private string _baseUrl = "https://localhost:44300/";

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="restRequestFactory">
        /// The rest Request Factory.
        /// </param>
        public HomeController(ILogger<HomeController> logger, IRestRequestFactory restRequestFactory, IDemoRestClient demoRestClient)
        {
            this._logger = logger;
            this._restRequestFactory = restRequestFactory;
            this._demoRestclient = demoRestClient;
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        public async Task<IActionResult> Index()
        {
            var client = await this._demoRestclient.CreateOpenClient(_baseUrl);
            var request = this._restRequestFactory.Get("api/opentest");
            var response = client.Execute(request);
            var viewModel = new HomeViewModel { Response = response.Content };
            return View(viewModel);
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
