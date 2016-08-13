using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModels
{
    [Validator(typeof(ProductViewModelValidator))]
    public class ProductViewModel
    {
        [Display(Name = "Id")]
        public int ProductId { get; set; }

        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Display(Name = "Description")]
        public string ProductDescription { get; set; }

        [Display(Name = "Price")]
        public decimal ProductPrice { get; set; }
    }
}
