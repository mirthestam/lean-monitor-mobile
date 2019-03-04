namespace LeanMobileProto.Services.Settings
{
    public interface ISettingsService
    {
        string AuthUserToken { get; set; }
        string AuthAccessToken { get; set; }
        string EndpointAddress { get; set; }
    }
}