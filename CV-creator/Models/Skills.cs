using System.ComponentModel.DataAnnotations;

namespace CV_creator.Models
{
    public class Skills : Entity
    {
        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string Description { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string Type { get; set; }

        // Foreign Key
        public int JobId { get; set; }

        // Navigation Property
        public WorkExperience Job { get; set; }
    }
}
