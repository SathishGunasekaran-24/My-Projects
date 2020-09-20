using MVC_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC_1.Controllers
{
    public class SitesController : Controller
    {
        // GET: Sites
        public ActionResult Index()
        
        {
            IEnumerable<SiteInformations> siteList;
            HttpResponseMessage responseMessage = GlobalVariables.webApiClient.GetAsync("materialInformations").Result;
            siteList = responseMessage.Content.ReadAsAsync<IEnumerable<SiteInformations>>().Result;
            return View(siteList);
        }
    }
}