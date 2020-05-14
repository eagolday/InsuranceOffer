using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace InsuranceOffer.Service.Services
{
    #region Example

    //const string uri = "http://localhost:57287/api";
    //IApiService client = new ApiService();

    //var getUri = string.Format("{0}/{1}?id={2}", uri, "GetMethod", 5);
    //var getResult = client.GetMethod<SampleModel>(getUri);

    //var postUri = string.Format("{0}/{1}", uri, "PostMethod");
    //var postResult = client.PostMethod<Response>(requestObject: "sampleRequest", uri: postUri);

    //var putUri = string.Format("{0}/{1}", uri, "PutMethod");
    //var putResult = client.PutMethod<Response>(requestObject: "sampleRequest", uri: putUri);

    //var deleteUri = string.Format("{0}/{1}?id={2}", uri, "DeleteMethod", 3);
    //var deleteResult = client.DeleteMethod<Response>(uri: deleteUri); 
    #endregion


    public interface IApiService
    {
        T PostMethod<T>(object requestObject, string uri, Dictionary<string, string> headers = null);

        T GetMethod<T>(string uri, Dictionary<string, string> headers = null);

        T PutMethod<T>(object requestObject, string uri, Dictionary<string, string> headers = null);

        T DeleteMethod<T>(string uri, Dictionary<string, string> headers = null);
    }

    public class ApiService : IApiService
    {
        public T PostMethod<T>(object requestObject, string uri, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            var result = GetResult<T>(client, request, requestObject, headers);

            return result;
        }

        public T GetMethod<T>(string uri, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };
            var result = GetResult<T>(client, request, null, headers);

            return result;
        }

        public T PutMethod<T>(object requestObject, string uri, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.PUT) { RequestFormat = DataFormat.Json };
            var result = GetResult<T>(client, request, requestObject, headers);

            return result;
        }

        public T DeleteMethod<T>(string uri, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.DELETE) { RequestFormat = DataFormat.Json };
            var result = GetResult<T>(client, request, null, headers);

            return result;
        }

        private T GetResult<T>(RestClient client, RestRequest request, object requestObject = null, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            if (requestObject != null)
            {
              var aaa=  request.AddJsonBody(requestObject);
            }

            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        }
    }
}
