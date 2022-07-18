using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using waste_management_parser.Data.Base;

namespace waste_management_parser.Models
{
    public class WmGroup : IEntityBase
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

        [Display(Name = "Normalized name")]
        [Required(ErrorMessage = "Normalized name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Normalized name must be between 3 and 50 chars.")]
        public string? NormalizedName { get; set; }

        [Display(Name = "Picture name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Picture name must be between 3 and 50 chars.")]
        public string? PictureName { get; set; }

        [Display(Name = "Picture data")]
        public byte[]? PictureData { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Creation date is required.")]
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Relationships.

        // Object.

        public List<WmObject>? WmObjects { get; set; }

        // Organization.

        public int WmOrganizationId { get; set; }

        [ForeignKey(nameof(WmOrganizationId))]
        public WmOrganization? WmOrganization { get; set; }
    }
}
