using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class Site
    {

        public Guid SiteId { get; set; }

        [Required]
        [Display(Name = "Site Name")]
        public String SiteName { get; set; }

        [Required]
        [Display(Name = "Location Desciption")]
        [StringLength(256, ErrorMessage = "Location description length can't be more than 256 characters.")]
        public String LocationDesc { get; set; }

        //public SystemCode SystemCode { get; set; }

        [ForeignKey("SystemCodeId")]
        [Display(Name = "Property Type")]
        public Guid PropertyTypeId { get; set; }

        public SystemCode PropertyType { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    throw new NotImplementedException();
        //}
    }
}