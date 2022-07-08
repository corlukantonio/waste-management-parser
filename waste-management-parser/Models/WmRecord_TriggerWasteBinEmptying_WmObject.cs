namespace waste_management_parser.Models
{
    public class WmRecord_TriggerWasteBinEmptying_WmObject
    {
        public int WmRecord_TriggerWasteBinEmptyingId { get; set; }
        public WmRecord_TriggerWasteBinEmptying? WmRecord_TriggerWasteBinEmptying { get; set; }

        public int WmObjectId { get; set; }
        public WmObject? WmObject { get; set; }
    }
}
