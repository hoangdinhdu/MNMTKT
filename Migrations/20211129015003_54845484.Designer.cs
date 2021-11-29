﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Demo.Migrations
{
    [DbContext(typeof(MVCDBContext))]
    [Migration("20211129015003_54845484")]
    partial class _54845484
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("Demo.Models.Category", b =>
                {
                    b.Property<string>("CategoryID")
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Demo.Models.Haha", b =>
                {
                    b.Property<string>("HahaID")
                        .HasColumnType("TEXT");

                    b.Property<string>("HahaName")
                        .HasColumnType("TEXT");

                    b.HasKey("HahaID");

                    b.ToTable("Haha");
                });

            modelBuilder.Entity("Demo.Models.Hehe", b =>
                {
                    b.Property<int>("HeheID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("HahaID")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeheName")
                        .HasColumnType("TEXT");

                    b.HasKey("HeheID");

                    b.HasIndex("HahaID");

                    b.ToTable("Hehes");
                });

            modelBuilder.Entity("Demo.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("Demo.Models.People", b =>
                {
                    b.Property<int>("PeopleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PeopleName")
                        .HasColumnType("TEXT");

                    b.HasKey("PeopleID");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("Discriminator").HasValue("People");
                });

            modelBuilder.Entity("Demo.Models.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersomName")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonID");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("Demo.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryID")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Demo.Models.Customer", b =>
                {
                    b.HasBaseType("Demo.Models.People");

                    b.Property<int>("Adress")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.ToTable("People");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("Demo.Models.Student", b =>
                {
                    b.HasBaseType("Demo.Models.Person");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.ToTable("Persons");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Demo.Models.Hehe", b =>
                {
                    b.HasOne("Demo.Models.Haha", "Haha")
                        .WithMany("Hehes")
                        .HasForeignKey("HahaID");
                });

            modelBuilder.Entity("Demo.Models.Product", b =>
                {
                    b.HasOne("Demo.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");
                });
#pragma warning restore 612, 618
        }
    }
}
