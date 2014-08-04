using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Software41.BackgroundCheck.Domain;
using Software41.BackgroundCheck.Repository;

namespace Software41.BackgroundCheck.Repository.EF
{
    public class BackgroundCheckContext:DbContext,IApplicantContext
    {
        public BackgroundCheckContext()
            : base("Software41.BackgroundCheckDb") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //The following apparently can also be accomplished by using the commented out line of code,
            //but I like the explicit table naming.
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Applicant>().ToTable("Applicant");
            modelBuilder.Entity<AddressHistory>().ToTable("AddressHistory");
            modelBuilder.Entity<EmploymentHistory>().ToTable("EmploymentHistory");
            modelBuilder.Entity<EducationHistory>().ToTable("EducationHistory");

            //Keys
            modelBuilder.Entity<Applicant>().HasKey(a => a.Id);

            //References
            modelBuilder.Entity<Applicant>()
                .HasMany<AddressHistory>(c => c.AddressHistory)
                .WithOptional()
                .WillCascadeOnDelete(true);

            //References
            modelBuilder.Entity<Applicant>()
                .HasMany<EmploymentHistory>(c => c.EmploymentHistory)
                .WithOptional()
                .WillCascadeOnDelete(true);

            //References
            modelBuilder.Entity<Applicant>()
                .HasMany<EducationHistory>(c => c.EducationHistory)
                .WithOptional()
                .WillCascadeOnDelete(true);
        }
        public IDbSet<Applicant> Applicant { get; set; }
        public IDbSet<AddressHistory> AddressHistory { get; set; }
        public IDbSet<EmploymentHistory> EmploymentHistory { get; set; }
        public IDbSet<EducationHistory> EducationHistory { get; set; }
    }
}
