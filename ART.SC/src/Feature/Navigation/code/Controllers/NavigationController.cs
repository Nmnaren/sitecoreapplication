using ART.SC.Feature.Navigation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ART.SC.Feature.Navigation.Controllers
{
    public class NavigationController : Controller
    {
        private readonly INavigationRepository navigationRepository;

        public NavigationController(INavigationRepository navigationRepository)
        {
            this.navigationRepository = navigationRepository;
        }
        public ActionResult PrimaryMenu()
        {
            var items = this.navigationRepository.GetPrimaryMenu();
            return this.View("PrimaryMenu", items);
        }
    }
}