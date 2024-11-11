using System.ComponentModel.DataAnnotations;

namespace CV_creator.Models
{
    public class Skills
    {
        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string Skill { get; set; }
    }
}
