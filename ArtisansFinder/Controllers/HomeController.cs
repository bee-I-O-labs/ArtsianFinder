using System;
using System.Web.Mvc;
using ArtisansFinder.Models;
using ArtisansFinder.Services;

namespace ArtisansFinder.Controllers
{
    public class HomeController : ControllerBase
    {
       private IMailService _mail;
        public AppConfig Config { get; set; }

       public HomeController(IMailService mail)
        {
            _mail = mail;
        }
        public virtual ActionResult Index()
        {
            ViewBag.Message = "MVC + ServiceStack PowerPack!";
            ViewBag.UserSession = base.UserSession;
            ViewBag.Config = Config;

            return View();
//            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
//
//            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg = String.Format("Comment From: {1}{0}Email: {2}{0}Website: {3}{0}Comment: {4}{0}",
                                    Environment.NewLine, 
                                    model.Name, 
                                    model.Email, 
                                    model.Website, 
                                    model.Comment);
           
            if (_mail.SendMail("noreply@yourdomain.com", "foo@yourdomain.com", "Website Contact", msg))
            {
                ViewBag.MailSent = true;
            }
            
            return View();
        }
        [Authorize]
        public ActionResult MyArtisans()
        {
            return View();
        }
        //Supposed to use Roles
//        [Authorize(Users = "gbozee")]
//        public ActionResult Moderation()
//        {
//            return View();
//        }
    }

   
}
