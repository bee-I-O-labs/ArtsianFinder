using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStack.ServiceInterface;

namespace ArtisansFinder.Controllers
{
    [Authenticate]
    public class SecureController : ControllerBase
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}