using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tekhub.Social.Facebook.Common.Helpers;
using Tekhub.Social.Facebook.Common.Interfaces;
using Tekhub.Social.Facebook.Repository.Common.Interfaces;
using Tekhub.Social.Facebook.Repository.Common.Models;

namespace Tekhub.Social.Facebook.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly IFbUrlHelper _fbUrlHelper;

        public UserRepository(IFbConfigHelper fbConfigHelper)
        {
            _fbUrlHelper = new FbUrlHelper(fbConfigHelper);
        }

        public FbUser GetUserDetails(string fbAuthToken, string[] fieldsToReturn)
        {
            var userDetailsUrl = _fbUrlHelper.GetFbUserDetailsUrl(fbAuthToken, fieldsToReturn);
            return JsonConvert.DeserializeObject<FbUser>(GetFbResponse(userDetailsUrl));
        }

        public bool IsValidAuthToken(string fbAuthToken, string email)
        {
            try
            {
                var userDetails = GetUserDetails(fbAuthToken, new[] {"email"});
                return userDetails.IsValid() && userDetails.Email.ToLower().Equals(email.ToLower());
            }
            catch
            {
                return false;
            }
        }
    }
}
