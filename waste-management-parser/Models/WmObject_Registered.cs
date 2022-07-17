using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using waste_management_parser.Data.Base;

namespace waste_management_parser.Models
{
    public class WmObject_Registered : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "MAC")]
        [Required(ErrorMessage = "MAC is required.")]
        [MaxLength(6), MinLength(6)]
        public byte[]? Mac { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars.")]
        public string? Name { get; set; }

        [Display(Name = "Activation code")]
        [Required(ErrorMessage = "Activation code is required.")]
        [MaxLength(4), MinLength(4)]
        public byte[]? ActivationCode { get; set; }

        [Required(ErrorMessage = "Creation date is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? CreatedAt { get; set; }
    }
}
