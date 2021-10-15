using Ordering.Domain.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Services.Validators
{
    public class MaxAllowedOrderVlaueAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => $"Order Value Must be Less Than 1500 EGP";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _repository = (IOrderingRepository)validationContext
                         .GetService(typeof(IOrderingRepository));
            var items = _repository.GetOrderItemsAsync((List<int>)value).GetAwaiter().GetResult();
            if (items.Sum(x => x.ItemPrice) > 1500)
            {
                return new ValidationResult(GetErrorMessage());

            }
            return ValidationResult.Success;

        }
    }

}
