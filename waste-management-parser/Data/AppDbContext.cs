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
            builder.Entity<WmRecord_TriggerWasteBinEmptying_WmObject>().HasKey(ro => new
            {
                ro.WmRecord_TriggerWasteBinEmptyingId,
                ro.WmObjectId
            });

            builder.Entity<WmRecord_TriggerWasteBinEmptying_WmObject>().HasOne(r => r.WmRecord_TriggerWasteBinEmptying).WithMany(ro => ro.WmRecords_TriggerWasteBinEmptying_WmObjects).HasForeignKey(r => r.WmRecord_TriggerWasteBinEmptyingId);

            builder.Entity<WmRecord_TriggerWasteBinEmptying_WmObject>().HasOne(o => o.WmObject).WithMany(ro => ro.WmRecords_TriggerWasteBinEmptying_WmObjects).HasForeignKey(o => o.WmObjectId);

            base.OnModelCreating(builder);
        }

        public DbSet<WmObject> WmObjects { get; set; }

        public DbSet<WmRecord> WmRecords { get; set; }

        public DbSet<WmRecord_TriggerWasteBinEmptying> WmRecords_TriggerWasteBinEmptying { get; set; }

        public DbSet<WmRecord_TriggerWasteBinEmptying_WmObject> WmRecords_TriggerWasteBinEmptying_WmObjects { get; set; }
    }
}
