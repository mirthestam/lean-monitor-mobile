using System.Threading.Tasks;
using LeanMobileProto.Model.Api.Responses;
using Refit;

namespace LeanMobileProto.Model.Api
{
    public interface IApi
    {
        [Get("/authenticate")]
        Task<AuthenticationResponse> GetAuthenticateAsync();
    }
}