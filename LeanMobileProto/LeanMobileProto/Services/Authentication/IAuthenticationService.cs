using System.Threading.Tasks;

namespace LeanMobileProto.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> IsAuthenticated(string authUserToken, string authAccessToken);
    }
}