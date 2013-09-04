using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtisansFinder.Models;
using ServiceStack.Mvc;
using ServiceStack.Mvc.MiniProfiler;

namespace ArtisansFinder.Controllers
{
    [ProfilingActionFilter]
    public class ControllerBase : ServiceStackController<CustomUserSession>
    {

    }
}