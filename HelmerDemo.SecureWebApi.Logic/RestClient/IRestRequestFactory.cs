namespace WE.POC.CommonCode.Helpers
{
    using System.Collections.Generic;

    using RestSharp;

    /// <summary>
    /// The RestRequestFactory interface.
    /// </summary>
    public interface IRestRequestFactory
    {
        /// <summary>
        /// Create a RestRequest
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        RestRequest Create(string requestUrl, Method method);

        /// <summary>
        /// Create a Rest-Get-Request
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        RestRequest Get(string requestUrl);

        /// <summary>
        /// Create a Get by parameters RestRequest
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        RestRequest GetByParameters(string requestUrl, Dictionary<string, string> parameters);

        /// <summary>
        /// Create a Rest-Post-Request
        /// </summary>
        /// <param name="postUrl">
        /// The post url.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="RestRequest"/>.
        /// </returns>
        RestRequest Post(string postUrl, Dictionary<string, string> parameters);

        /// <summary>
        /// Create a Rest-Post-Object-Request
        /// </summary>
        /// <param name="postUrl">
        /// The post url.
        /// </param>
        /// <param name="postObject">
        /// The post object.
        /// </param>
        /// <returns>
        /// The <see cref="RestRequest"/>.
        /// </returns>
        RestRequest PostObject(string postUrl, object postObject);
    }
}
