using NUnit.Framework;
using RestSharp;
using System.Threading;

namespace ReqresApiTesting.ApiTests;


public class LoginUserTest : ApiTestBase
{
    // данные для авторизации взяты с самого примера на reqres.in

    private const string Email = "eve.holt@reqres.in";
    private const string Password = "cityslicka";
    private const string MissingEmailError = "Missing email or username";
    private const string MissingPasswordError = "Missing password";
    
    [Test]
    [Parallelizable]
    public void SuccessfulUserLoginTesting()
    {
        
        RestRequest request = new RestRequest(ApiEndPoint.LoginUser, Method.Post);
        request = AddRequestHeaders(request);
        request.AddParameter("email", Email);
        request.AddParameter("password", Password);

        var response = SendRequestAndGetResponse(request);
        var content = GetResponseContent(response);

        Thread.Sleep(2000);

        Assert.AreEqual(StatusCodeOk, (int)response.StatusCode, "Статус код ответа не соответствует ожидаемому");
        Assert.IsNotEmpty(content["token"].ToString(), "Token is empty");
    }

    [Test]
    [Parallelizable]
    public void LoginUserWithMissingEmailTesting()
    {
        RestRequest request = new RestRequest(ApiEndPoint.LoginUser, Method.Post);
        request = AddRequestHeaders(request); 
        request.AddParameter("password", Password);

        var response = SendRequestAndGetResponse(request);
        var content = GetResponseContent(response);
        
        Thread.Sleep(2000);

        Assert.AreEqual(BadRequestStatusCode, (int)response.StatusCode, "Статус код ответа не соответствует ожидаемому");
        Assert.AreEqual(MissingEmailError, content["error"].ToString(), "Текст ошибки в ответе api != ожидаемому");
    }
    
    [Test]
    [Parallelizable]
    public void LoginUserWithMissingPasswordTesting()
    {
        RestRequest request = new RestRequest(ApiEndPoint.LoginUser, Method.Post);
        request = AddRequestHeaders(request); 
        request.AddParameter("email", Email);

        var response = SendRequestAndGetResponse(request);
        var content = GetResponseContent(response);

        Thread.Sleep(2000);

        Assert.AreEqual(BadRequestStatusCode, (int)response.StatusCode, "Статус код ответа не соответствует ожидаемому");
        Assert.AreEqual(MissingPasswordError, content["error"].ToString(), "Текст ошибки в ответе api != ожидаемому");
    }
}