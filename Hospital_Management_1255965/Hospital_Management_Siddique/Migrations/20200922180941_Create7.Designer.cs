﻿// <auto-generated />
using System;
using Hospital_Management_Siddique.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospital_Management_Siddique.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    [Migration("20200922180941_Create7")]
    partial class Create7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hospital_Management_Siddique.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Department");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<int>("HospitalId");

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("DoctorId");

                    b.HasIndex("HospitalId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Hospital_Management_Siddique.Models.DoctorPatient", b =>
                {
                    b.Property<int>("DoctorId");

                    b.Property<int>("PatientId");

                    b.HasKey("DoctorId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("DoctorPatients");
                });

            modelBuilder.Entity("Hospital_Management_Siddique.Models.Hospital", b =>
                {
                    b.Property<int>("HospitalId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(200);

                    b.Property<string>("Emailaddress")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("Established")
                        .HasColumnType("date");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Web")
                        .IsRequired();

                    b.HasKey("HospitalId");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("Hospital_Management_Siddique.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Age")
                        .IsRequired();

                    b.Property<DateTime>("DOB")
                        .HasColumnType("date");

                    b.Property<int>("Gender");

                    b.Property<int>("HospitalId");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("PatientId");

                    b.HasIndex("HospitalId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Hospital_Management_Siddique.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Contactual");

                    b.Property<decimal>("Expence");

                    b.Property<int>("HospitalId");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ServiceId");

                    b.HasIndex("HospitalId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Hospital_Management_Siddique.Models.Doctor", b =>
                {
                    b.HasOne("Hospital_Management_Siddique.Models.Hospital", "Hospital")
                        .WithMany("Doctor")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hospital_Management_Siddique.Models.DoctorPatient", b =>
                {
                    b.HasOne("Hospital_Management_Siddique.Models.Doctor", "Doctor")
                        .WithMany("DoctorPatients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hospital_Management_Siddique.Models.Patient", "Patient")
                        .WithMany("DoctorPatients")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hospital_Management_Siddique.Models.Patient", b =>
                {
                    b.HasOne("Hospital_Management_Siddique.Models.Hospital", "Hospital")
                        .WithMany()
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hospital_Management_Siddique.Models.Service", b =>
                {
                    b.HasOne("Hospital_Management_Siddique.Models.Hospital", "Hospital")
                        .WithMany("Service")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
