using System;
using NUnit.Framework;
using RestSharp;

namespace ReqresApiTesting.ApiTests;

public class DeleteUserTest : ApiTestBase
{
    [Test]
    public void DeleteUserTesting()
    {
        int someUserId = 3;
        
        RestRequest request = new RestRequest(ApiEndPoint.DeleteUser + $"/{someUserId}", Method.Delete);
        request = AddRequestHeaders(request);

        var response = SendRequestAndGetResponse(request);

        Assert.AreEqual(NoContentStatusCode, (int)response.StatusCode,
            "Статус код ответа != ожидаемому");
    }
}