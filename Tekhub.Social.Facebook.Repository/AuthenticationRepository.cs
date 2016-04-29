using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Tekhub.Social.Facebook.Common.Exceptions;
using Tekhub.Social.Facebook.Common.Helpers;
using Tekhub.Social.Facebook.Common.Interfaces;
using Tekhub.Social.Facebook.Repository.Common.FbResponseModels;
using Tekhub.Social.Facebook.Repository.Common.Interfaces;

namespace Tekhub.Social.Facebook.Repository
{
    public class AuthenticationRepository : BaseRepository, IAuthenticationRepository
    {
        private readonly IFbUrlHelper _fbUrlHelper;

        public AuthenticationRepository(IFbConfigHelper fbConfigHelper)
        {
            _fbUrlHelper = new FbUrlHelper(fbConfigHelper);
        }

        public string GetFbToken(string fbAuthCode, string appFbAuthRedirUrl)
        {
            var tokenGeneratorUrl = _fbUrlHelper.GetFbTokenGeneratorUrl(fbAuthCode, appFbAuthRedirUrl);
            
            //Get the user access token and token expire seconds 
            AccessTokenResponse accessTokenResponse;

            try
            {
                accessTokenResponse =
                    JsonConvert.DeserializeObject<AccessTokenResponse>(GetFbResponse(tokenGeneratorUrl));
            }
            catch (WebException wex)
            {
                throw new FacebookException(1, "Original message: " + wex.Message + ". Url requested: " + tokenGeneratorUrl);
            }

            if (!accessTokenResponse.IsValid()) throw new FacebookException(0, "Getting Facebook token failed");

            return accessTokenResponse.access_token; //TODO: Handle the expires_in response value as well
        }
    }
}
