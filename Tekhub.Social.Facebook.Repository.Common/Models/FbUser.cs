using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekhub.Social.Facebook.Repository.Common.Models
{
    public class FbUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Id);
        }
    }
}
