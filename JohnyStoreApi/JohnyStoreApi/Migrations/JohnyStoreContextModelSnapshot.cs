﻿// <auto-generated />
using System;
using JohnyStoreData.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JohnyStoreApi.Migrations
{
    [DbContext(typeof(JohnyStoreContext))]
    partial class JohnyStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JohnyStoreApi.Data.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("JohnyStoreData.Models.Availability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("Status35Id")
                        .HasColumnType("int");

                    b.Property<int>("Status36Id")
                        .HasColumnType("int");

                    b.Property<int>("Status37Id")
                        .HasColumnType("int");

                    b.Property<int>("Status38Id")
                        .HasColumnType("int");

                    b.Property<int>("Status39Id")
                        .HasColumnType("int");

                    b.Property<int>("Status40Id")
                        .HasColumnType("int");

                    b.Property<int>("Status41Id")
                        .HasColumnType("int");

                    b.Property<int>("Status42Id")
                        .HasColumnType("int");

                    b.Property<int>("Status43Id")
                        .HasColumnType("int");

                    b.Property<int>("Status44Id")
                        .HasColumnType("int");

                    b.Property<int>("Status45Id")
                        .HasColumnType("int");

                    b.Property<int>("Status46Id")
                        .HasColumnType("int");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.HasIndex("Status35Id");

                    b.HasIndex("Status36Id");

                    b.HasIndex("Status37Id");

                    b.HasIndex("Status38Id");

                    b.HasIndex("Status39Id");

                    b.HasIndex("Status40Id");

                    b.HasIndex("Status41Id");

                    b.HasIndex("Status42Id");

                    b.HasIndex("Status43Id");

                    b.HasIndex("Status44Id");

                    b.HasIndex("Status45Id");

                    b.HasIndex("Status46Id");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("JohnyStoreData.Models.AvailabilityStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AvailabilityStatuses");
                });

            modelBuilder.Entity("JohnyStoreData.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("JohnyStoreData.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SizeFoot")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.HasIndex("StatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("JohnyStoreData.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("JohnyStoreData.Models.PictureSneaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Href")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Main")
                        .HasColumnType("bit");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("PictureSneakers");
                });

            modelBuilder.Entity("JohnyStoreData.Models.Sneaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Article")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("New")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<bool>("Sale")
                        .HasColumnType("bit");

                    b.Property<int>("StyleId")
                        .HasColumnType("int");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.Property<bool>("WinterOrSummer")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("StyleId");

                    b.ToTable("ModelsSneakers");
                });

            modelBuilder.Entity("JohnyStoreData.Models.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("JohnyStoreData.Models.Availability", b =>
                {
                    b.HasOne("JohnyStoreData.Models.Sneaker", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JohnyStoreData.Models.AvailabilityStatus", "Status35")
                        .WithMany()
                        .HasForeignKey("Status35Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JohnyStoreData.Models.AvailabilityStatus", "Status36")
                        .WithMany()
                        .HasForeignKey("Status36Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JohnyStoreData.Models.AvailabilityStatus", "Status37")
                        .WithMany()
                        .HasForeignKey("Status37Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JohnyStoreData.Models.AvailabilityStatus", "Status38")
                        .WithMany()
                        .HasForeignKey("Status38Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JohnyStoreData.Models.AvailabilityStatus", "Status39")
                        .WithMany()
                        .HasForeignKey("Status39Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JohnyStoreData.Models.AvailabilityStatus", "Status40")
                        .WithMany()
                        .HasForeignKey("Status40Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JohnyStoreData.Models.AvailabilityStatus", "Status41")
                        .WithMany()
                        .HasForeignKey("Status41Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JohnyStoreData.Models.AvailabilityStatus", "Status42")
                        .WithMany()
                        .HasForeignKey("Status42Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JohnyStoreData.Models.AvailabilityStatus", "Status43")
                        .WithMany()
                        .HasForeignKey("Status43Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JohnyStoreData.Models.AvailabilityStatus", "Status44")
                        .WithMany()
                        .HasForeignKey("Status44Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JohnyStoreData.Models.AvailabilityStatus", "Status45")
                        .WithMany()
                        .HasForeignKey("Status45Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JohnyStoreData.Models.AvailabilityStatus", "Status46")
                        .WithMany()
                        .HasForeignKey("Status46Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("Status35");

                    b.Navigation("Status36");

                    b.Navigation("Status37");

                    b.Navigation("Status38");

                    b.Navigation("Status39");

                    b.Navigation("Status40");

                    b.Navigation("Status41");

                    b.Navigation("Status42");

                    b.Navigation("Status43");

                    b.Navigation("Status44");

                    b.Navigation("Status45");

                    b.Navigation("Status46");
                });

            modelBuilder.Entity("JohnyStoreData.Models.Order", b =>
                {
                    b.HasOne("JohnyStoreData.Models.Sneaker", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JohnyStoreData.Models.OrderStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("JohnyStoreData.Models.PictureSneaker", b =>
                {
                    b.HasOne("JohnyStoreData.Models.Sneaker", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("JohnyStoreData.Models.Sneaker", b =>
                {
                    b.HasOne("JohnyStoreData.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JohnyStoreData.Models.Style", "Style")
                        .WithMany()
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Style");
                });
#pragma warning restore 612, 618
        }
    }
}