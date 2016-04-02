using Epam.Wunderlist.DomainModel;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Epam.Wunderlist.WebApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UploadFile()
        {
            var fileName = string.Empty;

            var image = HttpContext.Request.Files[0];

            try
            {
                var imageType = image.FileName.Split('.').Last();
                fileName = (((ClaimsIdentity)User.Identity).Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value) + "." + imageType;
                var path = Path.Combine(Server.MapPath("~/WebApp/Files"), fileName);
                image.SaveAs(path);
            }
            catch (Exception)
            {
                fileName = string.Empty;
            }
            return new JsonResult { Data = new { FileName = fileName} };
        }
    }
}
