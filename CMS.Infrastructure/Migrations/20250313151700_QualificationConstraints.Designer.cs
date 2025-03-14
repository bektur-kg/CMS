﻿// <auto-generated />
using System;
using CMS.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CMS.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250313151700_QualificationConstraints")]
    partial class QualificationConstraints
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CMS.Domain.Modules.Appointments.Appointment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("DoctorProfileId")
                        .HasColumnType("bigint");

                    b.Property<long>("MedicalCardId")
                        .HasColumnType("bigint");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("StatusType")
                        .HasColumnType("int");

                    b.Property<long>("TimeSlotId")
                        .HasColumnType("bigint");

                    b.Property<long?>("VisitId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DoctorProfileId");

                    b.HasIndex("MedicalCardId");

                    b.HasIndex("VisitId")
                        .IsUnique()
                        .HasFilter("[VisitId] IS NOT NULL");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("CMS.Domain.Modules.Diagnoses.Diagnosis", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("IcdCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<long>("VisitId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VisitId");

                    b.ToTable("Diagnoses", t =>
                        {
                            t.HasCheckConstraint("CK_Diagnoses_IcdCode_Length", "LEN(IcdCode) BETWEEN 4 AND 7");
                        });
                });

            modelBuilder.Entity("CMS.Domain.Modules.DoctorProfiles.DoctorProfile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<int>("SpecializationType")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("DoctorProfiles");
                });

            modelBuilder.Entity("CMS.Domain.Modules.MedicalCards.MedicalCard", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("PatientNote")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("MedicalCards");
                });

            modelBuilder.Entity("CMS.Domain.Modules.Medications.Medication", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<long>("VisitId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VisitId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("CMS.Domain.Modules.Qualifications.Qualification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateObtained")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<long>("DoctorProfileId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IssuingAuthority")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("QualificationType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorProfileId");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("CMS.Domain.Modules.Reviews.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Comment")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PatientId")
                        .HasColumnType("bigint");

                    b.Property<byte>("Rating")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Reviews", t =>
                        {
                            t.HasCheckConstraint("CK_Review_Rating_Range", "Rating BETWEEN 0 AND 5");
                        });
                });

            modelBuilder.Entity("CMS.Domain.Modules.TimeSlots.TimeSlot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("DoctorProfileId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorProfileId");

                    b.ToTable("TimeSlots");
                });

            modelBuilder.Entity("CMS.Domain.Modules.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CMS.Domain.Modules.Visits.Visit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<DateTime>("VisitedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("CMS.Domain.Modules.Appointments.Appointment", b =>
                {
                    b.HasOne("CMS.Domain.Modules.DoctorProfiles.DoctorProfile", "DoctorProfile")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorProfileId");

                    b.HasOne("CMS.Domain.Modules.MedicalCards.MedicalCard", "MedicalCard")
                        .WithMany("Appointments")
                        .HasForeignKey("MedicalCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CMS.Domain.Modules.Visits.Visit", "Visit")
                        .WithOne("Appointment")
                        .HasForeignKey("CMS.Domain.Modules.Appointments.Appointment", "VisitId");

                    b.Navigation("DoctorProfile");

                    b.Navigation("MedicalCard");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("CMS.Domain.Modules.Diagnoses.Diagnosis", b =>
                {
                    b.HasOne("CMS.Domain.Modules.Visits.Visit", "Visit")
                        .WithMany("Diagnoses")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("CMS.Domain.Modules.DoctorProfiles.DoctorProfile", b =>
                {
                    b.HasOne("CMS.Domain.Modules.Users.User", "User")
                        .WithOne()
                        .HasForeignKey("CMS.Domain.Modules.DoctorProfiles.DoctorProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CMS.Domain.Modules.MedicalCards.MedicalCard", b =>
                {
                    b.HasOne("CMS.Domain.Modules.Users.User", "User")
                        .WithOne()
                        .HasForeignKey("CMS.Domain.Modules.MedicalCards.MedicalCard", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CMS.Domain.Modules.Medications.Medication", b =>
                {
                    b.HasOne("CMS.Domain.Modules.Visits.Visit", "Visit")
                        .WithMany("Medications")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("CMS.Domain.Modules.Qualifications.Qualification", b =>
                {
                    b.HasOne("CMS.Domain.Modules.DoctorProfiles.DoctorProfile", "DoctorProfile")
                        .WithMany("Qualifications")
                        .HasForeignKey("DoctorProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorProfile");
                });

            modelBuilder.Entity("CMS.Domain.Modules.Reviews.Review", b =>
                {
                    b.HasOne("CMS.Domain.Modules.Users.User", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CMS.Domain.Modules.Users.User", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("CMS.Domain.Modules.TimeSlots.TimeSlot", b =>
                {
                    b.HasOne("CMS.Domain.Modules.DoctorProfiles.DoctorProfile", "DoctorProfile")
                        .WithMany("TimeSlots")
                        .HasForeignKey("DoctorProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorProfile");
                });

            modelBuilder.Entity("CMS.Domain.Modules.DoctorProfiles.DoctorProfile", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Qualifications");

                    b.Navigation("TimeSlots");
                });

            modelBuilder.Entity("CMS.Domain.Modules.MedicalCards.MedicalCard", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("CMS.Domain.Modules.Visits.Visit", b =>
                {
                    b.Navigation("Appointment");

                    b.Navigation("Diagnoses");

                    b.Navigation("Medications");
                });
#pragma warning restore 612, 618
        }
    }
}
