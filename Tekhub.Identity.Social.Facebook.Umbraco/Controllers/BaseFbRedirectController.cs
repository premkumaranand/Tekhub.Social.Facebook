using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tekhub.Social.Facebook.Common.Exceptions;
using Tekhub.Social.Facebook.Common.Interfaces;
using Tekhub.Social.Facebook.Repository.Common.Interfaces;
using Umbraco.Web.Models;

namespace Tekhub.Identity.Social.Facebook.Umbraco.Controllers
{
    public class BaseFbRedirectController : FbSurfaceRenderMvcController
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IFbConfigHelper _fbConfigHelper;

        public BaseFbRedirectController(IAuthenticationRepository authenticationRepository, IFbConfigHelper fbConfigHelper)
        {
            _authenticationRepository = authenticationRepository;
            _fbConfigHelper = fbConfigHelper;
        }

        public override ActionResult Index(RenderModel model)
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

            var fbAuthToken = _authenticationRepository.GetFbToken(fbCode, _fbConfigHelper.GetAppRedirectUri());

            return Redirect(_fbConfigHelper.GetAppFbAuthHandlerUrl(fbAuthToken)); //TODO: Attach status to the URL so authenticity can be checked
        }
    }
}
