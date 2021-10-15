using Ordering.Domain.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Services.Validators
{
    public class ItemsAvailability : ValidationAttribute
    {
        public string GetErrorMessage() => $"All Orders Items Must be Valid";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _repository = (IOrderingRepository)validationContext
                         .GetService(typeof(IOrderingRepository));
            var items = _repository.GetOrderItemsAsync((List<int>)value).GetAwaiter().GetResult();
            if (items.Any(x => !x.isValid))
            {
                return new ValidationResult(GetErrorMessage());

            }
            return ValidationResult.Success;

        }
    }
}