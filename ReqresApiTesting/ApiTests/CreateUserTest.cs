using NUnit.Framework;
using RestSharp;
using System.Threading;

namespace ReqresApiTesting.ApiTests;

public class CreateUserTest : ApiTestBase
{
    [Test]
    [Parallelizable]
    public void CreateUserTesting()
    {
        string someName = "someName";
        string someJob = "someJob";
        
        RestRequest request = new RestRequest(ApiEndPoint.CreateUser, Method.Post);
        request = AddRequestHeaders(request);
        request.AddParameter("name", someName);
        request.AddParameter("job", someJob);

        var response = SendRequestAndGetResponse(request);
        var content = GetResponseContent(response);

        Thread.Sleep(2000);
        
        Assert.AreEqual(CreatedStatusCode, (int)response.StatusCode);
        Assert.AreEqual(someName, content["name"].ToString(), 
            "Имя пользователя отправленного в запросе != имени созданного пользователя");
        Assert.AreEqual(someJob, content["job"].ToString(),
            "Наименование работы отправленного в запросе != наименованию работы созданного пользователя");
        
        // при отправке этого запроса пользователь на самом деле не создается
        // если отправить запрос на получение данных о пользователя, то получим Not Found
        // поэтому нет возможности сделать проверку на то, действительно ли был создан пользователь
    }
}