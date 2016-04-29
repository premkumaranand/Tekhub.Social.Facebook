using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tekhub.Identity.Social.Facebook.Helpers;
using Tekhub.Social.Facebook.Common;
using Tekhub.Social.Facebook.Common.Exceptions;
using Tekhub.Social.Facebook.Common.Helpers;
using Tekhub.Social.Facebook.Common.Interfaces;
using Tekhub.Social.Facebook.Factory;
using Tekhub.Social.Facebook.Repository.Common.Interfaces;

namespace Tekhub.Identity.Social.Facebook.Controllers
{
    public class FacebookAuthController : Controller
    {
        public IFbUrlHelper FbUrlHelper { get; set; }
        public IFbConfigHelper FbConfigHelper { get; set; }
        public IAuthenticationRepository AuthenticationRepository { get; set; }

        public FacebookAuthController()
        {
            FbConfigHelper = new FbConfigHelper();

            var fac = new Factory();

            FbUrlHelper = fac.GetFbUrlHelper(FbConfigHelper);
            AuthenticationRepository = fac.GetAuthenticationRepository(FbConfigHelper);
        }

        public ActionResult Login(string redirectUrl)
        {
            var error = Request.QueryString["error"];

            if (!string.IsNullOrEmpty(error))
            {
                //Log error message
                //Request["error_description"];
                Redirect("/");
            }
            else
            {
                redirectUrl = FbUrlHelper.GetFbAuthUrl(); //TODO: Add "status" query param to check the authenticity of the FB calls
            }

            return Redirect(redirectUrl);
        }

        [AllowAnonymous]
        public ActionResult Redirect()
        {
            var error = Request.QueryString["error"];

            if (!string.IsNullOrEmpty(error))
            {
                //User denied the facebook permission
                if (Convert.ToInt32(Request.QueryString["error_code"]) == 200)
                {
                    //Log the FB drop outs if required
                    return Redirect("/");
                }

                throw new FacebookException(Convert.ToInt32(Request.QueryString["error_code"]),
                        Request.QueryString["error_description"]);
            }

            var fbCode = Request.QueryString["code"];
            //var returnUrl = Request.QueryString["state"]; //TODO: Get the status, decrypt and check the authenticity before redirection
                
            var fbAuthToken = AuthenticationRepository.GetFbToken(fbCode, FbConfigHelper.GetAppRedirectUri()); 

            return Redirect(FbConfigHelper.GetAppFbAuthHandlerUrl(fbAuthToken)); //TODO: Attach status to the URL so authenticity can be checked
        }
    }
}
