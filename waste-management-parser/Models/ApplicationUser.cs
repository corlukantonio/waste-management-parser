using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace waste_management_parser.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full name")]
        public string? FullName { get; set; }

        [Display(Name = "Picture name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Picture name must be between 3 and 50 chars.")]
        public string? PictureName { get; set; }

        [Display(Name = "Picture data")]
        public byte[]? PictureData { get; set; }

        [Display(Name = "Is password reset requested")]
        [Required(ErrorMessage = "Is password reset requested field is required.")]
        [DefaultValue(0)]
        public bool IsPasswordResetRequested { get; set; }

        // Relationships.

        public List<ApplicationUser_WmOrganization>? ApplicationUsers_WmOrganizations { get; set; }

        // Object.

        public List<WmObject>? WmObjects { get; set; }
    }
}
