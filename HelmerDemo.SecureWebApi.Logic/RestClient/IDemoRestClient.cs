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
        /// Creates a new non-secured rest client.
        /// </summary>
        /// <param name="baseUrl">
        /// The base url.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<RestClient> CreateOpenClient(string baseUrl);

        /// <summary>
        /// Creates a new secured rest client.
        /// </summary>
        /// <param name="baseUrl">
        /// The base url.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<RestClient> CreateSecuredClient(string baseUrl);
    }
}
