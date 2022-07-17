using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using waste_management_parser.Data.Base;

namespace waste_management_parser.Models
{
    public class WmRecord_TriggerWasteBinEmptying : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Creation date is required.")]
        public DateTime? CreatedAt { get; set; }

        // Relationships.

        public List<WmRecord_TriggerWasteBinEmptying_WmObject>? WmRecords_TriggerWasteBinEmptying_WmObjects { get; set; }
    }
}
