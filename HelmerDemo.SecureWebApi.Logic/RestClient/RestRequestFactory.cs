namespace WE.POC.CommonCode.Helpers
{
    using System.Collections.Generic;

    using RestSharp;

    /// <summary>
    /// The rest request factory.
    /// </summary>
    public class RestRequestFactory : IRestRequestFactory
    {
        /// <inheritdoc />
        public RestRequest Create(string requestUrl, Method method)
        {
            return new RestRequest(requestUrl, method);
        }

        /// <inheritdoc />
        public RestRequest Get(string requestUrl)
        {
            return new RestRequest(requestUrl, Method.GET);
        }

        /// <inheritdoc />
        public RestRequest GetByParameters(string requestUrl, Dictionary<string, string> parameters)
        {
            var request = new RestRequest(requestUrl, Method.GET, DataFormat.None);
            foreach (var item in parameters)
            {
                if (item.Value != null)
                    request.AddParameter(item.Key, item.Value);
            }
            return request;
        }

        /// <inheritdoc />
        public RestRequest Post(string postUrl, Dictionary<string, string> parameters)
        {
            var request = new RestRequest(postUrl, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            foreach (var item in parameters)
            {
                if (item.Value != null)
                    request.AddParameter(item.Key, item.Value);
            }
            return request;
        }

        /// <inheritdoc />
        public RestRequest PostObject(string postUrl, object postObject)
        {
            var request = new RestRequest(postUrl, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(postObject);
            return request;
        }
    }
}
