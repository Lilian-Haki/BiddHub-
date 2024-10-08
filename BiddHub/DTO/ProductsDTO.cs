using System.ComponentModel.DataAnnotations;

namespace BiddHub.DTO
{
    public class ProductsDTO
    {
        [Required(ErrorMessage = "Product name is required")]
        public required string ProductName { get; set; }
        [Required(ErrorMessage = "Reasons For Aution Is required")]
        public required string ReasonsForAution { get; set; }
        [Required(ErrorMessage = "Property Owner Is required")]
        public required string PropertyOwner { get; set; }
        [Required(ErrorMessage = "Date and Time for auction Is required")]
        public required string AuctionDateTime { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public required string Location { get; set; }

    }
}
