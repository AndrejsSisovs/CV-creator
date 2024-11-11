using System.ComponentModel.DataAnnotations;

namespace CV_creator.Models
{
    public class Achievements
    {
        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string Achievments { get; set; }
    }
}
