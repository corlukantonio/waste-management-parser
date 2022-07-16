using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace waste_management_parser.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full name")]
        public string? FullName { get; set; }

        // Relationships.

        public List<ApplicationUser_WmOrganization>? ApplicationUsers_WmOrganizations { get; set; }

        // Object.

        public List<WmObject>? WmObjects { get; set; }
    }
}
