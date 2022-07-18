using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using waste_management_parser.Data.Base;

namespace waste_management_parser.Models
{
    public class WmObject_WasteBinForEmptying : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        // Relationships.

        // Object.

        public int WmObjectId { get; set; }

        [ForeignKey(nameof(WmObjectId))]
        public WmObject? WmObject { get; set; }
    }
}
