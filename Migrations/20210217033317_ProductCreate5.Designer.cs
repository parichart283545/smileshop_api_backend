﻿// <auto-generated />
using System;
using BackEnd_DotNetCoreAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd_DotNetCoreAPI.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210217033317_ProductCreate5")]
    partial class ProductCreate5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd_DotNetCoreAPI.Models.MovementStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<Guid>("CreateById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovementTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOld")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreateById");

                    b.HasIndex("MovementTypeId");

                    b.HasIndex("ProductId");

                    b.ToTable("MovementStock");
                });

            modelBuilder.Entity("BackEnd_DotNetCoreAPI.Models.MovementType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MovementType");
                });

            modelBuilder.Entity("BackEnd_DotNetCoreAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CreateById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductGroupId")
                        .HasColumnType("int");

                    b.Property<int>("StockCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreateById");

                    b.HasIndex("ProductGroupId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BackEnd_DotNetCoreAPI.Models.ProductGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CreateById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreateById");

                    b.ToTable("ProductGroups");
                });

            modelBuilder.Entity("BackEnd_DotNetCoreAPI.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Role","auth");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3b75e1c4-5c8f-417c-a9a4-873daeed9401"),
                            Name = "user"
                        },
                        new
                        {
                            Id = new Guid("e63729df-9f39-4a86-a154-d28407a11a27"),
                            Name = "Manager"
                        },
                        new
                        {
                            Id = new Guid("bdee9114-1de1-481c-8515-630093af61e2"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("8b9fd96b-1a57-438a-9ebc-7f57b7e089c6"),
                            Name = "Developer"
                        });
                });

            modelBuilder.Entity("BackEnd_DotNetCoreAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("User","auth");
                });

            modelBuilder.Entity("BackEnd_DotNetCoreAPI.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole","auth");
                });

            modelBuilder.Entity("BackEnd_DotNetCoreAPI.Models.MovementStock", b =>
                {
                    b.HasOne("BackEnd_DotNetCoreAPI.Models.User", "CreateBy")
                        .WithMany()
                        .HasForeignKey("CreateById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_DotNetCoreAPI.Models.MovementType", "MovementType")
                        .WithMany()
                        .HasForeignKey("MovementTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_DotNetCoreAPI.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd_DotNetCoreAPI.Models.Product", b =>
                {
                    b.HasOne("BackEnd_DotNetCoreAPI.Models.User", "CreateBy")
                        .WithMany()
                        .HasForeignKey("CreateById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_DotNetCoreAPI.Models.ProductGroup", null)
                        .WithMany("Product")
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd_DotNetCoreAPI.Models.ProductGroup", b =>
                {
                    b.HasOne("BackEnd_DotNetCoreAPI.Models.User", "CreateBy")
                        .WithMany()
                        .HasForeignKey("CreateById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd_DotNetCoreAPI.Models.UserRole", b =>
                {
                    b.HasOne("BackEnd_DotNetCoreAPI.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_DotNetCoreAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}