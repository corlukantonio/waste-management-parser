using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using waste_management_parser.Data.Base;

namespace waste_management_parser.Models
{
    public class WmRecord : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Data is required.")]
        public byte[]? Data { get; set; }

        [Required(ErrorMessage = "Creation date is required.")]
        public DateTime? CreatedAt { get; set; }

        // Relationships.

        // Object.

        public int WmObjectId { get; set; }

        [ForeignKey("WmObjectId")]
        public WmObject? WmObject { get; set; }
    }
}
