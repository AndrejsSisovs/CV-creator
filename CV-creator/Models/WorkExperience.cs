using System.ComponentModel.DataAnnotations;

namespace CV_creator.Models
{
    public class WorkExperience : Entity
    {
        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string PositionHeld { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string EmploymentType { get; set; }

        
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        // Foreign Key
        public int BasicInformationId { get; set; }

        // Navigation Properties
        public BasicInformation BasicInformation { get; set; }
        public ICollection<Skills> Skills { get; set; }

        public Address WorkAddress { get; set; }
    }
}
