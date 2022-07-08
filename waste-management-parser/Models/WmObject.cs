using System.ComponentModel.DataAnnotations;
using waste_management_parser.Data.Base;

namespace waste_management_parser.Models
{
    public class WmObject : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "GUID")]
        [Required(ErrorMessage = "GUID is required.")]
        public byte[]? Guid { get; set; }

        [Display(Name = "MAC")]
        [Required(ErrorMessage = "MAC is required.")]
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

        [Required(ErrorMessage = "Creation date is required.")]
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Relationships.

        public List<WmRecord_TriggerWasteBinEmptying_WmObject>? WmRecords_TriggerWasteBinEmptying_WmObjects { get; set; }

        // Record.

        public List<WmRecord>? WmRecords { get; set; }
    }
}
