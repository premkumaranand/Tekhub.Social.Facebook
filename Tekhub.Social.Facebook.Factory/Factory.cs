using Tekhub.Social.Facebook.Common.Helpers;
using Tekhub.Social.Facebook.Common.Interfaces;
using Tekhub.Social.Facebook.Repository;
using Tekhub.Social.Facebook.Repository.Common.Interfaces;

namespace Tekhub.Social.Facebook.Factory
{
    public class Factory
    {
        private IAuthenticationRepository _authenticationRepository;
        private IUserRepository _userRepository;
        private IFbUrlHelper _fbUrlHelper;
        
        public IAuthenticationRepository GetAuthenticationRepository(IFbConfigHelper fbConfigHelper)
        {
            return _authenticationRepository ??
                   (_authenticationRepository = new AuthenticationRepository(fbConfigHelper));
        }

        public IUserRepository GetUserRepository(IFbConfigHelper fbConfigHelper)
        {
            return _userRepository ??
                   (_userRepository = new UserRepository(GetFbUrlHelper(fbConfigHelper)));
        }

        public IFbUrlHelper GetFbUrlHelper(IFbConfigHelper fbConfigHelper)
        {
            return _fbUrlHelper ?? (_fbUrlHelper = new FbUrlHelper(fbConfigHelper));
        }
    }
}
