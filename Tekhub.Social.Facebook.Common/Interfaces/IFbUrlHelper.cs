namespace Tekhub.Social.Facebook.Common.Interfaces
{
    public interface IFbUrlHelper
    {
        string GetFbAuthUrl();
        string GetFbTokenGeneratorUrl(string fbAuthCode, string appAuthRedirectionUrl);
        string GetFbUserDetailsUrl(string fbAuthToken, string[] fieldsToReturn);
    }
}
