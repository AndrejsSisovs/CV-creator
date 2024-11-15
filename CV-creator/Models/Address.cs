﻿using System.ComponentModel.DataAnnotations;

namespace CV_creator.Models
{
    public class Address: Entity
    {
        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string Country { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string PostalCode { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string City { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string Street { get; set; }

        [MaxLength(20), Required(AllowEmptyStrings = false)]
        public string HouseNumber { get; set; }

        // Foreign Keys (Nullable because an address can be linked to different entities)
        public int? BasicInformationId { get; set; }
        public int? EducationId { get; set; }
        public int? JobId { get; set; }

        // Navigation Properties
        public BasicInformation BasicInformation { get; set; }
        public Education Education { get; set; }
        public WorkExperience Job { get; set; }
    }
}
