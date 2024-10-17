using System.ComponentModel.DataAnnotations;

namespace BiddHub.DTO
{
    public class ProductsDTO
    {
        [Required(ErrorMessage = "Product name is required")]
<<<<<<< HEAD
        public required string Product_name { get; set; }
        public required string Reason_for_listing { get; set; }
        public required string Owners_name { get; set; }
        public required int Owner_Phone_no { get; set; }
        public required string Reserve_Price { get; set; }
        public required string Location {  get; set; }
        //public required string Reports { get; set; }
        //public int Photo_id { get; set; }
        //public string Documents_id { get;set; }
=======
        public required string ProductName { get; set; }
        [Required(ErrorMessage = "Reasons For Aution Is required")]
        public required string ReasonsForAution { get; set; }
        [Required(ErrorMessage = "Property Owner Is required")]
        public required string PropertyOwner { get; set; }
        [Required(ErrorMessage = "Date and Time for auction Is required")]
        public required string AuctionDateTime { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public required string Location { get; set; }
>>>>>>> 1ea0da431fdd166dc405fdca00e787f18fb3e6c3

    }
}
