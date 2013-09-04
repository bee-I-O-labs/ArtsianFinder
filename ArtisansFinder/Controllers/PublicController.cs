using System.Web.Mvc;

namespace ArtisansFinder.Controllers
{
    public class PublicController : ControllerBase
    {
        public ViewResult Index()
        {
            return View();
        }
         
    }
}