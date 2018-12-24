using ART.SC.Feature.Quote.Models;
using ART.SC.Feature.Quote.Repositories;
using ART.SC.Foundation.Services.Models;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ART.SC.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data.Items;
using Sitecore;
using Sitecore.Data;

namespace ART.SC.Feature.Quote.Controllers
{
    public class QuoteController : Controller
    {
        // GET: Quote
        private IQuoteRepository quoteRepository;

        public QuoteController(IQuoteRepository quoteRepository)
        {
            this.quoteRepository = quoteRepository;
        }
        public ActionResult QuickQuote()
        {
            MasterDetails masterDetails;
            string dataSource = RenderingContext.Current.Rendering.DataSource ?? string.Empty;
            Item dataSourceItem = !string.IsNullOrWhiteSpace(dataSource) ? Context.Database.GetItem(new ID(dataSource)) : null;
            var quoteData = quoteRepository.GetChildObjects(out masterDetails);
            quoteRepository.GetQuoteDataFromSitecore(quoteData , dataSourceItem);
            quoteData.HasError = false;
            if(masterDetails!=null)
            {
                TempData["masterDetails"] = masterDetails;
            }
            return View(quoteData);
        }
        [HttpPost]
        public ActionResult QuickQuote(QuickQuote quoteModel)
        {
            string dataSource = RenderingContext.Current.Rendering.DataSource ?? string.Empty;
            Item dataSourceItem = !string.IsNullOrWhiteSpace(dataSource) ? Context.Database.GetItem(new ID(dataSource)) : null;
            if (ModelState.IsValid)
            {
                var quickQuote = quoteRepository.MapPostDataToQuickQouteModel(quoteModel);
                var response = quoteRepository.Save(quickQuote);
                if (response.SuccessModel != null && response.SuccessModel.isSuccess)
                {
                    quoteModel.HasError = false;
                    if (dataSourceItem != null)
                    {
                        var pageUrl = dataSourceItem.LinkFieldUrl(Templates.QuoteDetails.Fields.ConfirmationPageUrl);
                        TempData["SuccessResponse"] = response.SuccessModel;
                        TempData.Keep("SuccessResponse");
                        return Redirect(pageUrl);
                    }
                }
            }
            quoteModel = quoteRepository.ReMapQuickQuoteData(quoteModel, TempData.Peek("masterDetails") as MasterDetails, TempData.Peek("vehicleDetails") as MotorVehicleDetails);
            quoteModel.HasError = true;
            quoteModel.GenericErrorMessege = dataSourceItem != null ?
                                             dataSourceItem.Fields[Templates.QuoteDetails.Fields.GenericErrorMessege].Value : string.Empty;
            return View(quoteModel);
        }
        [HttpGet]
        public JsonResult GetMotorVehcleDetails(string makeType)
        {
            var vehicleDetails = quoteRepository.GetMotorVehicleDetails(makeType);
            if(vehicleDetails!=null)
            {
                TempData["vehicleDetails"] = vehicleDetails;
            }
            return Json(vehicleDetails, JsonRequestBehavior.AllowGet);
        }

        public ActionResult QuickQuoteThankYou()
        {
            var response = TempData["SuccessResponse"] as QuickQuoteSuccessModel;
            return View(response);
        }
    }
}