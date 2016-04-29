using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekhub.Social.Facebook.Repository.Common.Interfaces
{
    public interface IAuthenticationRepository
    {
        string GetFbToken(string fbAuthCode, string appFbAuthRedirUrl);
    }
}
