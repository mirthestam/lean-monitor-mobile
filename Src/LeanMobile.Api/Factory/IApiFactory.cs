namespace LeanMobile.Api.Factory
{
    public interface IApiFactory
    {
        IApi Create(string authUserToken, string authAccessToken, string endpointAddress);
    }
}