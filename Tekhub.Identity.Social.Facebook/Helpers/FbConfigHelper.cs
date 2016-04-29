using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Tekhub.Social.Facebook.Common.Interfaces;

namespace Tekhub.Identity.Social.Facebook.Helpers
{
    public class FbConfigHelper : IFbConfigHelper
    {
        public string GetFbClientId()
        {
            return ConfigurationManager.AppSettings["FBClientId"];
        }

        public string GetAppRedirectUri()
        {
            var hostUrl = ConfigurationManager.AppSettings["hostUrl"];

            return string.Format("{0}{1}", hostUrl, "FacebookAuth/redirect/");
        }

        public string GetFbScopes()
        {
            return ConfigurationManager.AppSettings["FBPermissions"];
        }


        public string GetFbAppSecret()
        {
            return ConfigurationManager.AppSettings["FBAppSecret"];
        }


        public string GetAppFbAuthHandlerUrl(string authToken)
        {
            return string.Format("{0}?auth_token={1}", ConfigurationManager.AppSettings["FBAuthHandlerUrl"], authToken);
        }
    }
}
