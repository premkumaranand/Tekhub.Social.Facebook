using System.Net;
using System.Web;
using Tekhub.Social.Facebook.Common.Interfaces;

namespace Tekhub.Social.Facebook.Common.Helpers
{
    public class FbUrlHelper : IFbUrlHelper
    {
        private readonly IFbConfigHelper _configHelper;

        private const string FbApiVersion = "v2.3";

        private string BuildGraphUrl(string fbUrlPart, string fbAuthToken = "", string queryString = "")
        {
            if (!string.IsNullOrEmpty(fbAuthToken))
            {
                queryString = string.IsNullOrEmpty(queryString) ? string.Empty : "&" + queryString;

                return string.Format("https://graph.facebook.com/{0}/{1}?access_token={2}{3}", FbApiVersion,
                    fbUrlPart, fbAuthToken, queryString);
            }

            queryString = string.IsNullOrEmpty(queryString) ? string.Empty : "?" + queryString;

            return string.Format("https://graph.facebook.com/{0}/{1}{2}", FbApiVersion,
                    fbUrlPart, queryString);
        }

        public FbUrlHelper(IFbConfigHelper configHelper)
        {
            _configHelper = configHelper;
        }

        public string GetFbAuthUrl()
        {
            return string.Format("https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}&scope={2}", 
                     _configHelper.GetFbClientId(), WebUtility.UrlEncode(_configHelper.GetAppRedirectUri()), _configHelper.GetFbScopes());
        }

        public string GetFbTokenGeneratorUrl(string fbAuthCode, string appAuthRedirectionUrl)
        {
            var tokenGenUrlQueryString = string.Format("client_id={0}&redirect_uri={1}&client_secret={2}&code={3}",
                _configHelper.GetFbClientId(), WebUtility.UrlEncode(appAuthRedirectionUrl),
                _configHelper.GetFbAppSecret(), fbAuthCode);

            return BuildGraphUrl("oauth/access_token", queryString: tokenGenUrlQueryString);
        }

        public string GetFbUserDetailsUrl(string fbAuthToken, string[] fieldsToReturn)
        {
            var fieldsQueryParam = string.Format("fields={0}", string.Join(",", fieldsToReturn));
            return BuildGraphUrl("me", fbAuthToken, fieldsQueryParam);
        }
    }
}
