using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ART.SC.Feature.Quote.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class DateGreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        string otherPropertyName;
        string dateTimeFormat;
        public DateGreaterThanAttribute(string otherPropertyName,string dateTimeFormat, string errorMessage)
            : base(errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
            this.dateTimeFormat = dateTimeFormat;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
                if(value!=null)
                {
                    var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);
                    // Let's check that otherProperty is of type DateTime as we expect it to be
                  
                        DateTime toValidate = DateTime.ParseExact(value.ToString(), dateTimeFormat, CultureInfo.InvariantCulture);
                        var otherPropertyVal = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
                        DateTime referenceProperty = DateTime.ParseExact(otherPropertyVal.ToString(), dateTimeFormat, CultureInfo.InvariantCulture);
                        // if the end date is lower than the start date, than the validationResult will be set to false and return
                        // a properly formatted error message
                        int cmp = toValidate.CompareTo(referenceProperty);
                        if (cmp < 0)
                        {
                            validationResult = new ValidationResult(ErrorMessageString);
                        }
                   
                }
                // Using reflection we can get a reference to the other date property, in this example the project start date
               
            }
            catch (Exception ex)
            {
                // Do stuff, i.e. log the exception
                // Let it go through the upper levels, something bad happened
                throw ex;
            }

            return validationResult;
        }
        public IEnumerable<ModelClientValidationRule>
     GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
            ModelClientValidationRule dateGreaterCompareRule = new ModelClientValidationRule();
            dateGreaterCompareRule.ErrorMessage = errorMessage;
            dateGreaterCompareRule.ValidationType = "dategreaterthan";
            dateGreaterCompareRule.ValidationParameters.Add("otherpropertyname", otherPropertyName);
            dateGreaterCompareRule.ValidationParameters.Add("datetimeformat", dateTimeFormat);
            yield return dateGreaterCompareRule;
        }
    }
}