using System;
using System.Threading;
using NUnit.Framework;
using RestSharp;

namespace ReqresApiTesting.ApiTests;


public class DeleteUserTest : ApiTestBase
{
    [Test]
    [Parallelizable]
    public void DeleteUserTesting()
    {
        int someUserId = 3;
        
        RestRequest request = new RestRequest(ApiEndPoint.DeleteUser + $"/{someUserId}", Method.Delete);
        request = AddRequestHeaders(request);

        var response = SendRequestAndGetResponse(request);

        Thread.Sleep(2000);

        Assert.AreEqual(NoContentStatusCode, (int)response.StatusCode,
            "Статус код ответа != ожидаемому");
    }
}