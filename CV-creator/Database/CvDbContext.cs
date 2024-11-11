using CV_creator.Models;
using Microsoft.EntityFrameworkCore;

namespace CV_creator.Database
{
    public class CvDbContext : DbContext
    {
        public CvDbContext (DbContextOptions<CvDbContext> options) : base(options) 
        { 

        }
        public DbSet<Education> Educations { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Achievements> Achievements { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<BasicInformation> BasicInformations { get; set; }
        public DbSet<Skills> Skills { get; set; }

    }
}
