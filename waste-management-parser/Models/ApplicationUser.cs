using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace waste_management_parser.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}
