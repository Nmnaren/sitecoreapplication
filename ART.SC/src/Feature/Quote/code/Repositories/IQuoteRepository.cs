using ART.SC.Feature.Quote.Models;
using ART.SC.Foundation.Services.Models;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ART.SC.Feature.Quote.Repositories
{
    public interface IQuoteRepository
    {
        QuickQuoteResponseModel Save(QuickQuoteModel model);
        QuickQuote GetChildObjects(out MasterDetails outputMasterData);

        QuickQuote GetQuoteDataFromSitecore(QuickQuote quoteData, Item dataSourceItem);
        MasterDetails GetMasterDetails();
        MotorVehicleDetails GetMotorVehicleDetails(string makeType);
        QuickQuoteModel MapPostDataToQuickQouteModel(QuickQuote quoteModel);
        QuickQuote ReMapQuickQuoteData(QuickQuote quickQuote, MasterDetails masterDetails, MotorVehicleDetails motorVehicleDetails);
    }
}