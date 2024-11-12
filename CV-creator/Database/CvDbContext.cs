using CV_creator.Models;
using Microsoft.EntityFrameworkCore;

namespace CV_creator.Database
{
    public class CvDbContext : DbContext
    {
        public CvDbContext(DbContextOptions<CvDbContext> options) : base(options)
        {

        }
        public DbSet<Education> Educations { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BasicInformation> BasicInformations { get; set; }
        public DbSet<Skills> Skills { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships if needed, especially for complex mappings

            // Example: One BasicInformation has many Educations
            modelBuilder.Entity<BasicInformation>()
                .HasMany(b => b.Educations)         // BasicInformation has many Educations
                .WithOne(e => e.BasicInformation)   // Each Education is associated with one BasicInformation
                .HasForeignKey(e => e.BasicInformationId)  // Foreign Key to BasicInformation
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete (when BasicInformation is deleted, so are its Educations)

            modelBuilder.Entity<BasicInformation>()
                .HasMany(b => b.Jobs)              // BasicInformation has many Jobs
                .WithOne(j => j.BasicInformation)  // Each Job is associated with one BasicInformation
                .HasForeignKey(j => j.BasicInformationId)  // Foreign Key to BasicInformation
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete (when BasicInformation is deleted, so are its Jobs)

            modelBuilder.Entity<WorkExperience>()
                .HasMany(j => j.Skills)  // Job has many SkillsAchievements
                .WithOne(sa => sa.Job)               // Each SkillsAchievement is associated with one Job
                .HasForeignKey(sa => sa.JobId)       // Foreign Key to Job
                .OnDelete(DeleteBehavior.Cascade);   // Cascade delete (when Job is deleted, so are its SkillsAchievements)

            // Configure Address relationships
            modelBuilder.Entity<Address>()
                .HasOne(a => a.BasicInformation)     // Address has one BasicInformation
                .WithOne(b => b.ResidenceAddress)   // Each BasicInformation has one ResidenceAddress
                .HasForeignKey<Address>(a => a.BasicInformationId);  // Foreign Key to BasicInformation

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Education)           // Address has one Education
                .WithOne(e => e.InstitutionAddress) // Each Education has one InstitutionAddress
                .HasForeignKey<Address>(a => a.EducationId);  // Foreign Key to Education

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Job)                // Address has one Job
                .WithOne(j => j.WorkAddress)       // Each Job has one WorkAddress
                .HasForeignKey<Address>(a => a.JobId);  // Foreign Key to Job

            // Add configurations for additional models if any
        }
    }
}
