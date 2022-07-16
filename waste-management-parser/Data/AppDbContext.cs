using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using waste_management_parser.Models;

namespace waste_management_parser.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser_WmOrganization>().HasKey(uo => new
            {
                uo.ApplicationUserId,
                uo.WmOrganizationId
            });

            builder.Entity<ApplicationUser_WmOrganization>().HasOne(u => u.ApplicationUser).WithMany(uo => uo.ApplicationUsers_WmOrganizations).HasForeignKey(u => u.ApplicationUserId);

            builder.Entity<ApplicationUser_WmOrganization>().HasOne(o => o.WmOrganization).WithMany(uo => uo.ApplicationUsers_WmOrganizations).HasForeignKey(o => o.WmOrganizationId);

            builder.Entity<WmGroup>().Property(b => b.Guid).IsFixedLength();

            builder.Entity<WmGroup>().Property(b => b.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<WmObject>().Property(b => b.Guid).IsFixedLength();

            builder.Entity<WmObject>().Property(b => b.Mac).IsFixedLength();

            builder.Entity<WmObject>().Property(b => b.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<WmOrganization>().Property(b => b.Guid).IsFixedLength();

            builder.Entity<WmOrganization>().Property(b => b.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<WmRecord>().Property(b => b.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<WmRecord_TriggerWasteBinEmptying>().Property(b => b.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<WmRecord_TriggerWasteBinEmptying_WmObject>().HasKey(ro => new
            {
                ro.WmRecord_TriggerWasteBinEmptyingId,
                ro.WmObjectId
            });

            builder.Entity<WmRecord_TriggerWasteBinEmptying_WmObject>().HasOne(r => r.WmRecord_TriggerWasteBinEmptying).WithMany(ro => ro.WmRecords_TriggerWasteBinEmptying_WmObjects).HasForeignKey(r => r.WmRecord_TriggerWasteBinEmptyingId);

            builder.Entity<WmRecord_TriggerWasteBinEmptying_WmObject>().HasOne(o => o.WmObject).WithMany(ro => ro.WmRecords_TriggerWasteBinEmptying_WmObjects).HasForeignKey(o => o.WmObjectId);

            base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser_WmOrganization> ApplicationUsers_WmOrganizations { get; set; }

        public DbSet<WmGroup> WmGroups { get; set; }

        public DbSet<WmObject> WmObjects { get; set; }

        public DbSet<WmOrganization> WmOrganizations { get; set; }

        public DbSet<WmRecord> WmRecords { get; set; }

        public DbSet<WmRecord_TriggerWasteBinEmptying> WmRecords_TriggerWasteBinEmptying { get; set; }

        public DbSet<WmRecord_TriggerWasteBinEmptying_WmObject> WmRecords_TriggerWasteBinEmptying_WmObjects { get; set; }
    }
}
