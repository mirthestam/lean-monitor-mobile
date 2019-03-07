using LeanMobile.Data.Remote;

namespace LeanMobile.Data
{
    public interface IApiFactory
    {
        IApi Create(string authUserToken, string authAccessToken, string endpointAddress);
    }
}