namespace waste_management_parser.Models
{
    public class AspNetUser_WmOrganization
    {
        public string? UserId { get; set; }
        public AspNetUser? User { get; set; }

        public int WmOrganizationId { get; set; }
        public WmOrganization? WmOrganization { get; set; }
    }
}
