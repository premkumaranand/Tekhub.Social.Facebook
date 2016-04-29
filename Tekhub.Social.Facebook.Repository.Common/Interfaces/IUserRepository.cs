using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekhub.Social.Facebook.Repository.Common.Models;

namespace Tekhub.Social.Facebook.Repository.Common.Interfaces
{
    public interface IUserRepository
    {
        FbUser GetUserDetails(string fbAuthToken, string[] fieldsToReturn);
        bool IsValidAuthToken(string fbAuthToken, string email);
    }
}
