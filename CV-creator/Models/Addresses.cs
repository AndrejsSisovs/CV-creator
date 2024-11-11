using System.ComponentModel.DataAnnotations;

namespace CV_creator.Models
{
    public class Addresses
    {
        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string City { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string Country { get; set; }
    }
}
