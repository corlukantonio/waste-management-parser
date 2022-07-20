using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using waste_management_parser.Data.Base;

namespace waste_management_parser.Models
{
    public class WmOrganization : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "GUID")]
        [Required(ErrorMessage = "GUID is required.")]
        [MaxLength(36), MinLength(36)]
        public byte[]? Guid { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars.")]
        public string? Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Creation date is required.")]
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Relationships.

        public List<AspNetUser_WmOrganization>? Users_WmOrganizations { get; set; }

        // Group.

        public List<WmGroup>? WmGroups { get; set; }
    }
}
