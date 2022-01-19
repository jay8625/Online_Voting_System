using DAL_Data_Access_Layer_.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL_Data_Access_Layer_.Data
{
    public class CommonDbContext : IdentityDbContext
    {
        public CommonDbContext(DbContextOptions options) : base(options) { }
        //added models to DbContext 
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }

}