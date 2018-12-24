using ART.SC.Feature.Quote.Models;
using ART.SC.Foundation.DependencyInjection;
using ART.SC.Foundation.Services.Models;
using ART.SC.Foundation.Services.Service;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ART.SC.Feature.Quote.Repositories
{
    [Service(typeof(IQuoteRepository))]
    public class QuoteRepository : IQuoteRepository
    {
        MasterDataService _masterDataService;
        QuickQuote _quickQuote;
        VehicleInfo _vehicleInfo;
        InsuredInfo _insuredInfo;
        MasterDetails _masterDetails;
        MotorVehicleDetails _carDetails;
        MotorVehicleDetailsService _motorVehicleDetailsService;
        QuickQuoteService _quickQuoteService;

        public QuoteRepository(MasterDataService masterDataService, MotorVehicleDetailsService motorVehicleDetailsService, QuickQuoteService quickQuoteService)
        {
            this._masterDataService = masterDataService;
            this._motorVehicleDetailsService = motorVehicleDetailsService;
            this._quickQuoteService = quickQuoteService;
            this._masterDetails = new MasterDetails();
            this._carDetails = new MotorVehicleDetails();
            this._quickQuote = new QuickQuote();
            this._vehicleInfo = new VehicleInfo();
            this._insuredInfo = new InsuredInfo();
        }
        public QuickQuoteResponseModel Save(QuickQuoteModel model)
        {
            var response = _quickQuoteService.SaveQuickQuoteDetails(model);
            return response;
        }
        public QuickQuote GetChildObjects(out MasterDetails outputMasterData)
        {
            _vehicleInfo.ColorList = new List<string>();
            _vehicleInfo.VehicleModelList = new List<string>();
            _vehicleInfo.VehicleTypeList = new List<string>();
            _vehicleInfo.TransmissionTypeList = new List<string>();
            _quickQuote.PolicyDetails = new Policy();
            _quickQuote.LicenseDetails = new License();
            try
            {
                GetMasterDetails();
                bool isMasterDataAvailable = _masterDetails != null;
                _vehicleInfo.VehicleMakeList = isMasterDataAvailable ? _masterDetails.masterData.motor.vehicle.Make.ToList() : new List<string>();
                _vehicleInfo.VehicleUsageList = isMasterDataAvailable ? _masterDetails.masterData.motor.vehicle.Usage.ToList() : new List<string>();
                _insuredInfo.CityList = isMasterDataAvailable ? _masterDetails.masterData.cities.ToList() : new List<string>();
                _quickQuote.VehicleDetails = _vehicleInfo;
                _quickQuote.InsuredDetails = _insuredInfo;
                outputMasterData = isMasterDataAvailable ? _masterDetails : null;
            }
            catch (Exception ex)
            {
                _vehicleInfo.VehicleMakeList = new List<string>();
                _vehicleInfo.VehicleUsageList = new List<string>();
                _insuredInfo.CityList = new List<string>();
                _quickQuote.VehicleDetails = _vehicleInfo;
                _quickQuote.InsuredDetails = _insuredInfo;
                outputMasterData = null;
            }
            return _quickQuote;
        }

        public QuickQuoteModel MapPostDataToQuickQouteModel(QuickQuote quoteModel)
        {
            QuickQuoteModel model = new QuickQuoteModel();
            model.PolicyDetails = MapPolicyDetails(quoteModel.PolicyDetails);
            model.VehicleDetails = MapVehicleDetails(quoteModel.VehicleDetails);
            model.LicenseDetails = MapLicenseDetails(quoteModel.LicenseDetails);
            model.InsuredDetails = MapInsuredDetails(quoteModel.InsuredDetails);
            return model;
        }

        private InsuredDetails MapInsuredDetails(InsuredInfo insuredDetails)
        {
            if (insuredDetails != null)
            {
                List<string> addressLine = new List<string>();
                addressLine.Add(insuredDetails.AddressLine1);
                addressLine.Add(insuredDetails.AddressLine2);
                return new InsuredDetails
                {
                    address = new Address
                    {
                        lines = addressLine,
                        city = insuredDetails.City,
                        state = "NA",
                        zipCode = insuredDetails.ZipCode
                    },
                    firstName = insuredDetails.FirstName,
                    secondName = insuredDetails.SecondName,
                    lastName = insuredDetails.LastName
                };
            }
            return new InsuredDetails();
        }

        private LicenseDetails MapLicenseDetails(License licenseDetails)
        {
            if (licenseDetails != null)
            {
                return new LicenseDetails
                {
                    effectiveDate = licenseDetails.EffectiveDate,
                    expiryDate = licenseDetails.ExpiryDate,
                    number = licenseDetails.LicenseNumber,
                    placeOfIssue = licenseDetails.PlaceOfIssue
                };
            }
            return new LicenseDetails();
        }

        private VehicleDetails MapVehicleDetails(VehicleInfo vehicleDetails)
        {
            if (vehicleDetails != null)
            {
                return new VehicleDetails
                {
                    color = vehicleDetails.Color,
                    make = vehicleDetails.VehicleMake,
                    model = vehicleDetails.VehicleModel,
                    registration = vehicleDetails.RegistrationNumber,
                    odometer = Convert.ToDouble(vehicleDetails.ODOMeterReading),
                    transmission = vehicleDetails.TransmissionType,
                    type = vehicleDetails.VehicleType,
                    usage = vehicleDetails.VehicleUsage,
                    year = Convert.ToDateTime(vehicleDetails.YearOfManufacture).Year.ToString(),
                    distCoveredDaily = 50
                };
            }
            return new VehicleDetails();
        }

        private PolicyDetails MapPolicyDetails(Policy policyDetails)
        {
            if (policyDetails != null)
            {
                return new PolicyDetails
                {
                    effectiveDate = policyDetails.PolicyEffectiveDate,
                    expiryDate = policyDetails.PolicyExpiryDate,
                    coverageAmount = policyDetails.CoverageAmount
                };
            }
            return new PolicyDetails();
        }

        public MasterDetails GetMasterDetails()
        {
            _masterDetails = _masterDataService.GetMasterDetailsForVehicles();
            return _masterDetails;
        }
        public MotorVehicleDetails GetMotorVehicleDetails(string makeType)
        {
            _carDetails = _motorVehicleDetailsService.GetCarDetailsBasedOnSelection(makeType);
            return _carDetails;
        }

        public QuickQuote ReMapQuickQuoteData(QuickQuote quickQuote, MasterDetails masterDetails, MotorVehicleDetails motorVehicleDetails)
        {
            quickQuote.VehicleDetails.VehicleMakeList = masterDetails?.masterData?.motor?.vehicle?.Make ?? new List<string>();
            quickQuote.VehicleDetails.VehicleUsageList = masterDetails?.masterData?.motor?.vehicle?.Usage ?? new List<string>();
            quickQuote.VehicleDetails.ColorList = motorVehicleDetails?.Color ?? new List<string>();
            quickQuote.VehicleDetails.TransmissionTypeList = motorVehicleDetails?.Transmission ?? new List<string>();
            quickQuote.VehicleDetails.VehicleModelList = motorVehicleDetails?.Models ?? new List<string>();
            quickQuote.VehicleDetails.VehicleTypeList = motorVehicleDetails?.Class ?? new List<string>();
            quickQuote.InsuredDetails.CityList = masterDetails?.masterData?.cities ?? new List<string>();
            return quickQuote;
        }

        public QuickQuote GetQuoteDataFromSitecore(QuickQuote quoteData, Item dataSourceItem)
        {
            List<Item> childList = dataSourceItem.Children.ToList();
            quoteData.Item = dataSourceItem;
            quoteData.PolicyDetails.Item = childList.Where(x => x.TemplateID == Templates.Policy.TemplateID).FirstOrDefault();
            quoteData.LicenseDetails.Item = childList.Where(x => x.TemplateID == Templates.License.TemplateID).FirstOrDefault();
            quoteData.VehicleDetails.Item = childList.Where(x => x.TemplateID == Templates.Vehicle.TemplateID).FirstOrDefault();
            quoteData.InsuredDetails.Item = childList.Where(x => x.TemplateID == Templates.Insured.TemplateID).FirstOrDefault();
            return quoteData;
        }
    }
}