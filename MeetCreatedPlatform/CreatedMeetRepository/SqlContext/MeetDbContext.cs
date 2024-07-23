using CreatedMeetRepository.Model;
using Microsoft.EntityFrameworkCore;

namespace CreatedMeetRepository.SqlContext
{
    public class MeetDbContext : DbContext
    {

        public MeetDbContext(DbContextOptions<MeetDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MEET>().ToTable("MEET");
            modelBuilder.Entity<PARTICIPANTS>().ToTable("PARTICIPANTS");
            modelBuilder.Entity<PARTICIPANTS>().HasKey(x => new { x.USER_ID, x.MEET_ID });
            modelBuilder.Entity<PROFILEIMAGE>().ToTable("PROFILEIMAGE");
            modelBuilder.Entity<ROLES>().ToTable("ROLES");
            modelBuilder.Entity<USER>().ToTable("USER");
            modelBuilder.Entity<USER_IMAGE>().ToTable("USER_IMAGE");
            modelBuilder.Entity<USER_IMAGE>().HasKey(x => new { x.USER_ID, x.IMAGE_ID });
            modelBuilder.Entity<USER_ROLES>().ToTable("USER_ROLES");
            modelBuilder.Entity<USER_ROLES>().HasKey(x => new { x.USER_ID, x.ROLE_ID });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<LOGS> LOGs { get; set; }
        public DbSet<MEET> MEETs { get; set; }
        public DbSet<PARTICIPANTS> PARTICIPANTs { get; set; }
        public DbSet<PROFILEIMAGE> PROFILEIMAGEs { get; set; }
        public DbSet<ROLES> ROLEs { get; set; }
        public DbSet<USER> USERs { get; set; }
        public DbSet<USER_IMAGE> USER_IMAGEs { get; set; }
        public DbSet<USER_ROLES> USER_ROLEs { get; set; }

    }
}
