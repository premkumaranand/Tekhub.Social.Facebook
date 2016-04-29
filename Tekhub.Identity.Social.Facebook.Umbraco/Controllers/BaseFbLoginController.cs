using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tekhub.Social.Facebook.Common.Helpers;
using Tekhub.Social.Facebook.Common.Interfaces;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Tekhub.Identity.Social.Facebook.Umbraco.Controllers
{
    public class BaseFbLoginController : FbSurfaceRenderMvcController
    {
        private readonly IFbUrlHelper _fbUrlHelper;

        public BaseFbLoginController(IFbConfigHelper fbConfigHelper)
        {
            _fbUrlHelper = new FbUrlHelper(fbConfigHelper);
        }

        public override ActionResult Index(RenderModel model)
        {
            var error = Request.QueryString["error"];

            if (!string.IsNullOrEmpty(error))
            {
                //Log error message
                //Request["error_description"];
                return Redirect("/");
            }

            var fbAuthUrl = _fbUrlHelper.GetFbAuthUrl(); //TODO: Add "status" query param to check the authenticity of the FB calls
            return Redirect(fbAuthUrl);
        }
    }
}
