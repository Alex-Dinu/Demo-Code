using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUi.CustomValidatorAttributes
{
    public class ValidLogonAttribute : ValidationAttribute
    {
        private string _comparisonProperty;

        public ValidLogonAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var logon = (string)value;


            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property [" + _comparisonProperty + "] was not found");


            var preferredName = (string)property.GetValue(validationContext.ObjectInstance);


            if (logon != null && logon == preferredName)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
