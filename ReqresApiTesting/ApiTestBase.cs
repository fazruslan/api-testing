using Newtonsoft.Json.Linq;
using RestSharp;
using NUnit.Framework;

namespace ReqresApiTesting;

public class ApiTestBase
{
   
     
    private static string URI = "https://reqres.in";

    protected const int StatusCodeOk = 200;
    protected const int BadRequestStatusCode = 400;
    protected const int CreatedStatusCode = 201;
    protected const int NotFoundStatusCode = 404;
    protected const int NoContentStatusCode = 204;

    
    protected static RestRequest AddRequestHeaders(RestRequest request)
    {
        // тут можно задавать хедеры необходимые для запроса, либо, как пример, проходить авторизацию чтобы получить токен/куки
        // в случае с Reqres можно вообще ничего указывать, просто как пример
        
        request.AddHeader("Accept", "appplication/json");
        
        return request;
    }

    protected static RestResponse SendRequestAndGetResponse(RestRequest request)
    {
        var restClient = new RestClient(URI);
        
        RestResponse response = restClient.Execute(request);

        return response;
    }

    protected static JObject GetResponseContent(RestResponse response)
    {
        JObject json = JObject.Parse(response.Content);
        return json;
    }
}