using System.ComponentModel.DataAnnotations;

namespace CV_creator.Models
{
    public class BasicInformation
    {
        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public DateTime BirthDate { get; set; }
    }
}
