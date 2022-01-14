using DAL_Data_Access_Layer_.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL_Data_Access_Layer_.Data
{
    public class CommonDbContext : DbContext
    {
        public CommonDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().HasData(
                new Candidate { 
                                CandidateId = 1, 
                                FirstName = "Status",  
                                LastName = "Not Voted",
                                Age=33,
                                Gender="Male",
                                PhoneNumber= "1234567890"
                              }
                );
        }
    }

}