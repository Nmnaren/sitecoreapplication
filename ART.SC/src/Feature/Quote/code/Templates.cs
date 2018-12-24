
using Sitecore.Data;
using System;
namespace ART.SC.Feature.Quote
{
    public struct Templates
    {
        public struct QuoteDetails
        {
            public struct Fields
            {
                public static readonly ID ConfirmationPageUrl = new ID("{AA32E6A6-9A4D-4798-A61F-483F8E52EC4D}");
                public static readonly ID GenericErrorMessege = new ID("{6EBF6DCA-50E4-4648-A278-EA2CC72B6F95}");
                public static readonly ID SubmitButtonLabel = new ID("{8D40814D-F363-4F76-8F0B-AF8625F55684}");
                public static readonly ID SendForApprovalButtonLabel = new ID("{5A1032C7-D395-4107-86AF-0F411E1BE623}");
            }
        }
        public struct Policy
        {
            public static readonly ID TemplateID = new ID("{D5A4A7F6-FA7A-4ED9-9C8E-7BDEBCAA107F}");
            public struct Fields
            {
                public static readonly ID PolicyEffectiveDateLabel = new ID("{C59B5CB3-2978-40BF-889D-C0A32216F9A3}");
                public static readonly ID PolicyExpiryDateLabel = new ID("{3B746821-7B39-4997-9F2E-2B1AE0A7FC04}");
                public static readonly ID PolicyCoverageLabel = new ID("{8B25952E-59B4-4D8E-98B1-90E5D2E22F4C}");
            }
        }
        public struct Headline
        {
            public static readonly ID TemplateID = new ID("{1FED138A-738B-4D51-8A9B-4125568D4D48}");
            public struct Fields
            {
                public static readonly ID Title = new ID("{D01768F2-BA1F-4C28-B3EA-AC628865B25D}");
            }
        }

        public struct License
        {
            public static readonly ID TemplateID = new ID("{10882070-662B-4DF7-9066-71C9D4030AEC}");
            public struct Fields
            {
                public static readonly ID LicenseNumberLabel = new ID("{7C07FC54-79AD-4FA2-BE5C-05AA30AD2777}");
                public static readonly ID EffectiveDateLabel = new ID("{A7CE4A3C-3AC8-4313-9C6C-3BBAD561A84A}");
                public static readonly ID PlaceofIssueLabel = new ID("{D8DAD66A-4703-4D7D-94A3-B31DEC424A52}");
                public static readonly ID ExpiryDateLabel = new ID("{6D127D5B-94FA-406E-9352-8D0B5EBA0120}");
            }
        }

        public struct Vehicle
        {
            public static readonly ID TemplateID = new ID("{C2964D22-A58B-4D91-B016-D36C2EBD08BC}");
            public struct Fields
            {
                public static readonly ID VehicleMakeLabel = new ID("{432BAC9F-3B8B-4EF2-A1FE-0C5BED4ABFB1}");
                public static readonly ID ColorLabel = new ID("{14BE8BFA-39D8-4599-963E-CAE84E244F41}");
                public static readonly ID RegistrationNumberLabel = new ID("{B1CC1829-B529-4306-8A84-6043AFBFDBE6}");
                public static readonly ID VehicleModelLabel = new ID("{9F485315-0DB0-45C4-8094-9A548EBE39F3}");
                public static readonly ID VehicleUsageLabel = new ID("{C06B72AB-8A97-4AA4-B02A-AAE107F12C60}");
                public static readonly ID VehicleTypeLabel = new ID("{0D039316-64D2-4BF8-8783-EC7300F72400}");
                public static readonly ID YearofManufactureLabel = new ID("{E4D9A05C-22E2-400F-AF65-E9F409F0303B}");
                public static readonly ID OdoMeterReadingLabel = new ID("{4AB9521F-BA9B-4415-A4C8-D3693E797259}");
                public static readonly ID TransmissionTypeLabel = new ID("{587B594C-733D-47D8-B0A4-06CBB6427310}");
            }
        }

        public struct Insured
        {
            public static readonly ID TemplateID = new ID("{D9398695-A90E-4670-A814-CBC9547291C4}");
            public struct Fields
            {
                public static readonly ID FirstNameLabel = new ID("{45145689-1DFC-44EE-89E1-3E23EC67C784}");
                public static readonly ID MiddleNameLabel = new ID("{F6D856E1-7DEC-4133-ABC1-1C021CD5B7FB}");
                public static readonly ID LastNameLabel = new ID("{4D12C687-9580-49D3-906D-C936A5B2646E}");
                public static readonly ID DateofBirthLabel = new ID("{A2ADDB9F-0743-45E6-B149-56ED1583758B}");
                public static readonly ID AddressLine1Label = new ID("{317604C4-FABC-4D60-A3F7-3E9B6BAE23E4}");
                public static readonly ID AddressLine2Label = new ID("{BA4B2F0D-0AC0-4846-9B9B-FB58BCFE29B3}");
                public static readonly ID CityLabel = new ID("{4BDA407A-CB5C-4051-A4C6-405EA345F19D}");
                public static readonly ID ZipCodeLabel = new ID("{A3EE485F-D0A1-4884-BCC5-733E9DBC951E}");
            }
        }
    }
}