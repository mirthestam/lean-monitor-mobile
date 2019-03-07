using System.Threading.Tasks;

namespace LeanMobile.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> IsAuthenticated(string authUserToken, string authAccessToken);
    }
}