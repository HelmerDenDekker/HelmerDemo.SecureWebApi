namespace WE.POC.CommonCode.Helpers
{
    using System.Threading.Tasks;

    using RestSharp;

    /// <summary>
    /// The DemoRestClient interface.
    /// </summary>
    public interface IDemoRestClient
    {
        /// <summary>
        /// Creates a new rest client.
        /// </summary>
        /// <param name="baseUrl">
        /// The base url.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        RestClient Create(string baseUrl);
    }
}
