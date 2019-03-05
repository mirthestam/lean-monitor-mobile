using System.Threading.Tasks;

namespace LeanMobile.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> IsAuthenticated(string authUserToken, string authAccessToken);
    }
}