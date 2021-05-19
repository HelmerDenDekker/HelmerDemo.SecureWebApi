﻿namespace WE.POC.CommonCode.Helpers
{
    using System.Net;
    using System.Threading.Tasks;

    using RestSharp;
    using RestSharp.Serialization.Json;

    /// <summary>
    /// The demo rest client.
    /// </summary>
    public class DemoRestClient : IDemoRestClient
    {
        /// <inheritdoc />
        public RestClient Create(string baseUrl)
        {
            // NEVER Let this go to production! Ignores TLS (SSL) issues
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var client = new RestClient(baseUrl);

            client.UseSerializer(() => new JsonDeserializer());
            return client;
        }
    }
}
