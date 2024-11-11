using System.ComponentModel.DataAnnotations;

namespace CV_creator.Models
{
    public class Education
    {
        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string School { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public DateTime StartTime { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public DateTime EndTime { get; set; }
    }
}
