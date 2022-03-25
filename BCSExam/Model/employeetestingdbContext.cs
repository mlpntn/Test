﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BCSExam.Model
{
    public partial class employeetestingdbContext : DbContext
    {
        public employeetestingdbContext()
        {
        }

        public employeetestingdbContext(DbContextOptions<employeetestingdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SpokenToGuest> SpokenToGuests { get; set; }
        public virtual DbSet<Talktoguest> Talktoguests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:dev-employeetest-sql.database.windows.net,1433;Initial Catalog=employeetestingdb;Persist Security Info=False;User ID=apiuser;Password=FcqaJ65PR2jTgZmSWgwbyjqRf5gDWFv5zHYTgCU5BeStZzFcXDrfYyWkhEZBpzLA;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<SpokenToGuest>(entity =>
            {
                entity.HasKey(e => e.ResId);

                entity.ToTable("spokenToGuests");

                entity.Property(e => e.ResId)
                    .HasMaxLength(50)
                    .HasColumnName("ResID");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .HasColumnName("userEmail");
            });

            modelBuilder.Entity<Talktoguest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("talktoguests");

                entity.Property(e => e.AreaName).HasColumnName("Area_Name");

                entity.Property(e => e.GuestMobile).HasColumnName("Guest_Mobile");

                entity.Property(e => e.GuestName).HasColumnName("Guest_Name");

                entity.Property(e => e.MemberStatus).HasColumnName("Member_Status");

                entity.Property(e => e.NightsThisRes).HasColumnName("Nights_ThisRes");

                entity.Property(e => e.ParkCode).HasColumnName("Park_Code");

                entity.Property(e => e.PmEmail).HasColumnName("PM_Email");

                entity.Property(e => e.PrevNps).HasColumnName("Prev_NPS");

                entity.Property(e => e.PrevNpsComment).HasColumnName("Prev_NPS_Comment");

                entity.Property(e => e.PrevResId).HasColumnName("Prev_ResID");

                entity.Property(e => e.PriorNights).HasColumnName("Prior_Nights");

                entity.Property(e => e.PriorRevenue).HasColumnName("Prior_Revenue");

                entity.Property(e => e.PriorVisits).HasColumnName("Prior_Visits");

                entity.Property(e => e.ResId).HasColumnName("Res_ID");

                entity.Property(e => e.RevenueThisRes).HasColumnName("Revenue_ThisRes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
