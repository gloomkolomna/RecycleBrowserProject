﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using RecycleProject;
using System;

namespace RecycleProject.Migrations
{
    [DbContext(typeof(RecycleContext))]
    [Migration("20180322193457_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("RecycleProject.Model.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Home");

                    b.Property<int>("Index");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("RecycleProject.Model.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContactId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("RecycleProject.Model.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdressId");

                    b.Property<string>("Email");

                    b.Property<string>("Phone");

                    b.Property<string>("Web");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("RecycleProject.Model.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("RecycleProject.Model.RecyclePoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyId");

                    b.Property<int?>("LocationId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LocationId");

                    b.ToTable("RecyclePoint");
                });

            modelBuilder.Entity("RecycleProject.Model.RecycleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("RecyclePointId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RecyclePointId");

                    b.ToTable("RecycleType");
                });

            modelBuilder.Entity("RecycleProject.Model.Company", b =>
                {
                    b.HasOne("RecycleProject.Model.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("RecycleProject.Model.Contact", b =>
                {
                    b.HasOne("RecycleProject.Model.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId");
                });

            modelBuilder.Entity("RecycleProject.Model.RecyclePoint", b =>
                {
                    b.HasOne("RecycleProject.Model.Company", "Company")
                        .WithMany("RecyclePoints")
                        .HasForeignKey("CompanyId");

                    b.HasOne("RecycleProject.Model.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("RecycleProject.Model.RecycleType", b =>
                {
                    b.HasOne("RecycleProject.Model.Company")
                        .WithMany("RecycleTypes")
                        .HasForeignKey("CompanyId");

                    b.HasOne("RecycleProject.Model.RecyclePoint")
                        .WithMany("Types")
                        .HasForeignKey("RecyclePointId");
                });
#pragma warning restore 612, 618
        }
    }
}