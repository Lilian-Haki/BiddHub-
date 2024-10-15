using System.ComponentModel.DataAnnotations;

namespace BiddHub.DTO
{
    public class ProductsDTO
    {
        [Required(ErrorMessage = "Product name is required")]
        public required string Product_name { get; set; }
        public required string Reason_for_listing { get; set; }
        public required string Owners_name { get; set; }
        public required int Owner_Phone_no { get; set; }
        public required string Reserve_Price { get; set; }
        public required string Location {  get; set; }
        //public required string Reports { get; set; }
        //public int Photo_id { get; set; }
        //public string Documents_id { get;set; }

    }
}
