namespace LeanMobileProto.Model.Api
{
    public interface IApiFactory
    {
        IApi Create(string authUserToken, string authAccessToken, string endpointAddress);
    }
}