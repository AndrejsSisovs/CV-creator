using System.ComponentModel.DataAnnotations;

namespace CV_creator.Models
{
    public class WorkExperience
    {
        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string Workplace { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public DateTime StartTime { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public DateTime EndTime { get; set; }
    }
}
