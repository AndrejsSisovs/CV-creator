using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CV_creator.Models
{
    public class BasicInformation : Entity
    {
        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public long PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        
        public ICollection<Education> Educations { get; set; }
        public ICollection<WorkExperience> Jobs { get; set; }
        public Address ResidenceAddress { get; set; }
    }
}
