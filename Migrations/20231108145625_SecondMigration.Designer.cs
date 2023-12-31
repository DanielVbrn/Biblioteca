﻿// <auto-generated />
using System;
using Livraria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Livraria.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231108145625_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Livraria.Models.Books", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Authorname")
                        .HasColumnType("longtext");

                    b.Property<int?>("CatalogId")
                        .HasColumnType("int");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Notebooks")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CatalogId");

                    b.HasIndex("MemberId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Livraria.Models.Catalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Authorname")
                        .HasColumnType("longtext");

                    b.Property<int>("Noofcopies")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Catalog");
                });

            modelBuilder.Entity("Livraria.Models.Libraian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<int>("MobileNo")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Libraian");
                });

            modelBuilder.Entity("Livraria.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("LibraianId")
                        .HasColumnType("int");

                    b.Property<string>("Maddress")
                        .HasColumnType("longtext");

                    b.Property<string>("Mname")
                        .HasColumnType("longtext");

                    b.Property<int>("Mno")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LibraianId");

                    b.ToTable("Members");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Member");
                });

            modelBuilder.Entity("Livraria.Models.FacultyMember", b =>
                {
                    b.HasBaseType("Livraria.Models.Member");

                    b.HasDiscriminator().HasValue("FacultyMember");
                });

            modelBuilder.Entity("Livraria.Models.Student", b =>
                {
                    b.HasBaseType("Livraria.Models.Member");

                    b.Property<string>("SName")
                        .HasColumnType("longtext");

                    b.Property<string>("Studentcoll")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Livraria.Models.Books", b =>
                {
                    b.HasOne("Livraria.Models.Catalog", null)
                        .WithMany("Books")
                        .HasForeignKey("CatalogId");

                    b.HasOne("Livraria.Models.Member", null)
                        .WithMany("BooksIssued")
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("Livraria.Models.Member", b =>
                {
                    b.HasOne("Livraria.Models.Libraian", null)
                        .WithMany("Members")
                        .HasForeignKey("LibraianId");
                });

            modelBuilder.Entity("Livraria.Models.Catalog", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Livraria.Models.Libraian", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Livraria.Models.Member", b =>
                {
                    b.Navigation("BooksIssued");
                });
#pragma warning restore 612, 618
        }
    }
}
