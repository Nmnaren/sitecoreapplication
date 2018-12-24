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
    public sealed class DateGreaterThanCurrentAttribute : ValidationAttribute, IClientValidatable
    {
        string dateTimeFormat;
        string options;
        public DateGreaterThanCurrentAttribute(string dateTimeFormat,string options, string errorMessage)
            : base(errorMessage)
        {
            this.dateTimeFormat = dateTimeFormat;
            this.options = options;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            try
            {
             if(value != null)
                {
                    DateTime toValidate = DateTime.ParseExact(value.ToString(), dateTimeFormat, CultureInfo.InvariantCulture);
                    // if the end date is lower than the start date, than the validationResult will be set to false and return
                    // a properly formatted error message
                    int cmp = toValidate.CompareTo(DateTime.Now);
                    if(options.ToUpper()=="GREATER")
                    {
                        if (cmp < 0 || cmp == 0)
                        {
                            validationResult = new ValidationResult(ErrorMessageString);
                        }
                    }
                    else if((options.ToUpper() == "EARLIER"))
                    {
                        if(cmp>0)
                            validationResult = new ValidationResult(ErrorMessageString);
                    }      
                   
                }
                   
                
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
            dateGreaterCompareRule.ValidationType = "dategreaterthancurrent";
            dateGreaterCompareRule.ValidationParameters.Add("datetimeformat", dateTimeFormat);
            dateGreaterCompareRule.ValidationParameters.Add("options", options);
            yield return dateGreaterCompareRule;
        }
    }
}