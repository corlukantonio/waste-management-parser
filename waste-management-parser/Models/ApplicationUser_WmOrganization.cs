namespace waste_management_parser.Models
{
    public class ApplicationUser_WmOrganization
    {
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        public int WmOrganizationId { get; set; }
        public WmOrganization? WmOrganization { get; set; }
    }
}
