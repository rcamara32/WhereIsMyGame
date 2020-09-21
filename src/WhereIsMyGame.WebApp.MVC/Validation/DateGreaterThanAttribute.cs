using System;
using System.ComponentModel.DataAnnotations;

namespace WhereIsMyGame.WebApp.MVC.Validation
{
    public class DateGreaterThanAttribute : ValidationAttribute
    {

        private readonly string _startDatePropertyName;
        private readonly string _errorMessage;

        public DateGreaterThanAttribute(string startDatePropertyName, string errorMessage)
        {
            _startDatePropertyName = startDatePropertyName;
            _errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(_startDatePropertyName);
            var propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
            if ((DateTime)value > (DateTime)propertyValue)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(_errorMessage);
            }
        }
    }
}
