using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace DAL
{
    class Project_Db_Context : DbContext
    {
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Assessment> Assessments { get; set; }
        public virtual DbSet<Fall> Falls { get; set; }
        public virtual DbSet<Location_> Locations { get; set; }

    /*    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure ReportId as FK for ReportLocation
            modelBuilder.Entity<BE.Location_>()
                .HasOptional(t => t.report)
                .WithRequired(r => r.location);

            // Configure FallId as FK for Fall  Location
            modelBuilder.Entity<Location_>()
                       .HasOptional(f => f.fall)
                       .WithRequired(l => l.location);

            // configures many-to-many relationship between Assessment and Locations

         /*   modelBuilder.Entity<Assessment>()
                .HasMany<Location_>(s => s.Locations)
                .WithMany(c => c.assessment)
                .Map(cs =>
                {
                    cs.MapLeftKey("AssessmentID");
                    cs.MapRightKey("LocationID");
                    cs.ToTable("AssessmentLocation");
                });
                */

            //modelBuilder.Entity<BE.Assessment>()
            //            .HasMany<BE.Location_>(g => g.Locations)
            //            .WithRequired(s => s.assessment);

            //modelBuilder.Entity<Location_>()
            //    .HasRequired<Assessment>(s => s.Assessment)
            //    .WithMany(g => g.Locations)
            //    .HasForeignKey<int>(s => s.Assessment.id);

            // configures one-to-many relationship
            //modelBuilder.Entity<BE.Assessment>()
            //             .HasMany<BE.Report>(g => g.Reports)
            //               .WithRequired(s => s.Assessment);
            //// configures one-to-many relationship
            //modelBuilder.Entity<BE.Assessment>()
            //             .HasMany<BE.Fall>(g => g.Falls)
            //            .WithOptional(s => s.Assessment);






    }


}
