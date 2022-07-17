using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using waste_management_parser.Data.Base;

namespace waste_management_parser.Models
{
    public class WmObject : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "GUID")]
        [Required(ErrorMessage = "GUID is required.")]
        [MaxLength(36), MinLength(36)]
        public byte[]? Guid { get; set; }

        [Display(Name = "MAC")]
        [Required(ErrorMessage = "MAC is required.")]
        [MaxLength(6), MinLength(6)]
        public byte[]? Mac { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars.")]
        public string? Name { get; set; }

        [Display(Name = "Latitude")]
        [Required(ErrorMessage = "Latitude is required.")]
        public double Latitude { get; set; }

        [Display(Name = "Longitude")]
        [Required(ErrorMessage = "Longitude is required.")]
        public double Longitude { get; set; }

        [Display(Name = "Is activated")]
        [Required(ErrorMessage = "Is activated field is required.")]
        public bool IsActivated { get; set; }

        [Display(Name = "Activation code")]
        [MaxLength(4), MinLength(4)]
        public byte[]? ActivationCode { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Creation date is required.")]
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Relationships.

        public List<WmRecord_TriggerWasteBinEmptying_WmObject>? WmRecords_TriggerWasteBinEmptying_WmObjects { get; set; }

        // User.

        public string? OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public ApplicationUser? Owner { get; set; }

        // Group.

        public int WmGroupId { get; set; }

        [ForeignKey(nameof(WmGroupId))]
        public WmGroup? WmGroup { get; set; }

        // Record.

        public List<WmRecord>? WmRecords { get; set; }
    }
}
