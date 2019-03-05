using Fusillade;
using QuantConnect.Api;

namespace LeanMobile.Services.Api
{
    public interface IApiService
    {
        IApi Api { get; }        
    }
}