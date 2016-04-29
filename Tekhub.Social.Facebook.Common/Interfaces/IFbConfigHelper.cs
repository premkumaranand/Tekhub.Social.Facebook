namespace Tekhub.Social.Facebook.Common.Interfaces
{
    public interface IFbConfigHelper
    {
        string GetFbClientId();
        string GetFbAppSecret();
        string GetAppRedirectUri();
        string GetAppFbAuthHandlerUrl(string authToken);
        string GetFbScopes();
    }
}
