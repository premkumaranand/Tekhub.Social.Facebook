using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tekhub.Social.Facebook.Repository
{
    public class BaseRepository
    {
        protected string GetFbResponse(string fbGraphUrl)
        {
            var request = WebRequest.Create(fbGraphUrl);
            var reader = new StreamReader(request.GetResponse().GetResponseStream());
            return reader.ReadToEnd();
        }
    }
}
