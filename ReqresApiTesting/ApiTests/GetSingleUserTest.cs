using NUnit.Framework;
using RestSharp;
using System.Threading;

namespace ReqresApiTesting.ApiTests;


public class GetSingleUserTest : ApiTestBase
{
    
    [Test]
    [Parallelizable]
    public void GetSingleUserPositiveTesting()
    {
        int someUserId = 3;
        
        RestRequest request = new RestRequest(ApiEndPoint.GetSingleUser + $"/{someUserId}", Method.Get);
        request = AddRequestHeaders(request);

        var response = SendRequestAndGetResponse(request);
        var content = GetResponseContent(response);

        Thread.Sleep(2000);

        Assert.AreEqual(StatusCodeOk, (int)response.StatusCode, "Статус код ответа не соответствует ожидаемому");
        Assert.AreEqual(someUserId, (int)content["data"]?["id"], "Данные не по заданному пользователю");
    }

    [Test]
    [Parallelizable]
    public void GetSingleUserNegativeTesting()
    {
        int someNotExistUserId = 99999999;
        
        RestRequest request = new RestRequest(ApiEndPoint.GetSingleUser + $"/{someNotExistUserId}", Method.Get);
        request = AddRequestHeaders(request);

        var response = SendRequestAndGetResponse(request);
        var content = GetResponseContent(response);

        Thread.Sleep(2000);

        Assert.AreEqual(NotFoundStatusCode, (int)response.StatusCode, "Статус код ответа не соответствует ожидаемому");
        Assert.IsEmpty(content, "Тело ответа не пустое.");
    }
}